ALTER TABLE LicnaNagrada
    ADD CONSTRAINT LicnaNagrada_Nagrada_FK FOREIGN KEY ( NagradaID )
        REFERENCES Nagrada ( NagradaID );
