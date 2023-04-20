select cast(a.Id as int) from Address a right join City c on c.Description = 'Manaus'
WHERE a.Street = 'Rua 0' AND a.Number = 70 AND a.Neighborhood = 'Aquela lá' 
AND a.ZipCode = '14872-248' AND a.Complement = 'Na esquina'


select cast(c.Id as int) from Client c 
inner join Address a on a.Street = 'Rua 0' AND a.Number = 70 
AND a.Neighborhood = 'Aquela lá' AND a.ZipCode = '14872-248' 
AND a.Complement = 'Na esquina' right join City ct on ct.Description = 'São Paulo'
WHERE c.Name = 'Gabriel Brandão' AND c.Phone = '98765-4321' 


select t.Id, t.Value, t.IdOriginAddress, a.Street as originStreet, a.Number as originNumber, 
a.Neighborhood as originNeighborhood, a.ZipCode as originZipCode, 
a.Complement as originComplement, a.IdCity as originIdCity, ct.Description as originDescription, t.Date, 
t.IdDestinationAddress, a.Street as destinationStreet, a.Number as destinationNumber, 
a.Neighborhood as destinationNeighborhood, a.ZipCode as destinationZipCode, 
a.Complement as destinationComplement, a.IdCity as destinationIdCity, ct.Description as destinationDescription, 
t.IdClient, c.Name, c.Phone, c.IdAddress as IdClientAddress, a.Street as clientStreet, a.Number as clientNumber, 
a.Neighborhood as clientNeighborhood, a.ZipCode as clientZipCode, 
a.Complement as clientComplement, a.IdCity as clientIdCity, ct.Description as clientCityDescription, c.RegisterDate 
from Ticket t, Address a, City ct, Client c 
WHERE a.IdCity = ct.Id AND a.Id = t.IdOriginAddress AND a.Id = t.IdDestinationAddress AND t.IdClient = c.Id 


select * from Ticket
select * FROM Address
select * FROM CITY
select * from Client
select * from Hotel