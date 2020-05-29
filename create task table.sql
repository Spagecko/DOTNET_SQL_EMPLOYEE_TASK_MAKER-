CREATE TABLE Tasks (id int NOT NULL PRIMARY KEY,  TaskHolder VARCHAR(30) NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
TaskTitle VARCHAR (50) NOT NULL, 
TaskDesc VARCHAR (100), 
DateStartedOn DATE NOT NULL, 
EstimateToComplition  DATE, )  