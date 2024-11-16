using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using DevelopmentRepairEngine.systemwindowpages.MainWindowApp.pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            Btn_Users.Visibility = Visibility.Collapsed;
            Btn_Statistics.Visibility = Visibility.Collapsed;
            Btn_CheckOrder.Visibility = Visibility.Collapsed;
            Btn_CreateOrder.Visibility = Visibility.Collapsed;
            Btn_Message.Visibility = Visibility.Collapsed;
            LblGrid0.Visibility = Visibility.Visible;
            LblGrid1.Visibility = Visibility.Visible;

            ControlHelper.windowMainWindowAppFraim.frmobj = FrmMain;

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

            ControlHelper.windowMainWindowAppFraim.BtnCloseSystem.BtnClose = 0;
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "БытСервис | Пользователи";
            this.Width = 850;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesUsers());
        }
        private void Btn_CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "БытСервис | Создание заявки";
            this.Width = 850;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesCreateOrder());
        }

        private void Btn_CheckOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "БытСервис | Проверка заказа";
            this.Width = 1800;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesCheckOrder());
        }

        private void Btn_Statistics_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "БытСервис | Статистика деятельности";
            this.Width = 850;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesStatistick());
        }

        private void Btn_Message_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "БытСервис | Уведомление";
            this.Width = 850;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesMessage());
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти из системы",
                "Системное уведомление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                ControlHelper.windowMainWindowAppFraim.BtnCloseSystem.BtnClose = 1;

                CreateActionList();
                this.Close();
            }
        }

        /// <summary>
        /// Создание записи в журнал действий
        /// </summary>
        private static void CreateActionList()
        {
            try
            {
                ActionLog actionLog = new ActionLog()
                {
                    DateAndTime = DateTime.Now,
                    UserID = BufferUser.userid,
                    ActionStatusID = 3,
                    Descryption = "Нет дополнительных комментариев"
                };

                OdbConnectionHelper.OdbConnect.ActionLog.Add(actionLog);
                OdbConnectionHelper.OdbConnect.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания записи действий пользователя: " + ex,
                    "Системное уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (ControlHelper.windowMainWindowAppFraim.BtnCloseSystem.BtnClose == 0)
            {
                CreateActionList();
            }
        }
    }
}
