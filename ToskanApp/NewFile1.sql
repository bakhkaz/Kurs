create table position
(
    id   int auto_increment
        primary key,
    name varchar(255) null
);

create table role
(
    id   int auto_increment
        primary key,
    name varchar(255) null
);

create table employee
(
    id          int auto_increment
        primary key,
    firstname   varchar(255) null,
    lastname    varchar(255) null,
    patronymic  varchar(255) null,
    role_id     int          null,
    position_id int          null,
    login       varchar(255) null,
    password    varchar(255) null,
    constraint employee_position_id_fk
        foreign key (position_id) references position (id),
    constraint employee_role_id_fk
        foreign key (role_id) references role (id)
);

create table type_expense
(
    id   int auto_increment
        primary key,
    name varchar(255) null
);

create table unit
(
    id   int auto_increment
        primary key,
    name varchar(255) null
);

create table product
(
    id             int auto_increment
        primary key,
    name           varchar(255) null,
    unit_id        int          null,
    count          float        null,
    expiration_day int          null,
    constraint product_unit_id_fk
        foreign key (unit_id) references unit (id)
);

create table accounting_for_receipts
(
    id               int auto_increment
        primary key,
    product_id       int      null,
    date_expiration  datetime null,
    date_manufacture datetime null,
    count            float    null,
    employee_id      int      null,
    constraint accounting_for_expense_employee_id_fk
        foreign key (employee_id) references employee (id),
    constraint accounting_for_expense_product_id_fk
        foreign key (product_id) references product (id)
);

create table accounting_for_expense
(
    id                        int auto_increment
        primary key,
    accouting_for_receipts_id int      null,
    date                      datetime null,
    type_id                   int      null,
    count                     float    null,
    employee_id               int      null,
    constraint a1
        foreign key (employee_id) references employee (id),
    constraint a3
        foreign key (type_id) references type_expense (id),
    constraint accounting_for_expense_accounting_for_receipts_id_fk
        foreign key (accouting_for_receipts_id) references accounting_for_receipts (id),
    constraint a2
        foreign key (accouting_for_receipts_id) references accounting_for_receipts (id)
);

