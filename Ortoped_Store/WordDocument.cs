using Microsoft.Office.Interop.Word;
using System;
using word = Microsoft.Office.Interop.Word;

namespace Ortoped_Store
{
    class WordDocument
    {
        public System.Data.DataTable table = new System.Data.DataTable();
        public string table2;
        public string DataSegod = "";
        public string Mes = "";
        public string AVG = "", QC = "", PC = "";
        public void CheckOtch()
        {
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            string file_name = Registry_Class.DirPath + "\\СГ_" + "Чек за день"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".docx";
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "ПРОДАЖИ ЗА СЕГОДНЯ (" + DateTime.Now.ToLongDateString() + ")";
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph pTable = document.Paragraphs.Add();
                word.Table tbStudents = document.Tables.Add(pTable.Range, table.Rows.Count + 1,
                    table.Columns.Count);
                tbStudents.Borders.InsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbStudents.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbStudents.Cell(1, 1).Range.Text = "ИНН";
                tbStudents.Cell(1, 2).Range.Text = "Продавец";
                tbStudents.Cell(1, 3).Range.Text = "Товар";
                tbStudents.Cell(1, 4).Range.Text = "Стоимость";
                tbStudents.Range.Font.Size = 12;
                tbStudents.Range.Font.Name = "Times New Roman";
                tbStudents.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                tbStudents.Columns[1].Width = 80;
                tbStudents.Columns[2].Width = 100;
                tbStudents.Columns[3].Width = 230;
                tbStudents.Columns[4].Width = 80;
                for (int i = 2; i <= tbStudents.Rows.Count; i++)
                    for (int j = 1; j <= tbStudents.Columns.Count; j++)
                    {
                        tbStudents.Cell(i, j).Range.Text
                            = table.Rows[i - 2][j - 1].ToString();
                    }
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphRight;
                Name_Doc.Range.Text = "ОБЩАЯ СУММА = " + table2 + " рублей";
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.Close();
                application.Quit();
            }
        }

        public void CheckOtch2()
        {
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            string file_name = Registry_Class.DirPath + "\\СГ_" + "Чек за месяц"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".docx";
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "ПРОДАЖИ ЗА МЕСЯЦ (" + DateTime.Now.ToString("MMMM") + ")";
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph pTable = document.Paragraphs.Add();
                word.Table tbStudents = document.Tables.Add(pTable.Range, table.Rows.Count + 1,
                    table.Columns.Count);
                tbStudents.Borders.InsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbStudents.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbStudents.Cell(1, 1).Range.Text = "ИНН";
                tbStudents.Rows[1].Shading.BackgroundPatternColorIndex = WdColorIndex.wdGray25;
                tbStudents.Cell(1, 2).Range.Text = "Продавец";
                tbStudents.Cell(1, 3).Range.Text = "Товар";
                tbStudents.Cell(1, 4).Range.Text = "Стоимость";
                tbStudents.Range.Font.Size = 12;
                tbStudents.Range.Font.Name = "Times New Roman";
                tbStudents.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                tbStudents.Columns[1].Width = 80;
                tbStudents.Columns[2].Width = 100;
                tbStudents.Columns[3].Width = 230;
                tbStudents.Columns[4].Width = 80;
                for (int i = 2; i <= tbStudents.Rows.Count; i++)
                    for (int j = 1; j <= tbStudents.Columns.Count; j++)
                    {
                        tbStudents.Cell(i, j).Range.Text
                            = table.Rows[i - 2][j - 1].ToString();
                    }
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphRight;
                Name_Doc.Range.Text = "ОБЩАЯ СУММА = " + table2 + " рублей";
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "example.docx";
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.Close();
                application.Quit();
               
            }
        }
    }
}
