select u.id       as Id,
       u.username as Username,
       u.password as Password,
       r.name     as Role,
       c.id       as ClientId,
       c.name     as Name,
       c.address  as Address,
       c.inn      as INN,
       u.status   as Status
from users u
         join client c on c.id = u.client_id
         join role r on r.id = u.role_id
where u.role_id <> 1