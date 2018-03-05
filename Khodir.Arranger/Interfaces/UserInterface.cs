using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Khodir.Arranger.Interfaces
{
    public interface UserInterface
    {
        IDbConnection ArrangerConnection();
        long Id { get; set; }
    }
}
