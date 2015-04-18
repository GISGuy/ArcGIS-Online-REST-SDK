using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_Online_REST_SDK.Data
{
    public class AGOL_Error
    {
        public int Code { get; set; }
        public String Message { get; set; }
        public String[] Details { get; set; }
    }
}
