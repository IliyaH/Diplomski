﻿
ALTER TABLE Igrac
    ADD CONSTRAINT Igrac_Tim_FK FOREIGN KEY ( Tim_TimID )
        REFERENCES Tim ( TimID );