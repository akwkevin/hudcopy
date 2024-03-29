﻿#pragma checksum "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DCFA2E81727CEADA334A40E8E2CFA682"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AIC.Cloud.DataReplayer.UserControls;
using AIC.Cloud.DataReplayer.ViewModels;
using AIC.Cloud.DataReplayer.Views;
using AIC.Cloud.Presentation;
using AIC.Cloud.Presentation.Actions;
using AIC.Cloud.Presentation.Behaviors;
using AIC.Cloud.Presentation.Controls;
using AIC.Cloud.Presentation.Converters;
using AIC.CoreType;
using AIC.Themes.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace AIC.Cloud.DataReplayer.UserControls {
    
    
    /// <summary>
    /// DateRangeSlider
    /// </summary>
    public partial class DateRangeSlider : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AIC.Cloud.DataReplayer.UserControls.DateRangeSlider rangeSlider;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Thumb LeftThumb;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Thumb RightThumb;
        
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
            System.Uri resourceLocater = new System.Uri("/AIC.Cloud.DataReplayer;component/usercontrols/daterangeslider/daterangeslider.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
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
            this.rangeSlider = ((AIC.Cloud.DataReplayer.UserControls.DateRangeSlider)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 47 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            ((System.Windows.Controls.Primitives.Thumb)(target)).DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.CentreThumb_DragDelta);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            ((System.Windows.Controls.Primitives.Thumb)(target)).DragCompleted += new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Thumb_DragCompleted);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LeftThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 56 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            this.LeftThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.LeftThumb_DragDelta);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            this.LeftThumb.DragCompleted += new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Thumb_DragCompleted);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RightThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 72 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            this.RightThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.RightThumb_DragDelta);
            
            #line default
            #line hidden
            
            #line 73 "..\..\..\..\UserControls\DateRangeSlider\DateRangeSlider.xaml"
            this.RightThumb.DragCompleted += new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Thumb_DragCompleted);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

