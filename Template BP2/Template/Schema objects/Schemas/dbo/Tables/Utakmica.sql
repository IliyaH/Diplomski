CREATE TABLE Utakmica (
    UtakmicaID        INTEGER NOT NULL  IDENTITY(1,1),
    Odigrana          Char(1) NOT NULL,
    Datum             DATE NOT NULL,
    FazaTakmicenja   VARCHAR (30) NOT NULL
);
