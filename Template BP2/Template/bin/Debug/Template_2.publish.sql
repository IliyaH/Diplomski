﻿/*
Deployment script for DiplomskiBaza

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DiplomskiBaza"
:setvar DefaultFilePrefix "DiplomskiBaza"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Grad]...';


GO
CREATE TABLE [dbo].[Grad] (
    [GradID] INT          NOT NULL,
    [Drzava] VARCHAR (30) NOT NULL,
    [Ime]    VARCHAR (30) NOT NULL,
    CONSTRAINT [Grad_PK] PRIMARY KEY CLUSTERED ([GradID] ASC)
);


GO
PRINT N'Creating [dbo].[Igra]...';


GO
CREATE TABLE [dbo].[Igra] (
    [Tim_TimID]           INT NOT NULL,
    [Utakmica_UtakmicaID] INT NOT NULL,
    [Sudija_SudijaID]     INT NOT NULL,
    [BrojGolova]          INT NULL,
    CONSTRAINT [IgraPK] PRIMARY KEY CLUSTERED ([Tim_TimID] ASC, [Utakmica_UtakmicaID] ASC)
);


GO
PRINT N'Creating [dbo].[Igrac]...';


GO
CREATE TABLE [dbo].[Igrac] (
    [IgracID]               INT          NOT NULL,
    [Ime]                   VARCHAR (30) NOT NULL,
    [Prezime]               VARCHAR (30) NOT NULL,
    [BrojPostignutihGolova] INT          NOT NULL,
    [Tim_TimId]             INT          NOT NULL,
    CONSTRAINT [Igrac_PK] PRIMARY KEY CLUSTERED ([IgracID] ASC)
);


GO
PRINT N'Creating [dbo].[Karta]...';


GO
CREATE TABLE [dbo].[Karta] (
    [Odrzava_UtakmicaID] INT NOT NULL,
    [Odrzava_StadionID]  INT NOT NULL,
    [KartaID]            INT NOT NULL,
    [Cena]               INT NOT NULL,
    CONSTRAINT [Karta_PK] PRIMARY KEY CLUSTERED ([KartaID] ASC)
);


GO
PRINT N'Creating [dbo].[Kupuje]...';


GO
CREATE TABLE [dbo].[Kupuje] (
    [Karta_KartaID]     INT NOT NULL,
    [Navijac_NavijacID] INT NOT NULL,
    CONSTRAINT [Kupuje_PK] PRIMARY KEY CLUSTERED ([Karta_KartaID] ASC, [Navijac_NavijacID] ASC)
);


GO
PRINT N'Creating [dbo].[LicnaNagrada]...';


GO
CREATE TABLE [dbo].[LicnaNagrada] (
    [NagradaID]     INT          NOT NULL,
    [VrstaNagrade]  VARCHAR (30) NOT NULL,
    [Igrac_IgracID] INT          NULL,
    CONSTRAINT [LicnaNagrada_PK] PRIMARY KEY CLUSTERED ([NagradaID] ASC)
);


GO
PRINT N'Creating [dbo].[Nagrada]...';


GO
CREATE TABLE [dbo].[Nagrada] (
    [NagradaID] INT NOT NULL,
    CONSTRAINT [Nagrada_PK] PRIMARY KEY CLUSTERED ([NagradaID] ASC)
);


GO
PRINT N'Creating [dbo].[Navijac]...';


GO
CREATE TABLE [dbo].[Navijac] (
    [NavijacID]     INT          NOT NULL,
    [Ime]           VARCHAR (30) NOT NULL,
    [Prezime]       INT          NOT NULL,
    [KorisnickoIme] VARCHAR (30) NOT NULL,
    [Email]         VARCHAR (30) NOT NULL,
    [Sifra]         VARCHAR (30) NOT NULL,
    CONSTRAINT [Navijac_PK] PRIMARY KEY CLUSTERED ([NavijacID] ASC),
    CONSTRAINT [KorisnickoIme] UNIQUE NONCLUSTERED ([KorisnickoIme] ASC)
);


GO
PRINT N'Creating [dbo].[Odrzava]...';


GO
CREATE TABLE [dbo].[Odrzava] (
    [Utakmica_UtakmicaID] INT NOT NULL,
    [Stadion_StadionID]   INT NOT NULL,
    CONSTRAINT [Odrzava_PK] PRIMARY KEY CLUSTERED ([Utakmica_UtakmicaID] ASC, [Stadion_StadionID] ASC)
);


GO
PRINT N'Creating [dbo].[Posecuje]...';


GO
CREATE TABLE [dbo].[Posecuje] (
    [Kupuje_Karta_KartaID]     INT NOT NULL,
    [Kupuje_Navijac_NavijacID] INT NOT NULL,
    [Odrzava_UtakmicaID]       INT NOT NULL,
    [Odrzava_StadionID]        INT NOT NULL,
    CONSTRAINT [Posecuje_PKJ] PRIMARY KEY CLUSTERED ([Kupuje_Karta_KartaID] ASC, [Kupuje_Navijac_NavijacID] ASC, [Odrzava_UtakmicaID] ASC, [Odrzava_StadionID] ASC)
);


GO
PRINT N'Creating [dbo].[Stadion]...';


GO
CREATE TABLE [dbo].[Stadion] (
    [StadionID]   INT          NOT NULL,
    [Ime]         VARCHAR (30) NOT NULL,
    [Grad_GradID] INT          NOT NULL,
    CONSTRAINT [Stadion_PK] PRIMARY KEY CLUSTERED ([StadionID] ASC)
);


GO
PRINT N'Creating [dbo].[sudija]...';


GO
CREATE TABLE [dbo].[sudija] (
    [SudijaID] INT          NOT NULL,
    [Prezime]  VARCHAR (30) NOT NULL,
    [Ime]      VARCHAR (30) NOT NULL,
    CONSTRAINT [Sudija_PK] PRIMARY KEY CLUSTERED ([SudijaID] ASC)
);


GO
PRINT N'Creating [dbo].[Tim]...';


GO
CREATE TABLE [dbo].[Tim] (
    [TimID]       INT          NOT NULL,
    [Ime]         VARCHAR (30) NOT NULL,
    [Grad_GradId] INT          NOT NULL,
    CONSTRAINT [Tim_PK] PRIMARY KEY CLUSTERED ([TimID] ASC)
);


GO
PRINT N'Creating [dbo].[TimskaNagrada]...';


GO
CREATE TABLE [dbo].[TimskaNagrada] (
    [NagradaID]  INT          NOT NULL,
    [TipNagrade] VARCHAR (30) NOT NULL,
    [Tim_TimID]  INT          NULL,
    CONSTRAINT [Timska_Nagrada_PK] PRIMARY KEY CLUSTERED ([NagradaID] ASC)
);


GO
PRINT N'Creating [dbo].[Utakmica]...';


GO
CREATE TABLE [dbo].[Utakmica] (
    [UtakmicaID]     INT          NOT NULL,
    [Odigrana]       CHAR (1)     NOT NULL,
    [Datum]          DATE         NOT NULL,
    [FazaTakmicenja] VARCHAR (30) NOT NULL,
    CONSTRAINT [Utakmica_PK] PRIMARY KEY CLUSTERED ([UtakmicaID] ASC)
);


GO
PRINT N'Creating [dbo].[Igra_Utakmica_FK]...';


GO
ALTER TABLE [dbo].[Igra]
    ADD CONSTRAINT [Igra_Utakmica_FK] FOREIGN KEY ([Utakmica_UtakmicaID]) REFERENCES [dbo].[Utakmica] ([UtakmicaID]);


GO
PRINT N'Creating [dbo].[Igra_Tim_FK]...';


GO
ALTER TABLE [dbo].[Igra]
    ADD CONSTRAINT [Igra_Tim_FK] FOREIGN KEY ([Tim_TimID]) REFERENCES [dbo].[Tim] ([TimID]);


GO
PRINT N'Creating [dbo].[Igra_Sudija_FK]...';


GO
ALTER TABLE [dbo].[Igra]
    ADD CONSTRAINT [Igra_Sudija_FK] FOREIGN KEY ([Sudija_SudijaID]) REFERENCES [dbo].[sudija] ([SudijaID]);


GO
PRINT N'Creating [dbo].[Igrac_Tim_FK]...';


GO
ALTER TABLE [dbo].[Igrac]
    ADD CONSTRAINT [Igrac_Tim_FK] FOREIGN KEY ([Tim_TimId]) REFERENCES [dbo].[Tim] ([TimID]);


GO
PRINT N'Creating [dbo].[Karta_Odrzava_FK]...';


GO
ALTER TABLE [dbo].[Karta]
    ADD CONSTRAINT [Karta_Odrzava_FK] FOREIGN KEY ([Odrzava_UtakmicaID], [Odrzava_StadionID]) REFERENCES [dbo].[Odrzava] ([Utakmica_UtakmicaID], [Stadion_StadionID]);


GO
PRINT N'Creating [dbo].[Kupuje_Navijac_FK]...';


GO
ALTER TABLE [dbo].[Kupuje]
    ADD CONSTRAINT [Kupuje_Navijac_FK] FOREIGN KEY ([Navijac_NavijacID]) REFERENCES [dbo].[Navijac] ([NavijacID]);


GO
PRINT N'Creating [dbo].[Kupuje_Karta_FK]...';


GO
ALTER TABLE [dbo].[Kupuje]
    ADD CONSTRAINT [Kupuje_Karta_FK] FOREIGN KEY ([Karta_KartaID]) REFERENCES [dbo].[Karta] ([KartaID]);


GO
PRINT N'Creating [dbo].[LicnaNagrada_Nagrada_FK]...';


GO
ALTER TABLE [dbo].[LicnaNagrada]
    ADD CONSTRAINT [LicnaNagrada_Nagrada_FK] FOREIGN KEY ([NagradaID]) REFERENCES [dbo].[Nagrada] ([NagradaID]);


GO
PRINT N'Creating [dbo].[LicnaNagrada_Igrac_FK]...';


GO
ALTER TABLE [dbo].[LicnaNagrada]
    ADD CONSTRAINT [LicnaNagrada_Igrac_FK] FOREIGN KEY ([Igrac_IgracID]) REFERENCES [dbo].[Igrac] ([IgracID]);


GO
PRINT N'Creating [dbo].[Odrzava_Utakmica_FK]...';


GO
ALTER TABLE [dbo].[Odrzava]
    ADD CONSTRAINT [Odrzava_Utakmica_FK] FOREIGN KEY ([Utakmica_UtakmicaID]) REFERENCES [dbo].[Utakmica] ([UtakmicaID]);


GO
PRINT N'Creating [dbo].[Odrzava_Stadion_FK]...';


GO
ALTER TABLE [dbo].[Odrzava]
    ADD CONSTRAINT [Odrzava_Stadion_FK] FOREIGN KEY ([Stadion_StadionID]) REFERENCES [dbo].[Stadion] ([StadionID]);


GO
PRINT N'Creating [dbo].[Posecuje_Odrzava_FK]...';


GO
ALTER TABLE [dbo].[Posecuje]
    ADD CONSTRAINT [Posecuje_Odrzava_FK] FOREIGN KEY ([Odrzava_UtakmicaID], [Odrzava_StadionID]) REFERENCES [dbo].[Odrzava] ([Utakmica_UtakmicaID], [Stadion_StadionID]);


GO
PRINT N'Creating [dbo].[Posecuje_Kupuje_FK]...';


GO
ALTER TABLE [dbo].[Posecuje]
    ADD CONSTRAINT [Posecuje_Kupuje_FK] FOREIGN KEY ([Kupuje_Karta_KartaID], [Kupuje_Navijac_NavijacID]) REFERENCES [dbo].[Kupuje] ([Karta_KartaID], [Navijac_NavijacID]);


GO
PRINT N'Creating [dbo].[Stadion_Grad_FK]...';


GO
ALTER TABLE [dbo].[Stadion]
    ADD CONSTRAINT [Stadion_Grad_FK] FOREIGN KEY ([Grad_GradID]) REFERENCES [dbo].[Grad] ([GradID]);


GO
PRINT N'Creating [dbo].[Tim_Grad_FK]...';


GO
ALTER TABLE [dbo].[Tim]
    ADD CONSTRAINT [Tim_Grad_FK] FOREIGN KEY ([Grad_GradId]) REFERENCES [dbo].[Grad] ([GradID]);


GO
PRINT N'Creating [dbo].[TimskaNagrada_Nagrada_FK]...';


GO
ALTER TABLE [dbo].[TimskaNagrada]
    ADD CONSTRAINT [TimskaNagrada_Nagrada_FK] FOREIGN KEY ([NagradaID]) REFERENCES [dbo].[Nagrada] ([NagradaID]);


GO
PRINT N'Creating [dbo].[TimskaNagrada_Tim_FK]...';


GO
ALTER TABLE [dbo].[TimskaNagrada]
    ADD CONSTRAINT [TimskaNagrada_Tim_FK] FOREIGN KEY ([Tim_TimID]) REFERENCES [dbo].[Tim] ([TimID]);


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[LicnaNagrada]
    ADD CHECK (VrstaNagrade IN ('Najbolji Igrac', 'Ferplej', 'Najbolji Strelac'));


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[TimskaNagrada]
    ADD CHECK (TipNagrade IN ('Prvo Mesto', 'Drugo Mesto', 'Trece Mesto'));


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f91b9626-f46f-4491-bdc7-a47bd24af152')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f91b9626-f46f-4491-bdc7-a47bd24af152')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO