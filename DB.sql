USE [ATM]
GO
/****** Object:  Table [dbo].[AccountDetails]    Script Date: 5/26/2017 3:37:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountDetails](
	[Id_Account] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NULL,
	[Description] [varchar](50) NOT NULL,
	[CurrencyType] [varchar](50) NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 5/26/2017 3:37:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[Id_Transaction] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[TransactionAmount] [float] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Id_Account] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/26/2017 3:37:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id_User] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](25) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AccountDetails]  WITH CHECK ADD FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD FOREIGN KEY([Id_Account])
REFERENCES [dbo].[AccountDetails] ([Id_Account])
GO
