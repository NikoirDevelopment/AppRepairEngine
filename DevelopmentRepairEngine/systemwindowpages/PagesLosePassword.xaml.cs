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

        private void BtnCheckLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbUser.Text != null)
                {


                    if (true)
                    {

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь: " + TxbUser.Text + " не найден!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Поле для ввода логина пустое! Введите логин для поиска в системе",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла критеская ошибка! " + ex,
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private static void LoadData()
        {

        }
    }
}
