using SurveyRestApi.DataAccessLayer.Models;
using System.Data.SqlClient;

namespace SurveyRestApi.DataAccessLayer
{
    public class Db : IDb
    {
        private readonly string _connString;
        //Server=localhost;Database=dbtest;Trusted_Connection=True;
        public Db(string connectionString)
        {
            _connString = connectionString;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection()
            {
                ConnectionString = _connString
            };
        }


        public IEnumerable<DbAnswerInfo> GetOptionalAnswersFromSurveyId(int id)
        {
            var conn = GetSqlConnection();
            List<DbAnswerInfo> _ret = new List<DbAnswerInfo>();

            try
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetOptionsAnswersFromSurveyID";
                    cmd.Parameters.Add(new SqlParameter("@SurveyID", id));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _ret.Add(new DbAnswerInfo()
                            {

                                AnswerId = reader["answers_id"].AsInt(),
                                AnswerDescription = reader["answer_description"].ToString(),
                                AnswerKey = reader["answer_key"].AsInt()
                            });
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return _ret;
        }

        public IEnumerable<DbQuestionInfo> GetQuestionFromSurveyId(int id)
        {
            var conn = GetSqlConnection();
            List<DbQuestionInfo> _ret = new List<DbQuestionInfo>();

            try
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetQuestionsFromSurveyID";
                    cmd.Parameters.Add(new SqlParameter("@SurveyID", id));
                    using (var reader =cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _ret.Add(new DbQuestionInfo()
                            {
                                Id = reader["id"].AsInt(),
                                AnswerDescription = reader["ans_desc"].ToString(),
                                AnswerTypeId = reader["answer_type_id"].AsInt(),
                                Description = reader["description"].ToString(),
                                QuestionDescription = reader["question_desc"].ToString(),
                                Title = reader["title"].ToString()
                            });
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return _ret;
        }
    }
}
