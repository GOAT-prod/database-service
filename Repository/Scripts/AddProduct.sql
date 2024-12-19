insert into product (name, brand, price, status, factory_id)
values (@name, @brand, @price, @status, @factory_id)
returning id;