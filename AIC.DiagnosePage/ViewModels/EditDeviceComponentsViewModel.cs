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
using AIC.Core.SignalModels;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Diagnostics;
using System.Threading;
using AIC.ServiceInterface;
using System.Windows;
using AIC.Resources.Models;
using AIC.Core.DataModels;
using AIC.M9600.Common.DTO.Device;
using AIC.M9600.Common.SlaveDB.Generated;
using AIC.CoreType;
using System.Collections;
using AIC.Core.HardwareModels;
using AIC.Core.DiagnosticModels;
using AIC.Core.ExCommand;
using System.Windows.Controls;
using AIC.MatlabMath;
using Newtonsoft.Json;
using System.IO;
using OpenXmlPowerTools;
using System.Xml.Linq;
using AIC.DiagnosePage.Views;
using AIC.PDAPage.Models;
using AIC.Core;
using System.Windows.Media;
using AIC.Core.DiagnosticBaseModels;
using AIC.M9600.Common.MasterDB.Generated;

namespace AIC.DiagnosePage.ViewModels
{
    class EditDeviceComponentsViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IOrganizationService _organizationService;
        private readonly ISignalProcess _signalProcess;
        private readonly ICardProcess _cardProcess;
        private readonly IDatabaseComponent _databaseComponent;
        private readonly IRegionManager _regionManager;
        private readonly IDeviceDiagnoseTemplateService _deviceDiagnoseTemplateService;

        public EditDeviceComponentsViewModel(IEventAggregator eventAggregator, IOrganizationService organizationService, ISignalProcess signalProcess, ICardProcess cardProcess, IDatabaseComponent databaseComponent, IRegionManager regionManager, IDeviceDiagnoseTemplateService deviceDiagnoseTemplateService)
        {
            _eventAggregator = eventAggregator;
            _organizationService = organizationService;
            _signalProcess = signalProcess;
            _cardProcess = cardProcess;
            _databaseComponent = databaseComponent;
            _regionManager = regionManager;
            _deviceDiagnoseTemplateService = deviceDiagnoseTemplateService;

            InitTree();
        }

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

        private OrganizationTreeItemViewModel selectedTreeItem;
        public OrganizationTreeItemViewModel SelectedTreeItem
        {
            get { return selectedTreeItem; }
            set
            {
                if (selectedTreeItem != value)
                {
                    selectedTreeItem = value;
                    OnPropertyChanged("SelectedTreeItem");
                }
            }
        }

        private ViewModelStatus _status = ViewModelStatus.None;
        public ViewModelStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public string waitinfo;
        public string WaitInfo
        {
            get
            {
                return waitinfo;
            }
            set
            {
                waitinfo = value;
                OnPropertyChanged("WaitInfo");
            }
        }

        private DeviceTreeItemViewModel selectedDeviceTreeItemViewModel;
        public DeviceTreeItemViewModel SelectedDeviceTreeItemViewModel
        {
            get { return selectedDeviceTreeItemViewModel; }
            set
            {
                if (selectedDeviceTreeItemViewModel != value)
                {
                    selectedDeviceTreeItemViewModel = value;
                    OnPropertyChanged("SelectedDeviceTreeItemViewModel");
                }
            }
        }    

        private ObservableCollection<DeviceDiagnoseClass> devices;
        public ObservableCollection<DeviceDiagnoseClass> Devices
        {
            get { return devices; }
            set
            {
                devices = value;
                OnPropertyChanged("Devices");
            }
        }

        private DeviceDiagnoseClass selectedDevice;
        public DeviceDiagnoseClass SelectedDevice
        {
            get { return selectedDevice; }
            set
            {
                selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }
        #endregion

        #region 命令
        private ICommand selectedTreeChangedComamnd;
        public ICommand SelectedTreeChangedComamnd
        {
            get
            {
                return this.selectedTreeChangedComamnd ?? (this.selectedTreeChangedComamnd = new DelegateCommand<object>(para => this.SelectedTreeChanged(para)));
            }
        }

        private ICommand editShaftCommand;
        public ICommand EditShaftCommand
        {
            get
            {
                return this.editShaftCommand ?? (this.editShaftCommand = new DelegateCommand<object>(para => this.EditShaft(para)));
            }
        }

        private ICommand shaftSelectionChangedCommand;
        public ICommand ShaftSelectionChangedCommand
        {
            get
            {
                return this.shaftSelectionChangedCommand ?? (this.shaftSelectionChangedCommand = new DelegateCommand<object>(para => this.ShaftSelectionChanged(para)));
            }
        }

        private ICommand editComponentCommand;
        public ICommand EditComponentCommand
        {
            get
            {
                return this.editComponentCommand ?? (this.editComponentCommand = new DelegateCommand<object>(para => this.EditComponent(para)));
            }
        }

        private ICommand componentSelectionChangedCommand;
        public ICommand ComponentSelectionChangedCommand
        {
            get
            {
                return this.componentSelectionChangedCommand ?? (this.componentSelectionChangedCommand = new DelegateCommand<object>(para => this.ComponentSelectionChanged(para)));
            }
        }
        
        private ICommand clearDeviceCommand;
        public ICommand ClearDeviceCommand
        {
            get
            {
                return this.clearDeviceCommand ?? (this.clearDeviceCommand = new DelegateCommand<object>(para => this.ClearDevice(para)));
            }
        }

        private ICommand saveDeviceCommand;
        public ICommand SaveDeviceCommand
        {
            get
            {
                return this.saveDeviceCommand ?? (this.saveDeviceCommand = new DelegateCommand<object>(para => this.SaveDevice(para)));
            }
        }        

        private ICommand saveToFileCommand;
        public ICommand SaveToFileCommand
        {
            get
            {
                return this.saveToFileCommand ?? (this.saveToFileCommand = new DelegateCommand<object>(para => this.SaveToFile(para)));
            }
        }

        private ICommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                return this.loadCommand ?? (this.loadCommand = new DelegateCommand<object>(para => this.Load(para)));
            }
        }

        public DelegateCommand<object> mouseMoveComamnd;
        public DelegateCommand<object> MouseMoveComamnd
        {
            get
            {
                if (mouseMoveComamnd == null)
                {
                    mouseMoveComamnd = new DelegateCommand<object>(
                        para => this.MouseMove(para)
                        );
                }
                return mouseMoveComamnd;
            }
        }

        public DelegateCommand<object> mouseDownComamnd;
        public DelegateCommand<object> MouseDownComamnd
        {
            get
            {
                if (mouseDownComamnd == null)
                {
                    mouseDownComamnd = new DelegateCommand<object>(
                        para => this.MouseDown(para)
                        );
                }
                return mouseDownComamnd;
            }
        }

        public DelegateCommand<object> dragEnterCommand;
        public DelegateCommand<object> DragEnterCommand
        {
            get
            {
                if (dragEnterCommand == null)
                {
                    dragEnterCommand = new DelegateCommand<object>(
                        para => DragEnter(para)
                        );
                }
                return dragEnterCommand;
            }
        }

        public DelegateCommand<object> dragOverCommand;
        public DelegateCommand<object> DragOverCommand
        {
            get
            {
                if (dragOverCommand == null)
                {
                    dragOverCommand = new DelegateCommand<object>(
                        para => DragOver(para)
                        );
                }
                return dragOverCommand;
            }
        }

        public DelegateCommand<object> dragLeaveCommand;
        public DelegateCommand<object> DragLeaveCommand
        {
            get
            {
                if (dragLeaveCommand == null)
                {
                    dragLeaveCommand = new DelegateCommand<object>(
                        para => DragLeave(para)
                        );
                }
                return dragLeaveCommand;
            }
        }

        public DelegateCommand<object> dropCommand;
        public DelegateCommand<object> DropCommand
        {
            get
            {
                if (dropCommand == null)
                {
                    dropCommand = new DelegateCommand<object>(
                        para => Drop(para)
                        );
                }
                return dropCommand;
            }
        }

        public DelegateCommand<object> selectedDeviceChangedComamnd;
        public DelegateCommand<object> SelectedDeviceChangedComamnd
        {
            get
            {
                if (selectedDeviceChangedComamnd == null)
                {
                    selectedDeviceChangedComamnd = new DelegateCommand<object>(
                        para => SelectedDeviceChanged(para)
                        );
                }
                return selectedDeviceChangedComamnd;
            }
        }
        #endregion

        #region 管理树
        private void InitTree()
        {
            OrganizationTreeItems = _organizationService.OrganizationTreeItems;
            //TreeExpanded();
           
            if (Devices == null)
            {
                Devices = _deviceDiagnoseTemplateService.DeviceClassList;
            }
        }

        public void Init(DeviceTreeItemViewModel device)
        {
            SelectedDeviceTreeItemViewModel = device;
            SelectedDeviceTreeItemViewModel.IsSelected = true;
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

        #region 选择项
        private async void SelectedTreeChanged(object para)
        {
            SelectedDevice = null;
            SelectedDeviceTreeItemViewModel = para as DeviceTreeItemViewModel;
            if (SelectedDeviceTreeItemViewModel != null)
            {
                if (SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent == null)
                {
                    var component = await _deviceDiagnoseTemplateService.GetDeviceDiagnoseComponent(SelectedDeviceTreeItemViewModel.ServerIP, SelectedDeviceTreeItemViewModel.T_Organization.Guid);
                    SelectedDeviceTreeItemViewModel.IntiDeviceDiagnoseComponent(component);
                }
            }
        }
        #endregion

        #region 编辑模型
        private static Uri editShaftComponentView = new Uri("EditShaftComponentView", UriKind.Relative);
        private static Uri editMachComponentView = new Uri("EditMachComponentView", UriKind.Relative);
        private static Uri nullView = new Uri("NullView", UriKind.Relative);
        private bool editComponentDoubleClick = false;

        private void EditShaft(object para)
        {
            DeviceTreeItemViewModel devicemodel = para as DeviceTreeItemViewModel;
            if (devicemodel != null && devicemodel.DeviceDiagnoseComponent != null && devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft != null && devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft.Component != null && devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.Count == 0)
            {
                BearingComponent bear = NewComponent();
                devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.AddBearingComponent(bear);
                devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.SelectedComponent = bear;

                ComponentSelectionChanged(devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft);
            }
            else
            {
                ShaftSelectionChanged(para);
            }           
        }

        private BearingComponent NewComponent()
        {
            return new BearingComponent();            
        }

        private void ShaftSelectionChanged(object para)
        {
            if (editComponentDoubleClick)//避免EditShaft编辑事件
            {
                editComponentDoubleClick = false;
                return;
            }
            DeviceTreeItemViewModel devicemodel = para as DeviceTreeItemViewModel;
            if (devicemodel != null && devicemodel.DeviceDiagnoseComponent != null && devicemodel.DeviceDiagnoseComponent.Component.SelectedShaft != null)
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("DeviceDiagnoseComponent", devicemodel.DeviceDiagnoseComponent);
                _regionManager.RequestNavigate(RegionNames.EditComponentRegion, editShaftComponentView, navigationParameters);
            }
            else
            {
                _regionManager.RequestNavigate(RegionNames.EditComponentRegion, nullView);
            }
        }

        private void EditComponent(object para)
        {
            ComponentSelectionChanged(para);
        }

        private void ComponentSelectionChanged(object para)
        {
            ShaftComponent selectedshaft = para as ShaftComponent;
            if (selectedshaft != null && selectedshaft.Component != null && selectedshaft.Component.SelectedComponent != null)
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("ShaftComponent", selectedshaft);
                _regionManager.RequestNavigate(RegionNames.EditComponentRegion, editMachComponentView, navigationParameters);
            }
            else
            {
                _regionManager.RequestNavigate(RegionNames.EditComponentRegion, nullView);
            }
            editComponentDoubleClick = true;           
        }

        private void ClearDevice(object para)
        {
            DeviceTreeItemViewModel device = para as DeviceTreeItemViewModel;
            if (device == null)
            {
                return;
            }
#if XBAP
            MessageBoxResult result = MessageBox.Show("确定要重置" + SelectedDeviceTreeItemViewModel.Name + "?", "重置", MessageBoxButton.OK, MessageBoxImage.Warning);
#else
            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("确定要重置" + SelectedDeviceTreeItemViewModel.Name + "?", "重置", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
#endif
            if (result == MessageBoxResult.OK)
            {
                _deviceDiagnoseTemplateService.DeleteDeviceDiagnoseComponent(device.ServerIP, device.DeviceDiagnoseComponent.id);
                device.IntiDeviceDiagnoseComponent();
            }
        }

        private async void SaveDevice(object para)
        {
            DeviceTreeItemViewModel device = para as DeviceTreeItemViewModel;
            if (device != null)
            {
                try
                {
                    WaitInfo = "模型保存中";
                    Status = ViewModelStatus.Querying;
                    T_Diagnosis_Model t_model = DeviceDiagnoseComponent.ConvertToDB(device.DeviceDiagnoseComponent);
                    if (device.DeviceDiagnoseComponent.id == -1)
                    {
                        device.DeviceDiagnoseComponent.id  = await _deviceDiagnoseTemplateService.AddDeviceDiagnoseComponent(device.ServerIP, t_model);
                    }
                    else
                    {
                        await _deviceDiagnoseTemplateService.ModifyDeviceDiagnoseComponent(device.ServerIP, t_model);
                    }
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("设备诊断模型保存", ex));
                }
                finally
                {
                    Status = ViewModelStatus.None;
                }
            }
        }

        private void SaveToFile(object para)
        {
            DeviceTreeItemViewModel device = para as DeviceTreeItemViewModel;
            if (device != null && device.DeviceDiagnoseComponent != null)
            {
                string json = JsonConvert.SerializeObject(device.DeviceDiagnoseComponent);
                using (StreamWriter sw = new StreamWriter("设备" + device.Name.Replace(@"\","").Replace(@"/", "") + "诊断模型文件" + DateTime.Now.ToString("yyyy-MM-dd") + ".json", false))
                {
                    sw.Write(json);
                    sw.Close();
                    string dir = System.AppDomain.CurrentDomain.BaseDirectory;
                    System.Diagnostics.Process.Start("explorer.exe", Path.GetFullPath(dir));
                }
            }
        }

        private async void Load(object para)
        {
            DeviceTreeItemViewModel device = para as DeviceTreeItemViewModel;
            if (device != null && device.DeviceDiagnoseComponent != null)
            {
                try
                {
                    WaitInfo = "模板加载中";
                    Status = ViewModelStatus.Querying;
                    await _deviceDiagnoseTemplateService.GetClasses(device.ServerIP);
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("设备诊断模板加载", ex));
                }
                finally
                {
                    Status = ViewModelStatus.None;
                }
            }
        }

        private void SelectedDeviceChanged(object para)
        {
            DeviceDiagnoseClass deviceclass = para as DeviceDiagnoseClass;
            if (deviceclass != null && SelectedDeviceTreeItemViewModel != null)
            {
                SelectedDeviceTreeItemViewModel.IntiDeviceDiagnoseComponent(deviceclass);
            }
        }
        #endregion

        #region 拖拽
        private void MouseDown(object para)
        {

        }

        private void MouseMove(object para)
        {
            ListBox sender = ((ExCommandParameter)para).Sender as ListBox;
            MouseEventArgs e = ((ExCommandParameter)para).EventArgs as MouseEventArgs;
            object parameter = ((ExCommandParameter)para).Parameter as object;
           

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //ListBox list = sender as ListBox;
                //ShaftComponent sourceShaft = parameter as ShaftComponent;
                //if (sourceShaft != null)
                //{
                //    DragDropEffects finalDropEffect = DragDrop.DoDragDrop(list, sourceShaft, DragDropEffects.Move);
                //    if (finalDropEffect == DragDropEffects.Move)
                //    {

                //    }
                object item = GetlistBoxItem(sender, e);
                if (item is ShaftComponent)
                {
                    var sourceShaft = item as ShaftComponent;
                    if (sourceShaft != null)
                    {
                        DragDropEffects finalDropEffect = DragDrop.DoDragDrop(sender, sourceShaft, DragDropEffects.Move);
                        if (finalDropEffect == DragDropEffects.Move)
                        {
                            return;
                        }
                    }
                }
                else if (item is IMachComponent)
                {
                    var sourceComponent = item as IMachComponent;
                    if (sourceComponent != null)
                    {
                        DragDropEffects finalDropEffect = DragDrop.DoDragDrop(sender, sourceComponent, DragDropEffects.Move);
                        if (finalDropEffect == DragDropEffects.Move)
                        {
                            return;
                        }
                    }
                }
                else if (item is ItemInfo)
                {
                    var sourceItem = item as ItemInfo;
                    if (sourceItem != null)
                    {
                        DragDropEffects finalDropEffect = DragDrop.DoDragDrop(sender, sourceItem, DragDropEffects.Move);
                        if (finalDropEffect == DragDropEffects.Move)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void DragEnter(object para)
        {
            ;
        }

        private void DragOver(object para)
        {
            ListBox sender = ((ExCommandParameter)para).Sender as ListBox;
            DragEventArgs e = ((ExCommandParameter)para).EventArgs as DragEventArgs;
            object parameter = ((ExCommandParameter)para).Parameter as object;
            //if (!e.Data.GetDataPresent(typeof(ShaftComponent)) && parameter is ShaftComponent)
            //{
            //    e.Effects = DragDropEffects.None;//放置目标不接受该数据
            //    e.Handled = true;
            //}
            //if (!e.Data.GetDataPresent(typeof(IMachComponent)) && parameter is IMachComponent)
            //{
            //    e.Effects = DragDropEffects.None;//放置目标不接受该数据
            //    e.Handled = true;
            //}
            object item = GetlistBoxItem(sender, e);
            if (item is ShaftComponent)
            {
                if (!e.Data.GetDataPresent(typeof(ShaftComponent)) && !e.Data.GetDataPresent(typeof(ItemInfo)))
                {
                    e.Effects = DragDropEffects.None;//放置目标不接受该数据
                    e.Handled = true;
                }
            }
            else if (item is IMachComponent)
            {
                if (e.Data.GetDataPresent(typeof(ItemInfo)))
                {
                }
                else
                {
                    if (!e.Data.GetDataPresent(typeof(BearingComponent))
                        && !e.Data.GetDataPresent(typeof(BeltComponent))
                        && !e.Data.GetDataPresent(typeof(GearComponent))
                        && !e.Data.GetDataPresent(typeof(ImpellerComponent))
                        && !e.Data.GetDataPresent(typeof(MotorComponent)))
                    {
                        e.Effects = DragDropEffects.None;//放置目标不接受该数据
                        e.Handled = true;
                    }
                    var targetComponent = item as IMachComponent;
                    if (SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft != null && !SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.Contains(targetComponent))
                    {
                        e.Effects = DragDropEffects.None;//放置目标不接受该数据
                        e.Handled = true;
                    }
                }
            }
            else if (item is ItemInfo)
            {
                if (!e.Data.GetDataPresent(typeof(ItemInfo)))
                {
                    e.Effects = DragDropEffects.None;//放置目标不接受该数据
                    e.Handled = true;
                }
            }
        }

        private void DragLeave(object para)
        {
           
        }

        private void Drop(object para)
        {
            ListBox sender = ((ExCommandParameter)para).Sender as ListBox;
            DragEventArgs e = ((ExCommandParameter)para).EventArgs as DragEventArgs;
            object parameter = ((ExCommandParameter)para).Parameter as object;
            object item = GetlistBoxItem(sender, e);
            if (item is ShaftComponent)
            {
                var targetShaft = item as ShaftComponent;
                //查找元数据
                var sourceShaft = e.Data.GetData(typeof(ShaftComponent)) as ShaftComponent; //ShaftComponent sourceShaft = parameter as ShaftComponent;
                if (sourceShaft != null)
                {
                    if (ReferenceEquals(targetShaft, sourceShaft))
                    {
                        return;
                    }
                    if (sourceShaft != null && targetShaft != null)
                    {
                        int index = SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.Shafts.IndexOf(targetShaft);
                        SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.Shafts.Remove(sourceShaft);
                        SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.Shafts.Insert(index, sourceShaft);
                    }
                    return;
                }
                //查找元数据,从unallot -> allot或allot -> allot
                var sourceItem = e.Data.GetData(typeof(ItemInfo)) as ItemInfo;
                if (sourceItem != null)
                {
                    if (sourceItem != null && targetShaft != null)
                    {
                        //从unallot->allot
                        if (SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.Contains(sourceItem))
                        {
                            targetShaft.Component.AllotItems.Add(sourceItem);
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.Remove(sourceItem);
                        }
                        else//allot -> allot
                        {
                            targetShaft.Component.AllotItems.Add(sourceItem);
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.AllotItems.Remove(sourceItem);
                        }   
                    }
                    return;
                }
            }
            else if (item is IMachComponent)
            {
                var targetComponent = item as IMachComponent;
                //查找元数据
                IMachComponent sourceComponent = GetComponentItem(e);
                if (sourceComponent != null)
                {
                    if (sourceComponent != null && targetComponent != null)
                    {
                        //自身交换
                        if (SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.Contains(targetComponent))
                        {
                            int index = SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.IndexOf(targetComponent);
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.Remove(sourceComponent);
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.MachComponents.Insert(index, sourceComponent);
                        }
                    }
                    return;
                }
            }
            else if (item is ItemInfo)
            {
                var targetItem = item as ItemInfo;
                //查找元数据
                var sourceItem = e.Data.GetData(typeof(ItemInfo)) as ItemInfo;
                if (sourceItem != null)
                {
                    if (ReferenceEquals(targetItem, sourceItem))
                    {
                        return;
                    }
                    if (sourceItem != null && targetItem != null)
                    {
                        var sourceItemList = GetItemList(sourceItem);
                        var targetItemList = GetItemList(targetItem);
                        if (sourceItemList != null && targetItemList != null)
                        {
                            if (sourceItemList == targetItemList)
                            {
                                int index = targetItemList.IndexOf(targetItem);
                                sourceItemList.Remove(sourceItem);
                                targetItemList.Insert(index, sourceItem);
                            }
                            else
                            {
                                sourceItemList.Remove(sourceItem);
                                targetItemList.Add(sourceItem);
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                //从allot->unallot
                var arr1 = sender.Items.OfType<ItemInfo>().ToArray();
                var arr2 = SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.ToArray();
                var q = from a in arr1 join b in arr2 on a equals b select a;
                bool flag = arr1.Length == arr2.Length && q.Count() == arr1.Length;
                if (flag == true)
                {
                    var sourceItem = e.Data.GetData(typeof(ItemInfo)) as ItemInfo;
                    if (sourceItem != null)
                    {
                        if (!SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.Contains(sourceItem))
                        {
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.SelectedShaft.Component.AllotItems.Remove(sourceItem);
                            SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.Add(sourceItem);
                        }                                            
                        return;
                    }
                }
            }
        }

        private IList<ItemInfo> GetItemList(ItemInfo item)
        {
            if (SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems.Contains(item))
            {
                return SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.UnAllotItems;
            }
            else
            {
                foreach (var shaft in SelectedDeviceTreeItemViewModel.DeviceDiagnoseComponent.Component.Shafts)
                {
                    if (shaft.Component.AllotItems.Contains(item))
                    {
                        return shaft.Component.AllotItems;
                    }
                }
            }
            return null;
        }

        private object GetlistBoxItem(ListBox sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(sender);
            var result = VisualTreeHelper.HitTest(sender, pos);
            if (result == null)
            {
                return null;
            }
            //查找目标数据  
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null)
            {
                return null;
            }
            return listBoxItem.Content;
        }

        private object GetlistBoxItem(ListBox sender, DragEventArgs e)
        {
            var pos = e.GetPosition(sender);
            var result = VisualTreeHelper.HitTest(sender, pos);
            if (result == null)
            {
                return null;
            }
            //查找目标数据  
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null)
            {
                return null;
            }
            return listBoxItem.Content;
        }

        private IMachComponent GetComponentItem(DragEventArgs e)
        {
            IMachComponent sourceComponent = null;
            if (sourceComponent == null)
            {
                sourceComponent = e.Data.GetData(typeof(BearingComponent)) as IMachComponent; //ShaftComponent sourceShaft = parameter as ShaftComponent;
            }
            if (sourceComponent == null)
            {
                sourceComponent = e.Data.GetData(typeof(BeltComponent)) as IMachComponent;
            }
            if (sourceComponent == null)
            {
                sourceComponent = e.Data.GetData(typeof(GearComponent)) as IMachComponent;
            }
            if (sourceComponent == null)
            {
                sourceComponent = e.Data.GetData(typeof(ImpellerComponent)) as IMachComponent;
            }
            if (sourceComponent == null)
            {
                sourceComponent = e.Data.GetData(typeof(MotorComponent)) as IMachComponent;
            }
            return sourceComponent;
        }

        internal static class Utils
        {
            //根据子元素查找父元素  
            public static T FindVisualParent<T>(DependencyObject obj) where T : class
            {
                while (obj != null)
                {
                    if (obj is T)
                        return obj as T;

                    obj = VisualTreeHelper.GetParent(obj);
                }
                return null;
            }
        }
        #endregion
    }
}