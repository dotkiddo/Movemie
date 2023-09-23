CREATE TABLE Movies (
Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) UNIQUE NOT NULL,
Rating int NOT NULL,
Category varchar(255) NOT NULL,

CONSTRAINT CHK_Rating CHECK (Rating <= 5 AND Rating >= 1)
);
