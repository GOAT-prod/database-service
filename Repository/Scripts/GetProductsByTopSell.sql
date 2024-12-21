select p.id               as Id,
       c.id               as FactoryId,
       c.name             as FactoryName,
       p.brand            as Brand,
       p.name             as Name,
       p.price            as Price,
       p.status           as Status,
       count(oi.quantity) as TotalBuy
from product p
         join client c on c.id = p.factory_id
         left join product_item pri on pri.product_id = p.id
         left join orders_item oi on oi.product_item_id = pri.id
group by p.id, c.id, c.name, p.brand, p.name, p.price, p.status
order by TotalBuy desc,
         Id;