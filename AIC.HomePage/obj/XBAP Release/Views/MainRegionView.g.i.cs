﻿#pragma checksum "..\..\..\Views\MainRegionView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E70459EB9A91F16B94FD001FD57E0A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AIC.Core;
using AIC.Core.ControlModels;
using AIC.HomePage.Views;
using MahApps.Metro.Controls;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
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
using System.Windows.Interactivity;
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


namespace AIC.HomePage.Views {
    
    
    /// <summary>
    /// MainRegionView
    /// </summary>
    public partial class MainRegionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AIC.HomePage.Views.MainRegionView usercontrol;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 425 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ScreenShot;
        
        #line default
        #line hidden
        
        
        #line 433 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton togglebtn;
        
        #line default
        #line hidden
        
        
        #line 484 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 526 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl;
        
        #line default
        #line hidden
        
        
        #line 578 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton mutebtn;
        
        #line default
        #line hidden
        
        
        #line 629 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse ellipse;
        
        #line default
        #line hidden
        
        
        #line 645 "..\..\..\Views\MainRegionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse ellipse2;
        
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
            System.Uri resourceLocater = new System.Uri("/AIC.HomePage;component/views/mainregionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MainRegionView.xaml"
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
            this.usercontrol = ((AIC.HomePage.Views.MainRegionView)(target));
            return;
            case 2:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 95 "..\..\..\Views\MainRegionView.xaml"
            ((System.Windows.Controls.Menu)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Menu_MouseEnter);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\Views\MainRegionView.xaml"
            ((System.Windows.Controls.Menu)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Menu_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ScreenShot = ((System.Windows.Controls.Button)(target));
            
            #line 425 "..\..\..\Views\MainRegionView.xaml"
            this.ScreenShot.Click += new System.Windows.RoutedEventHandler(this.ScreenShot_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.togglebtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 6:
            this.slider = ((System.Windows.Controls.Slider)(target));
            return;
            case 7:
            this.tabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 8:
            this.mutebtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 9:
            this.ellipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 10:
            this.ellipse2 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

