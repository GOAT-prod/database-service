update product_item
set color  = @color,
    size   = @size,
    weight = @weight
where id = @id;