select o.id            as Id,
       o.type          as Type,
       o.status        as Status,
       o.create_date   as CreateDate,
       o.delivery_date as DeliveryDate,
       u.username      as Username,
       sum(pri.weight) as TotalWeight,
       sum(od.amount)  as TotalPrice
from orders o
         left join users u on u.id = o.user_id
         left join orders_item oi on o.id = oi.order_id
         left join product_item pri on oi.product_item_id = pri.id
         left join operation op on o.id = op.order_id
         left join operation_detail od on op.id = od.operation_id
group by o.id, o.type, o.status, o.create_date, o.delivery_date, u.username;