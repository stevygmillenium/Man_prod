CREATE TABLE [dbo].[Table] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [product_name] VARCHAR (50) NULL,
    [price]        FLOAT (53)   NULL,
    [quantity]     INT          NULL,
    [image]        IMAGE        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[order] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [cust_name] VARCHAR (150) NULL,
    [cust_em]   VARCHAR (150) NULL,
    [cust_addr] TEXT          NULL,
    [card_type] VARCHAR (50)  NULL,
    [j_data]    VARCHAR (MAX) NULL,
    [o_date]    DATETIME      NULL,
    [amount]    FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);