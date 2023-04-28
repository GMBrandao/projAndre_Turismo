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
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Ticket ticket)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into Ticket (IdOriginAddress, IdDestinationAddress, IdClient, Date, Value) " +
                    "values (@IdOriginAddress, @IdDestinationAddress, @Client, @Date, @Value)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                Address address = new();
                Address address2 = new();
                address = ticket.Origin;
                address2 = ticket.Destination;
                Client client = new();
                client = ticket.Client;

                commandInsert.Parameters.Add(new SqlParameter("@IdOriginAddress", new AddressController().FindAddress(address)));
                commandInsert.Parameters.Add(new SqlParameter("@IdDestinationAddress", new AddressController().FindAddress(address2)));
                commandInsert.Parameters.Add(new SqlParameter("@Client", new ClientController().FindClient(client)));
                commandInsert.Parameters.Add(new SqlParameter("@Date", ticket.Date));
                commandInsert.Parameters.Add(new SqlParameter("@Value", ticket.Value));

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

        public List<Ticket> FindAll()
        {

            List<Ticket> tickets = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select t.Id, t.Value, t.IdOriginAddress, ao.Street as originStreet, ao.Number as originNumber, ");
            sb.Append("ao.Neighborhood as originNeighborhood, ao.ZipCode as originZipCode, ");
            sb.Append("ao.Complement as originComplement, ao.IdCity as originIdCity, cto.Description as originDescription, t.Date, ");
            sb.Append("t.IdDestinationAddress, ad.Street as destinationStreet, ad.Number as destinationNumber, ");
            sb.Append("ad.Neighborhood as destinationNeighborhood, ad.ZipCode as destinationZipCode, ");
            sb.Append("ad.Complement as destinationComplement, ad.IdCity as destinationIdCity, ctd.Description as destinationDescription, ");
            sb.Append("t.IdClient, c.Name, c.Phone, c.IdAddress as IdClientAddress, ac.Street as clientStreet, ac.Number as clientNumber, ");
            sb.Append("ac.Neighborhood as clientNeighborhood, ac.ZipCode as clientZipCode, ");
            sb.Append("ac.Complement as clientComplement, ac.IdCity as clientIdCity, ctc.Description as clientCityDescription, c.RegisterDate ");
            sb.Append("from Ticket t ");
            sb.Append("join Address ao on ao.Id = t.IdOriginAddress right join City cto on ao.IdCity = cto.Id ");
            sb.Append("join Address ad on ad.Id = t.IdDestinationAddress right join City ctd on ad.IdCity = ctd.Id ");
            sb.Append("join Client c on c.Id = t.IdClient ");
            sb.Append("join Address ac on c.IdAddress = ac.Id right join City ctc on ac.IdCity = ctc.Id ");
            sb.Append("WHERE ao.Id = t.IdOriginAddress AND ad.Id = t.IdDestinationAddress AND t.IdClient = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket ticket = new();
                Address originAddress = new();
                Address destinationAddress = new();
                Address clientAddress = new();
                City originCity = new();
                City destinationCity = new();
                City clientCity = new();
                Client client = new();

                ticket.Id = (int)dr["Id"];
                ticket.Value = (double)(decimal)dr["Value"];
                ticket.Date = (DateTime)dr["Date"];

                originAddress.Id = (int)dr["IdOriginAddress"];
                originAddress.Street = (string)dr["originStreet"];
                originAddress.Number = (int)dr["originNumber"];
                originAddress.Neighborhood = (string)dr["originNeighborhood"];
                originAddress.ZipCode = (string)dr["originZipCode"];
                originAddress.Complement = (string)dr["originComplement"];
                originCity.Id = (int)dr["originIdCity"];
                originCity.Description = (string)dr["originDescription"];

                destinationAddress.Id = (int)dr["IdDestinationAddress"];
                destinationAddress.Street = (string)dr["destinationStreet"];
                destinationAddress.Number = (int)dr["destinationNumber"];
                destinationAddress.Neighborhood = (string)dr["destinationNeighborhood"];
                destinationAddress.ZipCode = (string)dr["destinationZipCode"];
                destinationAddress.Complement = (string)dr["destinationComplement"];
                destinationCity.Id = (int)dr["destinationIdCity"];
                destinationCity.Description = (string)dr["destinationDescription"];

                client.Id = (int)dr["IdClient"];
                client.Name = (string)dr["Name"];
                client.Phone = (string)dr["Phone"];
                client.RegisterDate = (DateTime)dr["RegisterDate"];
                clientAddress.Id = (int)dr["IdClientAddress"];
                clientAddress.Street = (string)dr["clientStreet"];
                clientAddress.Number = (int)dr["clientNumber"];
                clientAddress.Neighborhood = (string)dr["clientNeighborhood"];
                clientAddress.ZipCode = (string)dr["clientZipCode"];
                clientAddress.Complement = (string)dr["clientComplement"];
                clientCity.Id = (int)dr["clientIdCity"];
                clientCity.Description = (string)dr["clientCityDescription"];


                originAddress.City = originCity;
                destinationAddress.City = destinationCity;
                ticket.Origin = originAddress;
                ticket.Destination = destinationAddress;
                clientAddress.City = clientCity;
                client.Address = clientAddress;
                ticket.Client = client;    

                tickets.Add(ticket);
            }
            return tickets;
        }

        public int FindTicket(Ticket ticket)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cast(t.Id as int) from Ticket t ");
            sb.Append("WHERE t.IdOriginAddress = @Origin AND t.IdDestinationAddress = @Destination AND ");
            sb.Append("t.IdClient = @Client");

            SqlCommand commandSelect = new(sb.ToString(), conn);

            
            commandSelect.Parameters.Add(new SqlParameter("@Origin", new AddressController().FindAddress(ticket.Origin)));
            commandSelect.Parameters.Add(new SqlParameter("@Destination", new AddressController().FindAddress(ticket.Destination)));
            commandSelect.Parameters.Add(new SqlParameter("@Client", new ClientController().FindClient(ticket.Client)));

            return (int) commandSelect.ExecuteScalar();
        }
    }
}
