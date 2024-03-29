﻿using System;
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
using Wpf.CloseTabControl;

namespace AIC.CYSHPage.Views
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class HomeView : UserControl, ICloseable
    {
        public HomeView()
        {
            InitializeComponent();
            this.Closer = new CloseableHeader((string)Application.Current.Resources["tabFirst"], false);
        }
        public CloseableHeader Closer { get; private set; }
    }
}
