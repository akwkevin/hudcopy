﻿#pragma checksum "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0CEF722BF5C42F1F45E2C24D58D9016"
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
using Loya.Dameer;
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


namespace AIC.HistoryDataPage.Views {
    
    
    /// <summary>
    /// AlarmPointTrendDataView
    /// </summary>
    public partial class AlarmPointTrendDataView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 83 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton timeRadioBtn;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton frequencyRadioBtn;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showAMSCheckBox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridChart;
        
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
            System.Uri resourceLocater = new System.Uri("/AIC.HistoryDataPage;component/views/subviews/alarmpointtrenddataview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
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
            
            #line 49 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.timeRadioBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 83 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            this.timeRadioBtn.Checked += new System.Windows.RoutedEventHandler(this.timeRadioBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.frequencyRadioBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 84 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            this.frequencyRadioBtn.Checked += new System.Windows.RoutedEventHandler(this.frequencyRadioBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.showAMSCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 87 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            this.showAMSCheckBox.Checked += new System.Windows.RoutedEventHandler(this.showAMSCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 87 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            this.showAMSCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.showAMSCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridChart = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            
            #line 92 "..\..\..\..\Views\SubViews\AlarmPointTrendDataView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ScreenshotButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

