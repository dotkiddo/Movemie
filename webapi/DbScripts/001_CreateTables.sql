CREATE TABLE Categories (
Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) UNIQUE NOT NULL 
);


CREATE TABLE Movies (
Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) UNIQUE NOT NULL,
Rating int NOT NULL,
CategoryId int NOT NULL,

CONSTRAINT FK_MovieCategory FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
CONSTRAINT CHK_Rating CHECK (Rating <= 5 AND Rating >= 1)
);
