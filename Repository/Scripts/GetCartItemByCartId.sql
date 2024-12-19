select ci.id,
       pri.id,
       p.name,
       p.price,
       pri.color,
       pri.size,
       ci.quantity,
       ci.is_selected
from cart_item ci
         join product_item pri on ci.product_item_id = pri.id
         join product p on pri.product_id = p.id
where cart_id = @id;