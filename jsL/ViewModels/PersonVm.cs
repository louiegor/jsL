using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsL.ViewModels
{
    public class PersonVm
    {
        public string Name { get; set; }
        public string Organization { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public int Haki { get; set; }
        public int? AkumaNoMi { get; set; }
        public string AkumaName { get; set; }
        public string ImgSmall { get; set; }
        public string ImgLarge { get; set; }
        
    }
}