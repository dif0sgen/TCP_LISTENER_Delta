CREATE TABLE [dbo].[Table] (
    [Id]     INT      NOT NULL,
    [Camera] TEXT     NULL DEFAULT 0,
    [Time]   TIME (7) NULL DEFAULT 0,
    [1]      BIT      NULL DEFAULT 0,
    [2]      BIT      NULL DEFAULT 0,
    [3]      BIT      NULL DEFAULT 0,
    [4]      BIT      NULL DEFAULT 0,
    [5]      BIT      NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

