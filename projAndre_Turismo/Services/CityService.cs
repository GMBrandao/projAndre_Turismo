using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using projAndre_Turismo.Models;

namespace projAndre_Turismo.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(City city)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into City (Description, RegisterDate) values (@Description, @RegisterDate)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", city.RegisterDate));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public List<City> FindAll()
        {

            List<City> cities = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, c.Description, c.RegisterDate from City c ");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new();

                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
                city.RegisterDate = (DateTime)dr["RegisterDate"];

                cities.Add(city);
            }
            return cities;
        }

        public int FindCity(City city)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cast(Id as int) from City c ");
            sb.Append("WHERE c.Description = @Description");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            commandSelect.Parameters.Add(new SqlParameter("@Description", city.Description));

            return (int)commandSelect.ExecuteScalar();
        }

        public bool Update(int Id, City city) 
        {
            bool status = false;

            string commandUpdate = "UPDATE City SET Description = @Description WHERE Id = @Id";

            try
            {
                SqlCommand Update = new(commandUpdate, conn);
                Update.Parameters.Add(new SqlParameter("@Description", city.Description));
                Update.Parameters.Add(new SqlParameter("@Id", Id));
                Update.ExecuteNonQuery();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool Delete(int Id)
        {
            bool status = false;

            string commandDelete = ("DELETE FROM City WHERE Id = @Id");

            try 
            {
                SqlCommand Delete  = new(commandDelete, conn);
                Delete.Parameters.Add(new SqlParameter("@Id", Id));
                Delete.ExecuteNonQuery();
                status = true;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
                status = false;
                throw;
            } 
            finally 
            {
                conn.Close();
            }

            return status;
        }
    }
}
