﻿using AIC.Core.Helpers;
using AIC.Core.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Core.DiagnosticBaseModels
{
    public partial class DeviceDiagnoseClass : IDataErrorInfo
    {
        class DeviceDiagnoseClassMetadata
        {
            [StringNullValidation]
            public string Name { get; set; }
        }

        [JsonIgnore]
        public string Error
        {
            get
            {
                string error = null;
                PropertyInfo[] propertys = this.GetType().GetProperties();
                foreach (PropertyInfo pinfo in propertys)
                {
                    //循环遍历属性
                    if (pinfo.CanRead && pinfo.CanWrite)
                    {
                        error = this.ValidateProperty<DeviceDiagnoseClassMetadata>(pinfo.Name);
                        if (error != null && error.Length > 0)
                        {
                            break;
                        }
                    }
                }
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return this.ValidateProperty<DeviceDiagnoseClassMetadata>(columnName);
            }
        }
    }
}