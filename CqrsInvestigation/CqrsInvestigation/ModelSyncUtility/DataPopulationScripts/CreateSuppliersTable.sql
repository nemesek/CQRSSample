USE [Northwind]
GO

/****** Object:  Table [dbo].[Suppliers]    Script Date: 8/3/2013 5:17:55 PM ******/
DROP TABLE [dbo].[Suppliers]
GO

/****** Object:  Table [dbo].[Suppliers]    Script Date: 8/3/2013 5:17:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[HomePage] [nvarchar](max) NULL,
	[ContactName] [nvarchar](max) NULL,
	[ContactTitle] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

