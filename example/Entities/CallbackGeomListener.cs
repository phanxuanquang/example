using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Interop.ComApi;
using System;

namespace ModelViewer.Modal
{
    internal class CallbackGeomListener : InwSimplePrimitivesCB
    {
        public Mesh mesh = new Mesh();
        public Autodesk.Navisworks.Api.Interop.ComApi.InwLTransform3f3 coordinateStandard;
        public void Line(InwSimpleVertex v1, InwSimpleVertex v2) { }
        public void Point(InwSimpleVertex v1) { }
        public void SnapPoint(InwSimpleVertex v1) { }

        /// <summary>
        /// Create a trianlge with vertexes v1, v2, and v3
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void Triangle(InwSimpleVertex v1, InwSimpleVertex v2, InwSimpleVertex v3)
        {
            Point3D_Custom getCoordinatesFrom(Array triangle)
            {
                var x = Convert.ToDouble(triangle.GetValue(1)) + coordinateStandard.GetTranslation().data1;
                var y = Convert.ToDouble(triangle.GetValue(2)) + coordinateStandard.GetTranslation().data2;
                var z = Convert.ToDouble(triangle.GetValue(3)) + coordinateStandard.GetTranslation().data3;

                return new Point3D_Custom(x, y, z);
            }

            Point3D_Custom A = getCoordinatesFrom((Array)(object)v1.coord);
            Point3D_Custom B = getCoordinatesFrom((Array)(object)v2.coord);
            Point3D_Custom C = getCoordinatesFrom((Array)(object)v3.coord);

            mesh.AppendTriangleWithVertexes(A, B, C);
        }
    }
}
