using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Models
{
    [Table("Champions")]
    public class Champions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Gender { get; set; }

        [ForeignKey(nameof(Lane))]
        public int LaneId { get; set; }
        
        [NotMapped]
        public virtual Lanes Lane { get; set; }

        public string Species { get; set; }

        public string Resources { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        [NotMapped]
        public virtual Regions Region { get; set; }

        public int Release { get; set; }

        public Champions()
        {

        }
        public Champions(string entity)
        {
            string[] split = entity.Split('#');
            Id = int.Parse(split[0]);
            Name = split[1];
            Gender = split[2];
            LaneId = int.Parse(split[3]);
            Species = split[4];
            Resources = split[5];
            RegionId = int.Parse(split[6]);
            Release = int.Parse(split[7]);
        }
    }
}
