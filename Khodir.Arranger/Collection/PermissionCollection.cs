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
    class PermissionCollection : CollectionInterface<Permission>
    {
        public void Delete(Permission model)
        {
            var conn = Arranger.GetConnection();
            conn.Delete(model);
        }

        public void Delete(long Id)
        {
            var conn = Arranger.GetConnection();
            Permission perm = conn.Get<Permission>(Id);
            conn.Delete(perm);
        }

        public Permission FindById(long Id)
        {
            var conn = Arranger.GetConnection();
            return conn.Get<Permission>(Id);
        }

        public IEnumerable<Permission> GetAll()
        {
            var conn = Arranger.GetConnection();
            return conn.GetAll<Permission>();
        }

        public void Insert(Permission model)
        {
            var conn = Arranger.GetConnection();
            conn.Insert(model);
        }

        public void Update(Permission model)
        {
            var conn = Arranger.GetConnection();
            conn.Update(model);
        }
    }
}
