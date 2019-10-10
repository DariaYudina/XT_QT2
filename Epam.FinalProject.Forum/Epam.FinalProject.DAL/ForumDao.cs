﻿using Epam.FinalProject.AbstractDAL;
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
    }
}
