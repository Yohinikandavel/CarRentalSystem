CREATE DATABASE CarRental;

USE CarRental;

CREATE TABLE Vehicle (
    vehicleID INT PRIMARY KEY IDENTITY,
    make NVARCHAR(100),
    model NVARCHAR(100),
    year INT,
    dailyRate FLOAT,
    status NVARCHAR(20),
    passengerCapacity INT,
    engineCapacity FLOAT
);

CREATE TABLE Customer (
    customerID INT PRIMARY KEY IDENTITY,
    firstName NVARCHAR(100),
    lastName NVARCHAR(100),
    email NVARCHAR(100),
    phoneNumber NVARCHAR(20)
);

CREATE TABLE Lease (
    leaseID INT PRIMARY KEY IDENTITY,
    vehicleID INT FOREIGN KEY REFERENCES Vehicle(vehicleID),
    customerID INT FOREIGN KEY REFERENCES Customer(customerID),
    startDate DATE,
    endDate DATE,
    type NVARCHAR(20)
);

CREATE TABLE Payment (
    paymentID INT PRIMARY KEY IDENTITY,
    leaseID INT FOREIGN KEY REFERENCES Lease(leaseID),
    paymentDate DATE,
    amount FLOAT
);

INSERT INTO Vehicle (make, model, year, dailyRate, status, passengerCapacity, engineCapacity)
VALUES 
('Toyota', 'Camry', 2020, 2500.00, 'Available', 5, 2.5),
('Honda', 'Civic', 2021, 2200.00, 'Available', 5, 2.0),
('Mahindra', 'XUV700', 2022, 3000.00, 'Available', 7, 2.2);

INSERT INTO Customer (firstName, lastName, email, phoneNumber)
VALUES
('Yohini', 'K', 'yohini11@mail.com', '9876543210'),
('Rahul', 'K', 'rahul12@mail.com', '9876543211'),
('Riya', 'S', 'riya13@mail.com', '9876543212');

INSERT INTO Lease (vehicleID, customerID, startDate, endDate, type)
VALUES
(1, 1, '2025-07-01', '2025-07-05', 'Daily'),
(2, 2, '2025-07-02', '2025-07-04', 'Daily'),
(3, 3, '2025-07-01', '2025-07-03', 'Daily');

INSERT INTO Payment (leaseID, paymentDate, amount)
VALUES
(1, '2025-07-01', 10000.00),
(2, '2025-07-02', 6600.00),
(3, '2025-07-01', 6000.00);

SELECT * FROM Vehicle;
SELECT * FROM Customer;
SELECT * FROM Lease;
SELECT * FROM Payment;
