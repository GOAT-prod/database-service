update product
set name   = @name,
    status = @status,
    price  = @price
where id = @id;