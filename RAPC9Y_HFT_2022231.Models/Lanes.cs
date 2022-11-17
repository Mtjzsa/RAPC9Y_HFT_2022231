using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RAPC9Y_HFT_2022231.Models
{
    public class Lanes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string LaneName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Champions> ChampionsByLanes { get; set; }

        public Lanes()
        {
            this.ChampionsByLanes = new HashSet<Champions>();
        }

        //public Lanes(string entity)
        //{
        //    string[] split = entity.Split('#');
        //    Id = int.Parse(split[0]);
        //    LaneName = split[1];
        //}
    }
}
