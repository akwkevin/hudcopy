﻿using AIC.Core.UserManageModels;
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
using Wpf.CloseTabControl;

namespace AIC.HistoryDataPage.Views
{
    /// <summary>
    /// Interaction logic for ServerSetView.xaml
    /// </summary>
    public partial class HistoryEventListView : UserControl, ICloseable
    {
        public HistoryEventListView()
        {
            InitializeComponent();

            var menu = MenuManageList.GetMenu("menuSystemEventList");
            this.Closer = new CloseableHeader("menuSystemEventList", menu.Name, true, menu.IconPath);
        }
        public CloseableHeader Closer { get; private set; }
    }
}
