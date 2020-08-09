ALTER TABLE Igra
ADD CONSTRAINT Igra_Utakmica_FK FOREIGN KEY ( Utakmica_UtakmicaID )
REFERENCES Utakmica (UtakmicaID);
