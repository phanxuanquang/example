using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;

namespace Export3D
{
    internal class CallbackGeomListener : COMApi.InwSimplePrimitivesCB
    {
        private Mesh mesh = new Mesh();
        private Transform3D transform = new Transform3D();
        public double[] matrix = new double[16];
        public CallbackGeomListener()
        {

        }
        public void Line(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2) { }
        public void Point(COMApi.InwSimpleVertex v1) { }
        public void SnapPoint(COMApi.InwSimpleVertex v1) { }
        public void Triangle(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2, COMApi.InwSimpleVertex v3)
        {
            Point3D getCoordinatesFrom(Array triangle)
            {
                var x = Convert.ToDouble(triangle.GetValue(1));
                var y = Convert.ToDouble(triangle.GetValue(2));
                var z = Convert.ToDouble(triangle.GetValue(3));

                return new Point3D(x, y, z);
            }

            Point3D A = getCoordinatesFrom((Array)(object)v1.coord);
            Point3D B = getCoordinatesFrom((Array)(object)v2.coord);
            Point3D C = getCoordinatesFrom((Array)(object)v3.coord);
            
            mesh.AppendTriangleWithVertexes(A, B, C);
        }
    }
}
