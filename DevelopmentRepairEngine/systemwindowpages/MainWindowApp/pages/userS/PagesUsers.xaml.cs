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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevelopmentRepairEngine.systemwindowpages.MainWindowApp.pages
{
    /// <summary>
    /// Логика взаимодействия для PagesUser.xaml
    /// </summary>
    public partial class PagesUsers : Page
    {
        public PagesUsers()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DtgTable.ItemsSource = OdbConnectionHelper.OdbConnect.User.ToList();
        }
    }
}
