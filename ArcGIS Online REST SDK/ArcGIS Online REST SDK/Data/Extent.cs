using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class Extent
    {
        public Double xmin { get; set; }
        public Double ymin { get; set; }
        public Double xmax { get; set; }
        public Double ymax { get; set; }
        public SpatialReference SpatialReference { get; set; }
    }
}
