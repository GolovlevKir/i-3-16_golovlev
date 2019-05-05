using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace Ortoped_Store
{
    class PDFDocument
    {
        public System.Data.DataTable dtDannieSklada = new System.Data.DataTable();
        private int sch = 1;
        public void Docum()
        {
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\kirvi\source\repos\Ortoped_Store\Ortoped_Store\bin\Debug\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
            Document document = new Document();

            FileStream stream = new FileStream(Registry_Class.DirPath + "Список имеющегося товара"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".pdf", FileMode.Create);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Image jpg = Image.GetInstance(Application.StartupPath + @"/images.png");
            jpg.Alignment = Element.ALIGN_CENTER;
            jpg.ScaleToFit(150, 150);
            document.Add(jpg);
            String phrase = "Список имеющегося товара";
            Paragraph elements = new Paragraph(phrase, font);
            elements.Alignment = Element.ALIGN_CENTER;
            document.Add(elements);
            document.Add(new Paragraph(" ", font));
            for (int i = 0; i < dtDannieSklada.Rows.Count; i++)
            {
                document.Add(new Paragraph("    " + sch.ToString() + ". " + dtDannieSklada.Rows[i][0].ToString() + ". Осталось: " + dtDannieSklada.Rows[i][1].ToString() + " шт.", font1));
                sch++;
            }
            
            document.Close();
        }

    }
}
