use assessment1;

CREATE TABLE Sales_Raw
(
    OrderID INT,
    OrderDate VARCHAR(20),
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50),
    ProductNames VARCHAR(200),
    Quantities VARCHAR(100),
    UnitPrices VARCHAR(100),
    SalesPerson VARCHAR(100)
);
INSERT INTO Sales_Raw VALUES
(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),
(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore', 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),
(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop', '1', '54000', 'Suresh'),
(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad', 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),
(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore', 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');
SELECT * FROM Sales_Raw;


-- normalise table in 3nf
CREATE TABLE CustomerMaster
(
    CustID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50),
    PhoneNumber VARCHAR(10),
    City VARCHAR(50)
);
CREATE TABLE ProductMaster
(
    PID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50),
    UnitPrice FLOAT
);
CREATE TABLE SalesMaster
(
    SID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50)
);
CREATE TABLE CustomerOrderDetails
(
    OID INT PRIMARY KEY,
    CID INT,
    SID INT,
    Date DATE,
    FOREIGN KEY (CID) REFERENCES CustomerMaster(CustID),
    FOREIGN KEY (SID) REFERENCES SalesMaster(SID)
);
CREATE TABLE OrderDetails
(
    ID INT PRIMARY KEY AUTO_INCREMENT,
    OID INT,
    PID INT,
    Qty INT,
    FOREIGN KEY (OID) REFERENCES CustomerOrderDetails(OID),
    FOREIGN KEY (PID) REFERENCES ProductMaster(PID)
);

-- Customers ka data

INSERT INTO CustomerMaster (Name, PhoneNumber, City) VALUES
('Ravi Kumar', '9876543210', 'Chennai'),
('Priya Sharma', '9123456789', 'Bangalore'),
('John Peter', '9988776655', 'Hyderabad');

-- Products ka data

INSERT INTO ProductMaster (Name, UnitPrice) VALUES
('Laptop', 55000),
('Mouse', 500),
('Keyboard', 1500),
('Monitor', 12000);

-- Sales Persons ka data

INSERT INTO SalesMaster (Name) VALUES
('Anitha'),
('Suresh');

-- Orders ka data

INSERT INTO CustomerOrderDetails (OID, CID, SID, Date) VALUES
(101, 1, 1, '2024-01-05'),
(102, 2, 1, '2024-01-06'),
(103, 1, 2, '2024-01-10'),
(104, 3, 1, '2024-02-01'),
(105, 2, 2, '2024-02-10');

-- Order Items ka data

INSERT INTO OrderDetails (OID, PID, Qty) VALUES
(101, 1, 1),
(101, 2, 2),
(102, 3, 1),
(102, 2, 1),
(103, 1, 1),
(104, 4, 1),
(104, 2, 1),
(105, 1, 1),
(105, 3, 1);

-- third highest total sales

SELECT TotalAmount
FROM
(
    SELECT
        od.OID,
        SUM(od.Qty * pm.UnitPrice) AS TotalAmount
    FROM OrderDetails od
    JOIN ProductMaster pm
        ON od.PID = pm.PID
    GROUP BY od.OID
    ORDER BY TotalAmount DESC
    LIMIT 3
) t
ORDER BY TotalAmount
LIMIT 1;

-- salesperson sales > 60000

SELECT
    sm.Name AS SalesPerson,
    SUM(od.Qty * pm.UnitPrice) AS TotalRevenue
FROM OrderDetails od
JOIN ProductMaster pm
    ON od.PID = pm.PID
JOIN CustomerOrderDetails cod
    ON od.OID = cod.OID
JOIN SalesMaster sm
    ON cod.SID = sm.SID
GROUP BY sm.Name
HAVING SUM(od.Qty * pm.UnitPrice) > 60000;


-- customer above average

SELECT
    cm.Name AS CustomerName,
    SUM(od.Qty * pm.UnitPrice) AS TotalSpent
FROM OrderDetails od
JOIN ProductMaster pm
    ON od.PID = pm.PID
JOIN CustomerOrderDetails cod
    ON od.OID = cod.OID
JOIN CustomerMaster cm
    ON cod.CID = cm.CustID
GROUP BY cm.Name
HAVING SUM(od.Qty * pm.UnitPrice) >
(
    SELECT AVG(CustomerTotal)
    FROM
    (
        SELECT
            SUM(od2.Qty * pm2.UnitPrice) AS CustomerTotal
        FROM CustomerOrderDetails cod2
        JOIN OrderDetails od2
            ON cod2.OID = od2.OID
        JOIN ProductMaster pm2
            ON od2.PID = pm2.PID
        GROUP BY cod2.CID
    ) AvgCalc
);


-- string & date function

SELECT
    UPPER(cm.Name) AS CustomerName,
    MONTH(cod.Date) AS OrderMonth
FROM CustomerMaster cm
JOIN CustomerOrderDetails cod
    ON cm.CustID = cod.CID
WHERE cod.Date BETWEEN '2024-01-01' AND '2024-01-31';


