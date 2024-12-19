select p.id,
       c.id,
       c.name,
       p.name,
       p.price,
       p.status
from product p
         join client c on c.id = p.id;