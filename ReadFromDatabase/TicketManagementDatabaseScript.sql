CREATE DATABASE TicketManagementDatabase
USE TicketManagementDatabase

CREATE TABLE [Planes] (
    [Id] INT,
    [Name] VARCHAR(50),
    [Make] VARCHAR(50),
    [Model] VARCHAR(50),
    PRIMARY KEY ([Id])
    );

CREATE TABLE [Customers] (
    [Id] INT,
    [FirstName] VARCHAR(50),
    [LastName] VARCHAR(50),
    [Country] VARCHAR(50),
    [Age] INT,
    PRIMARY KEY ([Id])
    );

CREATE TABLE [Tickets] (
    [Id] INT,
    [From] VARCHAR(50),
    [To] VARCHAR(50),
    [DepartureTime] DATETIME2,
    [ArrivalTime] DATETIME2,
    [SeatNumber] VARCHAR(50),
    [PlaneId] INT,
    [CustomerId] INT,
    PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tickets.PlaneId]
    FOREIGN KEY ([PlaneId])
    REFERENCES [Planes]([Id]),
    CONSTRAINT [FK_Tickets.CustomerId]
    FOREIGN KEY ([CustomerId])
    REFERENCES [Customers]([Id])
    );

