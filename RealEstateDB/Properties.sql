CREATE TABLE [dbo].[Properties](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[Suburb] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[NumberOfRooms] [int] NOT NULL,
	[PropertyType] [varchar](50) NULL,
	[FloorArea] [float] NULL,
	[LandArea] [float] NULL,
	[RV] [varchar](50) NULL,
	[SellerEmail] VARCHAR(50) NULL, 
	CONSTRAINT [PK_Properties] PRIMARY KEY ([PropertyId]),
	CONSTRAINT [FK_Properties_Sellers] FOREIGN KEY([SellerEmail])
REFERENCES [dbo].[Sellers] ([Email])

)
