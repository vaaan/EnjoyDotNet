using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vaaan.SouFun.AutoFill.App.ZyExpertAutoFill
{
    public enum RentTypes
    {
        Rent = 0,
        Sale = 1,
        Both = 2
    }

    public class ExpertInformation
    {
        // Properties
        public string BuildCode { get; set; }
        public string Contractdate { get; set; }
        public string Contractid { get; set; }
        public string Managerid { get; set; }
        public RentTypes RentType { get; set; }
    }
}
