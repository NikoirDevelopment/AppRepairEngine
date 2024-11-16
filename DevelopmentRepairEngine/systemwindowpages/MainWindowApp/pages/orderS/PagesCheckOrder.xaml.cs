using DevelopmentRepairEngine.data;
using DevelopmentRepairEngine.data.script;
using DevelopmentRepairEngine.pages;
using DevelopmentRepairEngine.systemwindowpages.MainWindowApp.pages.orderS;
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
    /// Логика взаимодействия для PagesCheckOrder.xaml
    /// </summary>
    public partial class PagesCheckOrder : Page
    {
        public PagesCheckOrder()
        {
            InitializeComponent();
            LoadData();
        }

        private bool includeMaster;
        private void LoadData()
        {
            if (CmdHomeTech.SelectedValue == null && CmdTechFactory.SelectedValue == null
                && CmdModelTechFactory.SelectedValue == null && CmdTechColor.SelectedValue == null)
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

            if (BufferUser.role == 4)
            {
                var sqlConn = OdbConnectionHelper.OdbConnect.Request.Where(
                    x => x.ClientID == BufferUser.clientid);
                DtgTable.ItemsSource = sqlConn.ToList();

            }
            else
            {
                DtgTable.ItemsSource = OdbConnectionHelper.OdbConnect.Request.ToList();
            }
        }

        private void BtnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowEditOreder windowEditOreder = new WindowEditOreder((sender as Button).DataContext as Request);
            windowEditOreder.Show();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Каскадное фильтрирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdHomeTech_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmdHomeTech.SelectedValue is int selectedHomeTechID)
            {
                // Получаем все записи в Request, где HomeTechID соответствует выбранному
                var filteredTechFactory = OdbConnectionHelper.OdbConnect.Request
                    .Where(r => r.HomeTechID == selectedHomeTechID)
                    .Select(r => r.TechFactory)
                    .Distinct() // убираем дубликаты
                    .ToList();

                CmdTechFactory.ItemsSource = filteredTechFactory;
                CmdTechFactory.SelectedValue = null;
                CmdModelTechFactory.SelectedValue = null;
                CmdTechColor.SelectedValue = null;
            }
        }

        private void CmdTechFactory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmdTechFactory.SelectedValue is int selectedTechFactoryID)
            {
                var filteredModelTechFactory = OdbConnectionHelper.OdbConnect.ModelTechFactory
                    .Where(x => x.TechFactoryID == selectedTechFactoryID)
                    .ToList();

                CmdModelTechFactory.ItemsSource = filteredModelTechFactory;
                CmdModelTechFactory.SelectedValue = null;
                CmdTechColor.SelectedValue = null;
            }
        }

        private void CmdModelTechFactory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmdModelTechFactory.SelectedValue is int selectedModelTechFactoryID)
            {
                var filteredTechColors = OdbConnectionHelper.OdbConnect.Request
                    .Where(r => r.ModelTechFactoryID == selectedModelTechFactoryID)
                    .Select(r => r.TechColor)
                    .Distinct() // убираем дубликаты
                    .ToList();

                CmdTechColor.ItemsSource = filteredTechColors;
                CmdTechColor.SelectedValue = null;
            }
        }

        /// <summary>
        /// Поиск по каскадному фильтру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = OdbConnectionHelper.OdbConnect.Request.AsQueryable();

            if (CmdHomeTech.SelectedValue is int selectedHomeTechID)
            {
                query = query.Where(x => x.HomeTechID == selectedHomeTechID);
            }

            if (CmdTechFactory.SelectedValue is int selectedTechFactoryID)
            {
                query = query.Where(x => x.TechFactoryID == selectedTechFactoryID);
            }

            if (CmdModelTechFactory.SelectedValue is int selectedModelTechFactoryID)
            {
                query = query.Where(x => x.ModelTechFactoryID == selectedModelTechFactoryID);
            }

            if (CmdTechColor.SelectedValue is int selectedTechColorID)
            {
                query = query.Where(x => x.TechColorID == selectedTechColorID);
            }

            DtgTable.ItemsSource = query.ToList();
        }

        private void BtnClean_Click(object sender, RoutedEventArgs e)
        {
            CmdHomeTech.SelectedValue = null;
            CmdTechFactory.SelectedValue = null;
            CmdModelTechFactory.SelectedValue = null;
            CmdTechColor.SelectedValue = null;

            LoadData();

            DtgTable.ItemsSource = OdbConnectionHelper.OdbConnect.Request.ToList();
        }
    }
}
