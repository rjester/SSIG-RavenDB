using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ssig.Models
{
    public class Meeting {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}