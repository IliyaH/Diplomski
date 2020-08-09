ALTER TABLE Odrzava
    ADD CONSTRAINT Odrzava_Stadion_FK FOREIGN KEY ( Stadion_StadionID )
        REFERENCES Stadion ( StadionID );