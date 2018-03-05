using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khodir.Arranger.Models
{
    public class UserPermission
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public long PermissionID { get; set; }
    }
}
