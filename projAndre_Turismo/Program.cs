using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("André Turismos");

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
            Description = "Ribeirão Preto",
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

        //City
        //Console.WriteLine(new CityController().Insert(city3) ? "Cidade Inserida" : "Erro ao inserir");
        //new CityController().FindAll().ForEach(c => Console.WriteLine(c));
        //Console.WriteLine("Digite o id da cidade a ser apagada: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");

        //Address
        //Console.WriteLine(new AddressController().Insert(origin) ? "Endereço Inserido" : "Erro ao inserir");
        //new AddressController().FindAll().ForEach(a => Console.WriteLine(a));
        //Console.WriteLine("Digite o id do endereço a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");



        //Client
        //Console.WriteLine(new ClientController().Insert(client) ? "Cliente Inserido" : "Erro ao inserir");
        //new ClientController().FindAll().ForEach(c => Console.WriteLine(c));
        //Console.WriteLine("Digite o id do cliente a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");


        //Hotel
        //Console.WriteLine((new HotelController().Insert(hotel) ? "Hotel Inserido" : "Erro ao inserir"));
        //new HotelController().FindAll().ForEach(h => Console.WriteLine(h));
        //Console.WriteLine("Digite o id do hotel a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");


        //Ticket
        //Console.WriteLine((new TicketController().Insert(ticket) ? "Passagem Inserida" : "Erro ao inserir"));
        //new TicketController().FindAll().ForEach(t => Console.WriteLine(t));
        //Console.WriteLine("Digite o id da passagem a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");


        //Package
        //Console.WriteLine((new PackageController().Insert(package) ? "Pacote Inserido" : "Erro ao inserir"));
        //new PackageController().FindAll().ForEach(p => Console.WriteLine(p));
        //Console.WriteLine("Digite o id do pacote a ser apagado: ");
        //int del = int.Parse(Console.ReadLine());
        //Console.WriteLine(new CityController().Delete(del) ? "Deletado com sucesso" : "Erro ao deletar");

    }
}