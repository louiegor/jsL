using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace jsL.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public class Character:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgPathSmall { get; set; }
        public string ImgPathLarge { get; set; }

        public int StatsId { get; set; }
        public virtual Stats Stats { get; set; }

        
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public class Organization : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }

    public class Stats
    {
        public int Id { get; set; }
        public int Haki { get; set; }
        [Range(90,120)]
        public int? AkumaNoMi { get; set; } // The range for Akuma no mi must be between 90-120
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