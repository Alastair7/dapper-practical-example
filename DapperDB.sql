USE [dapperdev]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 05/04/2024 10:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[AuthorId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 05/04/2024 10:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[BookId] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[PagesNumber] [int] NOT NULL,
	[IdAuthor] [bigint] NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 05/04/2024 10:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[ItemId] [bigint] NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persons]    Script Date: 05/04/2024 10:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persons](
	[PersonId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[authors] ON 

INSERT [dbo].[authors] ([AuthorId], [Name]) VALUES (1, N'Brandon Sanderson')
INSERT [dbo].[authors] ([AuthorId], [Name]) VALUES (2, N'Random Testerson')
INSERT [dbo].[authors] ([AuthorId], [Name]) VALUES (3, N'Ranton Waterson')
SET IDENTITY_INSERT [dbo].[authors] OFF
GO
SET IDENTITY_INSERT [dbo].[books] ON 

INSERT [dbo].[books] ([BookId], [PersonId], [Name], [Description], [PagesNumber], [IdAuthor]) VALUES (1, 1, N'Mistborn', N'Just a book', 200, 1)
INSERT [dbo].[books] ([BookId], [PersonId], [Name], [Description], [PagesNumber], [IdAuthor]) VALUES (2, 1, N'Mistborn: Hero of Ages', N'Still a book...', 250, 1)
INSERT [dbo].[books] ([BookId], [PersonId], [Name], [Description], [PagesNumber], [IdAuthor]) VALUES (3, 1, N'Waterborn', N'Book, just book', 220, 2)
SET IDENTITY_INSERT [dbo].[books] OFF
GO
INSERT [dbo].[items] ([ItemId], [PersonId], [Name], [Description]) VALUES (1, 1, N'Laptop', N'Asus Zenbook')
INSERT [dbo].[items] ([ItemId], [PersonId], [Name], [Description]) VALUES (2, 1, N'Mobile Phone', N'A mobile phone')
GO
SET IDENTITY_INSERT [dbo].[persons] ON 

INSERT [dbo].[persons] ([PersonId], [FirstName], [LastName]) VALUES (1, N'Alexandru', N'Ban')
INSERT [dbo].[persons] ([PersonId], [FirstName], [LastName]) VALUES (2, N'Leo', N'Piedras')
INSERT [dbo].[persons] ([PersonId], [FirstName], [LastName]) VALUES (3, N'Test', N'Test')
SET IDENTITY_INSERT [dbo].[persons] OFF
GO
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [DF_books_PagesNumber]  DEFAULT ((0)) FOR [PagesNumber]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_authors] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[authors] ([AuthorId])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_authors]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[persons] ([PersonId])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_persons]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[persons] ([PersonId])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_persons]
GO
