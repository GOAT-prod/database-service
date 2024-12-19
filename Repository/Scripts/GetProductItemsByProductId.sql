select id,
       product_id,
       color,
    size,
    weight
from product_item
where product_id = @id;