select ci.id     as Id,
       pri.id    as ProductItemId,
       p.name    as ProductName,
       p.price   as Price,
       pri.color as Color,
       pri.size as Size,
       ci.quantity as SelectCount,
       ci.is_selected as IsSelected
from cart_item ci
    join product_item pri
on ci.product_item_id = pri.id
    join product p on pri.product_id = p.id
where ci.cart_id = @id;