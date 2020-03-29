using IBISEvaluation.Data;
using IBISEvaluation.Models;
using IBISEvaluation.Models.Glossary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IBISEvaluation.Services
{
    public class GlossaryServices : IGlossaryServices
    {
        //IDataProvider _data = null;
        //public GlossaryServices(IDataProvider data)
        //{
        //    _data = data;
        //}

        public List<Entity> Add(AddRequest model, string _connString)
        {
            int id = 0;
            List<Entity> result = null;
            Entity glossaryList = null;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Entity_Insert";

                command.Parameters.AddWithValue("@Term", model.Term);
                command.Parameters.AddWithValue("@Definition", model.Definition);
                conn.Open();

                IDataReader reader = command.ExecuteReader();

                if(result == null)
                {
                    result = new List<Entity>();
                    while (reader.Read())
                    {
                        glossaryList = MapGlossary(reader);

                        result.Add(glossaryList);
                    }
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }



        public List<Entity> GetGlossary(string _connString)
        {
            List<Entity> result = null;
            Entity glossaryList = null;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Entity_Select_All";
                conn.Open();

                IDataReader reader = command.ExecuteReader();

                if (result == null)
                {
                    result = new List<Entity>();
                    while (reader.Read())
                    {
                        glossaryList = MapGlossary(reader);

                        result.Add(glossaryList);
                    }
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        private static Entity MapGlossary(IDataReader reader)
        {
            Entity col = new Entity();

            col.Term = reader["Term"].ToString();
            col.Definition = reader["Definition"].ToString();

            return col;
        }
        private static void AddWithCommonParams(AddRequest model, SqlParameterCollection col)
        {
            col.AddWithValue("@Term", model.Term);
            col.AddWithValue("@Definition", model.Definition);

        }
    }
}
