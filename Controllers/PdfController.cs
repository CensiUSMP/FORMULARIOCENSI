using Microsoft.AspNetCore.Mvc;

public class PdfController : Controller
{
    private readonly PdfService _pdfService;

    public PdfController()
    {
        _pdfService = new PdfService();
    }

    public IActionResult DownloadPdf()
    {
        // Generar el PDF
        var pdf = _pdfService.CreatePdf();

        // Devolver el PDF como un archivo descargable
        return File(pdf, "application/pdf", "reporte.pdf");
    }
}
