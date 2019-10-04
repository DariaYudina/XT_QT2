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
    public class AwardDao : IStorableAward
    {
        private string _connectionString = "Data Source=DARIA-ПК\\SQLEXPRESS;Initial Catalog=UserDAL;Integrated Security=True";
        private Dictionary<Guid, Award> awards;
        public AwardDao()
        {
            awards = ReadFromDataBase().ToDictionary(award => award.AwardId);
        }
        public bool AddAward(Award award)
        {
            awards.Add(award.AwardId, award);
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var Id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = award.AwardId,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = award.Title,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Image = new SqlParameter
                {
                    ParameterName = "@Image",
                    Value = award.Image,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(Id);
                command.Parameters.Add(Title);
                command.Parameters.Add(Image);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteAward(Guid awardId) 
        {
            if (awards.ContainsKey(awardId))
            {
                awards.Remove(awardId); // from dictionary (cache)

                using (var connection = new SqlConnection(_connectionString)) //from data base
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardById";

                    var Id = new SqlParameter
                    {
                        ParameterName = "@AwardId",
                        Value = awardId,
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

        public IEnumerable<Award> GetAllAwards()
        {
            return awards.Values.ToList();
        }

        public Award GetAward(Guid awardId)
        {
            bool isSuccess = awards.TryGetValue(awardId, out Award award);
            return isSuccess ? award : null;
        }
        private IEnumerable<Award> ReadFromDataBase()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetAllAwards";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award
                    {
                        AwardId = (Guid)(reader["AwardId"]),
                        Title = (string)reader["Title"],
                        Image = (string)reader["Image"],
                    };
                }
                
            }
        }
    }
}
