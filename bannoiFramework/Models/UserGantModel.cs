using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bannoiFramework.Models
{
    public class UserGantModel
    {
        public string groupCode { get; set; }
        public decimal signId { get; set; }
        public string levelCode { get; set; }
        public string systemCode { get; set; }
        public string systemVersion { get; set; }
        public string isAdmin { get; set; }
    }
}
