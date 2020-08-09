
ALTER TABLE LicnaNagrada
    ADD CONSTRAINT LicnaNagrada_Igrac_FK FOREIGN KEY ( Igrac_IgracID)
        REFERENCES Igrac ( IgracID );