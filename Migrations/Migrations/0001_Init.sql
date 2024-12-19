create table if not exists role
(
    id   serial primary key,
    name text
);

insert into role (name)
values ('admin'),
       ('shop'),
       ('factory');

create table if not exists client
(
    id      serial primary key,
    name    text not null,
    address text not null,
    inn     text not null
);

create table if not exists users
(
    id        serial primary key,
    username  text not null,
    password  text not null,
    status    text,
    role_id   integer references role (id),
    client_id integer references client (id)
    );

create table if not exists product
(
    id         serial primary key,
    name       text    not null,
    brand      text    not null,
    price      numeric not null,
    status     text,
    factory_id integer references client (id)
    );

create table if not exists product_item
(
    id         serial primary key,
    product_id integer references product (id),
    color      text    not null,
    size       decimal not null,
    weight     decimal not null,
    quantity   integer not null
    );

create table if not exists material
(
    id   serial primary key,
    name text not null
);

create table if not exists product_material
(
    id          serial primary key,
    product_id  integer references product (id),
    material_id integer references material (id)
    );

create table if not exists image
(
    id         serial primary key,
    product_id integer references product (id),
    url        text
    );

create table if not exists cart
(
    id          serial primary key,
    user_id     integer   not null references users (id),
    create_date timestamp not null,
    status      text      not null
    );

create table if not exists cart_item
(
    id              serial primary key,
    cart_id         integer references cart (id),
    product_item_id integer references product_item (id),
    quantity        integer
    );

create table if not exists orders
(
    id            uuid      not null primary key,
    user_id       integer references users (id),
    create_date   timestamp not null,
    delivery_date timestamp not null,
    status        text      not null,
    type          text      not null
    );

create table if not exists orders_item
(
    id              uuid    not null primary key,
    order_id        uuid references orders (id),
    product_item_id integer references product_item (id),
    quantity        integer not null
    );

create table if not exists operation
(
    id          uuid      not null primary key,
    date        timestamp not null,
    order_id    uuid references orders (id),
    description text      not null
    );

create table if not exists operation_detail
(
    id           uuid    not null primary key,
    operation_id uuid references operation (id),
    type         text,
    amount       numeric not null
    );