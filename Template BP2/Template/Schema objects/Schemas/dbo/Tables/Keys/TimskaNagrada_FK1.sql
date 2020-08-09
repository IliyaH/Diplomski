ALTER TABLE TimskaNagrada
    ADD CONSTRAINT TimskaNagrada_Nagrada_FK FOREIGN KEY ( NagradaID )
        REFERENCES Nagrada ( NagradaID );

