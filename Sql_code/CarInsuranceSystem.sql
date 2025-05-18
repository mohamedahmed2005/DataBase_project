CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(100) NOT NULL,
    FullName VARCHAR(100),
    NationalID INT NOT NULL,
    PhoneNumber VARCHAR(20),
    Address VARCHAR(20),
    Nationality VARCHAR(50),
    Gender CHAR(1),
    DateOfBirth DATE,
    BloodType VARCHAR(5),
    CustomerStatus VARCHAR(20),
    AccountCreationDate DATE,
    AccountUpdateDate DATE
);

CREATE TABLE Car (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    LicensePlateNumber VARCHAR(20) NOT NULL,
    ChassisNumber VARCHAR(50) NOT NULL,
    LicenseStartDate DATE,
    LicenseEndDate DATE,
    GlassKind VARCHAR(50),
    Color VARCHAR(50),
    MotorNumber VARCHAR(50),
    MotorType VARCHAR(100),
    Type VARCHAR(50),
    Model VARCHAR(50),
    Manufacture VARCHAR(50),
    ModelYear INT,
    IsDisabledCar BIT,
    IsAvailable BIT,
    TrafficUnit VARCHAR(50),
    TrafficDepartment VARCHAR(50)
);

CREATE TABLE InsurancePolicy (
    PolicyID INT PRIMARY KEY IDENTITY(1,1),
    PolicyNumber VARCHAR(50) NOT NULL,
    PolicyType VARCHAR(50),
    CoverageDetails TEXT,
    Premium DECIMAL(10,2),
    StartDate DATE,
    EndDate DATE,
    Deductible DECIMAL(10,2),
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    CarID INT FOREIGN KEY REFERENCES Car(CarID)
);

CREATE TABLE Ownership (
    OwnershipID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE,
    EndDate DATE,
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    CarID INT FOREIGN KEY REFERENCES Car(CarID)
);

CREATE TABLE Accident (
    AccidentID INT PRIMARY KEY IDENTITY(1,1),
    PoliceReportNumber VARCHAR(50),
    IsNatural BIT,
    AccidentType VARCHAR(50),
    DamageCost DECIMAL(10,2),
    Description TEXT,
    Time TIME,
    AccidentDate DATE,
    Location VARCHAR(200),
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    CarID INT FOREIGN KEY REFERENCES Car(CarID)
);

CREATE TABLE Claim (
    ClaimID INT PRIMARY KEY IDENTITY(1,1),
    FaultPercentage DECIMAL(5,2),
    Status VARCHAR(20),
    ClaimDate DATE,
    ClaimAmount DECIMAL(10,2),
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    PolicyID INT FOREIGN KEY REFERENCES InsurancePolicy(PolicyID),
    AccidentID INT FOREIGN KEY REFERENCES Accident(AccidentID)
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATE,
    Method VARCHAR(50),
    Status VARCHAR(50),
    Amount VARCHAR(50),
    ClaimID INT FOREIGN KEY REFERENCES Claim(ClaimID)
);
-- a
SELECT COUNT(DISTINCT o.CustomerID) AS TotalOwnersInvolved
FROM Ownership o
INNER JOIN Accident a ON o.CarID = a.CarID
WHERE YEAR(a.AccidentDate) = 2017

-- b
SELECT COUNT(DISTINCT a.AccidentID) AS AccidentCount
FROM Customer c
INNER JOIN Ownership o ON c.CustomerID = o.CustomerID
INNER JOIN Car car ON o.CarID = car.CarID
INNER JOIN Accident a ON car.CarID = a.CarID
WHERE c.FullName = 'Ahmed Mohamed'

-- c
WITH AccidentCounts AS (
    SELECT c.Model, COUNT(a.AccidentID) AS AccidentCount
    FROM Accident a
    INNER JOIN Car c ON a.CarID = c.CarID
    WHERE YEAR(a.AccidentDate) = 2017
    GROUP BY c.Model
)
SELECT Model, AccidentCount
FROM AccidentCounts
WHERE AccidentCount = (SELECT MAX(AccidentCount) FROM AccidentCounts)

-- d
SELECT TOP 1 c.Model, COUNT(a.AccidentID) AS AccidentCount
FROM Accident a
INNER JOIN Car c ON a.CarID = c.CarID
WHERE YEAR(a.AccidentDate) = 2017
GROUP BY c.Model
ORDER BY AccidentCount DESC

-- e
SELECT DISTINCT c.Model
FROM Car c
WHERE c.CarID NOT IN (
    SELECT a.CarID
    FROM Accident a
    WHERE YEAR(a.AccidentDate) = 2017
)

-- f
SELECT COUNT(a.AccidentID) AS AccidentCount
FROM Accident a
INNER JOIN Car c ON a.CarID = c.CarID
WHERE c.Model = 'ModelName'

-- report

SELECT 
    YEAR(AccidentDate) AS AccidentYear,
    MONTH(AccidentDate) AS AccidentMonth,
    COUNT(*) AS TotalAccidents
FROM Accident
GROUP BY YEAR(AccidentDate), MONTH(AccidentDate)
ORDER BY YEAR(AccidentDate), MONTH(AccidentDate)
