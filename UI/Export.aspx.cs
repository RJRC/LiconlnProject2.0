using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Microsoft.Win32;

namespace UI
{
    public partial class Export : System.Web.UI.Page
    {

        private BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"].ToString().Equals("1"))
            {

                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string varr = Session["ExportType"].ToString();
            switch (varr)
            {
                case "1":

                    string i = Session["ExportYear"].ToString();
                    int year = int.Parse(i);
                    DataTable dataTable1 = bll.showSummaryYear(year);
                    DataTable dataTable2 = bll.showSummaryYearPerMonthsInAdminModule(year);

                    String data = "";

                    foreach (DataColumn item in dataTable1.Columns)
                    {
                        data += item.ColumnName + ",\t";

                    }

                    data += ",\n";

                    foreach (DataRow row in dataTable1.Rows)
                    {

                        data += row["Notario"] + ",\t";
                        data += row["Facturación Anual"] + ",\t";
                        data += row["Saldo Anual"] + ",\t";
                        data += row["Limite Anual"] + ",\t";

                        data += "\n";
                    }
                    data += "\n";
                    data += "\n";

                    foreach (DataColumn item in dataTable2.Columns)
                    {
                        data += item.ColumnName + ",\t";

                    }

                    data += ",\n";

                    foreach (DataRow row in dataTable2.Rows)
                    {

                        data += row["Iniciales"] + ",\t";
                        
                        data += row["Enero"] + ",\t";
                        data += row["Febrero"] + ",\t";
                        data += row["Marzo"] + ",\t";
                        data += row["Abril"] + ",\t";
                        data += row["Mayo"] + ",\t";
                        data += row["Junio"] + ",\t";
                        data += row["Julio"] + ",\t";
                        data += row["Agosto"] + ",\t";
                        data += row["Setiembre"] + ",\t";
                        data += row["Octubre"] + ",\t";
                        data += row["Noviembre"] + ",\t";
                        data += row["Diciembre"] + ",\t";

                        data += row["total"] + ",\t";


                        data += "\n";
                    }
                    export(data);
                    break;

                case "2":
                    string j = Session["ExportYear"].ToString();
                    int year2 = int.Parse(j);

                    string idNotaryfake = Session["NotaryID"].ToString();
                    int idNotary = int.Parse(idNotaryfake);

                    DataTable dataTable3 = bll.getAllOwnWritingsByNotary(idNotary, year2);
                    DataTable dataTable4 = bll.getAllCoNotariesByNotary(idNotary, year2);
                    DataTable dataTable5 = bll.showSummaryYearPerMonths(idNotary, year2) ;//falta agregar

                    String data2 = "";

                    foreach (DataColumn item in dataTable3.Columns)
                    {
                        data2 += item.ColumnName + ",\t";

                    }

                    data2 += ",\n";

                    foreach (DataRow row in dataTable3.Rows)
                    {

                        data2 += row["Notario"] + ",\t";
                        data2 += row["Numero de Escritura"] + ",\t";
                        data2 += row["Acto"] + ",\t";
                        data2 += row["Asunto"] + ",\t";
                        data2 += row["Cliente"] + ",\t";
                        data2 += row["Honorario"] + ",\t";
                        data2 += row["Facturado por Notario"] + ",\t";
                        data2 += row["Partes"] + ",\t";
                        data2 += row["Cédula a Facturar"] + ",\t";
                        data2 += row["Domicilio a Facturar"] + ",\t";
                        data2 += row["Correo a Facturar"] + ",\t";
                        data2 += row["Fecha"] + ",\t";

                        data2 += "\n";
                    }
                    data2 += "\n";
                    data2 += "\n";

                    foreach (DataColumn item in dataTable4.Columns)
                    {
                        data2 += item.ColumnName + ",\t";

                    }

                    data2 += ",\n";

                    foreach (DataRow row in dataTable4.Rows)
                    {

                        data2 += row["CoNotario"] + ",\t";
                        data2 += row["Numero de Escritura"] + ",\t";
                        data2 += row["Acto"] + ",\t";
                        data2 += row["Asunto"] + ",\t";
                        data2 += row["Cliente"] + ",\t";
                        data2 += row["Honorario"] + ",\t";
                        data2 += row["Facturado por CoNotario"] + ",\t";
                        data2 += row["Partes"] + ",\t";
                        data2 += row["Cédula a Facturar"] + ",\t";
                        data2 += row["Domicilio a Facturar"] + ",\t";
                        data2 += row["Correo a Facturar"] + ",\t";
                        data2 += row["Fecha"] + ",\t";


                        data2 += "\n";
                    }





                    export(data2);
                    break;

                }
            }

     

        
        public void export(String data)
        {
            String name = TextBox1.Text;
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + name + ".csv");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(data);
            Response.End();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string varr = Session["ExportType"].ToString();
            switch (varr) {
                case "1":

                string i = Session["ExportYear"].ToString();
                int year = int.Parse(i);
                DataTable dataTable10 = bll.showSummaryYearPerMonthsInAdminModuleToExport1(year);
                    DataTable dataTable30 = bll.showSummaryYearPerMonthsInAdminModuleToExport2(year);
                DataTable dataTable20 = bll.showSummaryYear(year);

                string mdoc = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();

                exportDataTableToPdf(dataTable10, dataTable30, dataTable20, mdoc + "\\" + TextBox1.Text + ".pdf", "Resumen Periodo Fiscal " + Session["ExportYear"].ToString());


                System.Diagnostics.Process.Start(mdoc + "\\" + TextBox1.Text + ".pdf");
                    break;

                case "2":

                    

                    string j = Session["ExportYear"].ToString();
                    int year2 = int.Parse(j);

                    string idNotaryfake = Session["NotaryID"].ToString();
                    int idNotary = int.Parse(idNotaryfake);

                    DataTable dataTable3 = bll.getAllOwnWritingsByNotaryToExport1(idNotary, year2);
                    DataTable dataTable6 = bll.getAllOwnWritingsByNotaryToExport2(idNotary, year2);

                    DataTable dataTable4 = bll.getAllCoNotariesByNotaryToExport1(idNotary, year2);

                    DataTable dataTable7 = bll.getAllCoNotariesByNotaryToExport2(idNotary, year2);


                    DataTable dataTable5 = bll.showSummaryYearPerMonths(idNotary, year2);

                    string mdoc2 = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();

                    exportDataTableToPdf(dataTable3, dataTable6, dataTable4, dataTable7, dataTable5, mdoc2 + "\\" + TextBox1.Text + ".pdf", "Resumen Periodo Fiscal " + Session["ExportYear"].ToString(), year2);


                    System.Diagnostics.Process.Start(mdoc2 + "\\" + TextBox1.Text + ".pdf");

                    break;

            }

        }

        void exportDataTableToPdf(DataTable dtblTable, DataTable dtblTable3, DataTable dtblTable2,  String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, Color.BLACK);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.BLACK);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Autor : Invicta Legal", fntAuthor));
            prgAuthor.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            //Write the table
            PdfPTable table3 = new PdfPTable(dtblTable3.Columns.Count);
            //Table header
            BaseFont btnColumnHeader3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader3 = new Font(btnColumnHeader3, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable3.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table3.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable3.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable3.Columns.Count; j++)
                {
                    table3.AddCell(dtblTable3.Rows[i][j].ToString());
                }
            }


            //Write the table
            PdfPTable table2 = new PdfPTable(dtblTable2.Columns.Count);
            //Table header
            BaseFont btnColumnHeader2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader2 = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable2.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table2.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable2.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable2.Columns.Count; j++)
                {
                    table2.AddCell(dtblTable2.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Add(table3);

            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(table2);
            document.Close();
            writer.Close();
            fs.Close();
        }

        void exportDataTableToPdf(DataTable dtblTable , DataTable dtblTable6, DataTable dtblTable2, DataTable dtblTable7,  DataTable dtblTable3,  String strPdfPath, string strHeader, int year)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();


            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, Color.BLACK);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.BLACK);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Autor : Invicta Legal", fntAuthor));
            prgAuthor.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            
            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
           // table.HorizontalAlignment = Element.ALIGN_JUSTIFIED ;

            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            //Write the table
            PdfPTable table6 = new PdfPTable(dtblTable6.Columns.Count);
            // table.HorizontalAlignment = Element.ALIGN_JUSTIFIED ;

            //Table header
            BaseFont btnColumnHeader6 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader6 = new Font(btnColumnHeader6, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable6.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable6.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table6.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable6.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable6.Columns.Count; j++)
                {
                    table6.AddCell(dtblTable6.Rows[i][j].ToString());
                }
            }



            //Write the table
            PdfPTable table2 = new PdfPTable(dtblTable2.Columns.Count);
            //Table header
            BaseFont btnColumnHeader2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader2 = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable2.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table2.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable2.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable2.Columns.Count; j++)
                {
                    table2.AddCell(dtblTable2.Rows[i][j].ToString());
                }
            }

            //Write the table
            PdfPTable table7 = new PdfPTable(dtblTable7.Columns.Count);
            // table.HorizontalAlignment = Element.ALIGN_JUSTIFIED ;

            //Table header
            BaseFont btnColumnHeader7 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader7 = new Font(btnColumnHeader7, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable7.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable7.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table7.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable7.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable7.Columns.Count; j++)
                {
                    table7.AddCell(dtblTable7.Rows[i][j].ToString());
                }
            }

            //Write the table
            PdfPTable table3 = new PdfPTable(dtblTable3.Columns.Count);
            //Table header
            BaseFont btnColumnHeader3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader3 = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable3.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table3.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable3.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable3.Columns.Count; j++)
                {
                    table3.AddCell(dtblTable3.Rows[i][j].ToString());
                }
            }


            //Titulo
            Paragraph prgAuthor2 = new Paragraph();
            BaseFont btnAuthor2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor2 = new Font(btnAuthor2, 12, 2, Color.BLACK);
            prgAuthor2.Alignment = Element.ALIGN_LEFT;
            prgAuthor2.Add(new Chunk("Facturacion Propia", fntAuthor2));
            
            //Titulo
            Paragraph prgAuthor3 = new Paragraph();
            BaseFont btnAuthor3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor3 = new Font(btnAuthor3, 12, 2, Color.BLACK);
            prgAuthor3.Alignment = Element.ALIGN_LEFT;
            prgAuthor3.Add(new Chunk("Facturacion CoNotariada", fntAuthor3));
            

            //Titulo
            Paragraph prgAuthor4 = new Paragraph();
            BaseFont btnAuthor4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor4 = new Font(btnAuthor4, 12, 2, Color.BLACK);
            prgAuthor4.Alignment = Element.ALIGN_LEFT;
            prgAuthor4.Add(new Chunk("Resumen Periodo Fiscal " + year , fntAuthor4));
            




            document.Add(prgAuthor2);
            document.Add(new Chunk("\n", fntHead));
            document.Add(table);
            document.Add(table6);
            //Add line break
            document.Add(new Chunk("\n", fntHead));
            document.Add(prgAuthor3);
            document.Add(new Chunk("\n", fntHead));
            document.Add(table2);
            document.Add(table7);
            document.Add(new Chunk("\n", fntHead));
            document.Add(prgAuthor4);
            document.Add(new Chunk("\n", fntHead));
            document.Add(table3);
            document.Close();
            writer.Close();
            fs.Close();
        }

    }
}