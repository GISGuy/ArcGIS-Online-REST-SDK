using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class ServiceItem
    {
        public String ID { get; set; }
        public String Owner { get; set; }
        public String Name { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public String[] Tags { get; set; }
        public String URL { get; set; }
    }
}
