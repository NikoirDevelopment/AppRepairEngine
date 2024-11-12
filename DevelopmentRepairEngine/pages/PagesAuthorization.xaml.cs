using System;
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
    /// Логика взаимодействия для PagesAuthorization.xaml
    /// </summary>
    public partial class PagesAuthorization : Page
    {
        public PagesAuthorization()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string login = TxbUser.Text;
            string password = TxbPassword.Password;

            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesRegistration());
        }

        private void BtnLose_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.frmobj.Navigate(new PagesLosePassword());
        }
    }
}
