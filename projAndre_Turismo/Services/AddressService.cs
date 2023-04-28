using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;

namespace projAndre_Turismo.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Address address)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into Address (Street, Number, Neighborhood, ZipCode, Complement, IdCity, RegisterDate) " +
                    "values (@Street, @Number, @Neighborhood, @ZipCode, @Complement, @IdCity, @RegisterDate)";
                
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                City city = new();
                city = address.City;

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", new CityController().FindCity(city)));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", address.RegisterDate));

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

        public List<Address> FindAll()
        {

            List<Address> addresses = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, a.Street, a.Number, a.Neighborhood, a.ZipCode, a.Complement, a.IdCity, c.Description, a.RegisterDate from Address a, City c ");
            sb.Append("WHERE a.IdCity = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Address address = new();
                City city = new City();
                address.Id = (int)dr["Id"];
                address.Street = (string)dr["Street"];
                address.Number = (int)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.ZipCode = (string)dr["ZipCode"];
                address.Complement = (string)dr["Complement"];
                city.Id = (int)dr["IdCity"];
                city.Description = (string)dr["Description"];
                address.RegisterDate = (DateTime)dr["RegisterDate"];

                address.City = city;
                addresses.Add(address);
            }
            return addresses;
        }

        public int FindAddress(Address address)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cast(a.Id as int) from Address a ");
            sb.Append("join City c on c.Description = @CityDescription ");
            sb.Append("WHERE a.Street = @Street AND a.Number = @Number ");
            sb.Append("AND a.Neighborhood = @Neighborhood AND a.ZipCode = @ZipCode ");
            sb.Append("AND a.Complement = @Complement");

            SqlCommand commandSelect = new(sb.ToString(), conn);

            City city = address.City;

            commandSelect.Parameters.Add(new SqlParameter("@CityDescription", city.Description));
            commandSelect.Parameters.Add(new SqlParameter("@Street", address.Street));
            commandSelect.Parameters.Add(new SqlParameter("@Number", address.Number));
            commandSelect.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            commandSelect.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
            commandSelect.Parameters.Add(new SqlParameter("@Complement", address.Complement));

            return (int)commandSelect.ExecuteScalar();
        }

        public bool Delete(int Id)
        {
            bool status = false;

            string commandDelete = ("DELETE FROM Address WHERE Id = @Id");

            try
            {
                SqlCommand Delete = new(commandDelete, conn);
                Delete.Parameters.Add(new SqlParameter("@Id", Id));
                Delete.ExecuteNonQuery();
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
    }
}
