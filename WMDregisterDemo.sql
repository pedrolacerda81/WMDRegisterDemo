CREATE DATABASE register
DEFAULT character SET utf8
DEFAULT collate utf8_general_ci;

USE register;

CREATE TABLE IF NOT EXISTS clients (
	`id` int not null auto_increment,
	`name` varchar(250) not null,
    `cnjp` bigint not null,

	primary key (id)
) DEFAULT CHARSET = utf8;

SELECT * FROM clients;

INSERT INTO clients(
			`id`, 
			`name`,
            `cnpj`
            )
     VALUES (
     		DEFAULT,
     		'Wmd Corp',
     		10293847
     		);

UPDATE clients
   SET `name` = 'WMD Corp', 
       `cnpj` = 03928476
 WHERE id = '1';

 DELETE FROM clients WHERE id = 1;