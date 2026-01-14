using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using EasyReceiptAPI.Models;

namespace EasyReceiptAPI.Controllers;

[ApiController]
[Route("api/recibos")]
public class ReciboController : ControllerBase
{
    [HttpPost("gerar")]
    public IActionResult GerarPdf([FromBody] Recibo dados)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var documento = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(1.5f, Unit.Centimetre);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily(Fonts.Verdana));

                page.Header().Column(col =>
                {
                    col.Item().AlignCenter().Text("RECIBO DE PAGAMENTO")
                        .FontSize(24).SemiBold().FontColor(Colors.Blue.Medium);

                    col.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                });

                page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                {
                    col.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(20).Column(innerCol =>
                    {
                        innerCol.Item().Text(t =>
                        {
                            t.Span("Recebemos de ");
                            t.Span($"{dados.Cliente}").Bold();
                            t.Span(", a importância de ");
                            t.Span($"R$ {dados.Valor:N2}").Bold();
                        });

                        innerCol.Item().PaddingTop(15).Text(t =>
                        {
                            t.Span("Referente aos serviços de: ");
                            t.Span($"{dados.Servico}").Italic();
                        });
                    });

                    col.Item().PaddingTop(3, Unit.Centimetre).Column(sigCol =>
                    {
                        sigCol.Item().AlignCenter().Width(250).BorderTop(1).PaddingTop(5)
                            .Text("Assinatura do Emissor").AlignCenter();

                        sigCol.Item().AlignCenter().Text("Rio de Janeiro - RJ").FontSize(10).FontColor(Colors.Grey.Medium);
                    });
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Documento gerado em: ").FontSize(10);
                    x.Span($"{dados.Data:dd/MM/yyyy HH:mm}").FontSize(10);
                });
            });
        });

        byte[] pdfBytes = documento.GeneratePdf();
        return File(pdfBytes, "application/pdf", $"Recibo_{dados.Cliente.Replace(" ", "_")}.pdf");
    }
}