ALTER TABLE Odrzava
    ADD CONSTRAINT Odrzava_Utakmica_FK FOREIGN KEY ( Utakmica_UtakmicaID )
        REFERENCES Utakmica ( UtakmicaID );