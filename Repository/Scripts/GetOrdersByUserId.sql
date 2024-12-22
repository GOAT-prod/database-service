with avaregeBuyPrice as (select o.user_id as    UserId,
                                avg(opd.amount) AvgAmount
                         from orders o
                                  join operation op on o.id = op.order_id
                                  join operation_detail opd on op.id = opd.operation_id
                         where o.user_id = @id
                         group by o.user_id),
     totalWeights as (select oi.order_id                   as OrderId,
                             sum(pri.weight * oi.quantity) as TotalWeight
                      from orders_item oi
                               join product_item pri on oi.product_item_id = pri.id
                      group by oi.order_id)
select distinct o.id            as Id,
                o.type          as Type,
                o.status        as Status,
                o.create_date   as CreateDate,
                o.delivery_date as DeliveryDate,
                u.username      as Username,
                tw.TotalWeight  as TotalWeight,
                od.amount       as TotalPrice,
                abp.AvgAmount   as AveragePrice
from avaregeBuyPrice abp
         join orders o on o.user_id = abp.UserId
         join totalWeights tw on tw.OrderId = o.id
         join users u on u.id = o.user_id
         join orders_item oi on o.id = oi.order_id
         join product_item pri on oi.product_item_id = pri.id
         join operation op on o.id = op.order_id
         join operation_detail od on op.id = od.operation_id
where u.id = @id;