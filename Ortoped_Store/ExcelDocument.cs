using Microsoft.Office.Interop.Excel;
using System;
using excel = Microsoft.Office.Interop.Excel;

namespace Ortoped_Store
{
    class ExcelDocument
    {
        public string name = "";
        public System.Data.DataTable dtDannieSklada = new System.Data.DataTable();
        public void SpisokOnSklad()
        {
            string name = Registry_Class.DirPath + "Список товара на складе"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".xlsx";
            excel.Application application = new excel.Application();
            excel.Workbook workbook = application.Workbooks.Add();
            excel.Worksheet worksheet =
                (excel.Worksheet)workbook.ActiveSheet;
            try
            {
                worksheet.Name = "Список товара на складе";
                worksheet.Cells[4, 1] = "Наименование товара";
                worksheet.Cells[4, 2] = "Количество";
                for (int i = 0; i < dtDannieSklada.Rows.Count; i++)
                {
                    worksheet.Cells[i + 5, 1] = dtDannieSklada.Rows[i][0].ToString();
                    worksheet.Cells[i + 5, 2] = dtDannieSklada.Rows[i][1].ToString();
                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[1].WrapText = true;
                }
                worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]].Interior.Color = XlRgbColor.rgbLightGray;

                excel.Range conf_cell = worksheet.Cells[3, 3];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell = worksheet.Cells[4, 1];

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();
                worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 2]].Merge();

                worksheet.Cells[2, 1] = "Список товара на складе на " + DateTime.Now.ToLongDateString();
                conf_cell = worksheet.Cells[2, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;

                worksheet.Cells[1, 1] = Registry_Class.OrganizationName;
                conf_cell = worksheet.Cells[1, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell.RowHeight = 50;

                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1]
                    = "Заместитель директора        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1]
                    = "Главный директор        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1]
                    = "Кладовщик        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1]
                    = "Дата: " + DateTime.Now.ToLongDateString();
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                application.ActiveWindow.View = XlWindowView.xlPageBreakPreview;

            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                workbook.SaveAs(name, application.DefaultSaveFormat);
                workbook.Close();
                application.Quit();
            }
        }

        public void SpisokOnPrih()
        {
            string name = Registry_Class.DirPath + "Список nрихода товара"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".xlsx";
            excel.Application application = new excel.Application();
            excel.Workbook workbook = application.Workbooks.Add();
            excel.Worksheet worksheet =
                (excel.Worksheet)workbook.ActiveSheet;
            try
            {
                worksheet.Name = "Список ПРИХОДА ТОВАРА";
                worksheet.Cells[4, 1] = "Наименование товара";
                worksheet.Cells[4, 2] = "Количество";
                for (int i = 0; i < dtDannieSklada.Rows.Count; i++)
                {
                    worksheet.Cells[i + 5, 1] = dtDannieSklada.Rows[i][0].ToString();
                    worksheet.Cells[i + 5, 2] = dtDannieSklada.Rows[i][1].ToString();
                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[1].WrapText = true;
                }
                worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]].Interior.Color = XlRgbColor.rgbLightGray;

                excel.Range conf_cell = worksheet.Cells[3, 3];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell = worksheet.Cells[4, 1];

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();
                worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 2]].Merge();

                worksheet.Cells[2, 1] = "Список приходов за весь период по " + DateTime.Now.ToLongDateString();
                conf_cell = worksheet.Cells[2, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;

                worksheet.Cells[1, 1] = Registry_Class.OrganizationName;
                conf_cell = worksheet.Cells[1, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell.RowHeight = 50;

                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1]
                    = "Заместитель директора        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1]
                    = "Главный директор        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1]
                    = "Кладовщик        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1]
                    = "Дата: " + DateTime.Now.ToLongDateString();
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                application.ActiveWindow.View = XlWindowView.xlPageBreakPreview;

            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                workbook.SaveAs(name, application.DefaultSaveFormat);
                workbook.Close();
                application.Quit();
            }
        }

        public void SpisokSotr()
        {
            string name = Registry_Class.DirPath + "Список сотрудников"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".xlsx";
            excel.Application application = new excel.Application();
            excel.Workbook workbook = application.Workbooks.Add();
            excel.Worksheet worksheet =
                (excel.Worksheet)workbook.ActiveSheet;
            try
            {
                worksheet.Name = "Список сотрудников организации";
                worksheet.Cells[4, 1] = "Фамилия Имя Отчество";
                worksheet.Cells[4, 2] = "Дата рождения";
                worksheet.Cells[4, 3] = "Должность";
                for (int i = 0; i < dtDannieSklada.Rows.Count; i++)
                {
                    worksheet.Cells[i + 5, 1] = dtDannieSklada.Rows[i][0].ToString();
                    worksheet.Cells[i + 5, 2] = dtDannieSklada.Rows[i][1].ToString();
                    worksheet.Cells[i + 5, 3] = dtDannieSklada.Rows[i][2].ToString();
                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[3].AutoFit();
                }
                worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 3]].Interior.Color = XlRgbColor.rgbLightGray;

                excel.Range conf_cell = worksheet.Cells[3, 3];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell = worksheet.Cells[4, 1];

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 3]].Merge();
                worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 3]].Merge();

                worksheet.Cells[2, 1] = "Список сотрудников организации на " + DateTime.Now.ToLongDateString();
                conf_cell = worksheet.Cells[2, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;

                worksheet.Cells[1, 1] = Registry_Class.OrganizationName;
                conf_cell = worksheet.Cells[1, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell.RowHeight = 50;

                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1]
                    = "Заместитель директора        __________________";
                worksheet.Range[worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1], worksheet.Cells[dtDannieSklada.Rows.Count + 10, 3]].Merge();
                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1]
                    = "Главный директор        __________________";
                worksheet.Range[worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1], worksheet.Cells[dtDannieSklada.Rows.Count + 11, 3]].Merge();
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1]
                    = "Главный отдела кадров        __________________";
                worksheet.Range[worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1], worksheet.Cells[dtDannieSklada.Rows.Count + 12, 3]].Merge();
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1]
                    = "Дата: " + DateTime.Now.ToLongDateString();
                worksheet.Range[worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1], worksheet.Cells[dtDannieSklada.Rows.Count + 13, 3]].Merge();
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                application.ActiveWindow.View = XlWindowView.xlPageBreakPreview;

            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                workbook.SaveAs(name, application.DefaultSaveFormat);
                workbook.Close();
                application.Quit();
            }
        }
    }
}
