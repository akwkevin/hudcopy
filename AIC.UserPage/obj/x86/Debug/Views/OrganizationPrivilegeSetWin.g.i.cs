﻿#pragma checksum "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E3B4C5E2B5F069B4F82ED56642D28E80"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AIC.Core.OrganizationModels;
using AIC.UserPage.Views;
using MahApps.Metro.Controls;
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


namespace AIC.UserPage.Views {
    
    
    /// <summary>
    /// OrganizationPrivilegeSetWin
    /// </summary>
    public partial class OrganizationPrivilegeSetWin : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 30 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeview;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExpandAll;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuUnExpandAll;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSelectAll;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuUnSelectAll;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/AIC.UserPage;component/views/organizationprivilegesetwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.treeview = ((System.Windows.Controls.TreeView)(target));
            return;
            case 5:
            this.menuExpandAll = ((System.Windows.Controls.MenuItem)(target));
            
            #line 82 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.menuExpandAll.Click += new System.Windows.RoutedEventHandler(this.menuExpandAll_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menuUnExpandAll = ((System.Windows.Controls.MenuItem)(target));
            
            #line 87 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.menuUnExpandAll.Click += new System.Windows.RoutedEventHandler(this.menuUnExpandAll_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuSelectAll = ((System.Windows.Controls.MenuItem)(target));
            
            #line 92 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.menuSelectAll.Click += new System.Windows.RoutedEventHandler(this.menuSelectAll_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menuUnSelectAll = ((System.Windows.Controls.MenuItem)(target));
            
            #line 97 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.menuUnSelectAll.Click += new System.Windows.RoutedEventHandler(this.menuUnSelectAll_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 41 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.menuSelectAllChild_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 65 "..\..\..\..\Views\OrganizationPrivilegeSetWin.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.menuSelectAllChild_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

