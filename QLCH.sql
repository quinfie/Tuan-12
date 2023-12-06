create database QLCH
use QLCH 

CREATE TABLE Artists (
  ArtistID INT PRIMARY KEY,
  ArtistName VARCHAR(100) NOT NULL
);

CREATE TABLE Albums (
  AlbumID INT PRIMARY KEY,
  AlbumName VARCHAR(100) NOT NULL,
  ArtistID INT,
  Price DECIMAL(10, 2),
  FOREIGN KEY (ArtistID) REFERENCES Artists(ArtistID)
);

CREATE TABLE Customers (
  CustomerID INT PRIMARY KEY,
  CustomerName VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Phone VARCHAR(20) NOT NULL,
  Address VARCHAR(200),
);

CREATE TABLE Orders (
  OrderID INT PRIMARY KEY,
  CustomerID INT,
  OrderDate DATE,
  FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
  OrderDetailID INT PRIMARY KEY,
  OrderID INT,
  AlbumID INT,
  Quantity INT,
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  FOREIGN KEY (AlbumID) REFERENCES Albums(AlbumID)
);

-- Chèn dữ liệu vào bảng Artists
INSERT INTO Artists (ArtistID, ArtistName)
VALUES (1, 'BTS');

INSERT INTO Artists (ArtistID, ArtistName)
VALUES (2, 'BLACKPINK');

INSERT INTO Artists (ArtistID, ArtistName)
VALUES (3, 'SHINee');

INSERT INTO Artists (ArtistID, ArtistName)
VALUES (4, 'Dreamcatcher');

INSERT INTO Artists (ArtistID, ArtistName)
VALUES (5, 'Baekhyun');

-- Chèn dữ liệu vào bảng Albums
INSERT INTO Albums (AlbumID, AlbumName, ArtistID, Price)
VALUES (1, 'Love Yourself: Answer', 1, 25.00);

INSERT INTO Albums (AlbumID, AlbumName, ArtistID, Price)
VALUES (2, 'The Album', 2, 20.00);

INSERT INTO Albums (AlbumID, AlbumName, ArtistID, Price)
VALUES (3, 'Don''t Call Me', 3, 22.00);

INSERT INTO Albums (AlbumID, AlbumName, ArtistID, Price)
VALUES (4, 'Dystopia: Road to Utopia', 4, 18.00);

INSERT INTO Albums (AlbumID, AlbumName, ArtistID, Price)
VALUES (5, 'Delight', 5, 15.00);

-- Chèn dữ liệu vào bảng Customers
INSERT INTO Customers (CustomerID, CustomerName, Email, Phone, Address)
VALUES (1, 'Nguyen Van A', 'nguyenvana@example.com', '123456789', '123 Main St');

INSERT INTO Customers (CustomerID, CustomerName, Email, Phone, Address)
VALUES (2, 'Tran Thi B', 'tranthib@example.com', '987654321', '456 Elm St');

-- Chèn dữ liệu vào bảng Orders
INSERT INTO Orders (OrderID, CustomerID, OrderDate)
VALUES (1, 1, '2023-11-28');

INSERT INTO Orders (OrderID, CustomerID, OrderDate)
VALUES (2, 2, '2023-11-29');

-- Chèn dữ liệu vào bảng OrderDetails
INSERT INTO OrderDetails (OrderDetailID, OrderID, AlbumID, Quantity)
VALUES (1, 1, 1, 2);

INSERT INTO OrderDetails (OrderDetailID, OrderID, AlbumID, Quantity)
VALUES (2, 1, 3, 1);

INSERT INTO OrderDetails (OrderDetailID, OrderID, AlbumID, Quantity)
VALUES (3, 2, 2, 3);

INSERT INTO OrderDetails (OrderDetailID, OrderID, AlbumID, Quantity)
VALUES (4, 2, 4, 2);