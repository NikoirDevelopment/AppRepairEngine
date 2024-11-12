using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для PagesRegistration.xaml
    /// </summary>
    public partial class PagesRegistration : Page
    {
        public PagesRegistration()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesAuthorization());
        }

        private void BtnLosePassword_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesLosePassword());
        }
    }
}
