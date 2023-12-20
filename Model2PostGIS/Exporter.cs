using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2PostGIS
{
    [PluginAttribute("Model2OBJ", "ADSK", ToolTip = "Export model to .obj file", DisplayName = "Model2OBJ")]
    [AddInPluginAttribute(AddInLocation.AddIn)]
    public class Exporter : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            

            return 0;
        }
    }
}
