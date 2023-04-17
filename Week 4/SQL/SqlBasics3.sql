--MOVIES DB
--1
INSERT INTO MOVIESTAR (NAME,GENDER,BIRTHDATE)
VALUES('Nicole Kidman','F','1967/06/20')

--2
DELETE FROM MOVIEEXEC
WHERE NETWORTH < 30000000

--3
DELETE FROM MOVIESTAR 
WHERE ADDRESS IS NULL

--PC DB
--1
insert into product values('C','1100','PC');
insert into pc values(12,'1100',2400,2048,500,'52x',299);

--2
DELETE FROM PC
WHERE model = 1100

--3 
DELETE FROM LAPTOP
WHERE model in (SELECT  t1.[model] FROM (
SELECT maker, type,model FROM PRODUCT
WHere type = 'Laptop') as t1
LEFT JOIN (SELECT maker, type from product
WHERE TYPE = 'Printer') as t2
ON t1.[maker] = t2.[maker]
WHERE t2.[Maker] IS NULL)

--4
UPDATE Product 
SET maker = 'A'
WHERE maker = 'B'

--5
UPDATE PC
Set price = price / 2 

UPDATE PC
SET hd = hd + 20


--6
UPDATE Laptop
SET screen = screen + 1
WHERE model in (SELECT model FROM PRODUCT
WHERE maker = 'B' and type = 'Laptop')


-- SHIPS DB
--1
INSERT INTO CLASSES
 VALUES ('Nelson ', 'bb', 'GREAT BRITAIN', 16, 16, 34000),
('Rodney  ', 'bb', 'GREAT BRITAIN', 16, 16, 34000)

INSERT INTO SHIPS
  VALUES ('ship1', 'Nelson', 1927),
   ('ship2', 'Rodney', 1927);

   --2
   DELETE FROM SHIPS
   WHERE NAME IN (   SELECT ship FROM Outcomes
   WHERE RESULT = 'sunk')

--3

UPDATE  CLASSES
SET BORE = BORE * 2.5

UPDATE CLASSES
SET DISPLACEMENT = DISPLACEMENT / 1.1




