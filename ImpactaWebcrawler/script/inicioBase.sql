CREATE TABLE [resposta] (
    [Id] uniqueidentifier NOT NULL,
    [horaInicio] datetime2 NOT NULL,
    [paginas] int NOT NULL,
    [linhas] int NOT NULL,
    [horaFim] datetime2 NOT NULL,
    CONSTRAINT [PK_resposta] PRIMARY KEY ([Id])
);
GO


