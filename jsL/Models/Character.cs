using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsL.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgPathSmall { get; set; }
        public string ImgPathLarge { get; set; }
        public Stats Stats { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Stats
    {
        public int Id { get; set; }
        public int Haki { get; set; }
        public int? AkumaNoMi { get; set; } // The range for Akuma no mi must be between 80-120
        public string AkumaNoMiName { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }

        public int Total()
        {
            if (AkumaNoMi != null)
            {
                return (Haki + Atk + Def + Spd + (int)AkumaNoMi)/5;
            }
            return (Haki + Atk + Def + Spd)/4;
        }

    }
}