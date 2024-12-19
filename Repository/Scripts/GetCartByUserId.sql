select id      as Id,
       user_id as UserId
from cart
where user_id = @id