using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dependency_Injection_explained.Interfaces;
using Dependency_Injection_explained.Models;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Dependency_Injection_explained.Repositories
{
    public class PersonRepository : IPerson
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;


        public string GetAllPeopleData()
        {
            Dictionary<string, dynamic> info = new Dictionary<string, dynamic>();
            List<Person> result = new List<Person>();

            SqlConnection conn = null;
            string querystr = "";
            SqlCommand command = null;
            SqlDataReader reader = null;

            

            try
            {
                conn = new SqlConnection(conStr);
                querystr = "SELECT [ID],[FirstName],[LastName],[Age],[Email] FROM [Person]";
                command = new SqlCommand(querystr, conn);
                conn.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person obj = new Person(
                        Convert.ToInt32(reader["ID"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        Convert.ToInt32(reader["Age"]),
                        reader["Email"].ToString()
                        );
                    
                    result.Add(obj);
                }

                info.Add("data", result);
                info.Add("status", "success");
            }
            catch(Exception ex)
            {
                info.Add("data", "error");
                info.Add("status", ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return JsonConvert.SerializeObject(info);
        }

        public string SavePersonData(Person person)
        {
            Dictionary<string, string> Info = new Dictionary<string, string>();
            Info.Add("Status", "OK");

            try
            {
                SqlConnection conn = new SqlConnection(conStr);
              
                string queryStr = "INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age],[Email]) VALUES(@fName, @lName, @age, @email)";
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@fName", person.FirstName);
                cmd.Parameters.AddWithValue("@lName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.Parameters.AddWithValue("@email", person.Email);
                conn.Open();
                int rowsAffectd = cmd.ExecuteNonQuery();

                conn.Close();
                Info["status"] = "success";
                Info.Add("rowsAffected", rowsAffectd.ToString());

            }

            catch (Exception ex)
            {
                Info["status"] = "error";
                Info.Add("message", ex.Message);
            }

       
            return JsonConvert.SerializeObject(Info);
        }

        public string UpdatePersonData(Person person)
        {
            Dictionary<string, dynamic> Info = new Dictionary<string, dynamic>();

            SqlConnection conn = null;
            string querystr = "";
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(conStr);
                querystr = "UPDATE [Person] " +
                    "SET[FirstName] = @fName, " +
                    "[LastName] = @lName, " +
                    "[Age] = @age," +
                    "[Email] = @email " +
                    "WHERE ID = @id";

                command = new SqlCommand(querystr, conn);

                command.Parameters.AddWithValue("@fName", person.FirstName);
                command.Parameters.AddWithValue("@lName", person.LastName);
                command.Parameters.AddWithValue("@age", person.Age);
                command.Parameters.AddWithValue("@email", person.Email);
                command.Parameters.AddWithValue("@id", person.ID);

                conn.Open();
                int rowsAffectd = command.ExecuteNonQuery();
                Info["status"] = "success";
                Info.Add("rowsAffected", rowsAffectd.ToString());
            }

            catch (Exception ex)
            {
                Info["status"] = "error";
                Info.Add("Message", ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return JsonConvert.SerializeObject(Info);
        }

        public string DeletePersonData(int personID)
        {
            Dictionary<string, string> Info = new Dictionary<string, string>();
           

            SqlConnection conn = null;
            string querystr = "";
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(conStr);
                querystr = "DELETE FROM [Person] WHERE ID = @personID";
                command = new SqlCommand(querystr, conn);


                command.Parameters.AddWithValue("@personID", personID);

                conn.Open();

                int rowsAffected = command.ExecuteNonQuery();
                Info["status"] = "success";
                Info.Add("rowsAffected", rowsAffected.ToString());
            }

            catch(Exception ex)
            {
                Info["status"] = "error";
                Info.Add("message", ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return JsonConvert.SerializeObject(Info);
        }

    }
}