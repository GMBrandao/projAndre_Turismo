select cast(a.Id as int) from Address a right join City c on c.Description = 'Manaus'
WHERE a.Street = 'Rua 0' AND a.Number = 70 AND a.Neighborhood = 'Aquela lá' 
AND a.ZipCode = '14872-248' AND a.Complement = 'Na esquina'


select cast(c.Id as int) from Client c 
inner join Address a on a.Street = 'Rua 0' AND a.Number = 70 
AND a.Neighborhood = 'Aquela lá' AND a.ZipCode = '14872-248' 
AND a.Complement = 'Na esquina' right join City ct on ct.Description = 'São Paulo'
WHERE c.Name = 'Gabriel Brandão' AND c.Phone = '98765-4321' 


select t.Id, t.Value, t.IdOriginAddress, ao.Street as originStreet, ao.Number as originNumber, 
ao.Neighborhood as originNeighborhood, ao.ZipCode as originZipCode, 
ao.Complement as originComplement, ao.IdCity as originIdCity, cto.Description as originDescription, t.Date, 
t.IdDestinationAddress, ad.Street as destinationStreet, ad.Number as destinationNumber, 
ad.Neighborhood as destinationNeighborhood, ad.ZipCode as destinationZipCode, 
ad.Complement as destinationComplement, ad.IdCity as destinationIdCity, ctd.Description as destinationDescription, 
t.IdClient, c.Name, c.Phone, c.IdAddress as IdClientAddress, ac.Street as clientStreet, ac.Number as clientNumber, 
ac.Neighborhood as clientNeighborhood, ac.ZipCode as clientZipCode, 
ac.Complement as clientComplement, ac.IdCity as clientIdCity, ctc.Description as clientCityDescription, c.RegisterDate 
from Ticket t 
join Address ao on ao.Id = t.IdOriginAddress right join City cto on ao.IdCity = cto.Id 
join Address ad on ad.Id = t.IdDestinationAddress right join City ctd on ad.IdCity = ctd.Id 
join Client c on c.Id = t.IdClient
join Address ac on c.IdAddress = ac.Id right join City ctc on ac.IdCity = ctc.Id 
WHERE ao.Id = t.IdOriginAddress AND ad.Id = t.IdDestinationAddress AND t.IdClient = c.Id

select p.Id, p.Value as packageValue, p.RegisterDate as packageRegDate, 
p.IdHotel, h.Name as hotelName, h.Value as hotelValue, 
ah.Street as hotelStreet, ah.Number as hotelNumber, ah.Neighborhood as hotelNeighborhood, 
ah.ZipCode as hotelZipCode, ah.Complement as hotelComplement, 
ah.IdCity as hotelIdCity, cth.Description as hotelDescription, 
p.IdClient, c.Name, c.Phone, 
c.IdAddress as IdClientAddress, ac.Street as clientStreet,  ac.Neighborhood as clientNeighborhood, 
ac.ZipCode as clientZipCode, ac.Complement as clientComplement, ac.Number as clientNumber, 
ac.IdCity as clientIdCity, ctc.Description as clientCityDescription, 
p.IdTicket, t.Value, t.Date, 
t.IdOriginAddress, ao.Street as originStreet, ao.Number as originNumber, 
ao.Neighborhood as originNeighborhood, ao.ZipCode as originZipCode, ao.Complement as originComplement,
ao.IdCity as originIdCity, cto.Description as originDescription,
t.IdDestinationAddress, ad.Street as destinationStreet, ad.Number as destinationNumber, 
ad.Neighborhood as destinationNeighborhood, ad.ZipCode as destinationZipCode, ad.Complement as destinationComplement,  
ad.IdCity as destinationIdCity, ctd.Description as destinationDescription, 
t.IdClient, tc.Name, tc.Phone as TicketClientPhone, 
tc.IdAddress as IdTicketClientAddress, tac.Street as TicketClientStreet, tac.Number as TicketClientNumber,  
tac.ZipCode as TicketClientZipCode, tac.Complement as TicketClientComplement, tac.Neighborhood as TicketClientNeighborhood,
tac.IdCity as TicketClientIdCity, tctc.Description as TicketClientCityDescription 
FROM Package p 
left join Hotel h on h.Id = p.IdHotel 
join Address ah on ah.Id = h.IdAddress join City cth on ah.IdCity = cth.Id 
left join Client c on c.Id = p.IdClient
join Address ac on ac.Id = c.IdAddress join City ctc on ac.IdCity = ctc.Id 
left join Ticket t on t.Id = pIdTicket
join Address ao on ao.Id = t.IdOriginAddress join City cto on ao.IdCity = cto.Id 
join Address ad on ad.Id = t.IdDestinationAddress join City ctd on ad.IdCity = ctd.Id 
join Client tc on tc.Id = t.IdClient 
join Address tac on tac.Id = tc.IdAddress join City tctc on tac.IdCity = tctc.Id 
WHERE p.Client = c.Id AND p.IdTicket = t.Id AND p.IdHotel = h.Id 

select * from Ticket
select * FROM Address
select * FROM CITY
select * from Client
select * from Hotel