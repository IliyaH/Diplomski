﻿CREATE TABLE LicnaNagrada (
    NagradaID       INTEGER NOT NULL  IDENTITY(1,1),
    VrstaNagrade    VARCHAR (30) NOT NULL,
    Igrac_IgracID   INTEGER NULL
)
Go
ALTER TABLE LicnaNagrada
ADD
CHECK ( VrstaNagrade IN ('Najbolji Igrac', 'Ferplej', 'Najbolji Strelac') )
GO