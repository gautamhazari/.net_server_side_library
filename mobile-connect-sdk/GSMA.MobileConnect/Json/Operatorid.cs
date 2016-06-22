using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Json
{
    /// <summary>
    /// Object for deserialization of Discovery Response content
    /// </summary>
    public class Operatorid
    {
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public List<Link> link { get; set; }
    }
}
