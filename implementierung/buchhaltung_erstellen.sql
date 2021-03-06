USE master;
GO

IF DB_ID(N'buchhaltung') IS NULL
  CREATE DATABASE buchhaltung;
GO

USE buchhaltung;
GO 

IF OBJECT_ID('Einkauf') IS NOT NULL
  DROP TABLE Einkauf;
GO


IF OBJECT_ID('Verkauf') IS NOT NULL
  DROP TABLE Verkauf;
GO


IF OBJECT_ID('Personal') IS NOT NULL
  DROP TABLE Personal;
GO

IF OBJECT_ID('Fixkosten') IS NOT NULL
  DROP TABLE Fixkosten;
GO

IF OBJECT_ID('Arbeitszeiten') IS NOT NULL
  DROP TABLE Arbeitszeiten;
GO

IF OBJECT_ID('Steuersaetze') IS NOT NULL
  DROP TABLE Steuersaetze;
GO

CREATE TABLE Steuersaetze (
  ID_Steuersatz int NOT NULL IDENTITY PRIMARY KEY,
  Bezeichnung nvarchar(100),
  Steuersatz decimal (18, 2)
);

CREATE TABLE Einkauf (
  ID_Einkauf int NOT NULL IDENTITY PRIMARY KEY, 
  Betrag_Netto decimal (18, 2),
  Datum date,
  ID_Steuersatz int
  CONSTRAINT fk_SteuersatzEinkauf 
  FOREIGN KEY (ID_Steuersatz)
	REFERENCES Steuersaetze(ID_Steuersatz)
);


CREATE TABLE Verkauf (
  ID_Verkauf int IDENTITY NOT NULL PRIMARY KEY, 
  Betrag_Netto decimal (18, 2),
  Datum date,
  ID_Steuersatz int
  CONSTRAINT fk_SteuersatzVerkauf 
  FOREIGN KEY (ID_Steuersatz)
	REFERENCES Steuersaetze(ID_Steuersatz)
);

CREATE TABLE Personal (
  ID_Personal int IDENTITY NOT NULL PRIMARY KEY,
  Nachname nvarchar(50),
  Stundenlohn decimal (18, 2),
);

CREATE TABLE Arbeitszeiten (
  ID_Arbeitszeit int IDENTITY NOT NULL PRIMARY KEY, 
  Arbeitsstunden decimal (18, 2),
  Datum date,
  ID_Personal int,
  CONSTRAINT fk_Personal 
  FOREIGN KEY (ID_Personal)
	REFERENCES Personal(ID_Personal)
);


CREATE TABLE Fixkosten (
  ID_Fixkosten int IDENTITY NOT NULL PRIMARY KEY, 
  Bezeichnung nvarchar(50),
  Betrag decimal (18, 2),	
  Datum date
);

