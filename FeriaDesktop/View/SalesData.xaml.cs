using FluentEmail.Core;
using FluentEmail.Smtp;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;
using FluentEmail.Core.Models;
using Paragraph = iTextSharp.text.Paragraph;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Interaction logic for SalesData.xaml
    /// </summary>
    public partial class SalesData : Window
    {
        public SalesData()
        {
            InitializeComponent();
        }
        private void SendMail(string pdfName) 
        {
            
            //Envio de Correos INICIO
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "maipograndereporte@gmail.com",
                    Password = "feriavirtual"
                }


            };
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfName);



            MailAddress MailFrom = new MailAddress("maipograndereporte@gmail.com", "MGReporte");
            MailAddress MailTo = new MailAddress(mailInput.Text, "Receptor Reporte");
            MailMessage MailMSG = new MailMessage()
            {
                From = MailFrom,
                Subject = "Reporte ventas Maipo Grande",
                Body = "MaipoGrande",

            };
            MailMSG.Attachments.Add(attachment);
            MailMSG.To.Add(MailTo);

            try
            {
                Client.Send(MailMSG);
                MessageBox.Show("Su archivo ha sido enviado", "Exito");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Archivo no enviado", "Error");

            }
            //Envio de Correos FINAL



        }

        private string GeneratePDF() 
        {
            //Generacion de PDF INICIO
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.FileName = @"Reporte.pdf";
            guarda.Filter = "PDF(*.pdf) | *.pdf";
            guarda.ShowDialog();
           

            if (guarda.FileName != "")
            {
                using (FileStream stream = new FileStream(guarda.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Paragraph("hola")); 
                    pdfDoc.Add(new Paragraph(this.GridDataSales.Items.Count == 0?"Si":"No"));

                    pdfDoc.Add(new Paragraph(this.GridDataSales.Items.GetItemAt(0).ToString()));
                    pdfDoc.Add(new Paragraph(this.GridDataSales.Items.ToString()));
                    pdfDoc.Add(new Paragraph(this.GridDataSales.Items.Count.ToString()));

                    PdfPTable table = new PdfPTable(3);

                    PdfPCell cell = new PdfPCell(new Phrase("Row 1 , Col 1, Col 2 and col 3"));
                    cell.Colspan = 3;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    table.AddCell("Row 2, Col 1");
                    table.AddCell("Row 2, Col 1");
                    table.AddCell("Row 2, Col 1");

                    table.AddCell("Row 3, Col 1");
                    cell = new PdfPCell(new Phrase("Row 3, Col 2 and Col3"));
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Row 4, Col 1 and Col2"));
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    table.AddCell("Row 4, Col 3");

                    pdfDoc.Add(table);


                    pdfDoc.Close();

                    stream.Close();

                }
                return guarda.FileName;
            }
            return null;

            //Generacion de PDF FINAL
        }

       
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           
            var filePass = this.GeneratePDF();

            if (filePass != null)
            {

                this.SendMail(filePass);

            }
            else {
                MessageBox.Show("file nulo");
            }


            
        }

    }
}
