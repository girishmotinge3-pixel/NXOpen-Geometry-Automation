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
    internal class GeometryUtility
    {
        public static void CreateBasicGeometry(Part workpart)
        {
            double Width = 500;
            double Height = 250;

            Point origin = CreatePoint(workpart, 0, 0, 0); // create point using Implimenting Method
            Point pt1 = CreatePoint(workpart, 0, 0, Width); // point created for line
            Point pt2 = CreatePoint(workpart, Height, 0, Height);
            Point pt3 = CreatePoint(workpart, 0, 0, Height);

            #region Construction Line

            Line line = workpart.Curves.CreateLine(origin, pt1); //
            line.SetVisibility(SmartObject.VisibilityOption.Visible);

            #endregion

            #region Feature Point

            Point FPoint1 = CreateConstructionPoint(workpart, (Height / 2), 0, Height);

            #endregion

            #region Associated Line

            CreateAssociateLine(workpart, pt3, pt2);

            #endregion

            #region Associated Arc Creation

            CreateArc(workpart, origin, pt2, pt1);

            #endregion
        }
        public static Point CreatePoint(Part workpart, double x, double y, double z)
        {
            Point3d point3D = new Point3d(x, y, z);
            Point point = workpart.Points.CreatePoint(point3D);
            point.SetVisibility(SmartObject.VisibilityOption.Visible);
            return point;
        }
        public static Point CreateConstructionPoint(Part workpart, double x, double y, double z)
        {
            Point3d point3D = new Point3d(x, y, z);
            Point point = workpart.Points.CreatePoint(point3D);

            Feature feature = null;
            PointFeatureBuilder Cpoint = workpart.BaseFeatures.CreatePointFeatureBuilder(feature);
            Cpoint.Point = point;
            Cpoint.Commit();
            Cpoint.Destroy();
            return point;
        }

        public static void CreateAssociateLine(Part workpart, Point A, Point B)
        {
            AssociativeLine Assline = null;
            AssociativeLineBuilder line = workpart.BaseFeatures.CreateAssociativeLineBuilder(Assline);
            line.StartPointOptions = AssociativeLineBuilder.StartOption.Point;
            line.StartPoint.Value = A;
            line.EndPointOptions = AssociativeLineBuilder.EndOption.Point;
            line.EndPoint.Value = B;
            line.Commit();
            line.Destroy();
        }

        public static void CreateArc(Part workpart, Point A, Point B, Point C)
        {
            Arc arc = null;
            AssociativeArcBuilder arc1 = workpart.BaseFeatures.CreateAssociativeArcBuilder(arc);
            arc1.StartPointOptions = AssociativeArcBuilder.StartOption.Point;
            arc1.StartPoint.Value = A;
            arc1.MidPointOptions = AssociativeArcBuilder.MidOption.Point;
            arc1.MidPoint.Value = B;
            arc1.EndPointOptions = AssociativeArcBuilder.EndOption.Point;
            arc1.EndPoint.Value = C;
            arc1.Commit();
            arc1.Destroy();
        }



    }
}
