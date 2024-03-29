﻿using AIC.HistoryDataPage.ViewModels;
using AIC.CoreType;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Arction.Wpf.Charting;
using Arction.Wpf.Charting.Axes;
using Arction.Wpf.Charting.SeriesXY;
using Arction.Wpf.Charting.Annotations;
using Arction.Wpf.Charting.Views.ViewXY;
using AIC.Core.Events;
using AIC.MatlabMath;
using AIC.HistoryDataPage.Models;
using AIC.Core;

namespace AIC.HistoryDataPage.Views
{
    /// <summary>
    /// Interaction logic for FrequencyDomainDataView.xaml
    /// </summary>
    public partial class FrequencyDomainDataView : DisposableUserControl
    {
        private LightningChartUltimate m_chart;
        private IDisposable channelDataChangedSubscription;
        private IDisposable channelAddedSubscription;
        private IDisposable channelRemovedSubscription;
        public FrequencyDomainDataView()
        {
            InitializeComponent();
            CreateChart();
            Loaded += FrequencyDomainDataView_Loaded;
        }

        private FrequencyDomainDataViewModel ViewModel
        {
            get { return DataContext as FrequencyDomainDataViewModel; }
            set { this.DataContext = value; }
        }

        protected void ViewModel_Closed(object sender, EventArgs e)
        {
            // Don't forget to clear chart grid child list.
            gridChart.Children.Clear();
            if (m_chart != null)
            {
                m_chart.Dispose();
                m_chart = null;
            }
            base.Dispose();
            base.GCCollect();
        }

        private void FrequencyDomainDataView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= FrequencyDomainDataView_Loaded;
            ViewModel = DataContext as FrequencyDomainDataViewModel;
            if (ViewModel != null)
            {
                channelAddedSubscription = ViewModel.WhenChannelAdded.Subscribe(OnChannelAdded);
                channelRemovedSubscription = ViewModel.WhenChannelRemoved.Subscribe(OnChannelRemoved);
                channelDataChangedSubscription = ViewModel.WhenChannelDataChanged.Subscribe(OnChannelDataChanged);
                ViewModel.Closed += ViewModel_Closed;
            }
        }

        private void OnChannelAdded(ChannelToken token)
        {
            try
            {
                var samecount = m_chart.ViewXY.PointLineSeries.Where(o => o.Tag == token).Count();
                if (samecount  >= 2)//每次添加两个相同Tag
                {
                    return;
                }

                if (ViewModel == null || !(token is BaseWaveChannelToken)) return;

                m_chart.BeginUpdate();

                var axisYnone = m_chart.ViewXY.YAxes.Where(o => o.Units.Text == "none").SingleOrDefault();
                m_chart.ViewXY.YAxes.Remove(axisYnone);

                BaseWaveChannelToken vToken = token as BaseWaveChannelToken;
                //Create new Y axis for each series 
                AxisY axisY = new AxisY(m_chart.ViewXY);
                axisY.Tag = vToken;
                axisY.Title.Visible = false;
                axisY.AxisThickness = 2;
                axisY.AxisColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);//Color.FromArgb(100, 135, 205, 238);
                m_chart.ViewXY.YAxes.Add(axisY);
                //Create a point-line series
                int count = m_chart.ViewXY.PointLineSeries.Count / 2;
                while (count > 15)
                {
                    count -= 15;
                }
                //Color color = DefaultColors.SeriesForBlackBackgroundWpf[count];
                PointLineSeries series = new PointLineSeries(m_chart.ViewXY, m_chart.ViewXY.XAxes[0], axisY);
                series.MouseInteraction = false;
                series.LineStyle.Color = vToken.SolidColorBrush.Color; //color;
                series.LineStyle.AntiAliasing = LineAntialias.None;
                series.LineStyle.Width = 1;
                series.Tag = vToken;
                series.Title.Text = vToken.DisplayName;//htzk123
                series.Title.Font = new WpfFont(System.Drawing.FontFamily.GenericSansSerif, 10f, System.Drawing.FontStyle.Bold);
                series.Title.Color = ChartTools.CalcGradient(Colors.White, Colors.White, 50);
                series.Title.HorizontalAlign = AlignmentHorizontal.Left;
                series.Title.VerticalAlign = AlignmentVertical.Top;
                series.Title.MoveByMouse = false;
                series.Title.MouseInteraction = false;
                series.Title.Offset = new PointIntXY(5, 5);
                series.Title.Visible = false;

                AxisY axisYPhase = new AxisY(m_chart.ViewXY);
                axisYPhase.Tag = vToken;
                axisYPhase.Title.Visible = false;
                axisYPhase.AxisThickness = 2;
                axisYPhase.AxisColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);//Color.FromArgb(100, 135, 205, 238);
                m_chart.ViewXY.YAxes.Add(axisYPhase);
                PointLineSeries phaseSeries = new PointLineSeries(m_chart.ViewXY, m_chart.ViewXY.XAxes[0], axisYPhase);
                phaseSeries.MouseInteraction = false;
                phaseSeries.LineStyle.Color = vToken.SolidColorBrush.Color; //color;
                phaseSeries.LineStyle.AntiAliasing = LineAntialias.None;
                phaseSeries.LineStyle.Width = 1;
                phaseSeries.Tag = vToken;
                phaseSeries.Title.Text = vToken.DisplayName + "相位";//htzk123
                phaseSeries.Visible = false;

                if (m_chart.ViewXY.Annotations.Count == 0)
                {
                    CreateCalloutAnnotation();
                    CreateFAAnnotation();
                }

                //Update Annotation
                AnnotationXY annotation = m_chart.ViewXY.Annotations[1];
                string[] branches = annotation.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < branches.Length; i++)
                {
                    sb.AppendLine(branches[i]);
                }
                string freText = "F";
                string ampText = "A";
                if (vToken.VData != null && vToken.VData.FFTLength != 0 && vToken.VData.Frequency != null && vToken.VData.Amplitude != null && vToken.VData.Phase != null)
                {
                    int length = vToken.VData.FFTLength;
                    SeriesPoint[] points = new SeriesPoint[length];
                    SeriesPoint[] phasePoints = new SeriesPoint[length];
                    for (int i = 0; i < length; i++)
                    {
                        points[i] = new SeriesPoint(vToken.VData.Frequency[i], vToken.VData.Amplitude[i]);
                        phasePoints[i] = new SeriesPoint(vToken.VData.Frequency[i], vToken.VData.Phase[i]);
                    }
                    series.Points = points;
                    phaseSeries.Points = phasePoints;

                    var fftValuesDict = vToken.VData.Amplitude.Select((s, i) => new { Key = i, Value = s }).OrderByDescending(o => o.Value).Take(6);
                    foreach (var item in fftValuesDict)
                    {
                        freText += string.Format("{0,6}|", vToken.VData.Frequency[item.Key].ToString("0.00"));
                        ampText += string.Format("{0,6}|", item.Value.ToString("0.00"));
                    }
                }
                sb.AppendLine(freText);
                sb.AppendLine(ampText);
                annotation.Text = sb.ToString();
                m_chart.ViewXY.PointLineSeries.Add(series);
                m_chart.ViewXY.PointLineSeries.Add(phaseSeries);

                m_chart.ViewXY.AxisLayout.Segments.Add(new YAxisSegment(m_chart.ViewXY.AxisLayout));
                axisY.SegmentIndex = m_chart.ViewXY.AxisLayout.Segments.Count - 1;
                axisYPhase.SegmentIndex = m_chart.ViewXY.AxisLayout.Segments.Count - 1;

                m_chart.ViewXY.Annotations[0].AssignYAxisIndex = -1;
                m_chart.ViewXY.Annotations[0].AssignYAxisIndex = 0;

                m_chart.ViewXY.ZoomToFit();
                m_chart.EndUpdate();
            }
            catch (Exception ex)
            {
                EventAggregatorService.Instance.EventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("数据回放-频域-添加通道", ex));
            }
        }
        private void OnChannelRemoved(ChannelToken token)
        {
            try
            {
                m_chart.BeginUpdate();
                var serieses = m_chart.ViewXY.PointLineSeries.Where(o => o.Tag == token).ToArray();
                if (serieses.Length > 0)
                {
                    foreach (var series in serieses)
                    {
                        series.Clear();
                        m_chart.ViewXY.PointLineSeries.Remove(series);
                    }

                    var yAxises = m_chart.ViewXY.YAxes.Where(o => o.Tag == token).ToArray();
                    int firstIndex = m_chart.ViewXY.YAxes.IndexOf(yAxises.First());
                    m_chart.ViewXY.AxisLayout.Segments.RemoveAt(yAxises[0].SegmentIndex);
                    foreach (var axis in yAxises)
                    {
                        m_chart.ViewXY.YAxes.Remove(axis);
                    }
                    if (m_chart.ViewXY.YAxes.Count > firstIndex)
                    {
                        for (int i = firstIndex / 2; i < m_chart.ViewXY.AxisLayout.Segments.Count; i++)
                        {
                            m_chart.ViewXY.YAxes[i * 2].SegmentIndex = i;
                            m_chart.ViewXY.YAxes[i * 2 + 1].SegmentIndex = i;
                        }
                    }
                    AnnotationXY annotation = m_chart.ViewXY.Annotations[1];
                    var branches = annotation.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    branches.RemoveRange(firstIndex, 2);
                    StringBuilder sb = new StringBuilder();
                    foreach (var branch in branches)
                    {
                        sb.AppendLine(branch);
                    }
                    annotation.Text = sb.ToString();

                    if (m_chart.ViewXY.YAxes.Count > 0)
                    {
                        m_chart.ViewXY.Annotations[0].AssignYAxisIndex = -1;
                        m_chart.ViewXY.Annotations[0].AssignYAxisIndex = 0;
                    }
                    else
                    {
                        m_chart.ViewXY.Annotations.Clear();

                        AxisY axisYnone = new AxisY(m_chart.ViewXY);
                        axisYnone.Title.Font = new WpfFont(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Regular);
                        axisYnone.AxisThickness = 2;
                        axisYnone.AxisColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);//Color.FromArgb(100, 135, 205, 238);
                        axisYnone.Units.Text = "none";
                        m_chart.ViewXY.YAxes.Add(axisYnone);
                    }
                }
                m_chart.EndUpdate();
            }
            catch (Exception ex)
            {
                EventAggregatorService.Instance.EventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("数据回放-频域-删除通道", ex));
            }
        }
        private async void OnChannelDataChanged(IEnumerable<BaseWaveChannelToken> tokens)
        {
            try
            {
                if (ViewModel == null) return;
                foreach (var token in tokens)//修复隐藏时候没有添加成功
                {
                    OnChannelAdded(token);
                }
                if (m_chart.ViewXY.PointLineSeries.Count == 0)
                {
                    return;
                }
                await FFTAndPhase(tokens);
                UpdateChartAsync(tokens);              
            }
            catch (Exception ex)
            {
                EventAggregatorService.Instance.EventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("数据回放-频域-更新通道数据", ex));
            }
        }
        private void CreateChart()
        {
            gridChart.Children.Clear();
            if (m_chart != null)
            {
                m_chart.Dispose();
                m_chart = null;
            }

            m_chart = new LightningChartUltimate();
            m_chart.BeginUpdate();
            m_chart.Title.Text = "";
            m_chart.ViewXY.AxisLayout.YAxesLayout = YAxesLayout.Segmented;
            m_chart.ViewXY.AxisLayout.YAxisAutoPlacement = YAxisAutoPlacement.LeftThenRight;
           // m_chart.ViewXY.AxisLayout.AutoAdjustAxisGap = 0;        

            m_chart.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            m_chart.ChartBackground.Color = Color.FromArgb(0, 0, 0, 0);
            m_chart.ChartBackground.GradientFill = GradientFill.Solid;
            m_chart.ViewXY.GraphBackground.Color = Color.FromArgb(0, 0, 0, 0);
            m_chart.ViewXY.GraphBackground.GradientFill = GradientFill.Solid;
            m_chart.ViewXY.GraphBorderColor = Color.FromArgb(0, 0, 0, 0);

            m_chart.ViewXY.XAxes[0].ValueType = AxisValueType.Number;
            m_chart.ViewXY.XAxes[0].Minimum = 0;
            m_chart.ViewXY.XAxes[0].Maximum = 1000;
            m_chart.ViewXY.XAxes[0].Title.Visible = false;
            m_chart.ViewXY.XAxes[0].MinorGrid.Visible = false;
            m_chart.ViewXY.XAxes[0].AxisThickness = 2;
            m_chart.ViewXY.XAxes[0].AxisColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);//Color.FromArgb(100, 135, 205, 238);
            m_chart.ViewXY.XAxes[0].MinorGrid.Visible = false;
            m_chart.ViewXY.XAxes[0].LabelsFont = new WpfFont(System.Drawing.FontFamily.GenericSansSerif, 9, System.Drawing.FontStyle.Regular);

            m_chart.ViewXY.YAxes.Clear();
            AxisY axisYnone = new AxisY(m_chart.ViewXY);
            axisYnone.Title.Font = new WpfFont(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Regular);
            axisYnone.AxisThickness = 2;
            axisYnone.AxisColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);//Color.FromArgb(100, 135, 205, 238);
            axisYnone.Units.Text = "none";
            m_chart.ViewXY.YAxes.Add(axisYnone);
            m_chart.ViewXY.AxisLayout.Segments.Clear();

            m_chart.ViewXY.LegendBoxes[0].Visible = true;
            m_chart.ViewXY.LegendBoxes[0].Layout = LegendBoxLayout.VerticalColumnSpan;
            m_chart.ViewXY.LegendBoxes[0].Fill.Style = RectFillStyle.None;
            m_chart.ViewXY.LegendBoxes[0].Shadow.Visible = false;
            m_chart.ViewXY.LegendBoxes[0].BorderWidth = 0;
            m_chart.ViewXY.LegendBoxes[0].Position = LegendBoxPositionXY.TopRight;
            m_chart.ViewXY.LegendBoxes[0].Offset.SetValues(-80, 10);
            m_chart.ViewXY.LegendBoxes[0].SeriesTitleFont = new WpfFont(System.Drawing.FontFamily.GenericSansSerif, 9, System.Drawing.FontStyle.Regular);
            //Add cursor
            LineSeriesCursor cursor = new LineSeriesCursor(m_chart.ViewXY, m_chart.ViewXY.XAxes[0]);
            m_chart.ViewXY.LineSeriesCursors.Add(cursor);
            cursor.PositionChanged += cursor_PositionChanged;
            cursor.LineStyle.Color = System.Windows.Media.Color.FromArgb(150, 255, 0, 0);
            cursor.LineStyle.Width = 2;
            cursor.SnapToPoints = true;
            cursor.TrackPoint.Color1 = Colors.White;
            m_chart.ViewXY.ZoomToFit();
            m_chart.EndUpdate();

            gridChart.Children.Add(m_chart);

            showCheckBox.Checked += showCheckBox_Checked;
            showCheckBox.Unchecked += showCheckBox_Checked;
        }
        private void CreateCalloutAnnotation()
        {
            AnnotationXY cursorValueDisplay = new AnnotationXY(m_chart.ViewXY, m_chart.ViewXY.XAxes[0], m_chart.ViewXY.YAxes[0]);
            cursorValueDisplay.Style = AnnotationStyle.Callout;
            cursorValueDisplay.LocationCoordinateSystem = CoordinateSystem.RelativeCoordinatesToTarget;
            cursorValueDisplay.LocationRelativeOffset = new PointFloatXY(80, -50);
            cursorValueDisplay.Sizing = AnnotationXYSizing.Automatic;
            cursorValueDisplay.TextStyle.Font = new WpfFont(System.Drawing.FontFamily.GenericMonospace, 9.5, System.Drawing.FontStyle.Regular);
            cursorValueDisplay.TextStyle.Color = Colors.White;
            cursorValueDisplay.Fill.Color = Color.FromArgb(128, 0, 0, 0);
            cursorValueDisplay.BorderLineStyle.Color = Color.FromArgb(64, 255, 255, 255);
            cursorValueDisplay.BorderLineStyle.Width = 1;
            cursorValueDisplay.Fill.GradientFill = GradientFill.Solid;
            cursorValueDisplay.TargetMoveByMouse = false;
            cursorValueDisplay.AnchorAdjustByMouse = false;
            cursorValueDisplay.ResizeByMouse = false;
            cursorValueDisplay.RotateByMouse = false;
            cursorValueDisplay.Shadow.Visible = false;
            cursorValueDisplay.AutoSizePadding = 5;
            cursorValueDisplay.Text = "";
            cursorValueDisplay.ClipInsideGraph = false;
            m_chart.ViewXY.Annotations.Add(cursorValueDisplay);
        }
        private void CreateFAAnnotation()
        {
            AnnotationXY cursorValueDisplay = new AnnotationXY(m_chart.ViewXY, m_chart.ViewXY.XAxes[0], m_chart.ViewXY.YAxes[0]);
            cursorValueDisplay.Style = AnnotationStyle.Rectangle;
            cursorValueDisplay.LocationCoordinateSystem = CoordinateSystem.ScreenCoordinates;
            cursorValueDisplay.LocationScreenCoords = new PointFloatXY(500, 37);
            cursorValueDisplay.Sizing = AnnotationXYSizing.Automatic;
            cursorValueDisplay.TextStyle.Font = new WpfFont(System.Drawing.FontFamily.GenericMonospace, 9.5, System.Drawing.FontStyle.Regular);
            cursorValueDisplay.TextStyle.Color = Colors.White;
            cursorValueDisplay.Fill.Color = Color.FromArgb(128, 0, 0, 0);
            cursorValueDisplay.BorderLineStyle.Color = Color.FromArgb(64, 255, 255, 255);
            cursorValueDisplay.BorderLineStyle.Width = 1;
            cursorValueDisplay.Fill.GradientFill = GradientFill.Solid;
            cursorValueDisplay.TargetMoveByMouse = false;
            cursorValueDisplay.AnchorAdjustByMouse = false;
            cursorValueDisplay.ResizeByMouse = false;
            cursorValueDisplay.RotateByMouse = false;
            cursorValueDisplay.Shadow.Visible = false;
            cursorValueDisplay.AutoSizePadding = 5;
            cursorValueDisplay.Text = "";
            cursorValueDisplay.ClipInsideGraph = false;
            m_chart.ViewXY.Annotations.Add(cursorValueDisplay);
            Binding b = new Binding();
            b.Source = DataContext as FrequencyDomainDataViewModel;
            b.Path = new PropertyPath("ShowDetail");
            b.Mode = BindingMode.TwoWay;
            //BindingOperations.SetBinding(cursorValueDisplay, AnnotationXY.VisibleProperty, b); htzk123
        }
        private void cursor_PositionChanged(Object sender, PositionChangedEventArgs e)
        {
            e.CancelRendering = true;
            UpdateCursorResult(e.Cursor.ValueAtXAxis);
        }
        private void UpdateCursorResult(double xValue)
        {
            m_chart.BeginUpdate();
           
            AnnotationXY cursorValueDisplay = m_chart.ViewXY.Annotations[0];
            float fTargetYCoord = m_chart.ViewXY.GetMarginsRect().Bottom;
            double dY;
            m_chart.ViewXY.YAxes[0].CoordToValue(fTargetYCoord, out dY);
            cursorValueDisplay.TargetAxisValues.X = xValue;
            cursorValueDisplay.TargetAxisValues.Y = dY;

            StringBuilder sb = new StringBuilder();
            int iSeriesNumber = 1;

            string strValue = "";
            bool bLabelVisible = false;

            int segmentCount = m_chart.ViewXY.AxisLayout.Segments.Count;
            for (int i = 0; i < segmentCount; i++)
            {
                var series = m_chart.ViewXY.PointLineSeries[i*2];
                var phaseSeries = m_chart.ViewXY.PointLineSeries[i * 2 + 1];
                strValue = iSeriesNumber + ":";
                BaseWaveChannelToken token = series.Tag as BaseWaveChannelToken;
                if (token.VData != null)
                {
                    bool bResolvedOK = false;
                    double yValue = 0;
                    bResolvedOK = SolveValueAccurate(series, xValue, out yValue);
                    if (bResolvedOK)
                    {
                        bLabelVisible = true;
                        //strValue = string.Format(strChannelStringFormat, iSeriesNumber, Math.Round(yValue, 2), unit);
                        strValue += Math.Round(yValue, 2) + "(" + token.VData.Unit + ")";
                    }
                    else
                    {
                        //strValue = string.Format(strChannelStringFormat, iSeriesNumber, "---", "Unit");
                        strValue += "---" + "(Unit)";
                    }
                }

                if (phaseSeries.Visible)
                {
                    BaseWaveChannelToken phaseToken = phaseSeries.Tag as BaseWaveChannelToken;
                    if (phaseToken.VData != null)
                    {
                        bool bResolvedOK = false;
                        double yValue = 0;
                        bResolvedOK = SolveValueAccurate(phaseSeries, xValue, out yValue);
                        if (bResolvedOK)
                        {
                            bLabelVisible = true;
                            strValue += "|" + Math.Round(yValue, 2);
                        }
                        else
                        {
                            //strValue = string.Format(strChannelStringFormat, iSeriesNumber, "---", "Unit");
                            strValue += "|---";
                        }
                    }
                }

                sb.AppendLine(strValue);
                iSeriesNumber++;
            }

            sb.AppendLine("频率: " + xValue.ToString("0.00") + "Hz");
            //Set text
            cursorValueDisplay.Text = sb.ToString().Trim();
            cursorValueDisplay.Visible = bLabelVisible;

            //Allow chart rendering
            m_chart.EndUpdate();
        }
        private bool SolveValueAccurate(PointLineSeries series, double xValue, out double yValue)
        {
            yValue = 0;
            LineSeriesValueSolveResult lssvs = series.SolveYValueAtXValue(xValue);
            if (lssvs.SolveStatus == LineSeriesSolveStatus.OK)
            {
                //PointLineSeries may have two or more points at same X value. If so, center it between min and max 
                yValue = (lssvs.YMax + lssvs.YMin) / 2.0;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MovePrevious_Click(object sender, RoutedEventArgs e)
        {
            //m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis -= 1;
            //20170407add by htzk123
            if (m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis <= m_chart.ViewXY.XAxes[0].Minimum)
            {
                m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis = m_chart.ViewXY.XAxes[0].Maximum;
            }

            double nowValue = m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis;
            double nextValue = m_chart.ViewXY.XAxes[0].Minimum;
            for (int i = 0; i < m_chart.ViewXY.PointLineSeries.Count; i++)
            {
                double? tempValue = (from g in m_chart.ViewXY.PointLineSeries[i].Points where g.X < nowValue select g.X).LastOrDefault();
                double valid = tempValue ?? m_chart.ViewXY.XAxes[0].Minimum;

                nextValue = Math.Max(nextValue, valid);
            }

            m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis = nextValue;
        }

        private void MoveNext_Click(object sender, RoutedEventArgs e)
        {
            //m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis += 1;
            if (m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis >= m_chart.ViewXY.XAxes[0].Maximum)
            {
                m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis = m_chart.ViewXY.XAxes[0].Minimum;
            }

            double nowValue = m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis;
            double nextValue = m_chart.ViewXY.XAxes[0].Maximum;
            for (int i = 0; i < m_chart.ViewXY.PointLineSeries.Count; i++)
            {
                double? tempValue = (from g in m_chart.ViewXY.PointLineSeries[i].Points where g.X > nowValue select g.X).FirstOrDefault();
                double valid = tempValue ?? m_chart.ViewXY.XAxes[0].Maximum;

                nextValue = Math.Min(nextValue, valid);
            }

            m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis = nextValue;
        }

        private void ScreenshotButton_Click(object sender, RoutedEventArgs e)
        {
            m_chart.CopyToClipboard(ClipboardImageFormat.Jpg);
        }

        private bool isRender;
        private async void filterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((CheckBox)sender).Name == "envelopeCheckBox")
                {
                    isRender = false;
                    tffCheckBox.IsChecked = false;
                    cepstrumCheckBox.IsChecked = false;
                }
                else if (((CheckBox)sender).Name == "tffCheckBox")
                {
                    isRender = false;
                    envelopeCheckBox.IsChecked = false;
                    cepstrumCheckBox.IsChecked = false;
                }
                else if (((CheckBox)sender).Name == "cepstrumCheckBox")
                {
                    isRender = false;
                    envelopeCheckBox.IsChecked = false;
                    tffCheckBox.IsChecked = false;
                }
                if (ViewModel == null) return;
                if (m_chart.ViewXY.PointLineSeries.Count == 0)
                {
                    return;
                }
                var tokens = m_chart.ViewXY.PointLineSeries.Select(o => o.Tag).OfType<BaseWaveChannelToken>().Distinct();
                await FFTAndPhase(tokens);
                UpdateChartAsync(tokens);
            }
            catch (Exception ex)
            {
                EventAggregatorService.Instance.EventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("数据回放-频域-滤波", ex));
            }
            finally
            {
                isRender = true;
            }
        }
        private async void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ViewModel == null) return;
                if (m_chart.ViewXY.PointLineSeries.Count == 0)
                {
                    return;
                }
                if (isRender)
                {
                    var tokens = m_chart.ViewXY.PointLineSeries.Select(o => o.Tag).OfType<BaseWaveChannelToken>().Distinct().ToArray();
                    await FFTAndPhase(tokens);
                    UpdateChartAsync(tokens);
                }    
            }
            catch (Exception ex)
            {
                EventAggregatorService.Instance.EventAggregator.GetEvent<ThrowExceptionEvent>().Publish(Tuple.Create<string, Exception>("数据回放-频域-滤波", ex));
            }
        }

        private void UpdateChartAsync(IEnumerable<BaseWaveChannelToken> tokens)
        {
            m_chart.BeginUpdate();
            foreach (var token in tokens)
            {
                var series = m_chart.ViewXY.PointLineSeries.Where(o => o.Tag == token).FirstOrDefault();
                var phaseSeries = m_chart.ViewXY.PointLineSeries.Where(o => o.Tag == token).LastOrDefault();
                if (series == null || phaseSeries == null)
                {
                    continue;
                }
                int index = m_chart.ViewXY.PointLineSeries.IndexOf(series);

                AnnotationXY annotation = m_chart.ViewXY.Annotations[1];
                string[] branches = annotation.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (token.VData != null)
                {

                    int length = token.VData.FFTLength;
                    if (series.Points == null || series.Points.Length != length)
                    {
                        series.Points = new SeriesPoint[length];
                    }
                    if (phaseSeries.Points == null || phaseSeries.Points.Length != length)
                    {
                        phaseSeries.Points = new SeriesPoint[length];
                    }

                    for (int i = 0; i < length; i++)
                    {
                        series.Points[i].X = token.VData.Frequency[i];
                        series.Points[i].Y = token.VData.Amplitude[i];
                        phaseSeries.Points[i].X = token.VData.Frequency[i];
                        phaseSeries.Points[i].Y = token.VData.Phase[i];
                    }

                    string freText = "F";// string.Format("{0}-F", index / 2 + 1);
                    string ampText = "A";// string.Format("{0}-A", index / 2 + 1);

                    var fftValuesDict = token.VData.Amplitude.Select((s, i) => new { Key = i, Value = s }).OrderByDescending(o => o.Value).Take(6);
                    foreach (var item in fftValuesDict)
                    {
                        freText += string.Format("{0,6}|", token.VData.Frequency[item.Key].ToString("0.00"));
                        ampText += string.Format("{0,6}|", item.Value.ToString("0.00"));
                    }
                    branches[index] = freText;
                    branches[index + 1] = ampText;
                }
                else
                {
                    series.Clear();
                    phaseSeries.Clear();
                    branches[index] = string.Format("{0}:{1,6}|{2,6}|", index / 2 + 1, " ", " ");
                    branches[index + 1] = string.Format("{0}:{1,6}|{2,6}|", index / 2 + 1, " ", " ");
                }
                series.InvalidateData();
                phaseSeries.InvalidateData();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < branches.Length; i++)
                {
                    sb.AppendLine(branches[i]);
                }
                annotation.Text = sb.ToString().Trim();
            }
            m_chart.ViewXY.ZoomToFit();
            m_chart.EndUpdate();

            m_chart.ViewXY.LineSeriesCursors[0].ValueAtXAxis = (m_chart.ViewXY.XAxes[0].Minimum + m_chart.ViewXY.XAxes[0].Maximum) / 2.0;
        }

        private async Task FFTAndPhase(IEnumerable<BaseWaveChannelToken> tokens)
        {
            List<Task> taskList = new List<Task>();
            foreach (var token in tokens)
            {
                if (token.VData != null)
                {
                    taskList.Add(AlgorithmAsync(token));
                }
            }
            await Task.WhenAll(taskList);
        }

        private async Task AlgorithmAsync(BaseWaveChannelToken token)
        {
            double sampleFre = token.VData.SampleFre;
            if (token.VData.Trigger == TriggerType.Angle)
            {
                sampleFre = token.VData.RPM * token.VData.TeethNumber / 60;
            }
            int samplePoint = token.VData.SamplePoint;
            double rpm = token.VData.RPM;
            var input = token.VData.Waveform;

            if (filterCheckBox.IsChecked == true)
            {
                input = await Task.Run(() => { return ViewModel.Filter(input, samplePoint, sampleFre, rpm); });
            }
            if (envelopeCheckBox.IsChecked == true)
            {
                input = await Task.Run(() => { return Algorithm.Instance.Envelope(input, samplePoint); });
            }
            else if (tffCheckBox.IsChecked == true)
            {
                input = await Task.Run(() => { return Algorithm.Instance.TFF(input, samplePoint, sampleFre); });
            }
            else if (cepstrumCheckBox.IsChecked == true)
            {
                input = await Task.Run(() => { return Algorithm.Instance.Cepstrum(input, samplePoint); });
            }

            var output = Algorithm.Instance.FFT2AndPhaseAction(input, samplePoint);

            double frequencyInterval = sampleFre / samplePoint;
            int length = (int)(samplePoint / 2.56) + 1;
            if (token.VData.Frequency == null || token.VData.Frequency.Length!=length)
            {
                token.VData.Frequency = new double[length];
            }
            for (int i = 0; i < length; i++)
            {
                token.VData.Frequency[i] = frequencyInterval * i;
            }
            token.VData.Amplitude = output[0].Take(length).ToArray();
            token.VData.Phase = output[1].Take(length).ToArray();
        }
        private void showCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (showCheckBox.IsChecked == true)
            {
                m_chart.ViewXY.Annotations[1].Visible = true;
                m_chart.ViewXY.LegendBoxes[0].Visible = true;
            }
            else
            {
                m_chart.ViewXY.Annotations[1].Visible = false;
                m_chart.ViewXY.LegendBoxes[0].Visible = false;
            }
        }
    }
}
