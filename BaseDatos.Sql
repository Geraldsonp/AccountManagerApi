drop database if exists AccountsManagerDB
go

CREATE DATABASE AccountsManagerDB;

USE AccountsManagerDB;

CREATE DATABASE AccountMngDB;

USE AccountMngDB;

-- CREATE TABLE Person (Remove this section, as you don't need a separate table for Person)

CREATE TABLE Client
(
    ClientID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    Age INT NOT NULL,
    Identification VARCHAR(20) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Status VARCHAR(20) NOT NULL
);

CREATE TABLE Account
(
    AccountNumber VARCHAR(20) PRIMARY KEY,
    AccountType VARCHAR(50) NOT NULL,
    InitialBalance DECIMAL(10, 2) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    ClientID INT NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Client(ClientID)
);

-- Table for Transactions
CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY IDENTITY,
    AccountNumber VARCHAR(20),
    Date DATETIME NOT NULL,
    TransactionType VARCHAR(50) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    Balance DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (AccountNumber) REFERENCES Account(AccountNumber)
);


