using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcAdmin.Shared
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public Comic Comic { get; set; }
        public int ComicId { get; set; }
    }
}
