using WkHtmlToPdfDotNet;

var htmlFilePath = @"template.html";

Dictionary<string, object> values = new() {
    { "{{INVOICE_NUMBER}}", 15623 },
    { "{{CREATE_DATE}}", DateOnly.FromDateTime(DateTime.Now) },
    { "{{DUE_DATE}}", DateOnly.FromDateTime(DateTime.Now.AddYears(1)) },
    { "{{ADDRESS}}", "Sefaköy<br/>Küçükçekmece<br/>İSTANBUL" },
    { "{{CORP_NAME}}", "RSU Bilişim" },
    { "{{FULL_NAME}}", "Mustafa Ünal" },
    { "{{EMAIL}}", "mustafa.unal@rsu.com.tr" },
};
var htmlContent = File.ReadAllText(htmlFilePath).ReplaceBulk(values);

var converter = new SynchronizedConverter(new PdfTools());
var doc = new HtmlToPdfDocument()
{
    GlobalSettings = {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        Margins = new MarginSettings(0,0,0,0),
        PaperSize = PaperKind.A4,
        Out = "out.pdf",
    },
    Objects = {
        new ObjectSettings() {
            //PagesCount = true,
            HtmlContent = htmlContent,
            WebSettings = { DefaultEncoding = "utf-8" },
            //HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
        }
    }
};
converter.Convert(doc);

// Show the PDF
//System.Diagnostics.Process.Start(@"c:\out.pdf");

//Console.ReadKey();