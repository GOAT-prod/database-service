select id  as Id,
       url as Url
from image
where product_id = @id;