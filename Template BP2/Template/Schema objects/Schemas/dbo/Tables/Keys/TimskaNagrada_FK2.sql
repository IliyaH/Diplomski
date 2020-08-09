
ALTER TABLE TimskaNagrada
    ADD CONSTRAINT TimskaNagrada_Tim_FK FOREIGN KEY ( Tim_TimID )
        REFERENCES Tim ( TimID );
