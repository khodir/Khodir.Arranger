using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khodir.Arranger.Models;
using Khodir.Arranger.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Khodir.Arranger.Collection
{
    class RoleCollection : CollectionInterface<Role>
    {
        public void Delete(Role model)
        {
            var conn = Arranger.GetConnection();
            conn.Delete(model);
        }

        public void Delete(long Id)
        {
            var conn = Arranger.GetConnection();
            Role role = conn.Get<Role>(Id);
            conn.Delete(role);
        }

        public Role FindById(long Id)
        {
            var conn = Arranger.GetConnection();
            Role role = conn.Get<Role>(Id);
            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            var conn = Arranger.GetConnection();
            return conn.GetAll<Role>();
        }

        public void Insert(Role model)
        {
            var conn = Arranger.GetConnection();
            conn.Insert(model);
        }

        public void Update(Role model)
        {
            var conn = Arranger.GetConnection();
            conn.Update(model);
        }
    }
}
