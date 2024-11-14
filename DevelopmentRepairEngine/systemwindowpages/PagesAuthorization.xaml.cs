using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using DevelopmentRepairEngine.pages.MainWindowApp;
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
                if (login.Length > 0)
                {
                    if (password.Length > 0)
                    {
                        var sqlConn = OdbConnectionHelper.OdbConnect.User.FirstOrDefault(
                        x => String.Compare(x.Login, login, StringComparison.InvariantCulture) == 0 &&
                        String.Compare(x.Password, password, StringComparison.InvariantCulture) == 0);

                        if (sqlConn != null)
                        {
                            if ((sqlConn.Login == login) && (sqlConn.Password == password))
                            {
                                BufferUser.userid = sqlConn.UserID;
                                BufferUser.name = sqlConn.Name;
                                BufferUser.surname = sqlConn.Surname;
                                BufferUser.midllename = sqlConn.MiddleName;
                                BufferUser.login = sqlConn.Login;
                                BufferUser.role = sqlConn.RoleID;
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Пользователь " + login + " не найден!",
                                "Системное уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь " + login + " не найден!",
                                "Системное уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Проверьте, что поле пароль заполнено!",
                            "Системное уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте, что поле логин заполнено!",
                            "Системное уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка базы данных! " + ex,
                                    "Критическая ошибка | Авторизация",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
            }
        }

        private static void LoadData()
        {
            MessageBox.Show("Добро пожаловать " + BufferUser.surname + " " + BufferUser.name + " " + BufferUser.midllename + "!",
                "Системное уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            windowMainWindowApp windowMainWindowApp = new windowMainWindowApp();
            windowMainWindowApp.Show();

            CreateActionList();
            Application.Current.MainWindow.Close();
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
                    ActionStatusID = 1,
                    Descryption = ""
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
