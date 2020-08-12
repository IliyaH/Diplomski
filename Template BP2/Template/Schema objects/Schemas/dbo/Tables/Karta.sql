CREATE TABLE Karta (
    Odrzava_UtakmicaID   INTEGER NOT NULL,
    Odrzava_StadionID    INTEGER NOT NULL,
    KartaID              INTEGER NOT NULL  IDENTITY(1,1),
    Cena                 INTEGER NOT NULL
);