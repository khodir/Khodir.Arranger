using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Khodir.Arranger.Models
{
    public class UserRole
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public long RoleID { get; set; }
    }
}
