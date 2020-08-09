ALTER TABLE Kupuje
    ADD CONSTRAINT Kupuje_Karta_FK FOREIGN KEY ( Karta_KartaID )
        REFERENCES Karta ( KartaID );