insert into cart (user_id, create_date)
values (@user_id, @create_date)
returning id;