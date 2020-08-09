ALTER TABLE Posecuje
    ADD CONSTRAINT Posecuje_Kupuje_FK FOREIGN KEY ( Kupuje_Karta_KartaID,
                                                    kupuje_Navijac_NavijacID )
        REFERENCES Kupuje ( Karta_KartaID,
                            Navijac_NavijacID );