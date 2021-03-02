USE AlarmSYS
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Equipments_Type')
CREATE TABLE Equipments_Type(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Value VARCHAR(100)
)
GO
IF NOT EXISTS (SELECT * FROM Equipments_Type WHERE Value = 'Tensão')
INSERT INTO Equipments_Type(Value) VALUES('Tensão')
GO
IF NOT EXISTS (SELECT * FROM Equipments_Type WHERE Value = 'Corrente')
INSERT INTO Equipments_Type(Value) VALUES('Corrente')
GO
IF NOT EXISTS (SELECT * FROM Equipments_Type WHERE Value = 'Óleo')
INSERT INTO Equipments_Type(Value) VALUES('Óleo')
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Equipments')
CREATE TABLE Equipments(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name Varchar(100) NOT NULL,
	Description VARCHAR(255),
	SerialNumber INT NOT NULL,
	Id_Type INT,
	RegisterDate DATETIME DEFAULT GETDATE()

	CONSTRAINT FK_Equipments_Type FOREIGN KEY (Id_Type) REFERENCES Equipments_Type(Id)
)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Alarms_Classification')
CREATE TABLE Alarms_Classification(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Value VARCHAR(100)
)
GO
IF NOT EXISTS (SELECT * FROM Alarms_Classification WHERE Value = 'Baixo')
INSERT INTO Alarms_Classification(Value) VALUES('Baixo')
GO
IF NOT EXISTS (SELECT * FROM Alarms_Classification WHERE Value = 'Médio')
INSERT INTO Alarms_Classification(Value) VALUES('Médio')
GO
IF NOT EXISTS (SELECT * FROM Alarms_Classification WHERE Value = 'Alto')
INSERT INTO Alarms_Classification(Value) VALUES('Alto')
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Alarms')
CREATE TABLE Alarms(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Description VARCHAR(255) NOT NULL,
	Id_Classification INT,
	Id_Equipment INT,
	RegisterDate DATETIME DEFAULT GETDATE()

	CONSTRAINT FK_Alarm_Classification FOREIGN KEY (Id_Classification) REFERENCES Alarms_Classification(Id),
	CONSTRAINT FK_Alarm_Equipment FOREIGN KEY (Id_Equipment) REFERENCES Equipments(Id)
)
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Alarms_Status')
CREATE TABLE Alarms_Status(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Value VARCHAR(100)
)
GO
IF NOT EXISTS (SELECT * FROM Alarms_Status WHERE Value = 'Atuando')
INSERT INTO Alarms_Status(Value) VALUES('Atuando')
GO
IF NOT EXISTS (SELECT * FROM Alarms_Status WHERE Value = 'Resolvido')
INSERT INTO Alarms_Status(Value) VALUES('Resolvido')
GO
IF NOT EXISTS (SELECT * FROM Alarms_Status WHERE Value = 'Não Resolvido')
INSERT INTO Alarms_Status(Value) VALUES('Não Resolvido')
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Alarms_Acted')
CREATE TABLE Alarms_Acted(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Id_Alarm INT,
	Id_Status INT,
	InputDate DATETIME, -- This field gonna represent the time when anyone start to take care about the related alarm
	OutputDate DATETIME,-- This field gonna represent the time when anyone end the care process of the related alarm,
	RegisterDate DATETIME DEFAULT GETDATE(),

	CONSTRAINT FK_Alarms_Acted_Status FOREIGN KEY (Id_Status) REFERENCES Alarms_Status(Id),
	CONSTRAINT FK_Alarms_Acted_Alarm FOREIGN KEY (Id_Alarm) REFERENCES Alarms(Id)

)