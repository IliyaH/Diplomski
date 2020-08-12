CREATE TABLE TimskaNagrada (
    NagradaID   INTEGER NOT NULL  IDENTITY(1,1),
    TipNagrade      VARCHAR (30) NOT NULL,
    Tim_TimID   INTEGER NULL
    )
GO

ALTER TABLE TimskaNagrada
ADD
CHECK ( TipNagrade IN ('Prvo Mesto', 'Drugo Mesto', 'Trece Mesto') )
GO