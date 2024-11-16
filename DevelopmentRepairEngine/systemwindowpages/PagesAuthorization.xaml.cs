using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using DevelopmentRepairEngine.pages.MainWindowApp;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
                        var sqlConn1 = OdbConnectionHelper.OdbConnect.Client.FirstOrDefault(
                            x => String.Compare(x.Login, login, StringComparison.InvariantCulture) == 0 &&
                            String.Compare(x.Password, password, StringComparison.InvariantCulture) == 0);

                        if (sqlConn1 == null)
                        {
                            var sqlConn2 = OdbConnectionHelper.OdbConnect.Employee.FirstOrDefault(
                                x => String.Compare(x.Login, login, StringComparison.InvariantCulture) == 0 &&
                                String.Compare(x.Password, password, StringComparison.InvariantCulture) == 0);

                            if (sqlConn2 != null)
                            {
                                var sqlConn4 = OdbConnectionHelper.OdbConnect.User.FirstOrDefault(
                                    x => x.UserID == sqlConn2.UserID);

                                if ((sqlConn2.Login == login) && (sqlConn2.Password == password))
                                {
                                    BufferUser.userid = sqlConn4.UserID;
                                    BufferUser.name = sqlConn4.Name;
                                    BufferUser.surname = sqlConn4.Surname;
                                    BufferUser.midllename = sqlConn4.MiddleName;
                                    BufferUser.login = sqlConn2.Login;
                                    BufferUser.role = sqlConn2.RoleID;
                                    LoadData();
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
                            var sqlConn3 = OdbConnectionHelper.OdbConnect.User.FirstOrDefault(
                                x => x.UserID == sqlConn1.UserID);

                            if ((sqlConn1.Login == login) && (sqlConn1.Password == password))
                            {
                                BufferUser.userid = sqlConn3.UserID;
                                BufferUser.clientid = sqlConn1.ClientID;
                                BufferUser.name = sqlConn3.Name;
                                BufferUser.surname = sqlConn3.Surname;
                                BufferUser.midllename = sqlConn3.MiddleName;
                                BufferUser.login = sqlConn1.Login;
                                BufferUser.role = sqlConn1.RoleID;
                                LoadData();
                            }
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
                    ActionStatusID = 2,
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

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.mainWindowFraim.frmobj.Navigate(new PagesRegistration());
        }

        private void BtnLose_Click(object sender, RoutedEventArgs e)
        {
            ControlHelper.mainWindowFraim.frmobj.Navigate(new PagesLosePassword());
        }
    }
}
