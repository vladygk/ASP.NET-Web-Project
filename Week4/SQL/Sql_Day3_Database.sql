CREATE DATABASE Subscriptions;

CREATE TABLE DebitCard(
    Id INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES [User](Id) ,
    [Number] CHAR(16),
    ExpDate Datetime2 
    CHECK (ExpDate > GETDATE())
);

CREATE TABLE Genre(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20)
)

CREATE TABLE SubType(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20)
);

CREATE TABLE ProductType(
     Id INT PRIMARY KEY IDENTITY,
     [Name] VARCHAR(20),
     GenreID INT FOREIGN KEY REFERENCES Genre(Id) 
);

CREATE TABLE ProductSubTypePrice(
   Id INT PRIMARY KEY IDENTITY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) ,
    SubTypeID INT FOREIGN KEY REFERENCES SubType(Id),
    Price Decimal(8,2),
    UNIQUE(ProductId,SubTypeID)
);

CREATE TABLE Subscription(
    Id INT PRIMARY KEY IDENTITY,
    ProductSubTypePriceID INT FOREIGN KEY REFERENCES ProductSubTypePrice(Id),
    UserID INT FOREIGN KEY REFERENCES [User](Id),
    Duration INT
);

CREATE TABLE Product(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20),
    ProductTypeId INT FOREIGN KEY REFERENCES ProductType(Id),
    MinAge INT,
    OriginCountryId INT FOREIGN KEY REFERENCES Country(Id),
    CHECK(MinAge>0)
);

CREATE TABLE Comment(
    Id INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES [User](Id),
    ProductId INT FOREIGN KEY REFERENCES Product(Id),
    [Text] VARCHAR(100)
);

CREATE TABLE Country(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20)
)

CREATE TABLE [User](
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(50),
    [Password] VARCHAR(50),
    [Name] VARCHAR(30),
    FailedAttempts INT,
    Age INT,
    Gender CHAR(1),
    CountryId INT FOREIGN KEY REFERENCES Country(Id),
    CHECK(Gender IN ('m','f')),
    Check(Age>0),
    Check(Email LIKE '_%@__%.__%'),
    CHECK(LEN(Password)>6)
);

CREATE TABLE UserLikes(
    ProductId INT FOREIGN KEY REFERENCES Product(Id),
    UserId INT FOREIGN KEY REFERENCES [User](Id),
    PRIMARY KEY (ProductId,UserID)
);

CREATE TABLE DistCountry(
    ProductId INT FOREIGN KEY REFERENCES Product(Id),
    CountryId INT FOREIGN KEY REFERENCES Country(Id),
    PRIMARY KEY (ProductId,CountryId)
)


SELECT t1.[Name] FROM (SELECT u.[Name],COUNT(p.Name)as magazine_count FROM [User] as u
JOIN Subscription as s
ON u.Id = s.UserId
JOIN ProductSubTypePrice as psp
ON psp.id = s.ProductSubTypePriceID
JOIN Product as p
ON psp.ProductId = p.id
JOIN ProductType as pt
ON p.ProductTypeId = pt.Id
WHERE p.MinAge = 18 AND pt.Name = 'magazine'
GROUP BY u.[Name]
) as t1
ORDER BY t1.[magazine_count]