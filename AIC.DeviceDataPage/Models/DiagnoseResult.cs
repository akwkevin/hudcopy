﻿using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.DeviceDataPage.Models
{
    public class DiagnoseResult : BindableBase
    {
        private ObservableCollection<DiagnoseFault> descriptionCollection = new ObservableCollection<DiagnoseFault>();
        private string error;
        private string warning;
        private string result;

        public IEnumerable<DiagnoseFault> description { get { return descriptionCollection; } }
        public string Error
        {
            get { return error; }
            set { this.SetProperty(ref error, value); }
        }
        public string Warning
        {
            get { return warning; }
            set { this.SetProperty(ref warning, value); }
        }

        public string DescriptionString
        {
            get
            {
                return string.Join("" , descriptionCollection.Select(p => p.Result));
            }
        }

        [JsonIgnore]
        public string Result
        {
            get { return result; }
            set { this.SetProperty(ref result, value); }
        }
    }

    public class DiagnoseFault : BindableBase
    {
        private int code;
        private string fault;
        private string harm;
        private string proposal;

        public int Code
        {
            get { return code; }
            set { this.SetProperty(ref code, value); }
        }
        public string Fault
        {
            get { return fault; }
            set { this.SetProperty(ref fault, value); }
        }
        public string Harm
        {
            get { return harm; }
            set { this.SetProperty(ref harm, value); }
        }
        public string Proposal
        {
            get { return proposal; }
            set { this.SetProperty(ref proposal, value); }
        }

        public string Result
        {
            get { return Code.ToString() + Fault + Harm + Proposal; }
        }
    }
}