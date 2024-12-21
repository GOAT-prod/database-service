select p.id     as Id,
       c.id     as FactoryId,
       c.name   as FactoryName,
       p.brand  as Brand,
       p.name   as Name,
       p.price  as Price,
       p.status as Status
from product p
         join client c on c.id = p.factory_id;