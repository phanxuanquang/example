using System;
using System.Collections.Generic;

namespace PostGISTest
{
    internal class Table
    {
        public string name { get; set; }
        public List<string> rows = new List<string>();
        public List<string> columns = new List<string>();
    }
}
