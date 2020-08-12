CREATE TABLE Igrac (
    IgracID     INTEGER NOT NULL  IDENTITY(1,1),
    Ime          VARCHAR(30) NOT NULL,
    Prezime      VARCHAR(30) NOT NULL,
    BrojPostignutihGolova   INTEGER NOT NULL,   
    Tim_TimId   INTEGER NOT NULL
);