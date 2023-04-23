--Task1

--1
SELECT COUNT(c.type) as [NO_Classes] FROM CLASSES as c
GROUP BY(c.type)
HAVING c.[TYPE] = 'bb';

--2
SELECT c.class,AVG(c.NUMGUNS) as avgGuns FROM CLASSES as c
GROUP BY(c.class) 

--3
SELECT AVG(c.NUMGUNS) as AvgGuns  FROM CLASSES as c;

--4
SELECT c.class,MIN(s.LAUNCHED)as FirstYear,MAX(s.LAUNCHED)as SecondYear FROM CLASSES as c
JOIN SHIPS as s
ON s.CLASS = c.CLASS
GROUP BY c.CLASS

--5
SELECT c.class, COUNT(c.CLASS) as NO_sunk FROM CLASSES as c
JOIN SHIPS as s
ON s.CLASS = c.CLASS
JOIN OUTCOMES as o
ON s.NAME = o.SHIP
WHERE o.RESULT = 'sunk'
GROUP BY c.CLASS

--6
SELECT c.class, COUNT(c.class) as NO_sunk FROM CLASSES as c
JOIN SHIPS as s
ON s.CLASS = c.CLASS
JOIN OUTCOMES as o
ON s.NAME = o.SHIP
WHERE o.RESULT = 'sunk' and s.Class in (SELECT t1.CLASS FROM (SELECT s.class,COUNT(s.NAME) as shipCount FROM Ships as s
                                        GROUP BY s.CLASS) as t1
                                        WHERE t1.shipCount >2)
GROUP BY c.CLASS

--7
SELECT c.COUNTRY,ROUND(AVG(t1.AvgBorePerShip),2) FROM (SELECT s.Name,AVG(c.BORE) as [AvgBorePerShip] FROM SHIPS as s 
JOIN CLASSES as c
ON S.CLASS = c.CLASS
GROUP BY s.NAME) as t1
JOIN ships as s
ON S.NAME = t1.NAME
JOIN CLASSES as c
ON s.CLASS = c.CLASS
GROUP BY c.COUNTRY

--Task2

--1
CREATE NONCLUSTERED INDEX index1 ON ships ([NAME]);
CREATE NONCLUSTERED INDEX index2 ON OUTCOMES ([SHIP]);
CREATE NONCLUSTERED INDEX index3 ON Battles ([Name]);
CREATE NONCLUSTERED INDEX index4 ON CLASSES ([Class]);

--2
DROP  INDEX index1 ON ships;
DROP  INDEX index2 ON OUTCOMES;
DROP  INDEX index3 ON Battles;
DROP  INDEX index4 ON CLASSES;

--Task3

--1
ALTER TABLE Flights
ADD num_pass INT DEFAULT 0 NOT NULL

--2
ALTER TABLE Agencies
ADD num_book INT DEFAULT 0 NOT NULL
GO;

--3
CREATE TRIGGER trigger1 ON Bookings
AFTER Insert 
AS
UPDATE  Flights  
SET num_pass = num_pass + 1
WHERE FNUMBER = (SELECT FLIGHT_NUMBER FROM Inserted)
UPDATE Agencies
SET num_book = num_book + 1
WHERE Name = (SELECT Agency FROM Inserted)
Go;

--4
CREATE TRIGGER trigger2 ON Bookings
AFTER Delete 
AS
UPDATE  Flights  
SET num_pass = num_pass - 1
WHERE FNUMBER = (SELECT FLIGHT_NUMBER FROM Deleted)
UPDATE Agencies
SET num_book = num_book - 1
WHERE Name = (SELECT Agency FROM Deleted)
Go;

--5
CREATE TRIGGER trigger3 ON Bookings
AFTER Update 
AS
IF (SELECT [STATUS] FROM Updated)=0
    UPDATE  Flights  
    SET num_pass = num_pass - 1
    WHERE FNUMBER = (SELECT FLIGHT_NUMBER FROM Updated);
ELSE IF (SELECT [STATUS] FROM Updated)=1
    UPDATE  Flights  
    SET num_pass = num_pass + 1
    WHERE FNUMBER = (SELECT FLIGHT_NUMBER FROM Updated);








