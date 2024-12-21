with avaregeBuyPrice as (select o.user_id as    UserId,
                                avg(opd.amount) AvgAmount
                         from orders o
                                  join operation op on o.id = op.order_id
                                  join operation_detail opd on op.id = opd.operation_id
                         where o.user_id = @id
                         group by o.user_id)
select o.id            as Id,
       o.type          as Type,
       o.status        as Status,
       o.create_date   as CreateDate,
       o.delivery_date as DeliveryDate,
       u.username      as Username,
       sum(pri.weight) as TotalWeight,
       sum(od.amount)  as TotalPrice,
       abp.AvgAmount   as AveragePrice
from avaregeBuyPrice abp
         join orders o on o.user_id = abp.UserId
         join users u on u.id = o.user_id
         join orders_item oi on o.id = oi.order_id
         join product_item pri on oi.product_item_id = pri.id
         join operation op on o.id = op.order_id
         join operation_detail od on op.id = od.operation_id
where u.id = @id
group by o.id, o.type, o.status, o.create_date, o.delivery_date, u.username, abp.AvgAmount;