using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonorDemo.Models
{
    public class DonorInfo
    {
        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public string DonorMobile { get; set; }
        public DateTime DateOfJoining { get; set; }
       
    }
}