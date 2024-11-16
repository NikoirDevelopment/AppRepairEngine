using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DevelopmentRepairEngine.pages
{
    /// <summary>
    /// Контейнер смены страниц
    /// </summary>
    class ControlHelper
    {
        internal class mainWindowFraim
        {
            public static Frame frmobj;
        }

        internal class windowMainWindowAppFraim
        {
            internal class BtnCloseSystem
            {
                public static int BtnClose {  get; set; }
            }

            public static Frame frmobj;
        }
    }
}
