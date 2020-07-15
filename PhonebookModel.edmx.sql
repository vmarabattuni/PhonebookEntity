
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2020 20:51:22
-- Generated from EDMX file: C:\Users\vmarabattuni\source\repos\PhonebookEntity\PhonebookModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContactDirectoryDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContactDirectories'
CREATE TABLE [dbo].[ContactDirectories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContactAddresses'
CREATE TABLE [dbo].[ContactAddresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Pincode] nvarchar(max)  NOT NULL,
    [ContactDirectoryId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ContactDirectories'
ALTER TABLE [dbo].[ContactDirectories]
ADD CONSTRAINT [PK_ContactDirectories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactAddresses'
ALTER TABLE [dbo].[ContactAddresses]
ADD CONSTRAINT [PK_ContactAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContactDirectoryId] in table 'ContactAddresses'
ALTER TABLE [dbo].[ContactAddresses]
ADD CONSTRAINT [FK_ContactDirectoryContactAddress]
    FOREIGN KEY ([ContactDirectoryId])
    REFERENCES [dbo].[ContactDirectories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactDirectoryContactAddress'
CREATE INDEX [IX_FK_ContactDirectoryContactAddress]
ON [dbo].[ContactAddresses]
    ([ContactDirectoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------