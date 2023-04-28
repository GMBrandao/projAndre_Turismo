using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;

namespace projAndre_Turismo.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into Package (IdHotel, IdTicket, Value, IdClient, RegisterDate) " +
                    "values (@Hotel, @Ticket, @Value, @Client, @RegisterDate)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                Ticket ticket = new();
                Client client = new();
                Hotel hotel = new();
                Address addressClient = new();
                Address addressHotel = new();

                ticket = package.Ticket;
                client = package.Client;
                hotel = package.Hotel;
                addressClient = client.Address;
                addressHotel = hotel.Address;

                commandInsert.Parameters.Add(new SqlParameter("@Hotel", new HotelController().FindHotel(hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket", new TicketController().FindTicket(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Client", new ClientController().FindClient(client)));
                commandInsert.Parameters.Add(new SqlParameter("@Value", package.Value));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", package.RegisterDate));

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

        public List<Package> FindAll()
        {
            List<Package> packages = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.Id, p.Value as packageValue, p.RegisterDate as packageRegDate, ");
            sb.Append("p.IdHotel, h.Name as hotelName, h.Value as hotelValue, h.IdAddress as IdHotelAddress, ");
            sb.Append("ah.Street as hotelStreet, ah.Number as hotelNumber, ah.Neighborhood as hotelNeighborhood, ");
            sb.Append("ah.ZipCode as hotelZipCode, ah.Complement as hotelComplement, ");
            sb.Append("ah.IdCity as hotelIdCity, cth.Description as hotelCityDescription, ");
            sb.Append("p.IdClient, c.Name as clientName, c.Phone as clientPhone, ");
            sb.Append("c.IdAddress as IdClientAddress, ac.Street as clientStreet, ac.Neighborhood as clientNeighborhood, ");
            sb.Append("ac.ZipCode as clientZipCode, ac.Complement as clientComplement, ac.Number as clientNumber, ");
            sb.Append("ac.IdCity as clientIdCity, ctc.Description as clientCityDescription, ");
            sb.Append("p.IdTicket, t.Value as ticketValue, t.Date as ticketDate, ");
            sb.Append("t.IdOriginAddress, ao.Street as originStreet, ao.Number as originNumber, ");
            sb.Append("ao.Neighborhood as originNeighborhood, ao.ZipCode as originZipCode, ao.Complement as originComplement, ");
            sb.Append("ao.IdCity as originIdCity, cto.Description as originDescription, ");
            sb.Append("t.IdDestinationAddress, ad.Street as destinationStreet, ad.Number as destinationNumber, ");
            sb.Append("ad.Neighborhood as destinationNeighborhood, ad.ZipCode as destinationZipCode, ad.Complement as destinationComplement, ");
            sb.Append("ad.IdCity as destinationIdCity, ctd.Description as destinationDescription, ");
            sb.Append("t.IdClient as IdTicketClient, tc.Name as TicketClientName, tc.Phone as TicketClientPhone, ");
            sb.Append("tc.IdAddress as IdTicketClientAddress, tac.Street as TicketClientStreet, tac.Number as TicketClientNumber, ");
            sb.Append("tac.ZipCode as TicketClientZipCode, tac.Complement as TicketClientComplement, tac.Neighborhood as TicketClientNeighborhood, ");
            sb.Append("tac.IdCity as TicketClientIdCity, tctc.Description as TicketClientCityDescription, ");
            sb.Append("tc.RegisterDate as tClientRG, h.RegisterDate as hotelRG, c.RegisterDate as clientRG ");
            sb.Append("FROM Package p ");
            sb.Append("left join Hotel h on h.Id = p.IdHotel ");
            sb.Append("join Address ah on ah.Id = h.IdAddress join City cth on ah.IdCity = cth.Id ");
            sb.Append("left join Client c on c.Id = p.IdClient ");
            sb.Append("join Address ac on ac.Id = c.IdAddress join City ctc on ac.IdCity = ctc.Id ");
            sb.Append("left join Ticket t on t.Id = p.IdTicket ");
            sb.Append("join Address ao on ao.Id = t.IdOriginAddress join City cto on ao.IdCity = cto.Id ");
            sb.Append("join Address ad on ad.Id = t.IdDestinationAddress join City ctd on ad.IdCity = ctd.Id ");
            sb.Append("join Client tc on tc.Id = t.IdClient ");
            sb.Append("join Address tac on tac.Id = tc.IdAddress join City tctc on tac.IdCity = tctc.Id ");
            sb.Append("WHERE p.IdClient = c.Id AND p.IdTicket = t.Id AND p.IdHotel = h.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package package = new();
                Hotel hotel = new();
                Address hotelAddress = new();
                City hotelCity = new();
                Ticket ticket = new();
                Address originAddress = new();
                City originCity = new();
                Address destinationAddress = new();
                City destinationCity = new();
                Address ticketClientAddress = new();
                Client ticketClient = new();
                City ticketClientCity = new();
                Client client = new();
                Address clientAddress = new();
                City clientCity = new();

                package.Id = (int)dr["Id"];
                package.Value = (double)(decimal)dr["packageValue"];
                package.RegisterDate = (DateTime)dr["packageRegDate"];

                hotel.Id = (int)dr["IdHotel"];
                hotel.Name = (string)dr["hotelName"];
                hotel.Value = (double)(decimal)dr["hotelValue"];
                hotel.RegisterDate = (DateTime)dr["hotelRG"];
                hotelAddress.Id = (int)dr["IdHotelAddress"];
                hotelAddress.Street = (string)dr["hotelStreet"];
                hotelAddress.Number = (int)dr["hotelNumber"];
                hotelAddress.Neighborhood = (string)dr["hotelNeighborhood"];
                hotelAddress.ZipCode = (string)dr["hotelZipCode"];
                hotelAddress.Complement = (string)dr["hotelComplement"];
                hotelCity.Id = (int)dr["hotelIdCity"];
                hotelCity.Description = (string)dr["hotelCityDescription"];

                hotelAddress.City = hotelCity;
                hotel.Address = hotelAddress;

                client.Id = (int)dr["IdClient"];
                client.Name = (string)dr["clientName"];
                client.Phone = (string)dr["clientPhone"];
                client.RegisterDate = (DateTime)dr["clientRG"];
                clientAddress.Id = (int)dr["IdClientAddress"];
                clientAddress.Street = (string)dr["clientStreet"];
                clientAddress.Number = (int)dr["clientNumber"];
                clientAddress.Neighborhood = (string)dr["clientNeighborhood"];
                clientAddress.ZipCode = (string)dr["clientZipCode"];
                clientAddress.Complement = (string)dr["clientComplement"];
                clientCity.Id = (int)dr["clientIdCity"];
                clientCity.Description = (string)dr["clientCityDescription"];

                clientAddress.City = clientCity;
                client.Address = clientAddress;

                ticket.Id = (int)dr["IdTicket"];
                ticket.Value = (double)(decimal)dr["ticketValue"];
                ticket.Date = (DateTime)dr["ticketDate"];

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

                ticketClient.Id = (int)dr["IdTicketClient"];
                ticketClient.Name = (string)dr["TicketClientName"];
                ticketClient.Phone = (string)dr["TicketClientPhone"];
                ticketClient.RegisterDate = (DateTime)dr["tClientRG"];
                ticketClientAddress.Id = (int)dr["IdTicketClientAddress"];
                ticketClientAddress.Street = (string)dr["TicketClientStreet"];
                ticketClientAddress.Number = (int)dr["TicketClientNumber"];
                ticketClientAddress.Neighborhood = (string)dr["TicketClientNeighborhood"];
                ticketClientAddress.ZipCode = (string)dr["TicketClientZipCode"];
                ticketClientAddress.Complement = (string)dr["TicketClientComplement"];
                ticketClientCity.Id = (int)dr["TicketClientIdCity"];
                ticketClientCity.Description = (string)dr["TicketClientCityDescription"];

                originAddress.City = originCity;
                destinationAddress.City = destinationCity;
                ticket.Origin = originAddress;
                ticket.Destination = destinationAddress;
                ticketClientAddress.City = clientCity;
                ticketClient.Address = clientAddress;
                ticket.Client = ticketClient;

                package.Ticket = ticket;
                package.Client = client;
                package.Hotel = hotel;

                packages.Add(package);
            }

            return packages;
        }

        public bool Update(int Id, Package package)
        {
            bool status = false;

            try
            {
                Ticket ticket = package.Ticket;
                Client client = package.Client;
                Hotel hotel = package.Hotel;
                Address addressClient = client.Address;
                Address addressHotel = hotel.Address;

                StringBuilder commandUpdate = new();

                commandUpdate.Append("UPDATE Client SET ");
                commandUpdate.Append("IdTicket = @Ticket, IdHotel = @Hotel, ");
                commandUpdate.Append("IdClient = @Client, Value = @Value ");
                commandUpdate.Append("WHERE Id = @Id");

                SqlCommand Update = new(commandUpdate.ToString(), conn);

                Update.Parameters.Add(new SqlParameter("@Hotel", new HotelController().FindHotel(hotel)));
                Update.Parameters.Add(new SqlParameter("@Ticket", new TicketController().FindTicket(ticket)));
                Update.Parameters.Add(new SqlParameter("@Client", new ClientController().FindClient(client)));
                Update.Parameters.Add(new SqlParameter("@Value", package.Value));

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

            string commandDelete = ("DELETE FROM Package WHERE Id = @Id");

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
