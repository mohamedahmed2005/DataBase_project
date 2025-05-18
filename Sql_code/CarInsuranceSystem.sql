-- Car Insurance Database DDL Script
-- Microsoft SQL Server

-- Create database (uncomment if needed)
-- CREATE DATABASE CarInsurance;
-- GO
-- USE CarInsurance;
-- GO

-- Customer table
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

-- Car table
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

-- InsurancePolicy table
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

-- Ownership table
CREATE TABLE Ownership (
    OwnershipID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE,
    EndDate DATE,
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    CarID INT FOREIGN KEY REFERENCES Car(CarID)
);

-- Accident table
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

-- Claim table
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

-- Payment table
CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATE,
    Method VARCHAR(50),
    Status VARCHAR(50),
    Amount VARCHAR(50),
    ClaimID INT FOREIGN KEY REFERENCES Claim(ClaimID)
);

-- Create indexes for better performance
CREATE INDEX IX_Customer_Email ON Customer(Email);
CREATE INDEX IX_Customer_Username ON Customer(Username);
CREATE INDEX IX_Car_LicensePlateNumber ON Car(LicensePlateNumber);
CREATE INDEX IX_Car_ChassisNumber ON Car(ChassisNumber);
CREATE INDEX IX_InsurancePolicy_PolicyNumber ON InsurancePolicy(PolicyNumber);
CREATE INDEX IX_InsurancePolicy_CustomerID ON InsurancePolicy(CustomerID);
CREATE INDEX IX_InsurancePolicy_CarID ON InsurancePolicy(CarID);
CREATE INDEX IX_Accident_AccidentDate ON Accident(AccidentDate);
CREATE INDEX IX_Claim_ClaimDate ON Claim(ClaimDate);
CREATE INDEX IX_Payment_PaymentDate ON Payment(PaymentDate);
CREATE INDEX IX_Payment_ClaimID ON Payment(ClaimID);

-- Create useful views
GO

-- View for active policies
CREATE VIEW vw_ActivePolicies AS
SELECT 
    p.PolicyID, p.PolicyNumber, p.PolicyType, p.Premium, p.StartDate, p.EndDate,
    c.CustomerID, c.FullName, c.Email, c.PhoneNumber,
    car.CarID, car.LicensePlateNumber, car.Model, car.Manufacture, car.ModelYear
FROM 
    InsurancePolicy p
    INNER JOIN Customer c ON p.CustomerID = c.CustomerID
    INNER JOIN Car car ON p.CarID = car.CarID
WHERE 
    p.EndDate >= GETDATE();
GO

-- View for customer claims history
CREATE VIEW vw_CustomerClaimsHistory AS
SELECT 
    c.CustomerID, c.FullName, c.Email,
    cl.ClaimID, cl.ClaimDate, cl.ClaimAmount, cl.Status,
    a.AccidentID, a.AccidentDate, a.AccidentType, a.DamageCost,
    car.CarID, car.LicensePlateNumber, car.Model, car.Manufacture
FROM 
    Customer c
    LEFT JOIN Claim cl ON c.CustomerID = cl.CustomerID
    LEFT JOIN Accident a ON cl.AccidentID = a.AccidentID
    LEFT JOIN Car car ON a.CarID = car.CarID;
GO

-- Triggers
-- Trigger to update policy status based on dates
CREATE TRIGGER trg_UpdatePolicyStatus
ON InsurancePolicy
AFTER INSERT, UPDATE
AS
BEGIN
    -- Add PolicyStatus column if it doesn't exist
    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('InsurancePolicy') AND name = 'PolicyStatus')
    BEGIN
        ALTER TABLE InsurancePolicy ADD PolicyStatus VARCHAR(20);
    END

    -- Update status based on dates
    UPDATE p
    SET PolicyStatus = 
        CASE 
            WHEN p.EndDate < GETDATE() THEN 'Expired'
            WHEN p.StartDate > GETDATE() THEN 'Future'
            ELSE 'Active'
        END
    FROM InsurancePolicy p
    INNER JOIN inserted i ON p.PolicyID = i.PolicyID;
END;
GO

-- Trigger to validate car license dates
CREATE TRIGGER trg_ValidateCarLicenseDates
ON Car
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE LicenseEndDate < LicenseStartDate
    )
    BEGIN
        RAISERROR('License end date cannot be earlier than license start date', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- Trigger to log claim status changes
CREATE TRIGGER trg_LogClaimStatusChanges
ON Claim
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Status)
    BEGIN
        -- Create log table if it doesn't exist
        IF OBJECT_ID('ClaimStatusLog', 'U') IS NULL
        BEGIN
            CREATE TABLE ClaimStatusLog (
                LogID INT PRIMARY KEY IDENTITY(1,1),
                ClaimID INT,
                OldStatus VARCHAR(20),
                NewStatus VARCHAR(20),
                ChangeDate DATETIME DEFAULT GETDATE(),
                ChangedBy VARCHAR(50) DEFAULT SYSTEM_USER
            );
        END

        -- Insert log record
        INSERT INTO ClaimStatusLog (ClaimID, OldStatus, NewStatus)
        SELECT d.ClaimID, d.Status, i.Status
        FROM deleted d
        INNER JOIN inserted i ON d.ClaimID = i.ClaimID
        WHERE d.Status <> i.Status;
    END
END;
GO

-- Trigger to automatically set payment status
CREATE TRIGGER trg_SetInitialPaymentStatus
ON Payment
AFTER INSERT
AS
BEGIN
    UPDATE Payment
    SET Status = 'Pending'
    FROM Payment p
    INNER JOIN inserted i ON p.PaymentID = i.PaymentID
    WHERE p.Status IS NULL;
END;
GO

-- Stored procedures
-- Procedure to create new policy
CREATE PROCEDURE sp_CreateNewPolicy
    @CustomerID INT,
    @CarID INT,
    @PolicyType VARCHAR(50),
    @CoverageDetails TEXT,
    @Premium DECIMAL(10,2),
    @StartDate DATE,
    @DurationMonths INT,
    @Deductible DECIMAL(10,2)
AS
BEGIN
    DECLARE @EndDate DATE;
    DECLARE @PolicyNumber VARCHAR(50);
    
    -- Calculate end date
    SET @EndDate = DATEADD(MONTH, @DurationMonths, @StartDate);
    
    -- Generate policy number (Year + Customer ID + Random)
    SET @PolicyNumber = CONCAT(
        YEAR(@StartDate),
        '-',
        RIGHT('000000' + CAST(@CustomerID AS VARCHAR(10)), 6),
        '-',
        RIGHT('000' + CAST(ABS(CHECKSUM(NEWID())) % 1000 AS VARCHAR(3)), 3)
    );
    
    -- Insert new policy
    INSERT INTO InsurancePolicy (
        PolicyNumber, PolicyType, CoverageDetails, Premium, 
        StartDate, EndDate, Deductible, CustomerID, CarID
    )
    VALUES (
        @PolicyNumber, @PolicyType, @CoverageDetails, @Premium,
        @StartDate, @EndDate, @Deductible, @CustomerID, @CarID
    );
    
    -- Return the new policy ID
    SELECT SCOPE_IDENTITY() AS NewPolicyID, @PolicyNumber AS PolicyNumber;
END;
GO

-- Procedure to file a new claim
CREATE PROCEDURE sp_FileNewClaim
    @CustomerID INT,
    @PolicyID INT,
    @AccidentID INT,
    @ClaimAmount DECIMAL(10,2),
    @FaultPercentage DECIMAL(5,2) = NULL
AS
BEGIN
    DECLARE @ClaimID INT;
    
    -- Insert new claim
    INSERT INTO Claim (
        CustomerID, PolicyID, AccidentID, ClaimAmount, 
        FaultPercentage, ClaimDate, Status
    )
    VALUES (
        @CustomerID, @PolicyID, @AccidentID, @ClaimAmount,
        @FaultPercentage, GETDATE(), 'Filed'
    );
    
    SET @ClaimID = SCOPE_IDENTITY();
    
    -- Return the new claim ID
    SELECT @ClaimID AS NewClaimID;
END;
GO

-- Procedure to get policy premium statistics
CREATE PROCEDURE sp_GetPremiumStatistics
AS
BEGIN
    SELECT 
        PolicyType,
        COUNT(*) AS PolicyCount,
        AVG(Premium) AS AveragePremium,
        MIN(Premium) AS MinimumPremium,
        MAX(Premium) AS MaximumPremium,
        SUM(Premium) AS TotalPremium
    FROM 
        InsurancePolicy
    GROUP BY 
        PolicyType;
END;
GO
-- Sample Data
INSERT INTO Customer (Username, Password, Email, FullName, NationalID)
VALUES 
('user1', 'pass1', 'user1@example.com', 'Customer One', 1111),
('user2', 'pass2', 'user2@example.com', 'Customer Two', 2222),
('user3', 'pass3', 'user3@example.com', 'Customer Three', 3333),
('user4', 'pass4', 'user4@example.com', 'Customer Four', 4444),
('user5', 'pass5', 'user5@example.com', 'Customer Five', 5555);
INSERT INTO Car (LicensePlateNumber, ChassisNumber, Color, Model, Manufacture, ModelYear)
VALUES 
('PLT001', 'CH001', 'Red', 'ModelA', 'MakeA', 2015),
('PLT002', 'CH002', 'Blue', 'ModelB', 'MakeB', 2016),
('PLT003', 'CH003', 'Black', 'ModelC', 'MakeC', 2017),
('PLT004', 'CH004', 'White', 'ModelD', 'MakeD', 2014),
('PLT005', 'CH005', 'Gray', 'ModelE', 'MakeE', 2018),
('PLT006', 'CH006', 'Red', 'ModelF', 'MakeF', 2019),
('PLT007', 'CH007', 'Green', 'ModelG', 'MakeG', 2013),
('PLT008', 'CH008', 'Yellow', 'ModelH', 'MakeH', 2020),
('PLT009', 'CH009', 'Blue', 'ModelI', 'MakeI', 2021),
('PLT010', 'CH010', 'Silver', 'ModelJ', 'MakeJ', 2022);
INSERT INTO Ownership (CustomerID, CarID, StartDate)
VALUES 
(1, 1, '2016-01-01'),
(2, 2, '2016-02-01'),
(3, 3, '2016-03-01'),
(4, 4, '2016-04-01'),
(5, 5, '2016-05-01'),
(1, 6, '2017-01-01'),
(2, 7, '2017-02-01'),
(3, 8, '2017-03-01'),
(4, 9, '2017-04-01'),
(5, 10, '2017-05-01'),
(1, 2, '2016-06-01'),
(2, 3, '2016-07-01'),
(3, 4, '2016-08-01'),
(4, 5, '2016-09-01'),
(5, 1, '2016-10-01');
INSERT INTO Accident (CarID, CustomerID, AccidentDate, AccidentType, DamageCost)
VALUES
(1, 1, '2017-01-15', 'Minor', 100.00),
(2, 2, '2017-02-15', 'Major', 500.00),
(3, 3, '2017-03-15', 'Minor', 200.00),
(4, 4, '2017-04-15', 'Major', 700.00),
(5, 5, '2017-05-15', 'Minor', 150.00),
(6, 1, '2017-06-15', 'Major', 300.00),
(7, 2, '2017-07-15', 'Minor', 250.00),
(8, 3, '2017-08-15', 'Major', 600.00),
(9, 4, '2017-09-15', 'Minor', 180.00),
(10, 5, '2017-10-15', 'Major', 800.00);

------ asked queries

-- Total number of people who owned cars involved in accidents in 2017
CREATE PROCEDURE sp_AccidentsInvolvedCount_2017
AS
BEGIN
    SELECT COUNT(DISTINCT o.CustomerID) AS TotalOwnersInvolved
    FROM Ownership o
    INNER JOIN Accident a ON o.CarID = a.CarID
    WHERE YEAR(a.AccidentDate) = 2017;
END;
GO

-- Number of accidents involving cars belonging to "Ahmed Mohamed"
CREATE PROCEDURE sp_GetAccidentCountForAhmedMohamed
AS
BEGIN

    SELECT COUNT(DISTINCT a.AccidentID) AS AccidentCount
    FROM Customer c
    INNER JOIN Ownership o ON c.CustomerID = o.CustomerID
    INNER JOIN Car car ON o.CarID = car.CarID
    INNER JOIN Accident a ON car.CarID = a.CarID
    WHERE c.FullName = 'Ahmed Mohamed';
END;

-- Model with maximum number of accidents in 2017
CREATE PROCEDURE sp_MaxAccidentModel_2017
AS
BEGIN
    WITH AccidentCounts AS (
        SELECT 
            c.Model, 
            COUNT(a.AccidentID) AS AccidentCount
        FROM Accident a
        INNER JOIN Car c ON a.CarID = c.CarID
        WHERE YEAR(a.AccidentDate) = 2017
        GROUP BY c.Model
    )
    SELECT Model, AccidentCount
    FROM AccidentCounts
    WHERE AccidentCount = (SELECT MAX(AccidentCount) FROM AccidentCounts);
END;
GO

CREATE PROCEDURE sp_MaxOneAccidentModel_2017
AS
BEGIN
    SELECT TOP 1 c.Model, COUNT(a.AccidentID) AS AccidentCount
    FROM Accident a
    INNER JOIN Car c ON a.CarID = c.CarID
    WHERE YEAR(a.AccidentDate) = 2017
    GROUP BY c.Model
    ORDER BY AccidentCount DESC;
END;
GO

-- Model with maximum number of accidents in 2017
CREATE PROCEDURE sp_MaxAccidentModel_2017
AS
BEGIN
    WITH AccidentCounts AS (
        SELECT 
            c.Model, 
            COUNT(a.AccidentID) AS AccidentCount
        FROM Accident a
        INNER JOIN Car c ON a.CarID = c.CarID
        WHERE YEAR(a.AccidentDate) = 2017
        GROUP BY c.Model
    )
    SELECT Model, AccidentCount
    FROM AccidentCounts
    WHERE AccidentCount = (SELECT MAX(AccidentCount) FROM AccidentCounts);
END;
GO

-- Models with zero accidents in 2017
CREATE PROCEDURE sp_GetModelsWithZeroAccidentsIn2017
AS
BEGIN
    SELECT DISTINCT c.Model
    FROM Car c
    WHERE c.CarID NOT IN (
        SELECT a.CarID
        FROM Accident a
        WHERE YEAR(a.AccidentDate) = 2017
    );
END;
GO

-- Customer information for owners of cars involved in 2017
Create PROCEDURE Retrieve_information
As
Begin
SELECT DISTINCT cu.*
FROM Customer cu
INNER JOIN Ownership o ON cu.CustomerID = o.CustomerID
INNER JOIN Car c ON o.CarID = c.CarID
INNER JOIN Accident a ON a.CarID = c.CarID
WHERE YEAR(a.AccidentDate) = 2017
  AND (o.StartDate IS NULL OR o.StartDate <= a.AccidentDate)
  AND (o.EndDate IS NULL OR o.EndDate >= a.AccidentDate);
  End;
  Go
-- Number of accidents for a specific model (parameterized)
CREATE PROCEDURE sp_AccidentsByModel
    @ModelName VARCHAR(50)
AS
BEGIN
    SELECT COUNT(a.AccidentID) AS AccidentCount
    FROM Accident a
    INNER JOIN Car c ON a.CarID = c.CarID
    WHERE c.Model = @ModelName;
END;
GO

------- addition queries if you needed 
-- minimum number of accidents
CREATE PROCEDURE sp_MinAccidentModel_2017
AS
BEGIN
    WITH AccidentCounts AS (
        SELECT 
            c.Model, 
            COUNT(a.AccidentID) AS AccidentCount
        FROM Accident a
        INNER JOIN Car c ON a.CarID = c.CarID
        WHERE YEAR(a.AccidentDate) = 2017
        GROUP BY c.Model
    )
    SELECT Model, AccidentCount
    FROM AccidentCounts
    WHERE AccidentCount = (SELECT MIN(AccidentCount) FROM AccidentCounts);
END;
GO

-- Most common accident type:
CREATE PROCEDURE sp_MostCommonAccidentType_2017
AS
BEGIN
    WITH TypeCounts AS (
        SELECT 
            AccidentType, 
            COUNT(*) AS TypeCount
        FROM Accident
        WHERE YEAR(AccidentDate) = 2017
        GROUP BY AccidentType
    )
    SELECT AccidentType, TypeCount
    FROM TypeCounts
    WHERE TypeCount = (SELECT MAX(TypeCount) FROM TypeCounts);
END;
GO
-- Customer with the most accidents in a selected year
CREATE PROCEDURE sp_CustomerWithMostAccidentsInYear
    @Year INT
AS
BEGIN
    WITH CustomerAccidentCounts AS (
        SELECT 
            c.CustomerID,
            c.FullName,
            c.Email,
            c.PhoneNumber,
            COUNT(a.AccidentID) AS AccidentCount
        FROM Accident a
        INNER JOIN Ownership o ON a.CarID = o.CarID
        INNER JOIN Customer c ON o.CustomerID = c.CustomerID
        WHERE YEAR(a.AccidentDate) = @Year
        GROUP BY c.CustomerID, c.FullName, c.Email, c.PhoneNumber
    )
    SELECT 
        CustomerID,
        FullName,
        Email,
        PhoneNumber,
        AccidentCount
    FROM CustomerAccidentCounts
    WHERE AccidentCount = (SELECT MAX(AccidentCount) FROM CustomerAccidentCounts)
    ORDER BY FullName;
END;
GO

-- Customers with the most accidents in any year 
CREATE PROCEDURE sp_CustomersWithMostAccidentsAllTime
AS
BEGIN
    WITH CustomerAccidentCounts AS (
        SELECT 
            c.CustomerID,
            c.FullName,
            c.Email,
            c.PhoneNumber,
            COUNT(a.AccidentID) AS AccidentCount
        FROM Accident a
        INNER JOIN Ownership o ON a.CarID = o.CarID
        INNER JOIN Customer c ON o.CustomerID = c.CustomerID
        GROUP BY c.CustomerID, c.FullName, c.Email, c.PhoneNumber
    )
    SELECT 
        CustomerID,
        FullName,
        Email,
        PhoneNumber,
        AccidentCount
    FROM CustomerAccidentCounts
    WHERE AccidentCount = (SELECT MAX(AccidentCount) FROM CustomerAccidentCounts)
    ORDER BY FullName;
END;
GO
