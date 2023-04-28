using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;

namespace projAndre_Turismo.Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Client client)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into Client (Name, Phone, IdAddress, RegisterDate) " +
                    "values (@Name, @Phone, @IdAddress, @RegisterDate)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                Address address = new();
                address = client.Address;

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressController().FindAddress(address)));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", client.RegisterDate));

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

        public List<Client> FindAll()
        {

            List<Client> clients = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, c.Name, c.Phone, c.IdAddress, a.Street, a.Number, a.Neighborhood, a.ZipCode, ");
            sb.Append("a.Complement, a.IdCity, ct.Description, c.RegisterDate from Client c, Address a, City ct ");
            sb.Append("WHERE a.IdCity = ct.Id AND a.Id = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new();
                Address address = new();
                City city = new();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Phone = (string)dr["Phone"];
                client.RegisterDate = (DateTime)dr["RegisterDate"];

                address.Id = (int)dr["IdAddress"];
                address.Street = (string)dr["Street"];
                address.Number = (int)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.ZipCode = (string)dr["ZipCode"];
                address.Complement = (string)dr["Complement"];

                city.Id = (int)dr["IdCity"];
                city.Description = (string)dr["Description"];

                address.City = city;
                client.Address = address;

                clients.Add(client);
            }
            return clients;
        }

        public int FindClient(Client client)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cast(c.Id as int) from Client c ");
            sb.Append("inner join Address a on a.Street = @Street AND a.Number = @Number ");
            sb.Append("AND a.Neighborhood = @Neighborhood AND a.ZipCode = @ZipCode ");
            sb.Append("AND a.Complement = @Complement right join City ct on ct.Description = @CityDescription ");
            sb.Append("WHERE c.Name = @Name AND c.Phone = @Phone ");

            SqlCommand commandSelect = new(sb.ToString(), conn);

            commandSelect.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandSelect.Parameters.Add(new SqlParameter("@Phone", client.Phone));

            commandSelect.Parameters.Add(new SqlParameter("@Street", client.Address.Street));
            commandSelect.Parameters.Add(new SqlParameter("@Number", client.Address.Number));
            commandSelect.Parameters.Add(new SqlParameter("@Neighborhood", client.Address.Neighborhood));
            commandSelect.Parameters.Add(new SqlParameter("@ZipCode", client.Address.ZipCode));
            commandSelect.Parameters.Add(new SqlParameter("@CityDescription", client.Address.City.Description));
            commandSelect.Parameters.Add(new SqlParameter("@Complement", client.Address.Complement));

            return (int)commandSelect.ExecuteScalar();
        }
    }
}
