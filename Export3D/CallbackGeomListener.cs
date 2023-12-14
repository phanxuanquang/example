using Autodesk.Navisworks.Api;
using System;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;

namespace Model2OBJ
{
    internal class CallbackGeomListener : COMApi.InwSimplePrimitivesCB
    {
        private Mesh mesh = new Mesh();
        public Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3 coordinateStandard;
        public void Line(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2) { }
        public void Point(COMApi.InwSimpleVertex v1) { }
        public void SnapPoint(COMApi.InwSimpleVertex v1) { }
        public void Triangle(COMApi.InwSimpleVertex v1, COMApi.InwSimpleVertex v2, COMApi.InwSimpleVertex v3)
        {
            Point3D getCoordinatesFrom(Array triangle)
            {
                var x = Convert.ToDouble(triangle.GetValue(1)) + coordinateStandard.GetTranslation().data1;
                var y = Convert.ToDouble(triangle.GetValue(2)) + coordinateStandard.GetTranslation().data2;
                var z = Convert.ToDouble(triangle.GetValue(3)) + coordinateStandard.GetTranslation().data3;

                return new Point3D(x, y, z);
            }

            Point3D A = getCoordinatesFrom((Array)(object)v1.coord);
            Point3D B = getCoordinatesFrom((Array)(object)v2.coord);
            Point3D C = getCoordinatesFrom((Array)(object)v3.coord);

            mesh.AppendTriangleWithVertexes(A, B, C);
        }
    }
}
