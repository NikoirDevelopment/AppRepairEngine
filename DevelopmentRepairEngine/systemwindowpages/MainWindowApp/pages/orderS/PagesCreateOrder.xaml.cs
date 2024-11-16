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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevelopmentRepairEngine.systemwindowpages.MainWindowApp.pages
{
    /// <summary>
    /// Логика взаимодействия для PagesCreateOrder.xaml
    /// </summary>
    public partial class PagesCreateOrder : Page
    {
        public PagesCreateOrder()
        {
            InitializeComponent();
            LoadData();
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
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? homeTechId = CmdHomeTech.SelectedValue as int?;
                int? techFactoryId = CmdTechFactory.SelectedValue as int?;
                int? modelTechFactoryId = CmdModelTechFactory.SelectedValue as int?;
                int? techColorId = CmdTechColor.SelectedValue as int?;

                if (homeTechId.HasValue && techFactoryId.HasValue && modelTechFactoryId.HasValue &&
                    techColorId.HasValue && !string.IsNullOrEmpty(TxbProblemeDescryption.Text) && BufferUser.userid != 0)
                {
                    Request request = new Request
                    {
                        StartDate = DateTime.Now,
                        HomeTechID = homeTechId.Value,
                        TechFactoryID = techFactoryId.Value,
                        ModelTechFactoryID = modelTechFactoryId.Value,
                        TechColorID = techColorId.Value,
                        ProblemeDescryption = TxbProblemeDescryption.Text,
                        RequestStatusID = 1,
                        ClientID = BufferUser.clientid
                    };

                    OdbConnectionHelper.OdbConnect.Request.Add(request);
                    OdbConnectionHelper.OdbConnect.SaveChanges();

                    MessageBox.Show("Ваша заявка создана!",
                        "Системное уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    CreateActionList();

                    // Очистка полей после успешного добавления
                    CmdHomeTech.SelectedValue = null;
                    CmdTechFactory.SelectedValue = null;
                    CmdModelTechFactory.SelectedValue = null;
                    CmdTechColor.SelectedValue = null;
                    TxbProblemeDescryption.Text = null;
                    ControlHelper.windowMainWindowAppFraim.frmobj.Navigate(new PagesCheckOrder());
                }
                else
                {
                    MessageBox.Show("Проверьте, что все атрибуты и поля заполнены!",
                        "Системное уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Колонка: {validationError.PropertyName}. Ошибка: {validationError.ErrorMessage}",
                            "Ошибка валидации данных",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var innerException = ex.InnerException?.InnerException;
                if (innerException != null)
                {
                    MessageBox.Show($"Ошибка обновления данных: {innerException.Message}",
                        "Ошибка обновления",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при обновлении данных.",
                        "Ошибка обновления",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка базы данных! " + ex.Message,
                    "Критическая ошибка | Создание заявки",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private static void CreateActionList()
        {
            try
            {
                ActionLog actionLog = new ActionLog()
                {
                    DateAndTime = DateTime.Now,
                    UserID = BufferUser.userid,
                    ActionStatusID = 4,
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
