using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class PdfService
{
    public byte[] CreatePdf()
    {
        // Creación de un documento PDF utilizando QuestPDF
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                    .Text("Reporte de Ejemplo")
                    .SemiBold()
                    .FontSize(36)
                    .FontColor(Colors.Blue.Medium);

                page.Content()
                    .Text("Este es un ejemplo simple de PDF generado con QuestPDF.")
                    .FontSize(24);

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
            });
        });

        // Retornar el PDF como un array de bytes
        return document.GeneratePdf();
    }
}
