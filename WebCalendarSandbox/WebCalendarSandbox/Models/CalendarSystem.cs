using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace WebCalendarSandbox.Models
{
    public class CalendarSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; } //User Nickname
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public bool isAbstract { get; set; } // if True, Calendar system will hasn't day for 01/01/0001 from our Calendar

        public int MonthCount {  get; set; }

        public int DaysPerWeek { get; set; }
    }
}
