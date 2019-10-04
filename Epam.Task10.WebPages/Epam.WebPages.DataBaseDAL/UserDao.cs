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
        private string _connectionString = "Data Source=DARIA-ПК\\SQLEXPRESS;Initial Catalog=UserDAL;Integrated Security=True";
        private Dictionary<Guid, User> users;
        public UserDao()
        {
            users = ReadFromDataBase().ToDictionary(user => user.UserId);
        }
        public bool AddAwards(Guid userId, List<Award> awards)
        {
            User user = GetUser(userId);
            if (user != null)
            {
                user.Awards.AddRange(awards);
                foreach (var award in awards)
                {
                    if(!AddUserAwardToDB(userId, award))
                    {
                        return false;
                    }
                }
                    return true;
            }
            else
            {
                return false;
            }
        }
        private bool AddUserAwardToDB(Guid userId, Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUserAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var UserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = userId,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };
                var AwardId = new SqlParameter
                {
                    ParameterName = "@AwardId",
                    Value = award.AwardId,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };             
                command.Parameters.Add(UserId);
                command.Parameters.Add(AwardId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool AddRoleToUser(Guid userId, string role)
        {
            User user = GetUser(userId);
            if (user != null)
            {
                user.Role = role;
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "AddRoleToUser";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var UserId = new SqlParameter
                    {
                        ParameterName = "@UserId",
                        Value = userId,
                        SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    var Role = new SqlParameter
                    {
                        ParameterName = "@Role",
                        Value = user.Role,
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(UserId);
                    command.Parameters.Add(Role);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }               
            }
            else
            {
                return false;
            }
        }
        public bool AddUser(User user)
        {
            if (users.Any(u => u.Value.UserId == user.UserId))
            {
                return false;
            }
            users.Add(user.UserId, user);
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var Id = new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = user.UserId,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Role = new SqlParameter
                {
                    ParameterName = "@Role",
                    Value = user.Role,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Birthday = new SqlParameter
                {
                    ParameterName = "@Birthday",
                    Value = user.BirthDate,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Avatar = new SqlParameter
                {
                    ParameterName = "@Avatar",
                    Value = user.Avatar,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(Id);
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
        public bool Delete(Guid userId)
        {
            if (users.ContainsKey(userId))
            {
                users.Remove(userId);
                using (var connection = new SqlConnection(_connectionString)) //from data base
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "DeleteUserById";

                    var Id = new SqlParameter
                    {
                        ParameterName = "@UserId",
                        Value = userId,
                        SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAward(Guid userId, Guid awardid)
        {
            User user = GetUser(userId);
            user.Awards.Remove(user.Awards.FirstOrDefault(x => x.AwardId == awardid));

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var UserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = userId,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };
                var AwardId = new SqlParameter
                {
                    ParameterName = "@AwardId",
                    Value = awardid,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(UserId);
                command.Parameters.Add(AwardId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public void DeleteUsersAward(Guid awardId)
        {
            foreach (var user in GetAllUsers())
            {
                DeleteAward(user.UserId, awardId);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users.Values.ToList();
        }

        public User GetUser(Guid userId)
        {
            bool isSuccess = users.TryGetValue(userId, out User user);
            return isSuccess ? user : null; 
        }
        private IEnumerable<User> ReadFromDataBase()
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
                        UserId = (Guid)(reader["UserID"]),
                        Name = (string)reader["Name"],
                        BirthDate =  (DateTime)reader["Birthday"],
                        Awards = new List<Award>(),
                        Avatar = (string)reader["Avatar"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                    };
                }
            }
        }
    }
}

