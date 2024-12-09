using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupEventAPI.Models.Requests
{
    public class CreateEventRequestModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Datetime { get; set; }
    }
}
