ALTER TABLE Kupuje
    ADD CONSTRAINT Kupuje_Navijac_FK FOREIGN KEY ( Navijac_NavijacID )
        REFERENCES Navijac ( NavijacID );