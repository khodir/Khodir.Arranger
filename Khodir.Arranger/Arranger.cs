using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khodir.Arranger.Models;
using Khodir.Arranger.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Contrib;
using System.Data;

namespace Khodir.Arranger
{
    public static class Arranger
    {

        /// <summary>
        /// Arranger Default Connection
        /// </summary>
        private static IDbConnection Connection;

        /// <summary>
        /// Set Arranger Default Connection
        /// </summary>
        public static void SetConnection(IDbConnection conn)
        {
            Connection = conn;
        }

        /// <summary>
        /// Get Arranger Default Connection
        /// </summary>
        public static IDbConnection GetConnection()
        {
            return Connection;
        }

        /// <summary>
        /// Add Permission to User via UserInterface
        /// </summary>
        public static void Can(this UserInterface user, string PermissionName)
        {
            var conn = user.ArrangerConnection();
            if(conn == null)
            {
                conn = GetConnection();
            }
            var permission = conn.GetAll<Permission>().Where(x => x.PermissionName == PermissionName).First();

            UserPermission up = new UserPermission();
            up.UserID = user.Id;
            up.PermissionID = permission.Id;
            conn.Insert(up);
        }

        /// <summary>
        /// Add Permission to Role
        /// </summary>
        public static void Can(this Role role, string PermissionName)
        {
            var conn = GetConnection();
            var Permission = conn.GetAll<Permission>().First(x => x.PermissionName == PermissionName);

            RolePermission rp = new RolePermission();
            rp.RoleID = role.Id;
            rp.PermissionID = Permission.Id;
            conn.Insert(rp);
        }

        /// <summary>
        /// Remove Permission from User via UserInterface
        /// </summary>
        public static void Cant(this UserInterface user, string PermissionName)
        {
            var conn = user.ArrangerConnection();
            if(conn == null)
                conn = GetConnection();

            Permission p = conn.GetAll<Permission>().First(x => x.PermissionName == PermissionName);
            UserPermission up = conn.GetAll<UserPermission>().First(x => x.PermissionID == p.Id && x.UserID == user.Id);
            conn.Delete(up);
        }

        /// <summary>
        /// Remove Permission from Role
        /// </summary>
        public static void Cant(this Role role, string PermissionName)
        {
            var conn = GetConnection();
            Permission p = conn.GetAll<Permission>().First(x => x.PermissionName == PermissionName);
            RolePermission up = conn.GetAll<RolePermission>().First(x => x.PermissionID == p.Id && x.RoleID == role.Id);
            conn.Delete(up);
        }

        /// <summary>
        /// Add Role to User via UserInterface
        /// </summary>
        public static void IsA(this UserInterface user, string RoleName)
        {
            var conn = user.ArrangerConnection();
            if (conn == null)
                conn = GetConnection();
            Role role = conn.GetAll<Role>().First(x => x.RoleName == RoleName);

            UserRole ur = new UserRole() { RoleID = role.Id, UserID = user.Id };
            conn.Insert(ur);
        }

        /// <summary>
        /// Add Role to User via UserInterface
        /// </summary>
        public static void IsAn(this UserInterface user, string[] RoleNames)
        {
            var conn = user.ArrangerConnection();
            if (conn == null)
                conn = GetConnection();

            foreach(string RoleName in RoleNames)
            {
                Role role = conn.GetAll<Role>().First(x => x.RoleName == RoleName);

                UserRole ur = new UserRole() { UserID = user.Id, RoleID = role.Id};
                conn.Insert(ur);
            }
        }

        /// <summary>
        /// Add Role to User via UserInterface
        /// </summary>
        public static void IsntA(this UserInterface user, string RoleName)
        {
            var conn = user.ArrangerConnection();
            if (conn == null)
                conn = GetConnection();

            Role role = conn.GetAll<Role>().First(x => x.RoleName == RoleName);
            UserRole ur = conn.GetAll<UserRole>().First(x => x.RoleID == role.Id && x.UserID == user.Id);
            conn.Delete(ur);
        }

        /// <summary>
        /// Add Role to User via UserInterface
        /// </summary>
        public static void IsntAn(this UserInterface user, string[] RoleNames)
        {
            var conn = user.ArrangerConnection();
            if(conn == null)
            {
                conn = GetConnection();
            }

            foreach(string roleName in RoleNames)
            {
                Role role = conn.GetAll<Role>().First(x => x.RoleName == roleName);
                UserRole ur = conn.GetAll<UserRole>().First(x => x.RoleID == role.Id && x.UserID == user.Id);
                conn.Delete(ur);
            }
        }
    }

}
