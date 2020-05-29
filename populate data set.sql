-- Inserting data into Employees table 
INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(1, 'MrBoss12', 1, 'CEO' );

INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(2, 'MrManager', 2, 'Manager' );

INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(3, 'HardWorker1', 3, 'Data Entry Temp' );

INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(4, 'HardWorker2', 3, 'UnderWriter' );

INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(5, 'HardWorker3', 3, 'Data analyst' );

INSERT INTO Employees (id, EmployeeId, AcessLevel, Title) 
VALUES(6, 'HardWorker4', 3, 'Data Entry Temp' )

-- Inserting data into Tasks Data 

INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(1, 'MrBoss12', 'BEST BOSS', 'giving work to managers',  '2018-11-11', '2021-11-11');

INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(2, 'MrManager', 'Cool Manager', 'tell boss that he is the best', '2020-11-11', '2020-12-11');

INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(3, 'MrManager', 'Give work', 'Give underlings work',  '2020-11-11', '2020-11-11');


INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(4, 'HardWorker1', 'Talk to Manager', '', '2020-11-11', '2020-12-11');
INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(5, 'HardWorker1', 'enter large data set', 'help transition old CMS to new CMS', '2020-11-11', '');
INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(6, 'HardWorker2', 'Risk aseement', 'Look at the Report', '2020-11-11', '2020-12-11');

INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(7, 'HardWorker3', 'Generate Report', 'Look at new numbers', '2020-11-11', '2020-12-11');


INSERT INTO Tasks (id, TaskHolder, TaskTitle, TaskDesc, DateStartedOn, EstimateToComplition)
VALUES(8, 'HardWorker4', 'enter large data set', 'help fellows out', '2020-11-11', '');