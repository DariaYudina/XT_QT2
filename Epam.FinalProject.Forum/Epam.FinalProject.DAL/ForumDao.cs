using Epam.FinalProject.AbstractDAL;
using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.DAL
{
    public class ForumDao : IForumDAL
    {
        private string _connectionString = "Data Source=DARIA-ПК\\SQLEXPRESS;Initial Catalog=Forum;Integrated Security=True";

        public bool AddMessage(int topicId, int userId, DateTime datecreation, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddMessage";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var UserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = userId,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                };
                var TopicId = new SqlParameter
                {
                    ParameterName = "@TopicId",
                    Value = topicId,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                };
                var DateCreation = new SqlParameter
                {
                    ParameterName = "@DateCreationMessage",
                    Value = datecreation,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                };
                var Text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = text,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(UserId);
                command.Parameters.Add(TopicId);
                command.Parameters.Add(DateCreation);
                command.Parameters.Add(Text);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool AddSection(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddSection";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var Title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = title,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(Title);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool AddTopic(int sectionId, string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddTopic";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var SectionId = new SqlParameter
                {
                    ParameterName = "@SectionId",
                    Value = sectionId,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                };
                
                var Title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = title,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(SectionId);
                command.Parameters.Add(Title);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<Section> GetAllSections()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetAllSections";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Section
                    {
                        SectionId = (int)reader["SectionId"],
                        Title = (string)reader["Title"],
                    };
                }
            }
        }

        public IEnumerable<Topic> GetSectionTopics(int sectionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetSectionTopics";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var SectionId = new SqlParameter
                {
                    ParameterName = "@SectionId",
                    Value = sectionId,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(SectionId);
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Topic
                    {
                        TopicId = (int)reader["TopicId"],
                        SectionId = (int)reader["TopicId"],
                        Title = (string)reader["Title"],
                    };
                }
            }
        }

        public IEnumerable<Message> GetTopicMessages(int topicId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "GetTopicMessages";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var TopicId = new SqlParameter
                {
                    ParameterName = "@TopicId",
                    Value = topicId,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(TopicId);
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Message
                    {
                        MessageId = (int)reader["MessageId"],
                        UserId = (int)reader["UserId"],
                        TopicId = (int)reader["TopicId"],
                        DateCreation = (DateTime)reader["DateCreationMessage"],
                        Text = (string)reader["Text"],
                    };
                }
            }
        }
    
    }
}
