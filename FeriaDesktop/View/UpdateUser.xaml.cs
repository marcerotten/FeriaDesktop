﻿using FeriaDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        public UpdateUser()
        {
            InitializeComponent();
            this.DataContext = new UsersViewModel();
        }
    }
}