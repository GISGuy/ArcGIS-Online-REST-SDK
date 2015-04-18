using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class QueryResult
    {
        public int Count { get; set; }
        public String objectIdFieldName { get; set; }
        public int[] OBJECTIDs { get; set; }
        public Feature[] Features { get; set; }
    }
}
