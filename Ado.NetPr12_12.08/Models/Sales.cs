using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetPr12_12._08.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CountryName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
