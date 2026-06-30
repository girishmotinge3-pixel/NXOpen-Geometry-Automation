using NXOpen;
using NXOpen.UF;
using NXOpen.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_Geometry_Creation
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Session theSession = Session.GetSession();

            try
            {
                Part workPart = FileUtility.CreatePart();

                GeometryUtility.CreateBasicGeometry(workPart);

                workPart.Save(BasePart.SaveComponents.True, BasePart.CloseAfterSave.False);

            }
            catch (Exception ex)
            {
                theSession.ListingWindow.Open();
                theSession.ListingWindow.WriteLine(ex.ToString());
            }

        }
    }
}
