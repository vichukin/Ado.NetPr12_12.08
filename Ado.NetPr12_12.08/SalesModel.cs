using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetPr12_12._08
{
    public class SalesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CountryId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
