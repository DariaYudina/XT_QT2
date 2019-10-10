using Epam.FinalProject.AbstractDAL;
using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.DAL
{
    public class UserDao : IUserDAL
    {
        private string _connectionString = "Data Source=DARIA-ПК\\SQLEXPRESS;Initial Catalog=Forum;Integrated Security=True";
        public bool AddUser(string name, DateTime birthDate, string avatar, string password, string role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = password,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Role = new SqlParameter
                {
                    ParameterName = "@Role",
                    Value = role,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Birthday = new SqlParameter
                {
                    ParameterName = "@Birthday",
                    Value = birthDate,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Avatar = new SqlParameter
                {
                    ParameterName = "@Avatar",
                    Value = avatar,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(Name);
                command.Parameters.Add(Password);
                command.Parameters.Add(Role);
                command.Parameters.Add(Birthday);
                command.Parameters.Add(Avatar);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }          
        }
        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetAllUsers";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User
                    {
                        Name = (string)reader["Login"],
                        BirthDate = (DateTime)reader["Birthday"],
                        Avatar = (string)reader["Avatar"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                        UserId = (int)(reader["UserID"]),
                    };
                }
            }
        }
        public User GetUser(int id)
        {
            return GetAllUsers().FirstOrDefault(x => x.UserId == id);
        }
    }
}
