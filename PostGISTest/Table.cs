using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGISTest
{
    internal class Table
    {
        public string name {  get; set; }
        public List<String> rows = new List<String>();
        public List<String> columns = new List<String>();
    }
}
