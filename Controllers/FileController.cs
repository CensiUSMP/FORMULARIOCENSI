using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FORMULARIOCENSI.Models;

namespace FORMULARIOCENSI.Controllers
{
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly int _maxFileSize = 10 * 1024 * 1024; // 10MB limit

        // Lista estática de dispositivos Raspberry Pi
        private static readonly List<RaspberryPiDevice> RaspberryPis = new List<RaspberryPiDevice>
        {
            new RaspberryPiDevice
            {
                Name = "Device1",
                IpAddress = "10.12.1.101",
                Port = 12345,
                Location = "Room 101"
            },
            new RaspberryPiDevice
            {
                Name = "Device2",
                IpAddress = "10.12.1.103",
                Port = 12345,
                Location = "Room 102"
            },
            new RaspberryPiDevice
            {
                Name = "Device3",
                IpAddress = "10.12.1.104",
                Port = 12345,
                Location = "Room 103"
            }
        };

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(RaspberryPis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload([FromForm] IFormFile pdfFile, [FromForm] string selectedDevice)
        {
            try
            {
                if (!ValidateFile(pdfFile))
                {
                    TempData["Error"] = "Invalid file";
                    return RedirectToAction(nameof(Index));
                }

                var device = GetRaspberryPiConfig(selectedDevice);
                if (device.ip == null)
                {
                    TempData["Error"] = "Invalid device selected";
                    return RedirectToAction(nameof(Index));
                }

                await SendFileToRaspberryPi(pdfFile, device.ip, device.port);

                TempData["Success"] = $"File sent successfully to {selectedDevice}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing file upload");
                TempData["Error"] = "Internal server error";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClosePdf(string selectedDevice)
        {
            try
            {
                var device = GetRaspberryPiConfig(selectedDevice);
                if (device.ip == null)
                {
                    TempData["Error"] = "Invalid device selected";
                    return RedirectToAction(nameof(Index));
                }

                await SendCloseSignal(device.ip, device.port);
                TempData["Success"] = $"PDF closed successfully on {selectedDevice}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending close signal");
                TempData["Error"] = "Error closing PDF";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> BroadcastPdf(IFormFile pdfFile)
        {
            try
            {
                if (!ValidateFile(pdfFile))
                {
                    TempData["Error"] = "Invalid file";
                    return RedirectToAction(nameof(Index));
                }

                var tasks = new List<Task>();

                foreach (var device in RaspberryPis)
                {
                    tasks.Add(SendFileToRaspberryPi(pdfFile, device.IpAddress, device.Port));
                }

                await Task.WhenAll(tasks);

                TempData["Success"] = "File broadcasted to all devices successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting file");
                TempData["Error"] = "Error broadcasting file to devices";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseAll()
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var device in RaspberryPis)
                {
                    tasks.Add(SendCloseSignal(device.IpAddress, device.Port));
                }

                await Task.WhenAll(tasks);

                TempData["Success"] = "PDFs closed on all devices";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error closing PDFs on all devices");
                TempData["Error"] = "Error closing PDFs on all devices";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("No file provided");
                return false;
            }

            if (file.Length > _maxFileSize)
            {
                _logger.LogWarning($"File size {file.Length} exceeds limit of {_maxFileSize}");
                return false;
            }

            if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning($"Invalid content type: {file.ContentType}");
                return false;
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (extension != ".pdf")
            {
                _logger.LogWarning($"Invalid file extension: {extension}");
                return false;
            }

            return true;
        }

        private (string ip, int port) GetRaspberryPiConfig(string deviceName)
        {
            var device = RaspberryPis.FirstOrDefault(d => d.Name == deviceName);
            if (device == null)
            {
                _logger.LogError($"Device configuration not found for: {deviceName}");
                return (null, 0);
            }

            return (device.IpAddress, device.Port);
        }

        private async Task SendFileToRaspberryPi(IFormFile file, string ip, int port)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            byte[] fileBytes = ms.ToArray();

            byte[] fileNameBytes = Encoding.UTF8.GetBytes(file.FileName);
            byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);
            byte[] fileLengthBytes = BitConverter.GetBytes(fileBytes.Length);

            int packetSize = 4 + fileNameBytes.Length + 4 + fileBytes.Length;

            if (packetSize > 65507)
            {
                throw new InvalidOperationException("File too large for single UDP packet");
            }

            byte[] packet = new byte[packetSize];
            int offset = 0;

            Buffer.BlockCopy(fileNameLength, 0, packet, offset, 4);
            offset += 4;

            Buffer.BlockCopy(fileNameBytes, 0, packet, offset, fileNameBytes.Length);
            offset += fileNameBytes.Length;

            Buffer.BlockCopy(fileLengthBytes, 0, packet, offset, 4);
            offset += 4;

            Buffer.BlockCopy(fileBytes, 0, packet, offset, fileBytes.Length);

            using var udpClient = new UdpClient();
            await udpClient.SendAsync(packet, packet.Length, ip, port);

            _logger.LogInformation($"File sent successfully to {ip}:{port}: {file.FileName}");
        }

        private async Task SendCloseSignal(string ip, int port)
        {
            using var udpClient = new UdpClient();
            byte[] closeSignal = Encoding.UTF8.GetBytes("CLOSE_PDF");
            await udpClient.SendAsync(closeSignal, closeSignal.Length, ip, port);
            _logger.LogInformation($"Close signal sent successfully to {ip}:{port}");
        }
    }
}