﻿using AIC.Core.Models;
using AIC.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIC.Core.ControlModels;
using AIC.Core.OrganizationModels;
using AIC.ServiceInterface;
using AIC.Core;
using AIC.OnLineDataPage.Models;
using System.Windows.Input;
using AIC.CoreType;
using System.Windows.Controls;
using AIC.Domain;
using AIC.Core.SignalModels;
using System.Windows;
using Wpf.PageNavigationControl;
using AIC.Core.ExCommand;
using System.ComponentModel;
using System.Windows.Data;

namespace AIC.OnLineDataPage.ViewModels
{
    class OnlineDataOverviewViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IOrganizationService _organizationService;
        private readonly ICardProcess _cardProcess;
        private readonly ISignalProcess _signalProcess;
        public OnlineDataOverviewViewModel(IEventAggregator eventAggregator, IOrganizationService organizationService, ICardProcess cardProcess, ISignalProcess signalProcess)
        {
            _eventAggregator = eventAggregator;
            _organizationService = organizationService;
            _cardProcess = cardProcess;
            _signalProcess = signalProcess;          

            InitTree();
            InitItem(OrganizationTreeItems);
            selecteddevices = _cardProcess.GetDevices(OrganizationTreeItems);

            _view = new ListCollectionView(SignalMonitors);
            _view.Filter = (object item) =>
            {
                var itemPl = (SignalListViewModel)item;
                if (selecteddevices.Contains(itemPl.Device))
                {
                    if (IsInvalidSignal == false && IsNormalSignal == false && IsPreAlarmSignal == false && IsAlarmSignal == false && IsDangerSignal == false)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.Invalid && IsInvalidSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.HighNormal && IsNormalSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.HighPreAlarm && IsPreAlarmSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.HighAlarm && IsAlarmSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.HighDanger && IsDangerSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.LowDanger && IsDangerSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.LowAlarm && IsAlarmSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.LowPreAlarm && IsPreAlarmSignal == true)
                    {
                        return true;
                    }
                    if (itemPl.Device.Alarm == AlarmGrade.LowNormal && IsNormalSignal == true)
                    {
                        return true;
                    }

                    return false;
                }
                return false;
            };

            //_signalList.SortDescriptions.Add(new SortDescription("DeviceName", ListSortDirection.Ascending));
            readDataTimer.Tick += new EventHandler(timeCycle);
            readDataTimer.Interval = new TimeSpan(0, 0, 0, 1);
            readDataTimer.Start();
        }        

        #region 管理树
        private void InitTree()
        {
            OrganizationTreeItems = _organizationService.OrganizationTreeItems;
            //TreeExpanded();
        }

        private void TreeExpanded()
        {
            foreach (var first in OrganizationTreeItems)
            {
                first.IsExpanded = true;
                foreach (var second in first.Children)
                {
                    second.IsExpanded = true;
                    foreach (var third in second.Children)
                    {
                        third.IsExpanded = true;
                    }
                }
            }
        }
        #endregion

        #region 属性与字段
        private ObservableCollection<OrganizationTreeItemViewModel> _organizationTreeItems;
        public ObservableCollection<OrganizationTreeItemViewModel> OrganizationTreeItems
        {
            get { return _organizationTreeItems; }
            set
            {
                _organizationTreeItems = value;
                OnPropertyChanged("OrganizationTreeItems");
            }
        }

        private readonly ICollectionView _view;
        public ICollectionView SignalList { get { return _view; } }

        private FastObservableCollection<SignalListViewModel> signalMonitors = new FastObservableCollection<SignalListViewModel>();
        public FastObservableCollection<SignalListViewModel> SignalMonitors
        {
            get { return signalMonitors; }
            set
            {
                signalMonitors = value;
                OnPropertyChanged("SignalMonitors");
            }
        }

        private SignalListViewModel selectedSignalMonitor;
        public SignalListViewModel SelectedSignalMonitor
        {
            get { return selectedSignalMonitor; }
            set
            {
                if (selectedSignalMonitor != value)
                {
                    if (selectedSignalMonitor != null)
                    {
                        selectedSignalMonitor.IsSelected = false;
                    }
                    selectedSignalMonitor = value;
                    if (selectedSignalMonitor != null)
                    {
                        selectedSignalMonitor.IsSelected = true;                       
                    }
                    OnPropertyChanged("SelectedSignalMonitor");
                }
            }
        }

        //private string searchName;
        //public string OrganizationNames
        //{
        //    get { return searchName; }
        //    set
        //    {
        //        searchName = value;
        //        OnPropertyChanged("OrganizationNames");
        //    }
        //}

        private double itemWidth =300;
        public double ItemWidth
        {
            get { return itemWidth; }
            set
            {
                if (itemWidth != value)
                {
                    itemWidth = value;
                    OnPropertyChanged("ItemWidth");
                    foreach (var item in SignalMonitors)
                    {
                        item.ItemWidth = value;
                    }
                }
            }
        }

        private double itemHeight = 125;
        public double ItemHeight
        {
            get { return itemHeight; }
            set
            {
                if (itemHeight != value)
                {
                    itemHeight = value;
                    OnPropertyChanged("ItemHeight");
                    foreach (var item in SignalMonitors)
                    {
                        item.ItemHeight = value;
                    }
                }
            }
        }        

        private Orientation orientation = Orientation.Horizontal;
        public Orientation Orientation
        {
            get { return orientation; }
            set
            {
                if (orientation != value)
                {
                    orientation = value;
                    OnPropertyChanged("Orientation");
                    if (value == Orientation.Horizontal)
                    {
                        HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    }
                    if (value == Orientation.Vertical)
                    {
                        HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                        VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    }
                }
            }
        }

        private ScrollBarVisibility verticalScrollBarVisibility = ScrollBarVisibility.Auto;
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return verticalScrollBarVisibility; }
            set
            {
                if (verticalScrollBarVisibility != value)
                {
                    verticalScrollBarVisibility = value;
                    OnPropertyChanged("VerticalScrollBarVisibility");
                }
            }
        }

        private ScrollBarVisibility horizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get { return horizontalScrollBarVisibility; }
            set
            {
                if (horizontalScrollBarVisibility != value)
                {
                    horizontalScrollBarVisibility = value;
                    OnPropertyChanged("HorizontalScrollBarVisibility");
                }
            }
        }

        private bool isComposing = false;
        public bool IsComposing
        {
            get { return isComposing; }
            set
            {
                if (isComposing != value)
                {
                    isComposing = value;
                    OnPropertyChanged("IsComposing");
                }
            }
        }

        private bool isInvalidSignal;
        public bool IsInvalidSignal
        {
            get { return isInvalidSignal; }
            set
            {
                if (isInvalidSignal != value)
                {
                    isInvalidSignal = value;
                    OnPropertyChanged(() => IsInvalidSignal);
                    _view.Refresh();
                }
            }
        }

        private bool isNormalSignal;
        public bool IsNormalSignal
        {
            get { return isNormalSignal; }
            set
            {
                if (isNormalSignal != value)
                {
                    isNormalSignal = value;
                    OnPropertyChanged(() => IsNormalSignal);
                    _view.Refresh();
                }
            }
        }

        private bool isPreAlertSignal;
        public bool IsPreAlarmSignal
        {
            get { return isPreAlertSignal; }
            set
            {
                if (isPreAlertSignal != value)
                {
                    isPreAlertSignal = value;
                    OnPropertyChanged(() => IsPreAlarmSignal);
                    _view.Refresh();
                }
            }
        }

        private bool isAlertSignal;
        public bool IsAlarmSignal
        {
            get { return isAlertSignal; }
            set
            {
                if (isAlertSignal != value)
                {
                    isAlertSignal = value;
                    OnPropertyChanged(() => IsAlarmSignal);
                    _view.Refresh();
                }
            }
        }

        private bool isDangerSignal;
        public bool IsDangerSignal
        {
            get { return isDangerSignal; }
            set
            {
                if (isDangerSignal != value)
                {
                    isDangerSignal = value;
                    OnPropertyChanged(() => IsDangerSignal);
                    _view.Refresh();
                }
            }
        }

        private int normalCount;
        public int NormalCount
        {
            get { return normalCount; }
            set
            {
                if (normalCount != value)
                {
                    normalCount = value;
                    this.OnPropertyChanged(() => this.NormalCount);
                }
            }
        }

        private int preAlertCount;
        public int PreAlertCount
        {
            get { return preAlertCount; }
            set
            {
                if (preAlertCount != value)
                {
                    preAlertCount = value;
                    this.OnPropertyChanged(() => this.PreAlertCount);
                }
            }
        }

        private int alertCount;
        public int AlertCount
        {
            get { return alertCount; }
            set
            {
                if (alertCount != value)
                {
                    alertCount = value;
                    this.OnPropertyChanged(() => this.AlertCount);
                }
            }
        }

        private int dangerCount;
        public int DangerCount
        {
            get { return dangerCount; }
            set
            {
                if (dangerCount != value)
                {
                    dangerCount = value;
                    this.OnPropertyChanged(() => this.DangerCount);
                }
            }
        }

        private int abnormalCount;
        public int AbnormalCount
        {
            get { return abnormalCount; }
            set
            {
                if (abnormalCount != value)
                {
                    abnormalCount = value;
                    this.OnPropertyChanged(() => this.AbnormalCount);
                }
            }
        }

        private int unConnectCount;
        public int UnConnectCount
        {
            get { return unConnectCount; }
            set
            {
                if (unConnectCount != value)
                {
                    unConnectCount = value;
                    this.OnPropertyChanged(() => this.UnConnectCount);
                }
            }
        }
        #endregion

        #region Command   
        private ICommand queryCommand;
        public ICommand QueryCommand
        {
            get
            {
                return this.queryCommand ?? (this.queryCommand = new DelegateCommand<object>(para => this.Query(para)));
            }
        }

        private ICommand groupCommand;
        public ICommand GroupCommand
        {
            get
            {
                return this.groupCommand ?? (this.groupCommand = new DelegateCommand<object>(para => this.Group(para)));
            }
        }

        private ICommand unGroupCommand;
        public ICommand UnGroupCommand
        {
            get
            {
                return this.unGroupCommand ?? (this.unGroupCommand = new DelegateCommand<object>(para => this.UnGroup(para)));
            }
        }

        private ICommand selectedTreeChangedComamnd;
        public ICommand SelectedTreeChangedComamnd
        {
            get
            {
                return this.selectedTreeChangedComamnd ?? (this.selectedTreeChangedComamnd = new DelegateCommand<object>(para => this.SelectedTreeChanged(para)));
            }
        }
        #endregion

        #region 添加、删除显示

        private void InitItem(IList<OrganizationTreeItemViewModel> organization)
        {           
            var devices = _cardProcess.GetDevices(organization);
            foreach (var device in devices)
            {
                SignalListViewModel viewModel = new SignalListViewModel(device);
                viewModel.ItemWidth = itemWidth;
                viewModel.ItemHeight = itemHeight;
                SignalMonitors.Add(viewModel);
            }

        }

        private void Query(object para)
        {
            _view.Refresh();
        }

        private void Group(object para)
        {
            _view.GroupDescriptions.Clear();
            _view.GroupDescriptions.Add(new PropertyGroupDescription("DeviceName"));//对视图进行分组
        }

        private void UnGroup(object para)
        {
            _view.GroupDescriptions.Clear();
            _view.GroupDescriptions.Add(new PropertyGroupDescription("NullName"));//对视图进行分组
        }
        #endregion

        #region       
        private List<DeviceTreeItemViewModel> selecteddevices;
        public void SelectedTreeChanged(object para)
        {
            if (para is OrganizationTreeItemViewModel)
            {
                selecteddevices = _cardProcess.GetDevices(para as OrganizationTreeItemViewModel);
                _view.Refresh();
            }
        }
        #endregion

        private System.Windows.Threading.DispatcherTimer readDataTimer = new System.Windows.Threading.DispatcherTimer();
        private void timeCycle(object sender, EventArgs e)
        {
            NormalCount = 0;
            PreAlertCount = 0;
            AlertCount = 0;
            DangerCount = 0;
            AbnormalCount = 0;
            UnConnectCount = 0;
            foreach (var item in _view.AsParallel())
            {
                var sg = item as SignalListViewModel;
                if (sg != null)
                {
                    switch (sg.Device.Alarm)
                    {
                        case AlarmGrade.HighNormal:
                        case AlarmGrade.LowNormal:
                            NormalCount++; break;
                        case AlarmGrade.HighPreAlarm:
                        case AlarmGrade.LowPreAlarm:
                            PreAlertCount++; break;
                        case AlarmGrade.HighAlarm:
                        case AlarmGrade.LowAlarm:
                            AlertCount++; break;
                        case AlarmGrade.HighDanger:
                        case AlarmGrade.LowDanger:
                            DangerCount++; break;
                        case AlarmGrade.Abnormal:
                            AbnormalCount++; break;
                        case AlarmGrade.DisConnect:
                            UnConnectCount++; break;
                        default:
                            UnConnectCount++; break;
                    }
                }
            }
        }
    }
}
