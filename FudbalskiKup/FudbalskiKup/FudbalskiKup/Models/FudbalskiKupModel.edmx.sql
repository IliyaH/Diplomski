
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/07/2020 17:11:01
-- Generated from EDMX file: F:\Diplomski\FudbalskiKup\FudbalskiKup\FudbalskiKup\App_Data\FudbalskiKupModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BazaDiplomski];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Igra_Sudija_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igra] DROP CONSTRAINT [FK_Igra_Sudija_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Igra_Tim_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igra] DROP CONSTRAINT [FK_Igra_Tim_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Igra_Utakmica_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igra] DROP CONSTRAINT [FK_Igra_Utakmica_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Igrac_Tim_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igrac] DROP CONSTRAINT [FK_Igrac_Tim_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Karta_Odrzava_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Karta] DROP CONSTRAINT [FK_Karta_Odrzava_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Kupuje_Karta_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kupuje] DROP CONSTRAINT [FK_Kupuje_Karta_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Kupuje_Navijac_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kupuje] DROP CONSTRAINT [FK_Kupuje_Navijac_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_LicnaNagrada_Igrac_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicnaNagrada] DROP CONSTRAINT [FK_LicnaNagrada_Igrac_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_LicnaNagrada_Nagrada_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicnaNagrada] DROP CONSTRAINT [FK_LicnaNagrada_Nagrada_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Odrzava_Stadion_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odrzava] DROP CONSTRAINT [FK_Odrzava_Stadion_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Odrzava_Utakmica_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odrzava] DROP CONSTRAINT [FK_Odrzava_Utakmica_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Posecuje_Kupuje_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posecuje] DROP CONSTRAINT [FK_Posecuje_Kupuje_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Posecuje_Odrzava_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posecuje] DROP CONSTRAINT [FK_Posecuje_Odrzava_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Stadion_Grad_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stadion] DROP CONSTRAINT [FK_Stadion_Grad_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_Tim_Grad_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tim] DROP CONSTRAINT [FK_Tim_Grad_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_TimskaNagrada_Nagrada_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimskaNagrada] DROP CONSTRAINT [FK_TimskaNagrada_Nagrada_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_TimskaNagrada_Tim_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimskaNagrada] DROP CONSTRAINT [FK_TimskaNagrada_Tim_FK];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__RefactorLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__RefactorLog];
GO
IF OBJECT_ID(N'[dbo].[Grad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grad];
GO
IF OBJECT_ID(N'[dbo].[Igra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Igra];
GO
IF OBJECT_ID(N'[dbo].[Igrac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Igrac];
GO
IF OBJECT_ID(N'[dbo].[Karta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Karta];
GO
IF OBJECT_ID(N'[dbo].[Kupuje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kupuje];
GO
IF OBJECT_ID(N'[dbo].[LicnaNagrada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LicnaNagrada];
GO
IF OBJECT_ID(N'[dbo].[Nagrada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nagrada];
GO
IF OBJECT_ID(N'[dbo].[Navijac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Navijac];
GO
IF OBJECT_ID(N'[dbo].[Odrzava]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odrzava];
GO
IF OBJECT_ID(N'[dbo].[Posecuje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posecuje];
GO
IF OBJECT_ID(N'[dbo].[Stadion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stadion];
GO
IF OBJECT_ID(N'[dbo].[sudija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sudija];
GO
IF OBJECT_ID(N'[dbo].[Tim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tim];
GO
IF OBJECT_ID(N'[dbo].[TimskaNagrada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimskaNagrada];
GO
IF OBJECT_ID(N'[dbo].[Utakmica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utakmica];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__RefactorLog'
CREATE TABLE [dbo].[C__RefactorLog] (
    [OperationKey] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Grads'
CREATE TABLE [dbo].[Grads] (
    [GradID] int  NOT NULL,
    [Drzava] varchar(30)  NOT NULL,
    [Ime] varchar(30)  NOT NULL
);
GO

-- Creating table 'Igras'
CREATE TABLE [dbo].[Igras] (
    [Tim_TimID] int  NOT NULL,
    [Utakmica_UtakmicaID] int  NOT NULL,
    [Sudija_SudijaID] int  NOT NULL,
    [BrojGolova] int  NULL
);
GO

-- Creating table 'Igracs'
CREATE TABLE [dbo].[Igracs] (
    [IgracID] int  NOT NULL,
    [Ime] varchar(30)  NOT NULL,
    [Prezime] varchar(30)  NOT NULL,
    [BrojPostignutihGolova] int  NOT NULL,
    [Tim_TimId] int  NOT NULL
);
GO

-- Creating table 'Kartas'
CREATE TABLE [dbo].[Kartas] (
    [Odrzava_UtakmicaID] int  NOT NULL,
    [Odrzava_StadionID] int  NOT NULL,
    [KartaID] int  NOT NULL,
    [Cena] int  NOT NULL
);
GO

-- Creating table 'Kupujes'
CREATE TABLE [dbo].[Kupujes] (
    [Karta_KartaID] int  NOT NULL,
    [Navijac_NavijacID] int  NOT NULL
);
GO

-- Creating table 'LicnaNagradas'
CREATE TABLE [dbo].[LicnaNagradas] (
    [NagradaID] int  NOT NULL,
    [VrstaNagrade] varchar(30)  NOT NULL,
    [Igrac_IgracID] int  NULL
);
GO

-- Creating table 'Nagradas'
CREATE TABLE [dbo].[Nagradas] (
    [NagradaID] int  NOT NULL
);
GO

-- Creating table 'Navijacs'
CREATE TABLE [dbo].[Navijacs] (
    [NavijacID] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [KorisnickoIme] nvarchar(max)  NOT NULL,
    [Sifra] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Odrzavas'
CREATE TABLE [dbo].[Odrzavas] (
    [Utakmica_UtakmicaID] int  NOT NULL,
    [Stadion_StadionID] int  NOT NULL
);
GO

-- Creating table 'Stadions'
CREATE TABLE [dbo].[Stadions] (
    [StadionID] int  NOT NULL,
    [Ime] varchar(30)  NOT NULL,
    [Grad_GradID] int  NOT NULL
);
GO

-- Creating table 'sudijas'
CREATE TABLE [dbo].[sudijas] (
    [SudijaID] int  NOT NULL,
    [Prezime] varchar(30)  NOT NULL,
    [Ime] varchar(30)  NOT NULL
);
GO

-- Creating table 'Tims'
CREATE TABLE [dbo].[Tims] (
    [TimID] int  NOT NULL,
    [Ime] varchar(30)  NOT NULL,
    [Grad_GradId] int  NOT NULL
);
GO

-- Creating table 'TimskaNagradas'
CREATE TABLE [dbo].[TimskaNagradas] (
    [NagradaID] int  NOT NULL,
    [TipNagrade] varchar(30)  NOT NULL,
    [Tim_TimID] int  NULL
);
GO

-- Creating table 'Utakmicas'
CREATE TABLE [dbo].[Utakmicas] (
    [UtakmicaID] int  NOT NULL,
    [Odigrana] bit  NOT NULL,
    [Datum] datetime  NOT NULL,
    [FazaTakmicenja] varchar(30)  NOT NULL
);
GO

-- Creating table 'Posecuje'
CREATE TABLE [dbo].[Posecuje] (
    [Kupujes_Karta_KartaID] int  NOT NULL,
    [Kupujes_Navijac_NavijacID] int  NOT NULL,
    [Odrzavas_Utakmica_UtakmicaID] int  NOT NULL,
    [Odrzavas_Stadion_StadionID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OperationKey] in table 'C__RefactorLog'
ALTER TABLE [dbo].[C__RefactorLog]
ADD CONSTRAINT [PK_C__RefactorLog]
    PRIMARY KEY CLUSTERED ([OperationKey] ASC);
GO

-- Creating primary key on [GradID] in table 'Grads'
ALTER TABLE [dbo].[Grads]
ADD CONSTRAINT [PK_Grads]
    PRIMARY KEY CLUSTERED ([GradID] ASC);
GO

-- Creating primary key on [Tim_TimID], [Utakmica_UtakmicaID] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [PK_Igras]
    PRIMARY KEY CLUSTERED ([Tim_TimID], [Utakmica_UtakmicaID] ASC);
GO

-- Creating primary key on [IgracID] in table 'Igracs'
ALTER TABLE [dbo].[Igracs]
ADD CONSTRAINT [PK_Igracs]
    PRIMARY KEY CLUSTERED ([IgracID] ASC);
GO

-- Creating primary key on [KartaID] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [PK_Kartas]
    PRIMARY KEY CLUSTERED ([KartaID] ASC);
GO

-- Creating primary key on [Karta_KartaID], [Navijac_NavijacID] in table 'Kupujes'
ALTER TABLE [dbo].[Kupujes]
ADD CONSTRAINT [PK_Kupujes]
    PRIMARY KEY CLUSTERED ([Karta_KartaID], [Navijac_NavijacID] ASC);
GO

-- Creating primary key on [NagradaID] in table 'LicnaNagradas'
ALTER TABLE [dbo].[LicnaNagradas]
ADD CONSTRAINT [PK_LicnaNagradas]
    PRIMARY KEY CLUSTERED ([NagradaID] ASC);
GO

-- Creating primary key on [NagradaID] in table 'Nagradas'
ALTER TABLE [dbo].[Nagradas]
ADD CONSTRAINT [PK_Nagradas]
    PRIMARY KEY CLUSTERED ([NagradaID] ASC);
GO

-- Creating primary key on [NavijacID] in table 'Navijacs'
ALTER TABLE [dbo].[Navijacs]
ADD CONSTRAINT [PK_Navijacs]
    PRIMARY KEY CLUSTERED ([NavijacID] ASC);
GO

-- Creating primary key on [Utakmica_UtakmicaID], [Stadion_StadionID] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [PK_Odrzavas]
    PRIMARY KEY CLUSTERED ([Utakmica_UtakmicaID], [Stadion_StadionID] ASC);
GO

-- Creating primary key on [StadionID] in table 'Stadions'
ALTER TABLE [dbo].[Stadions]
ADD CONSTRAINT [PK_Stadions]
    PRIMARY KEY CLUSTERED ([StadionID] ASC);
GO

-- Creating primary key on [SudijaID] in table 'sudijas'
ALTER TABLE [dbo].[sudijas]
ADD CONSTRAINT [PK_sudijas]
    PRIMARY KEY CLUSTERED ([SudijaID] ASC);
GO

-- Creating primary key on [TimID] in table 'Tims'
ALTER TABLE [dbo].[Tims]
ADD CONSTRAINT [PK_Tims]
    PRIMARY KEY CLUSTERED ([TimID] ASC);
GO

-- Creating primary key on [NagradaID] in table 'TimskaNagradas'
ALTER TABLE [dbo].[TimskaNagradas]
ADD CONSTRAINT [PK_TimskaNagradas]
    PRIMARY KEY CLUSTERED ([NagradaID] ASC);
GO

-- Creating primary key on [UtakmicaID] in table 'Utakmicas'
ALTER TABLE [dbo].[Utakmicas]
ADD CONSTRAINT [PK_Utakmicas]
    PRIMARY KEY CLUSTERED ([UtakmicaID] ASC);
GO

-- Creating primary key on [Kupujes_Karta_KartaID], [Kupujes_Navijac_NavijacID], [Odrzavas_Utakmica_UtakmicaID], [Odrzavas_Stadion_StadionID] in table 'Posecuje'
ALTER TABLE [dbo].[Posecuje]
ADD CONSTRAINT [PK_Posecuje]
    PRIMARY KEY CLUSTERED ([Kupujes_Karta_KartaID], [Kupujes_Navijac_NavijacID], [Odrzavas_Utakmica_UtakmicaID], [Odrzavas_Stadion_StadionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Grad_GradID] in table 'Stadions'
ALTER TABLE [dbo].[Stadions]
ADD CONSTRAINT [FK_Stadion_Grad_FK]
    FOREIGN KEY ([Grad_GradID])
    REFERENCES [dbo].[Grads]
        ([GradID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Stadion_Grad_FK'
CREATE INDEX [IX_FK_Stadion_Grad_FK]
ON [dbo].[Stadions]
    ([Grad_GradID]);
GO

-- Creating foreign key on [Grad_GradId] in table 'Tims'
ALTER TABLE [dbo].[Tims]
ADD CONSTRAINT [FK_Tim_Grad_FK]
    FOREIGN KEY ([Grad_GradId])
    REFERENCES [dbo].[Grads]
        ([GradID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tim_Grad_FK'
CREATE INDEX [IX_FK_Tim_Grad_FK]
ON [dbo].[Tims]
    ([Grad_GradId]);
GO

-- Creating foreign key on [Sudija_SudijaID] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [FK_Igra_Sudija_FK]
    FOREIGN KEY ([Sudija_SudijaID])
    REFERENCES [dbo].[sudijas]
        ([SudijaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Igra_Sudija_FK'
CREATE INDEX [IX_FK_Igra_Sudija_FK]
ON [dbo].[Igras]
    ([Sudija_SudijaID]);
GO

-- Creating foreign key on [Tim_TimID] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [FK_Igra_Tim_FK]
    FOREIGN KEY ([Tim_TimID])
    REFERENCES [dbo].[Tims]
        ([TimID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Utakmica_UtakmicaID] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [FK_Igra_Utakmica_FK]
    FOREIGN KEY ([Utakmica_UtakmicaID])
    REFERENCES [dbo].[Utakmicas]
        ([UtakmicaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Igra_Utakmica_FK'
CREATE INDEX [IX_FK_Igra_Utakmica_FK]
ON [dbo].[Igras]
    ([Utakmica_UtakmicaID]);
GO

-- Creating foreign key on [Tim_TimId] in table 'Igracs'
ALTER TABLE [dbo].[Igracs]
ADD CONSTRAINT [FK_Igrac_Tim_FK]
    FOREIGN KEY ([Tim_TimId])
    REFERENCES [dbo].[Tims]
        ([TimID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Igrac_Tim_FK'
CREATE INDEX [IX_FK_Igrac_Tim_FK]
ON [dbo].[Igracs]
    ([Tim_TimId]);
GO

-- Creating foreign key on [Igrac_IgracID] in table 'LicnaNagradas'
ALTER TABLE [dbo].[LicnaNagradas]
ADD CONSTRAINT [FK_LicnaNagrada_Igrac_FK]
    FOREIGN KEY ([Igrac_IgracID])
    REFERENCES [dbo].[Igracs]
        ([IgracID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicnaNagrada_Igrac_FK'
CREATE INDEX [IX_FK_LicnaNagrada_Igrac_FK]
ON [dbo].[LicnaNagradas]
    ([Igrac_IgracID]);
GO

-- Creating foreign key on [Odrzava_UtakmicaID], [Odrzava_StadionID] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [FK_Karta_Odrzava_FK]
    FOREIGN KEY ([Odrzava_UtakmicaID], [Odrzava_StadionID])
    REFERENCES [dbo].[Odrzavas]
        ([Utakmica_UtakmicaID], [Stadion_StadionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Karta_Odrzava_FK'
CREATE INDEX [IX_FK_Karta_Odrzava_FK]
ON [dbo].[Kartas]
    ([Odrzava_UtakmicaID], [Odrzava_StadionID]);
GO

-- Creating foreign key on [Karta_KartaID] in table 'Kupujes'
ALTER TABLE [dbo].[Kupujes]
ADD CONSTRAINT [FK_Kupuje_Karta_FK]
    FOREIGN KEY ([Karta_KartaID])
    REFERENCES [dbo].[Kartas]
        ([KartaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Navijac_NavijacID] in table 'Kupujes'
ALTER TABLE [dbo].[Kupujes]
ADD CONSTRAINT [FK_Kupuje_Navijac_FK]
    FOREIGN KEY ([Navijac_NavijacID])
    REFERENCES [dbo].[Navijacs]
        ([NavijacID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kupuje_Navijac_FK'
CREATE INDEX [IX_FK_Kupuje_Navijac_FK]
ON [dbo].[Kupujes]
    ([Navijac_NavijacID]);
GO

-- Creating foreign key on [NagradaID] in table 'LicnaNagradas'
ALTER TABLE [dbo].[LicnaNagradas]
ADD CONSTRAINT [FK_LicnaNagrada_Nagrada_FK]
    FOREIGN KEY ([NagradaID])
    REFERENCES [dbo].[Nagradas]
        ([NagradaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [NagradaID] in table 'TimskaNagradas'
ALTER TABLE [dbo].[TimskaNagradas]
ADD CONSTRAINT [FK_TimskaNagrada_Nagrada_FK]
    FOREIGN KEY ([NagradaID])
    REFERENCES [dbo].[Nagradas]
        ([NagradaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Stadion_StadionID] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [FK_Odrzava_Stadion_FK]
    FOREIGN KEY ([Stadion_StadionID])
    REFERENCES [dbo].[Stadions]
        ([StadionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Odrzava_Stadion_FK'
CREATE INDEX [IX_FK_Odrzava_Stadion_FK]
ON [dbo].[Odrzavas]
    ([Stadion_StadionID]);
GO

-- Creating foreign key on [Utakmica_UtakmicaID] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [FK_Odrzava_Utakmica_FK]
    FOREIGN KEY ([Utakmica_UtakmicaID])
    REFERENCES [dbo].[Utakmicas]
        ([UtakmicaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tim_TimID] in table 'TimskaNagradas'
ALTER TABLE [dbo].[TimskaNagradas]
ADD CONSTRAINT [FK_TimskaNagrada_Tim_FK]
    FOREIGN KEY ([Tim_TimID])
    REFERENCES [dbo].[Tims]
        ([TimID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TimskaNagrada_Tim_FK'
CREATE INDEX [IX_FK_TimskaNagrada_Tim_FK]
ON [dbo].[TimskaNagradas]
    ([Tim_TimID]);
GO

-- Creating foreign key on [Kupujes_Karta_KartaID], [Kupujes_Navijac_NavijacID] in table 'Posecuje'
ALTER TABLE [dbo].[Posecuje]
ADD CONSTRAINT [FK_Posecuje_Kupuje]
    FOREIGN KEY ([Kupujes_Karta_KartaID], [Kupujes_Navijac_NavijacID])
    REFERENCES [dbo].[Kupujes]
        ([Karta_KartaID], [Navijac_NavijacID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Odrzavas_Utakmica_UtakmicaID], [Odrzavas_Stadion_StadionID] in table 'Posecuje'
ALTER TABLE [dbo].[Posecuje]
ADD CONSTRAINT [FK_Posecuje_Odrzava]
    FOREIGN KEY ([Odrzavas_Utakmica_UtakmicaID], [Odrzavas_Stadion_StadionID])
    REFERENCES [dbo].[Odrzavas]
        ([Utakmica_UtakmicaID], [Stadion_StadionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Posecuje_Odrzava'
CREATE INDEX [IX_FK_Posecuje_Odrzava]
ON [dbo].[Posecuje]
    ([Odrzavas_Utakmica_UtakmicaID], [Odrzavas_Stadion_StadionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------