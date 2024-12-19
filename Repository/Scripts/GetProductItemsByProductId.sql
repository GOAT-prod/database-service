select id         as Id,
       product_id as ProductId,
       color      as Color, 
       size       as Size, 
       weight     as Weight
from product_item
where product_id = @id;