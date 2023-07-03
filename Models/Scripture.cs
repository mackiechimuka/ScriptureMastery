using System;
using System.ComponentModel.DataAnnotations;

namespace ScriptureMastery.Models
{
    public class Scripture
    {
       public int ScriptureId { get; set; }
        public int BookId { get; set; }
        [Required,StringLength(150)]
        public string Chapter { get; set; }
        [Required, StringLength(255)]
        public string Verses { get; set; }
        [Required, StringLength(255)]
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public Book Books { get; set; }


    }
}

