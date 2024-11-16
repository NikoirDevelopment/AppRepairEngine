using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using DevelopmentRepairEngine.pages;
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

namespace DevelopmentRepairEngine.systemwindowpages.MainWindowApp.pages.orderS
{
    /// <summary>
    /// Логика взаимодействия для WindowEditOreder.xaml
    /// </summary>
    public partial class WindowEditOreder : Window
    {
        private Request _request;

        public WindowEditOreder(Request req)
        {
            InitializeComponent();
            LoadDataSender(req);
            LoadData();
            EditSystem();
        }

        private void LoadDataSender(Request req)
        {
            var sqlConn = OdbConnectionHelper.OdbConnect.Request.FirstOrDefault(
                x => x.RequestID == req.RequestID);

            _request = sqlConn;
        }

        private void LoadData()
        {
            CmdHomeTech.ItemsSource = OdbConnectionHelper.OdbConnect.HomeTech.ToList();
            CmdHomeTech.SelectedValuePath = "HomeTechID";
            CmdHomeTech.DisplayMemberPath = "Type";

            CmdTechFactory.ItemsSource = OdbConnectionHelper.OdbConnect.TechFactory.ToList();
            CmdTechFactory.SelectedValuePath = "TechFactoryID";
            CmdTechFactory.DisplayMemberPath = "Title";

            CmdModelTechFactory.ItemsSource = OdbConnectionHelper.OdbConnect.ModelTechFactory.ToList();
            CmdModelTechFactory.SelectedValuePath = "ModelTechFactoryID";
            CmdModelTechFactory.DisplayMemberPath = "Title";

            CmdTechColor.ItemsSource = OdbConnectionHelper.OdbConnect.TechColor.ToList();
            CmdTechColor.SelectedValuePath = "TechColorID";
            CmdTechColor.DisplayMemberPath = "Color";

            var sqlConn = OdbConnectionHelper.OdbConnect.Employee.Where(
                x => x.RoleID == 2);
            CmdMaster.ItemsSource =  sqlConn.ToList();
            CmdMaster.SelectedValuePath = "UserID";
            CmdMaster.DisplayMemberPath = "Surname";

            CmdOrderStatus.ItemsSource = OdbConnectionHelper.OdbConnect.RequestStatus.ToList();
            CmdOrderStatus.SelectedValuePath = "RequestStatusID";
            CmdOrderStatus.DisplayMemberPath = "Status";

            if (CmdHomeTech.ItemsSource == null || CmdTechFactory.ItemsSource == null || CmdModelTechFactory.ItemsSource == null
                || CmdTechColor.ItemsSource == null)
            {
                CmdHomeTech.SelectedValue = null;
                CmdTechFactory.SelectedValue = null;
                CmdModelTechFactory.SelectedValue = null;
                CmdTechColor.SelectedValue = null;
                TxbProblemeDescryption.Text = "Ошибка подключение к базе данных";
            }
            else
            {
                CmdHomeTech.SelectedValue = _request.HomeTechID;
                CmdTechFactory.SelectedValue = _request.TechFactoryID;
                CmdModelTechFactory.SelectedValue = _request.ModelTechFactoryID;
                CmdTechColor.SelectedValue = _request.TechColorID;
                TxbProblemeDescryption.Text = _request.ProblemeDescryption;
            }
        }

        /// <summary>
        /// Выдача прав действий
        /// </summary>
        private void EditSystem()
        {
            switch (BufferUser.role)
            {
                case 1: // Менеджер
                    TxbProblemeDescryption.IsEnabled = false;
                    TxbProblemeDescryptionMaster.IsEnabled = true;
                    CmdHomeTech.IsEnabled = false;
                    CmdModelTechFactory.IsEnabled = false;
                    CmdTechColor.IsEnabled = false;
                    CmdTechFactory.IsEnabled = false;
                    CmdMaster.IsEnabled = false;
                    CmdOrderStatus.IsEnabled = false;
                    break;

                case 2: // Мастер
                    TxbProblemeDescryption.IsEnabled = false;
                    TxbProblemeDescryptionMaster.IsEnabled = true;
                    CmdHomeTech.IsEnabled = false;
                    CmdModelTechFactory.IsEnabled = false;
                    CmdTechColor.IsEnabled = false;
                    CmdTechFactory.IsEnabled = false;
                    CmdMaster.IsEnabled = false;
                    CmdOrderStatus.IsEnabled = false;
                    break;

                case 3: //Оператор
                    TxbProblemeDescryption.IsEnabled = false;
                    TxbProblemeDescryptionMaster.IsEnabled = true;
                    CmdHomeTech.IsEnabled = false;
                    CmdModelTechFactory.IsEnabled = false;
                    CmdTechColor.IsEnabled = false;
                    CmdTechFactory.IsEnabled = false;
                    CmdMaster.IsEnabled = true;
                    CmdOrderStatus.IsEnabled = true;
                break;

                case 4: // Клиент
                    TxbProblemeDescryption.IsEnabled = true;
                    TxbProblemeDescryptionMaster.IsEnabled = false;
                    CmdHomeTech.IsEnabled = true;
                    CmdModelTechFactory.IsEnabled = true;
                    CmdTechColor.IsEnabled = true;
                    CmdTechFactory.IsEnabled = true;
                    CmdMaster.IsEnabled = false;
                    CmdOrderStatus.IsEnabled = false;
                    break;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Логика сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (BufferUser.role)
                {
                    case 1:

                    case 2:

                    case 3:
                        if (CmdHomeTech.ItemsSource != null && CmdModelTechFactory.ItemsSource != null
                            && CmdTechFactory.ItemsSource != null && TxbProblemeDescryption.Text.Length > 0)
                        {


                            //_buff.HomeTechID = (int)CmdHomeTech.SelectedValue;
                            //_buff.TechFactoryID = (int)CmdTechFactory.SelectedValue;
                            //_buff.ModelTechFactoryID = (int)CmdModelTechFactory.SelectedValue;
                            //_buff.TechColorID = (int)CmdTechColor.SelectedValue;
                            //_buff.ProblemeDescryption = TxbProblemeDescryption.Text;
                            //_buff.MasterID = (int)CmdMaster.SelectedValue;
                            //_buff.RequestStatusID = (int)CmdOrderStatus.SelectedValue;
                            //_buff.RepairParts = TxbProblemeDescryptionMaster.Text;
                            OdbConnectionHelper.OdbConnect.SaveChanges();

                            MessageBox.Show("Статус заявки изменено!",
                                "Системное уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                            CreateActionList();
                            this.Close();
                        }
                    break;

                    case 4:
                        if (CmdHomeTech.ItemsSource != null && CmdModelTechFactory.ItemsSource != null
                            && CmdTechFactory.ItemsSource != null && TxbProblemeDescryption.Text.Length > 0)
                        {
                            _request.HomeTechID = (int)CmdHomeTech.SelectedValue;
                            _request.TechFactoryID = (int)CmdTechFactory.SelectedValue;
                            _request.ModelTechFactoryID = (int)CmdModelTechFactory.SelectedValue;
                            _request.TechColorID = (int)CmdTechColor.SelectedValue;
                            _request.ProblemeDescryption = TxbProblemeDescryption.Text;
                            OdbConnectionHelper.OdbConnect.SaveChanges();

                            MessageBox.Show("Ваша заявка изменена!",
                                "Системное уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                            CreateActionList();
                            this.Close();
                        }
                    break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка базы данных! " + ex,
                    "Критическая ошибка | Изменение заявки",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Создание записи действий
        /// </summary>
        private static void CreateActionList()
        {
            try
            {
                ActionLog actionLog = new ActionLog()
                {
                    DateAndTime = DateTime.Now,
                    UserID = BufferUser.userid,
                    ActionStatusID = 5,
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
    }
}
