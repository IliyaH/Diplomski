ALTER TABLE Igra
ADD CONSTRAINT Igra_Sudija_FK 
FOREIGN KEY ( Sudija_SudijaID )
REFERENCES Sudija ( SudijaID );

