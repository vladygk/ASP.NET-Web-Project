CREATE DATABASE Demo;

--1 
CREATE TABLE Product(
    maker CHAR(1),
    model CHAR(4),
    [type] VARCHAR(7)
);

CREATE TABLE Printer(
    code INT,
    model CHAR(4),
    price DECIMAL(8,2)
);
--2
INSERT INTO Product 
VALUES
('a','mod1','typ1'),
('b','mod2','type2'),
('c','mod3','type3');

INSERT INTO Printer
VALUES
(1,'mod1',10000.00),
(2,'mod2',10000.00),
(3,'mod3',10000.00);

--3
ALTER TABLE Printer 
ADD [type] VARCHAR(6);

GO;

ALTER TABLE Printer
ADD CONSTRAINT cstr1
CHECK ([type] in ('laser','matrix','jet'));

ALTER TABLE Printer
ADD color CHAR(1) DEFAULT 'n';

GO;

ALTER TABLE Printer
ADD CONSTRAINT cstr2
CHECK (color in ('y','n'));

--4
ALTER TABLE Printer
DROP COLUMN Price;

--5
DROP TABLE Printer;
DROP TABLE Product;