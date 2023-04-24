using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

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
        //string strCity = (new CityController().Insert(city2) ? "Cidade Inserida" : "Erro ao inserir");
        //Console.WriteLine(strCity);
        //var cities = new CityController().FindAll();
        //cities.ForEach(c => Console.WriteLine(c));

        //Address
        //string strAddress = (new AddressController().Insert(origin) ? "Endereço Inserido" : "Erro ao inserir");
        //Console.WriteLine(strAddress);
        //var addresses = new AddressController().FindAll();
        //addresses.ForEach(c => Console.WriteLine(c));


        //Client
        //Console.WriteLine((new ClientController().Insert(client) ? "Cliente Inserido" : "Erro ao inserir"));
        //new ClientController().FindAll().ForEach(c => Console.WriteLine(c));

        //Hotel
        //Console.WriteLine((new HotelController().Insert(hotel) ? "Hotel Inserido" : "Erro ao inserir"));
        //new HotelController().FindAll().ForEach(h => Console.WriteLine(h));

        //Ticket
        //Console.WriteLine((new TicketController().Insert(ticket) ? "Passagem Inserida" : "Erro ao inserir"));
        //new TicketController().FindAll().ForEach(t => Console.WriteLine(t));

        //Package

    }
}