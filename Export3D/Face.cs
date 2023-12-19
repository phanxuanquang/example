using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2OBJ
{
    internal class Face
    {
        public int id {  get; set; }
        public int f1 { get; set; }
        public int f2 { get; set; }
        public int f3 { get; set; }
        public Face(int id, int f1, int f2, int f3)
        {
            this.id = id;
            this.f1 = f1;
            this.f2 = f2;
            this.f3 = f3;
        }
    }
}
