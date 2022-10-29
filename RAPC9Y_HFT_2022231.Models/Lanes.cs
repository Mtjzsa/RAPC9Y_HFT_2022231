using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual ICollection<Champions> ChampionByLanes { get; set; }

        public Lanes()
        {
            this.ChampionByLanes = new HashSet<Champions>();
        }
    }
}
