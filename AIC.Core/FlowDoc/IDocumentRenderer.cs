﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AIC.Core.FlowDoc
{
    public interface IDocumentRenderer
    {
        void Render(FlowDocument doc, Object data);
    }
}
