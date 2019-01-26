CREATE TABLE [dbo].[EmpTable] (
    [Id]    INT    IDENTITY (1,1)   NOT NULL,
    [FName] NVARCHAR (50) NULL,
    [LName] NVARCHAR (50) NULL,
    [Age]   NCHAR (10)    NULL,
    [DepID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

