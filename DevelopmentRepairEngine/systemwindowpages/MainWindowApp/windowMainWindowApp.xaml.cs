using DevelopmentRepairEngine.data.script;
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
using System.Windows.Shapes;

namespace DevelopmentRepairEngine.pages.MainWindowApp
{
    /// <summary>
    /// Логика взаимодействия для windowMainWindowApp.xaml
    /// </summary>
    public partial class windowMainWindowApp : Window
    {
        public windowMainWindowApp()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Btn_Users.Visibility = Visibility.Collapsed;
            Btn_Statistics.Visibility = Visibility.Collapsed;
            Btn_CheckOrder.Visibility = Visibility.Collapsed;
            Btn_CreateOrder.Visibility = Visibility.Collapsed;
            Btn_Message.Visibility = Visibility.Collapsed;
            LblGrid0.Visibility = Visibility.Visible;
            LblGrid1.Visibility = Visibility.Visible;

            switch (BufferUser.role)
            {
                case 1:
                    Btn_Users.Visibility = Visibility.Visible;
                    Btn_Statistics.Visibility = Visibility.Visible;
                    Btn_CheckOrder.Visibility = Visibility.Visible;
                    Btn_CreateOrder.Visibility = Visibility.Visible;
                    Btn_Message.Visibility = Visibility.Visible;
                    LblGrid0.Visibility = Visibility.Hidden;
                    LblGrid1.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Btn_Users.Visibility = Visibility.Visible;
                    Btn_Statistics.Visibility = Visibility.Visible;
                    Btn_CheckOrder.Visibility = Visibility.Visible;
                    Btn_CreateOrder.Visibility = Visibility.Visible;
                    Btn_Message.Visibility = Visibility.Visible;
                    LblGrid0.Visibility = Visibility.Hidden;
                    LblGrid1.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Btn_Users.Visibility = Visibility.Visible;
                    Btn_Statistics.Visibility = Visibility.Visible;
                    Btn_CheckOrder.Visibility = Visibility.Visible;
                    Btn_CreateOrder.Visibility = Visibility.Visible;
                    Btn_Message.Visibility = Visibility.Visible;
                    LblGrid0.Visibility = Visibility.Hidden;
                    LblGrid1.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    Btn_Users.Visibility = Visibility.Collapsed;
                    Btn_Statistics.Visibility = Visibility.Collapsed;
                    Btn_CheckOrder.Visibility = Visibility.Visible;
                    Btn_CreateOrder.Visibility = Visibility.Visible;
                    Btn_Message.Visibility = Visibility.Visible;
                    LblGrid0.Visibility = Visibility.Hidden;
                    LblGrid1.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_CheckOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Statistick_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Statistics_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
