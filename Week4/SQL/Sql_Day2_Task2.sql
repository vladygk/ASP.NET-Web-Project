--Task 2

--1
SELECT * FROM ships as s
JOIN CLASSES as c
ON s.CLASS = c.CLASS;

--2
SELECT * FROM ships as s
RIGHT JOIN CLASSES as c
ON s.CLASS = c.CLASS
WHERE c.CLASS IN (SELECT s.NAME FROM SHIPS as s);

--3
SELECT c.COUNTRY,s.NAME FROM SHIPS as s 
JOIN CLASSES as c 
ON s.CLASS = c.CLASS
LEFT JOIN OUTCOMES as o
ON o.SHIP = s.NAME
WHERE o.RESULT IS NULL
ORDER BY c.COUNTRY, s.NAME;

--4
SELECT s.NAME as [Ship Name] FROM SHIPS as s
JOIN CLASSES as c
ON c.CLASS = s.CLASS
WHERE s.LAUNCHED = 1916 and c.NUMGUNS >= 7; 

--5
SELECT s.NAME as ship,b.NAME,b.[DATE] FROM SHIPS as s 
JOIN OUTCOMES as o
ON s.NAME = o.SHIP
JOIN BATTLES as b
ON b.NAME = o.BATTLE
WHERE o.RESULT = 'sunk'
ORDER BY b.NAME;

--6
SELECT s.NAME,c.DISPLACEMENT,s.LAUNCHED FROM SHIPS as s 
JOIN CLASSES as c
ON s.CLASS = c.CLASS
WHERE s.NAME = c.CLASS;

--7
SELECT c.CLASS,c.[TYPE],c.NUMGUNS,c.BORE,c.DISPLACEMENT FROM CLASSES as c 
LEFT JOIN SHIPS as s 
ON c.CLASS = s.CLASS
WHERE s.NAME IS NULL;

--8
SELECT s.name,c.DISPLACEMENT,c.numguns,o.result FROM OUTCOMES as o
JOIN ships as s 
ON s.name = o.ship
JOIN CLASSes as c
ON s.class =c.class
WHERE o.BATTLE = 'North Atlantic';

--9
SELECT s.Name from Ships as s
JOIN CLASSES as c
ON c.class = s.class
WHERE c.DISPLACEMENT >50000;

--10
SELECT s.name,c.DISPLACEMENT,c.numguns FROM OUTCOMES as o
JOIN ships as s 
ON s.name = o.ship
JOIN CLASSes as c
ON s.class =c.class
WHERE o.BATTLE = 'Guadalcanal';

--11
SELECT t2.Country from (SELECT Country FROM CLASSES
WHERE [Type] ='bb') as t1
JOIN (SELECT Country FROM CLASSES
WHERE [Type] ='bc') as t2
ON t1.Country = t2.Country;

--12
SELECT t1.ship from (SELECT ship FROM OUTCOMES
WHERE RESULT = 'damaged'
) as t1 
JOIN (SELECT ship FROM OUTCOMES
WHERE RESULT = 'ok') as t2
ON t1.ship = t2.ship;




