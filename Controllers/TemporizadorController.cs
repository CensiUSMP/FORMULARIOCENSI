using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;
using FORMULARIOCENSI.Models;

namespace FORMULARIOCENSI.Controllers
{
    public class TemporizadorController : Controller
    {
        // Lista de IPs de Raspberry Pi
        private static readonly string[] RaspberryPis = 
        {
            "10.12.1.101",
            "10.12.1.102", 
            "10.12.1.103",
            "10.12.1.104",
            "10.12.1.105",
            "10.12.1.106",
            "10.12.1.107",
            "10.12.1.108",
            "10.12.1.109",
            "10.12.1.110",
        };

        private const int Port = 65432; // Puerto que estás utilizando

        public IActionResult Index()
        {
            ViewBag.RaspberryPis = RaspberryPis; // Pasar las IPs a la vista
            return View();
        }

        [HttpPost]
        public IActionResult IniciarTemporizador(ComandoModel model)
        {
            if (ModelState.IsValid)
            {
                // Convertir los minutos a segundos
                int tiempoEnSegundos = model.Tiempo;

                string comando = $"iniciar_temporizador,{tiempoEnSegundos}";
                EnviarComando(comando, model.RaspberryPiIP); // Pasar la IP seleccionada
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult IniciarTemporizadorTodos(string[] raspberryPiIPs, int TiempoTodos)
        {
            if (TiempoTodos > 0 && raspberryPiIPs != null && raspberryPiIPs.Length > 0)
            {
                // Convertir los minutos a segundos
                int tiempoEnSegundos = TiempoTodos * 60;

                foreach (var raspberryPiIP in raspberryPiIPs)
                {
                    string comando = $"iniciar_temporizador,{tiempoEnSegundos}";
                    EnviarComando(comando, raspberryPiIP);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CerrarTemporizador(string[] raspberryPiIPs)
        {
            if (raspberryPiIPs != null && raspberryPiIPs.Length > 0)
            {
                foreach (var raspberryPiIP in raspberryPiIPs)
                {
                    string comando = "cerrar_temporizador"; // Comando para cerrar el temporizador
                    EnviarComando(comando, raspberryPiIP);
                }
            }
            return RedirectToAction("Index");
        }

        private void EnviarComando(string comando, string raspberryPiIP)
        {
            using (var client = new UdpClient())
            {
                var endpoint = new IPEndPoint(IPAddress.Parse(raspberryPiIP), Port);
                var data = System.Text.Encoding.UTF8.GetBytes(comando);
                client.Send(data, data.Length, endpoint);
            }
        }
    }
}