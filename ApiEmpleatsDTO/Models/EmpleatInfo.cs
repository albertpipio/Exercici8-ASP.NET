using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleatsDTO.Models
{
    public class EmpleatInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Secret { get; set; }
    }
}
