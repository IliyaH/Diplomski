
ALTER TABLE Posecuje
    ADD CONSTRAINT Posecuje_Odrzava_FK FOREIGN KEY ( Odrzava_UtakmicaID,
                                                     Odrzava_StadionID )
        REFERENCES Odrzava ( Utakmica_UtakmicaID,
                             Stadion_StadionID );
