select o.id,
       o.type,
       o.status,
       o.create_date,
       o.delivery_date,
       u.username,
       sum(pri.weight) as TotalWeight,
       sum(od.amount)  as TotalPrice
from orders o
         join users u on u.id = o.user_id
         join orders_item oi on o.id = oi.order_id
         join product_item pri on oi.product_item_id = pri.id
         join operation o on o.id = o.order_id
         join operation_detail od on o.id = od.operation_id
where u.id = @id
group by o.id, o.type, o.status, o.create_date, o.delivery_date, u.username;