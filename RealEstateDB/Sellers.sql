CREATE TABLE [dbo].[Sellers](
	[SellerId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) UNIQUE NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Address] [text] NULL,
	[Phone] [varchar](10) NULL, 
	CONSTRAINT [PK_Sellers] PRIMARY KEY ([Email]))