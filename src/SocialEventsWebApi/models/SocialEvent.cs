using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialEventsWebApi.models
{
    public class SocialEvent
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Some content must be provided, please enter some content!")]
        [MinLength(10,ErrorMessage ="Content must be at least 10 characters!")]
        public string Content { get; set; }
        public string MapUrl { get; set; }
        [Required(ErrorMessage = "A title must be provided, please enter one!")]
        [MinLength(2, ErrorMessage = "Title must be greater > than 1 character!")]
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "An event must have a date, please pick one!")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date and time(ex: 2/14/2011 0:00)")]
        public DateTime EventDate { get; set; }
    }
}
