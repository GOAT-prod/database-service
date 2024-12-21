SELECT r.name AS Role,
       count(1) as Count,
       json_agg(json_build_object(
               'Id', u.id,
               'Username', u.username,
               'Password', u.password,
               'Role', r.name,
               'ClientId', c.id,
               'Name', c.name,
               'Address', c.address,
               'INN', c.inn,
               'Status', u.status
                )) AS Users
FROM users u
    JOIN client c
ON c.id = u.client_id
    JOIN role r ON r.id = u.role_id
WHERE u.role_id <> 1 -- Исключаем пользователей с role_id = 1
GROUP BY r.name;
