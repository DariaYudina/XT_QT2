using Epam.WebPages.AbstractDAL;
using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.DataBaseDAL
{
    public class UserDao : IStorableUser
    {
        private string _connectionstring = "Data Source=DARIA-ПК\\SQLEXPRESS;Initial Catalog=UserDAL;Integrated Security=True";
        public bool AddAwards(Guid userId, List<Award> awards)
        {
            throw new NotImplementedException();
        }

        public bool AddRoleToUser(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
        public bool AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var id = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(name);
                command.Parameters.Add(id);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAward(Guid userId, Guid awardid)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsersAward(Guid awardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

