using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    internal class Videogame
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("software_house_id")]
        public long SoftwareHouseId { get; set; }

        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }
    }
}
