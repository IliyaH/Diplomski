﻿ALTER TABLE Tim
    ADD CONSTRAINT Tim_Grad_FK FOREIGN KEY ( Grad_GradID )
        REFERENCES Grad ( GradID );
