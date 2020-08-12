﻿/*
Deployment script for VideotekaBP

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "VideotekaBP"
:setvar DefaultFilePrefix "VideotekaBP"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

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
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Rename refactoring operation with key f91b9626-f46f-4491-bdc7-a47bd24af152 is skipped, element [dbo].[KlijentskiProjekti].[Id] (SqlSimpleColumn) will not be renamed to Id_klijent';


GO
PRINT N'Creating [dbo].[Clan]...';


GO
CREATE TABLE [dbo].[Clan] (
    [CLAN_ID]            INT          IDENTITY (1, 1) NOT NULL,
    [CLAN_IME]           VARCHAR (20) NOT NULL,
    [CLAN_PREZIME]       VARCHAR (20) NOT NULL,
    [Menadzer_RADNIK_ID] INT          NOT NULL,
    [CLAN_SIFRA]         VARCHAR (20) NOT NULL,
    [CLAN_EMAIL]         VARCHAR (25) NOT NULL,
    [CLAN_BROJ_TELEFONA] VARCHAR (15) NOT NULL,
    CONSTRAINT [Clan_PK] PRIMARY KEY CLUSTERED ([CLAN_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Film]...';


GO
CREATE TABLE [dbo].[Film] (
    [FILM_ID]    INT          IDENTITY (1, 1) NOT NULL,
    [FILM_NAZIV] VARCHAR (25) NOT NULL,
    CONSTRAINT [Film_PK] PRIMARY KEY CLUSTERED ([FILM_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Izdaje]...';


GO
CREATE TABLE [dbo].[Izdaje] (
    [Film_FILM_ID]       INT NOT NULL,
    [Izdavac_IZDAVAC_ID] INT NOT NULL,
    CONSTRAINT [Izdaje_PK] PRIMARY KEY CLUSTERED ([Film_FILM_ID] ASC, [Izdavac_IZDAVAC_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Izdavac]...';


GO
CREATE TABLE [dbo].[Izdavac] (
    [IZDAVAC_ID]    INT          IDENTITY (1, 1) NOT NULL,
    [IZDAVAC_NAZIV] VARCHAR (25) NOT NULL,
    CONSTRAINT [Izdavac_PK] PRIMARY KEY CLUSTERED ([IZDAVAC_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Iznajmljuje]...';


GO
CREATE TABLE [dbo].[Iznajmljuje] (
    [Prodavac_RADNIK_ID]              INT NOT NULL,
    [PrimerakFilma_PRIMERAK_FILMA_ID] INT NOT NULL,
    [PrimerakFilma_Film_FILM_ID]      INT NOT NULL,
    [Clan_CLAN_ID]                    INT NOT NULL,
    CONSTRAINT [Iznajmljuje_PK] PRIMARY KEY CLUSTERED ([Prodavac_RADNIK_ID] ASC, [PrimerakFilma_PRIMERAK_FILMA_ID] ASC, [PrimerakFilma_Film_FILM_ID] ASC, [Clan_CLAN_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Opomena]...';


GO
CREATE TABLE [dbo].[Opomena] (
    [OPOMENA_ID] INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [Opomena_PK] PRIMARY KEY CLUSTERED ([OPOMENA_ID] ASC)
);


GO
PRINT N'Creating [dbo].[PrimerakFilma]...';


GO
CREATE TABLE [dbo].[PrimerakFilma] (
    [Film_FILM_ID]         INT         NOT NULL,
    [PRIMERAK_FILMA_ID]    INT         IDENTITY (1, 1) NOT NULL,
    [PRIMERAK_FILMA_IZDAT] BIT         NOT NULL,
    [Menadzer_RADNIK_ID]   INT         NOT NULL,
    [PRIMERAK_FILMA_HD]    BIT         NOT NULL,
    [PRIMERAK_FILMA_MEDIJ] VARCHAR (1) NOT NULL,
    CONSTRAINT [PrimerakFilma_PK] PRIMARY KEY CLUSTERED ([PRIMERAK_FILMA_ID] ASC, [Film_FILM_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Pripada]...';


GO
CREATE TABLE [dbo].[Pripada] (
    [Zanr_ZANR_ID] INT NOT NULL,
    [Film_FILM_ID] INT NOT NULL,
    CONSTRAINT [Pripada_PK] PRIMARY KEY CLUSTERED ([Zanr_ZANR_ID] ASC, [Film_FILM_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Radi]...';


GO
CREATE TABLE [dbo].[Radi] (
    [Radnik_RADNIK_ID] INT NOT NULL,
    [Smena_SMENA_ID]   INT NOT NULL,
    CONSTRAINT [Radi_PK] PRIMARY KEY CLUSTERED ([Radnik_RADNIK_ID] ASC, [Smena_SMENA_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Radnik]...';


GO
CREATE TABLE [dbo].[Radnik] (
    [RADNIK_ID]            INT          IDENTITY (1, 1) NOT NULL,
    [RADNIK_IME]           VARCHAR (20) NOT NULL,
    [RADNIK_PREZIME]       VARCHAR (20) NOT NULL,
    [RADNIK_SIFRA]         VARCHAR (20) NOT NULL,
    [RADNIK_EMAIL]         VARCHAR (25) NOT NULL,
    [RADNIK_BROJ_TELEFONA] VARCHAR (15) NOT NULL,
    [RADNIK_ULOGA]         VARCHAR (10) NOT NULL,
    CONSTRAINT [Radnik_PK] PRIMARY KEY CLUSTERED ([RADNIK_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Rezira]...';


GO
CREATE TABLE [dbo].[Rezira] (
    [Film_FILM_ID]       INT NOT NULL,
    [Reziser_REZISER_ID] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[Reziser]...';


GO
CREATE TABLE [dbo].[Reziser] (
    [REZISER_ID]      INT          IDENTITY (1, 1) NOT NULL,
    [REZISER_IME]     VARCHAR (20) NOT NULL,
    [REZISER_PREZIME] VARCHAR (20) NOT NULL,
    CONSTRAINT [Reziser_PK] PRIMARY KEY CLUSTERED ([REZISER_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Smena]...';


GO
CREATE TABLE [dbo].[Smena] (
    [SMENA_ID]  INT          IDENTITY (1, 1) NOT NULL,
    [SMENA_TIP] VARCHAR (10) NOT NULL,
    CONSTRAINT [Smena_PK] PRIMARY KEY CLUSTERED ([SMENA_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Zanr]...';


GO
CREATE TABLE [dbo].[Zanr] (
    [ZANR_ID]  INT          IDENTITY (1, 1) NOT NULL,
    [ZANR_TIP] VARCHAR (10) NOT NULL,
    CONSTRAINT [Zanr_PK] PRIMARY KEY CLUSTERED ([ZANR_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Zavodi]...';


GO
CREATE TABLE [dbo].[Zavodi] (
    [Prodavac_RADNIK_ID] INT NOT NULL,
    [Opomena_OPOMENA_ID] INT NOT NULL,
    [Clan_CLAN_ID]       INT NOT NULL,
    CONSTRAINT [Zavodi_PK] PRIMARY KEY CLUSTERED ([Prodavac_RADNIK_ID] ASC, [Opomena_OPOMENA_ID] ASC, [Clan_CLAN_ID] ASC)
);


GO
PRINT N'Creating [dbo].[Zavodi].[Zavodi__IDX]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [Zavodi__IDX]
    ON [dbo].[Zavodi]([Clan_CLAN_ID] ASC);


GO
PRINT N'Creating [dbo].[Zavodi].[Zavodi__IDXv1]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [Zavodi__IDXv1]
    ON [dbo].[Zavodi]([Opomena_OPOMENA_ID] ASC);


GO
PRINT N'Creating [dbo].[Clan_FK1]...';


GO
ALTER TABLE [dbo].[Clan] WITH NOCHECK
    ADD CONSTRAINT [Clan_FK1] FOREIGN KEY ([Menadzer_RADNIK_ID]) REFERENCES [dbo].[Radnik] ([RADNIK_ID]);


GO
PRINT N'Creating [dbo].[Izdaje_FK2]...';


GO
ALTER TABLE [dbo].[Izdaje] WITH NOCHECK
    ADD CONSTRAINT [Izdaje_FK2] FOREIGN KEY ([Izdavac_IZDAVAC_ID]) REFERENCES [dbo].[Izdavac] ([IZDAVAC_ID]);


GO
PRINT N'Creating [dbo].[Izdaje_FK1]...';


GO
ALTER TABLE [dbo].[Izdaje] WITH NOCHECK
    ADD CONSTRAINT [Izdaje_FK1] FOREIGN KEY ([Film_FILM_ID]) REFERENCES [dbo].[Film] ([FILM_ID]);


GO
PRINT N'Creating [dbo].[Iznajmljuje_FK2]...';


GO
ALTER TABLE [dbo].[Iznajmljuje] WITH NOCHECK
    ADD CONSTRAINT [Iznajmljuje_FK2] FOREIGN KEY ([Clan_CLAN_ID]) REFERENCES [dbo].[Clan] ([CLAN_ID]);


GO
PRINT N'Creating [dbo].[Iznajmljuje_FK3]...';


GO
ALTER TABLE [dbo].[Iznajmljuje] WITH NOCHECK
    ADD CONSTRAINT [Iznajmljuje_FK3] FOREIGN KEY ([PrimerakFilma_PRIMERAK_FILMA_ID], [PrimerakFilma_Film_FILM_ID]) REFERENCES [dbo].[PrimerakFilma] ([PRIMERAK_FILMA_ID], [Film_FILM_ID]);


GO
PRINT N'Creating [dbo].[Iznajmljuje_FK1]...';


GO
ALTER TABLE [dbo].[Iznajmljuje] WITH NOCHECK
    ADD CONSTRAINT [Iznajmljuje_FK1] FOREIGN KEY ([Prodavac_RADNIK_ID]) REFERENCES [dbo].[Radnik] ([RADNIK_ID]);


GO
PRINT N'Creating [dbo].[PrimerakFilma_FK2]...';


GO
ALTER TABLE [dbo].[PrimerakFilma] WITH NOCHECK
    ADD CONSTRAINT [PrimerakFilma_FK2] FOREIGN KEY ([Film_FILM_ID]) REFERENCES [dbo].[Film] ([FILM_ID]);


GO
PRINT N'Creating [dbo].[PrimerakFilma_FK1]...';


GO
ALTER TABLE [dbo].[PrimerakFilma] WITH NOCHECK
    ADD CONSTRAINT [PrimerakFilma_FK1] FOREIGN KEY ([Menadzer_RADNIK_ID]) REFERENCES [dbo].[Radnik] ([RADNIK_ID]);


GO
PRINT N'Creating [dbo].[Pripada_FK1]...';


GO
ALTER TABLE [dbo].[Pripada] WITH NOCHECK
    ADD CONSTRAINT [Pripada_FK1] FOREIGN KEY ([Zanr_ZANR_ID]) REFERENCES [dbo].[Zanr] ([ZANR_ID]);


GO
PRINT N'Creating [dbo].[Pripada_FK2]...';


GO
ALTER TABLE [dbo].[Pripada] WITH NOCHECK
    ADD CONSTRAINT [Pripada_FK2] FOREIGN KEY ([Film_FILM_ID]) REFERENCES [dbo].[Film] ([FILM_ID]);


GO
PRINT N'Creating [dbo].[Radi_FK1]...';


GO
ALTER TABLE [dbo].[Radi] WITH NOCHECK
    ADD CONSTRAINT [Radi_FK1] FOREIGN KEY ([Radnik_RADNIK_ID]) REFERENCES [dbo].[Radnik] ([RADNIK_ID]);


GO
PRINT N'Creating [dbo].[Radi_FK2]...';


GO
ALTER TABLE [dbo].[Radi] WITH NOCHECK
    ADD CONSTRAINT [Radi_FK2] FOREIGN KEY ([Smena_SMENA_ID]) REFERENCES [dbo].[Smena] ([SMENA_ID]);


GO
PRINT N'Creating [dbo].[Zavodi_FK1]...';


GO
ALTER TABLE [dbo].[Zavodi] WITH NOCHECK
    ADD CONSTRAINT [Zavodi_FK1] FOREIGN KEY ([Clan_CLAN_ID]) REFERENCES [dbo].[Clan] ([CLAN_ID]);


GO
PRINT N'Creating [dbo].[Zavodi_FK2]...';


GO
ALTER TABLE [dbo].[Zavodi] WITH NOCHECK
    ADD CONSTRAINT [Zavodi_FK2] FOREIGN KEY ([Opomena_OPOMENA_ID]) REFERENCES [dbo].[Opomena] ([OPOMENA_ID]);


GO
PRINT N'Creating [dbo].[Zavodi_FK3]...';


GO
ALTER TABLE [dbo].[Zavodi] WITH NOCHECK
    ADD CONSTRAINT [Zavodi_FK3] FOREIGN KEY ([Prodavac_RADNIK_ID]) REFERENCES [dbo].[Radnik] ([RADNIK_ID]);


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[PrimerakFilma] WITH NOCHECK
    ADD CHECK (PRIMERAK_FILMA_MEDIJ IN ('BLURAY', 'CD', 'DIGITALNO', 'FLASH', 'KASETA'
));


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[Radnik] WITH NOCHECK
    ADD CHECK (RADNIK_ULOGA IN ('PRODAVAC', 'MENADZER'));


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[Smena] WITH NOCHECK
    ADD CHECK (SMENA_TIP IN ('DRUGA', 'PRVA', 'TRECA'));


GO
PRINT N'Creating <unnamed>...';


GO
ALTER TABLE [dbo].[Zanr] WITH NOCHECK
    ADD CHECK (ZANR_TIP IN ('AKCIJA', 'ANIMIRANI', 'DECIJI', 'DRAMA', 'HOROR',
'KOMEDIJA', 'MJUZIKL', 'ROMANTIKA', 'SCIFI', 'TRILER'));


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
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Clan] WITH CHECK CHECK CONSTRAINT [Clan_FK1];

ALTER TABLE [dbo].[Izdaje] WITH CHECK CHECK CONSTRAINT [Izdaje_FK2];

ALTER TABLE [dbo].[Izdaje] WITH CHECK CHECK CONSTRAINT [Izdaje_FK1];

ALTER TABLE [dbo].[Iznajmljuje] WITH CHECK CHECK CONSTRAINT [Iznajmljuje_FK2];

ALTER TABLE [dbo].[Iznajmljuje] WITH CHECK CHECK CONSTRAINT [Iznajmljuje_FK3];

ALTER TABLE [dbo].[Iznajmljuje] WITH CHECK CHECK CONSTRAINT [Iznajmljuje_FK1];

ALTER TABLE [dbo].[Pripada] WITH CHECK CHECK CONSTRAINT [Pripada_FK1];

ALTER TABLE [dbo].[Pripada] WITH CHECK CHECK CONSTRAINT [Pripada_FK2];

ALTER TABLE [dbo].[Radi] WITH CHECK CHECK CONSTRAINT [Radi_FK1];

ALTER TABLE [dbo].[Radi] WITH CHECK CHECK CONSTRAINT [Radi_FK2];

ALTER TABLE [dbo].[Zavodi] WITH CHECK CHECK CONSTRAINT [Zavodi_FK1];

ALTER TABLE [dbo].[Zavodi] WITH CHECK CHECK CONSTRAINT [Zavodi_FK2];

ALTER TABLE [dbo].[Zavodi] WITH CHECK CHECK CONSTRAINT [Zavodi_FK3];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.PrimerakFilma'), OBJECT_ID(N'dbo.Radnik'), OBJECT_ID(N'dbo.Smena'), OBJECT_ID(N'dbo.Zanr'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO