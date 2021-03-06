USE [master]
GO
/****** Object:  Database [JustPolls]    Script Date: 06/02/2012 19:56:04 ******/
CREATE DATABASE [JustPolls] ON  PRIMARY 
( NAME = N'JustPolls', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\JustPolls.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JustPolls_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\JustPolls_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JustPolls] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JustPolls].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JustPolls] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [JustPolls] SET ANSI_NULLS OFF
GO
ALTER DATABASE [JustPolls] SET ANSI_PADDING OFF
GO
ALTER DATABASE [JustPolls] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [JustPolls] SET ARITHABORT OFF
GO
ALTER DATABASE [JustPolls] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [JustPolls] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [JustPolls] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [JustPolls] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [JustPolls] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [JustPolls] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [JustPolls] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [JustPolls] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [JustPolls] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [JustPolls] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [JustPolls] SET  DISABLE_BROKER
GO
ALTER DATABASE [JustPolls] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [JustPolls] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [JustPolls] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [JustPolls] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [JustPolls] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [JustPolls] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [JustPolls] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [JustPolls] SET  READ_WRITE
GO
ALTER DATABASE [JustPolls] SET RECOVERY SIMPLE
GO
ALTER DATABASE [JustPolls] SET  MULTI_USER
GO
ALTER DATABASE [JustPolls] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [JustPolls] SET DB_CHAINING OFF
GO
USE [JustPolls]
GO
/****** Object:  Table [dbo].[Polls]    Script Date: 06/02/2012 19:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polls](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Polls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Polls] ON
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (1, N'ala bala', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (2, N'ala bala1', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (3, N'ala bala2', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (4, N'ala bala3', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (5, N'ala bala4', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (6, N'ala bala5', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (7, N'ala bala6', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (8, N'ala bala7', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (9, N'ala bala8', CAST(0x0000A06400000000 AS DateTime))
INSERT [dbo].[Polls] ([id], [Title], [Date]) VALUES (10, N'If 4 out of 5 people suffer from diarrhea, does that mean the 5th one enjoys it?', CAST(0x0000A064011826C0 AS DateTime))
SET IDENTITY_INSERT [dbo].[Polls] OFF
/****** Object:  Table [dbo].[PossibleAnswers]    Script Date: 06/02/2012 19:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PossibleAnswers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PollId] [int] NOT NULL,
	[text] [nvarchar](500) NOT NULL,
	[VotesCount] [int] NOT NULL,
 CONSTRAINT [PK_PossibleAnswers_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PossibleAnswers] ON
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (1, 1, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (2, 1, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (3, 1, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (4, 1, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (5, 2, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (6, 2, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (7, 2, N'Answer 3', 1)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (8, 2, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (9, 3, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (10, 3, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (11, 3, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (12, 3, N'Answer 4', 1)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (13, 4, N'Answer 1', 1)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (14, 4, N'Answer 2', 2)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (15, 4, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (16, 4, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (17, 5, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (18, 5, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (19, 5, N'Answer 3', 1)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (20, 5, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (21, 6, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (22, 6, N'Answer 2', 1)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (23, 6, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (24, 6, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (25, 7, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (26, 7, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (27, 7, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (28, 7, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (29, 8, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (30, 8, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (31, 8, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (32, 8, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (33, 9, N'Answer 1', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (34, 9, N'Answer 2', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (35, 9, N'Answer 3', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (36, 9, N'Answer 4', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (37, 10, N'No silly, the 5th person doesn''t have diarrhea!', 0)
INSERT [dbo].[PossibleAnswers] ([id], [PollId], [text], [VotesCount]) VALUES (38, 10, N'You just never know what some people will enjoy.', 1)
SET IDENTITY_INSERT [dbo].[PossibleAnswers] OFF
/****** Object:  Table [dbo].[Votes]    Script Date: 06/02/2012 19:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[answerId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[voterIp] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Votes_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Votes] ON
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (1, 13, CAST(0x0000A06400F0A4CD AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (2, 14, CAST(0x0000A06400F0A4CD AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (3, 14, CAST(0x0000A06400F0A4CD AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (4, 19, CAST(0x0000A0640109A9CA AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (5, 22, CAST(0x0000A0640115AF08 AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (6, 38, CAST(0x0000A06401191545 AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (7, 12, CAST(0x0000A064012C48C7 AS DateTime), N'::1')
INSERT [dbo].[Votes] ([id], [answerId], [Date], [voterIp]) VALUES (8, 7, CAST(0x0000A0640141DD4C AS DateTime), N'::1')
SET IDENTITY_INSERT [dbo].[Votes] OFF
/****** Object:  Default [DF_PossibleAnswers_VotesCount]    Script Date: 06/02/2012 19:56:07 ******/
ALTER TABLE [dbo].[PossibleAnswers] ADD  CONSTRAINT [DF_PossibleAnswers_VotesCount]  DEFAULT ((0)) FOR [VotesCount]
GO
/****** Object:  ForeignKey [FK_PossibleAnswers_Polls]    Script Date: 06/02/2012 19:56:07 ******/
ALTER TABLE [dbo].[PossibleAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PossibleAnswers_Polls] FOREIGN KEY([PollId])
REFERENCES [dbo].[Polls] ([id])
GO
ALTER TABLE [dbo].[PossibleAnswers] CHECK CONSTRAINT [FK_PossibleAnswers_Polls]
GO
/****** Object:  ForeignKey [FK_Votes_PossibleAnswers]    Script Date: 06/02/2012 19:56:07 ******/
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_PossibleAnswers] FOREIGN KEY([answerId])
REFERENCES [dbo].[PossibleAnswers] ([id])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_PossibleAnswers]
GO
