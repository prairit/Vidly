using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFees { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

    }
}