CREATE TABLE Navijac (
    NavijacID  INTEGER NOT NULL  IDENTITY(1,1),
    Ime       VARCHAR(30) NOT NULL,
    Prezime   INTEGER NOT NULL,
    KorisnickoIme VARCHAR(30) NOT NULL,
    Email VARCHAR(30) NOT NULL,
    Sifra VARCHAR(30) NOT NULL, 
    CONSTRAINT KorisnickoIme UNIQUE (KorisnickoIme)
);
