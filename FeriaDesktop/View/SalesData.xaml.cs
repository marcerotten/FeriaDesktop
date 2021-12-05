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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Generacion de PDF
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            guarda.ShowDialog();

            if (guarda.ShowDialog() == DialogResult)
            {
                using (FileStream stream = new FileStream(guarda.FileName, FileMode.Create))
                {



                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase("test pdf"));

                    pdfDoc.Close();

                    stream.Close();




                }
            }


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
            MailAddress MailFrom = new MailAddress("maipograndereporte@gmail.com", "MGReporte");
            MailAddress MailTo = new MailAddress(mailInput.Text, "testing");
            MailMessage MailMSG = new MailMessage()
            {
                From = MailFrom,
                Subject = "hola como estas",
                Body = "MaipoTest",
                //Attachments = "La variable que almacene el pdf"

        };
            MailMSG.To.Add(MailTo);

            try
            {
                Client.Send(MailMSG);
                MessageBox.Show("enviado", "bien");


            }
            catch (Exception ex)
            {
                MessageBox.Show("error", "error2");

            }
            //Envio de Correos FINAL
        }
    }
}
