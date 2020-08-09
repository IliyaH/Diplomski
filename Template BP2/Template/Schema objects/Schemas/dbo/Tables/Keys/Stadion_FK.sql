ALTER TABLE Stadion
    ADD CONSTRAINT Stadion_Grad_FK FOREIGN KEY ( Grad_GradID )
        REFERENCES Grad ( GradID );