﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DevelopmentRepairEngine.pages
{
    /// <summary>
    /// Логика взаимодействия для PagesLosePassword.xaml
    /// </summary>
    public partial class PagesLosePassword : Page
    {
        public PagesLosePassword()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesAuthorization());
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesRegistration());
        }
    }
}