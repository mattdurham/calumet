using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calumetbase.Models
{
    public class Event
    {
        public long EventID { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? EndDate { get; set; }

        [StringLength(100,MinimumLength =3)]
        [Required]
        public string Name { get; set; }

        public string Creator { get; set; }

        [Required]
        public DateTime DateOrTime { get; set; }

        public string Link { get; set; }

        [StringLength(1000)]
        public string Comments { get; set; }

        public Event()
        {

        }
    }

    public enum DateTime { Date, Time}
}