using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("André Turismos");

        #region Objects
        City city = new City()
        {
            Description = "São Paulo",
            RegisterDate = DateTime.Now,
        };

        City city2 = new() 
        {
            Description = "Manaus",
            RegisterDate = DateTime.Now,
        };

        City city3 = new()
        {
            Description = "Bauru",
            RegisterDate = DateTime.Now,
        };

        Address address = new Address()
        {
            Street = "Rua 0",
            Number = 70,
            Neighborhood = "Aquela lá",
            Complement = "Na esquina",
            ZipCode = "14872-248",
            City = city,
            RegisterDate = DateTime.Now,
        };

        Address address2 = new Address()
        {
            Street = "Rua Sete",
            Number = 81,
            Neighborhood = "Tal",
            Complement = "Na frente da árvore azul",
            ZipCode = "17214-874",
            City = city2,
            RegisterDate = DateTime.Now,
        };

        Address origin = new Address()
        {
            Street = "Praça Comandante Linneu Gomes",
            Number = 468,
            Neighborhood = "Santo Amaro",
            Complement = "Na placa escrita aeroporto",
            ZipCode = "04626-911",
            City = city,
            RegisterDate = DateTime.Now,
        };

        Client client = new Client()
        {
            Name = "Gabriel Brandão",
            Phone = "98765-4321",
            Address = address,
            RegisterDate = DateTime.Now
        };

        Hotel hotel = new()
        {
            Name = "Hotel Genérico",
            Address = address2,
            Value = 475.58,
            RegisterDate = DateTime.Now
        };

        Ticket ticket = new()
        {
            Origin = origin,
            Destination = address2,
            Client = client,
            Date = new DateTime(2024, 2, 17, 8, 30, 00),
            Value = 452.33
        };

        Package package = new()
        {
            Hotel = hotel,
            Ticket = ticket,
            Client = client,
            Value = 2013.54,
            RegisterDate = DateTime.Now
        };
        #endregion

        #region City
        ////Create
        //Console.WriteLine(new CityController().Insert(city3) ? "Cidade Inserida" : "Erro ao inserir");
        ////Read
        //new CityController().FindAll().ForEach(c => Console.WriteLine(c));
        ////Update
        //Console.WriteLine("Digite o id da cidade a ser atualizada: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Update(upd, city3) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id da cidade a ser apagada: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion

        #region Address
        ////Create
        //Console.WriteLine(new AddressController().Insert(origin) ? "Endereço Inserido" : "Erro ao inserir");
        ////Read
        //new AddressController().FindAll().ForEach(a => Console.WriteLine(a));
        ////Update
        //Console.WriteLine("Digite o id do endereço a ser atualizado: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new AddressController().Update(upd, address2) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id do endereço a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new AddressController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion

        #region Client
        ////Create
        //Console.WriteLine(new ClientController().Insert(client) ? "Cliente Inserido" : "Erro ao inserir");
        ////Read
        //new ClientController().FindAll().ForEach(c => Console.WriteLine(c));
        ////Update
        //Console.WriteLine("Digite o id do cliente a ser atualizado: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new ClientController().Update(upd, client) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id do cliente a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new ClientController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion

        #region Hotel
        ////Create
        //Console.WriteLine((new HotelController().Insert(hotel) ? "Hotel Inserido" : "Erro ao inserir"));
        ////Read
        //new HotelController().FindAll().ForEach(h => Console.WriteLine(h));
        ////Update
        //Console.WriteLine("Digite o id do hotel a ser atualizado: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new HotelController().Update(upd, hotel) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id do hotel a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new HotelController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion

        #region Ticket
        ////Create
        //Console.WriteLine((new TicketController().Insert(ticket) ? "Passagem Inserida" : "Erro ao inserir"));
        ////Read
        //new TicketController().FindAll().ForEach(t => Console.WriteLine(t));
        ////Update
        //Console.WriteLine("Digite o id da passagem a ser atualizada: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new TicketController().Update(upd, ticket) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id da passagem a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new TicketController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion

        #region Package
        ////Create
        //Console.WriteLine((new PackageController().Insert(package) ? "Pacote Inserido" : "Erro ao inserir"));
        ////Read
        //new PackageController().FindAll().ForEach(p => Console.WriteLine(p));
        ////Update
        //Console.WriteLine("Digite o id do pacote a ser atualizado: ");
        //int upd = int.Parse(Console.ReadLine());
        //Console.WriteLine(new PackageController().Update(upd, package) ? "Atualizado com sucesso" : "Erro ao atualizar");
        ////Delete
        //Console.WriteLine("Digite o id do pacote a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new PackageController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");
        #endregion
    }
}