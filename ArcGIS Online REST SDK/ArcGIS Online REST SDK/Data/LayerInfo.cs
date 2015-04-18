using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class LayerInfo
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public Boolean DefaultVisibility { get; set; }
        public int minScale { get; set; }
        public int maxScale { get; set; }
        public Feature Features { get; set; }
    }
}
