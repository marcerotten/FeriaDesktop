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

            if (guarda.ShowDialog() == DialogResult)
            {
                using (FileStream stream = new FileStream(guarda.FileName, FileMode.Create))
                {



                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Add(new Phrase("test pdf"));




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
                    UserName = "entretekno@gmail.com",
                    Password = "abonita2"
                }


            };
            MailAddress MailFrom = new MailAddress("entretekno@gmail.com", "Orlando");
            MailAddress MailTo = new MailAddress("o.labbe@duocuc.cl", "testing");
            MailMessage MailMSG = new MailMessage()
            {
                From = MailFrom,
                Subject = "hola como estas",
                Body = "MaipoTest",

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
