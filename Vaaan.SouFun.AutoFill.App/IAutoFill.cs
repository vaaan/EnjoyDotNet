﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vaaan.SouFun.AutoFill.App
{
    interface IAutoFill
    {
        string AutoFill(WebBrowser fillWebBrowser);
    }
}
