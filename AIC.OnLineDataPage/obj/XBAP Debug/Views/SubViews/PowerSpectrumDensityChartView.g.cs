﻿#pragma checksum "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D7BD227AE6CE30C164BE8EBFB8B885E2"
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
using AIC.CoreType;
using AIC.OnLineDataPage.Views.SubViews;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace AIC.OnLineDataPage.Views.SubViews {
    
    
    /// <summary>
    /// PowerSpectrumDensityChartView
    /// </summary>
    public partial class PowerSpectrumDensityChartView : AIC.OnLineDataPage.Views.SubViews.ChartViewBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AIC.OnLineDataPage.Views.SubViews.PowerSpectrumDensityChartView timeDomainOnLineView;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard OnLoaded2_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridChart;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtValue;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox filterCheckBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DropDownButton dropDownButton;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton bandPassRb;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton highPassRb;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton lowPassRb;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox fitViewCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/AIC.OnLineDataPage;component/views/subviews/powerspectrumdensitychartview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.timeDomainOnLineView = ((AIC.OnLineDataPage.Views.SubViews.PowerSpectrumDensityChartView)(target));
            return;
            case 2:
            this.OnLoaded2_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.gridChart = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.txtValue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.filterCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.dropDownButton = ((Xceed.Wpf.Toolkit.DropDownButton)(target));
            return;
            case 7:
            this.bandPassRb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.highPassRb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.lowPassRb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.fitViewCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            
            #line 224 "..\..\..\..\Views\SubViews\PowerSpectrumDensityChartView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ScreenshotButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

