﻿using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;

namespace ModelViewer.Modal
{
    internal class Point3D_Custom
    {
        public double x {  get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Point3D_Custom(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if(obj is Point3D_Custom other)
            {
                return x==other.x && y==other.y && z==other.z;
            }
            return false;
        }
    }
    internal class Mesh
    {
        /// <summary>
        /// Vertex list of the mesh
        /// </summary>
        public List<Point3D_Custom> vertexes { get; set; }
        /// <summary>
        /// Face index list of the mesh
        /// </summary>
        public List<int> faceIndexes { get; set; }
        /// <summary>
        /// This mesh
        /// </summary>
        public static Mesh instance { get; set; }
        public Mesh()
        {
            vertexes = new List<Point3D_Custom>();
            faceIndexes = new List<int>();
            instance = this;
        }
        public void AppendTriangleWithVertexes(Point3D_Custom x, Point3D_Custom y, Point3D_Custom z)
        {
            var xIndex = GetIndexOf(x);
            var yIndex = GetIndexOf(y);
            var zIndex = GetIndexOf(z);
            //vertexes.Add(x);
            //vertexes.Add(y);
            //vertexes.Add(z);

            faceIndexes.Add(xIndex);
            faceIndexes.Add(yIndex);
            faceIndexes.Add(zIndex);
        }

        private int GetIndexOf(Point3D_Custom x)
        {
            if (vertexes.Contains(x))
            {
                return vertexes.IndexOf(x);
            }
            vertexes.Add(x);
            return vertexes.Count - 1;
        }
    }
}
