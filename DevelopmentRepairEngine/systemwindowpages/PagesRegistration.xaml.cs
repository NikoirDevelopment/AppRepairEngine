using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            TxbUser.IsEnabled = true;
            TxbName.IsEnabled = false;
            TxbSurname.IsEnabled = false;
            TxbMiddlename.IsEnabled = false;
            TxbPhone.IsEnabled = false;
            TxbPassword1.IsEnabled = false;
            TxbPassword2.IsEnabled = false;
        }

        public static int userID { get; set; }
        public static string login {  get; set; }
        public static string name { get; set; }
        public static string surname { get; set; }
        public static string middlename { get; set; }
        public static float phone { get; set; }
        public static string password1 { get; set; }
        public static string password2 { get; set; }

        private void TxbUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbUser.Text.Length > 3)
            {
                TxbName.IsEnabled = true;
            }
            else
            {
                TxbName.IsEnabled = false;
                TxbName.Text = null;
            }
        }

        private void TxbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbName.Text.Length > 0)
            {
                TxbSurname.IsEnabled = true;
            }
            else
            {
                TxbSurname.IsEnabled = false;
                TxbSurname.Text = null;
            }
        }

        private void TxbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbSurname.Text.Length > 0)
            {
                TxbMiddlename.IsEnabled = true;
            }
            else
            {
                TxbMiddlename.IsEnabled = false;
                TxbMiddlename.Text = null;
            }
        }

        private void TxbMiddlename_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbMiddlename.Text.Length > 0)
            {
                TxbPhone.IsEnabled = true;
            }
            else
            {
                TxbPhone.IsEnabled = false;
                TxbPhone.Text = null;
            }
        }

        private void TxbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbPhone.Text.Length > 10)
            {
                TxbPassword1.IsEnabled = true;
                TxbPassword2.IsEnabled = true;
            }
            else
            {
                TxbPassword1.IsEnabled = false;
                TxbPassword1.Password = null;

                TxbPassword2.IsEnabled = false;
                TxbPassword2.Password = null;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            login = TxbUser.Text;
            name = TxbName.Text;
            surname = TxbSurname.Text;
            middlename = TxbMiddlename.Text;
            phone = Convert.ToInt64(TxbPhone.Text);
            password1 = TxbPassword1.Password;
            password2 = TxbPassword1.Password;

            try
            {
                if (password1 == password2)
                {
                    var sqlConn = OdbConnectionHelper.OdbConnect.Client.FirstOrDefault(
                    x => String.Compare(x.Login, login, StringComparison.InvariantCulture) == 0);

                    if (sqlConn == null)
                    {
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь " + login + " уже занят!",
                            "Системное уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте, что поле пароль заполнено верно и совпадает!",
                        "Системное уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла критическая ошибка! Подробнее: " + ex,
                    "Критическая ошибка | Регистрация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        private static void LoadData()
        {
            try
            {
                User user = new User()
                {
                    Name = name,
                    Surname = surname,
                    MiddleName = middlename,
                    Phone = phone,
                };
                OdbConnectionHelper.OdbConnect.User.Add(user);
                OdbConnectionHelper.OdbConnect.SaveChanges();

                var sqlConn1 = OdbConnectionHelper.OdbConnect.User.FirstOrDefault(
                            x => x.Name == name && x.Surname == surname && x.MiddleName == middlename && x.Phone == phone);

                Client client = new Client()
                {
                    UserID = sqlConn1.UserID,
                    Login = login,
                    Password = password2,
                    RoleID = 4
                };
                OdbConnectionHelper.OdbConnect.Client.Add(client);
                OdbConnectionHelper.OdbConnect.SaveChanges();

                userID = sqlConn1.UserID;

                MessageBox.Show("Пользователь " + login + " создан!",
                    "Регистрация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                CreateActionList();
                ControlHelper.mainWindowFraim.frmobj.Navigate(new PagesAuthorization());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Системная ошибка! " + ex,
                    "Критическая ошибка | Регистрация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
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
                    ActionStatusID = 1,
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

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            TxbUser.Text = null;
            TxbName.Text = null;
            TxbSurname.Text = null;
            TxbMiddlename.Text = null;
            TxbPhone.Text = null;
            TxbPassword1.Password = null;
            TxbPassword2.Password = null;

            ControlHelper.mainWindowFraim.frmobj.Navigate(new PagesAuthorization());
        }

        private void BtnLosePassword_Click(object sender, RoutedEventArgs e)
        {
            TxbUser.Text = null;
            TxbName.Text = null;
            TxbSurname.Text = null;
            TxbMiddlename.Text = null;
            TxbPhone.Text = null;
            TxbPassword1.Password = null;
            TxbPassword2.Password = null;

            ControlHelper.mainWindowFraim.frmobj.Navigate(new PagesLosePassword());
        }
    }
}
