﻿#pragma checksum "..\..\..\system\PagesLosePassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "280BFFB436C918C6A30478C78DB8E719673630A7BF616F5E8083CB8F02542217"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevelopmentRepairEngine.pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DevelopmentRepairEngine.pages {
    
    
    /// <summary>
    /// PagesLosePassword
    /// </summary>
    public partial class PagesLosePassword : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 75 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbUser;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCheckLogin;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TxbPassword1;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TxbPassword;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAuth;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\system\PagesLosePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DevelopmentRepairEngine;component/system/pageslosepassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\system\PagesLosePassword.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxbUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnCheckLogin = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\system\PagesLosePassword.xaml"
            this.BtnCheckLogin.Click += new System.Windows.RoutedEventHandler(this.BtnCheckLogin_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxbPassword1 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.TxbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.BtnAuth = ((System.Windows.Controls.Button)(target));
            
            #line 224 "..\..\..\system\PagesLosePassword.xaml"
            this.BtnAuth.Click += new System.Windows.RoutedEventHandler(this.BtnAuth_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnReg = ((System.Windows.Controls.Button)(target));
            
            #line 238 "..\..\..\system\PagesLosePassword.xaml"
            this.BtnReg.Click += new System.Windows.RoutedEventHandler(this.BtnReg_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

