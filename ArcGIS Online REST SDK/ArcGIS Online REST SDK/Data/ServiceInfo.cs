using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class ServiceInfo
    {
        public String Description { get; set; }
        public SpatialReference SpatialReference { get; set; }
        public Extent InitialExtent { get; set; }
        public Extent FullExtent { get; set; }
        public LayerInfo[] Layers { get; set; }
    }
}
