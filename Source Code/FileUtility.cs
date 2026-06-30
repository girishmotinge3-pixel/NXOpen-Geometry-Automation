using NXOpen;
using NXOpen.CAE;
using NXOpen.Features;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_Geometry_Creation
{
    internal class FileUtility
    {
        public static Part CreatePart()
        {
            Session theSession = Session.GetSession();
            FileNew newfile = theSession.Parts.FileNew();
            newfile.Units = Part.Units.Millimeters;
            newfile.UseBlankTemplate = false;
            newfile.TemplateFileName = "model-plain-1-mm-template.prt";
            newfile.NewFileName = @"D:\0000_NX Open_By FeesWorth\Fresh Reinstall Visual Studio\Project_1_Selftest_till_DatumAxis\3D_Model File\Creted_File.prt"; // defined filepath and filename for new file creation
            newfile.MakeDisplayedPart = true;
            newfile.Commit();
            newfile.Destroy();
            return theSession.Parts.Display;
        }

    }
}
