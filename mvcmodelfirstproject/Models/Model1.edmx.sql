
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2023 09:30:57
-- Generated from EDMX file: C:\Users\fztme\OneDrive\Masaüstü\webornekleri\webornekleri2\mvcmodelfirstproject\mvcmodelfirstproject\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mvcmodelfirst];
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

-- Creating table 'plazaSet'
CREATE TABLE [dbo].[plazaSet] (
    [plazaNo] int IDENTITY(1,1) NOT NULL,
    [plazaAdi] nvarchar(max)  NOT NULL,
    [plazaAdres] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'firmaSet'
CREATE TABLE [dbo].[firmaSet] (
    [firmaNo] int IDENTITY(1,1) NOT NULL,
    [firmaAdi] nvarchar(max)  NOT NULL,
    [firmaAdres] nvarchar(max)  NOT NULL,
    [firmaTelefon] nvarchar(max)  NOT NULL,
    [plazaNo] int  NOT NULL
);
GO

-- Creating table 'departmanSet'
CREATE TABLE [dbo].[departmanSet] (
    [departmanNo] int IDENTITY(1,1) NOT NULL,
    [departmanAdi] nvarchar(max)  NOT NULL,
    [departmanAdres] nvarchar(max)  NOT NULL,
    [departmanTel] nvarchar(max)  NOT NULL,
    [firmaNo] int  NOT NULL
);
GO

-- Creating table 'calisanSet'
CREATE TABLE [dbo].[calisanSet] (
    [calisanNo] int IDENTITY(1,1) NOT NULL,
    [adsoyad] nvarchar(max)  NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [calisanTel] nvarchar(max)  NOT NULL,
    [departmanNo] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [plazaNo] in table 'plazaSet'
ALTER TABLE [dbo].[plazaSet]
ADD CONSTRAINT [PK_plazaSet]
    PRIMARY KEY CLUSTERED ([plazaNo] ASC);
GO

-- Creating primary key on [firmaNo] in table 'firmaSet'
ALTER TABLE [dbo].[firmaSet]
ADD CONSTRAINT [PK_firmaSet]
    PRIMARY KEY CLUSTERED ([firmaNo] ASC);
GO

-- Creating primary key on [departmanNo] in table 'departmanSet'
ALTER TABLE [dbo].[departmanSet]
ADD CONSTRAINT [PK_departmanSet]
    PRIMARY KEY CLUSTERED ([departmanNo] ASC);
GO

-- Creating primary key on [calisanNo] in table 'calisanSet'
ALTER TABLE [dbo].[calisanSet]
ADD CONSTRAINT [PK_calisanSet]
    PRIMARY KEY CLUSTERED ([calisanNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [plazaNo] in table 'firmaSet'
ALTER TABLE [dbo].[firmaSet]
ADD CONSTRAINT [FK_plazafirma]
    FOREIGN KEY ([plazaNo])
    REFERENCES [dbo].[plazaSet]
        ([plazaNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_plazafirma'
CREATE INDEX [IX_FK_plazafirma]
ON [dbo].[firmaSet]
    ([plazaNo]);
GO

-- Creating foreign key on [firmaNo] in table 'departmanSet'
ALTER TABLE [dbo].[departmanSet]
ADD CONSTRAINT [FK_firmadepartman]
    FOREIGN KEY ([firmaNo])
    REFERENCES [dbo].[firmaSet]
        ([firmaNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_firmadepartman'
CREATE INDEX [IX_FK_firmadepartman]
ON [dbo].[departmanSet]
    ([firmaNo]);
GO

-- Creating foreign key on [departmanNo] in table 'calisanSet'
ALTER TABLE [dbo].[calisanSet]
ADD CONSTRAINT [FK_departmancalisan]
    FOREIGN KEY ([departmanNo])
    REFERENCES [dbo].[departmanSet]
        ([departmanNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_departmancalisan'
CREATE INDEX [IX_FK_departmancalisan]
ON [dbo].[calisanSet]
    ([departmanNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------