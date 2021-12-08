﻿using FluentEmail.Core;
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
            //Generacion de PDF INICIO
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.FileName = "reporte.pdf"; //DateTime.Now.ToString("ddMMyyyyHHmmss") +


            if (guarda.ShowDialog() == DialogResult)
            {
                using (FileStream stream = new FileStream(guarda.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase("hola"));

                    pdfDoc.Close();

                    stream.Close();

                }
            }

            //Generacion de PDF FINAL

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
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Git\reporte.pdf");

           

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








    }
}
