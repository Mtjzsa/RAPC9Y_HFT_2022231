using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Models
{
    public class Regions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string RegionName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Champions> ChampionsByRegions { get; set; }

        public Regions()
        {
           this.ChampionsByRegions = new HashSet<Champions>();
        }

        //public Regions(string entity)
        //{
        //    string[] split = entity.Split('#');
        //    Id = int.Parse(split[0]);
        //    RegionName = split[1];
        //}
    }
}
