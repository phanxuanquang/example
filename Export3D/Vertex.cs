using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2OBJ
{
    internal class Vertex
    {
        public int id {  get; set; }
        public Point3D point { get; set; }
        public Vertex(int id, Point3D point)
        {
            this.id = id;
            this.point = point;
        }
    }
}
