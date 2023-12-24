using System;
using System.Collections.Generic;

namespace PostGISTest
{
    internal class Table
    {
        public string name { get; set; }
        public List<String> rows = new List<String>();
        public List<String> columns = new List<String>();
    }
}
