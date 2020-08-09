
ALTER TABLE Karta
    ADD CONSTRAINT Karta_Odrzava_FK FOREIGN KEY ( Odrzava_UtakmicaID,
                                                  Odrzava_StadionID )
        REFERENCES Odrzava ( Utakmica_UtakmicaID,
                             Stadion_StadionID );