USE [master]
GO
/****** Object:  Database [AnhPhat]    Script Date: 05/29/2016 16:24:04 ******/
CREATE DATABASE [AnhPhat] ON  PRIMARY 
( NAME = N'AnhPhat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\AnhPhat.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AnhPhat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\AnhPhat_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AnhPhat] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnhPhat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnhPhat] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AnhPhat] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AnhPhat] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AnhPhat] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AnhPhat] SET ARITHABORT OFF
GO
ALTER DATABASE [AnhPhat] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AnhPhat] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AnhPhat] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AnhPhat] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AnhPhat] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AnhPhat] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AnhPhat] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AnhPhat] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AnhPhat] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AnhPhat] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AnhPhat] SET  DISABLE_BROKER
GO
ALTER DATABASE [AnhPhat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AnhPhat] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AnhPhat] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AnhPhat] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AnhPhat] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AnhPhat] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AnhPhat] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AnhPhat] SET  READ_WRITE
GO
ALTER DATABASE [AnhPhat] SET RECOVERY SIMPLE
GO
ALTER DATABASE [AnhPhat] SET  MULTI_USER
GO
ALTER DATABASE [AnhPhat] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AnhPhat] SET DB_CHAINING OFF
GO
USE [AnhPhat]
GO
/****** Object:  Table [dbo].[service]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[id] [int] NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
	[detail_vn] [nvarchar](1000) NULL,
	[detail_en] [nvarchar](1000) NULL,
	[image] [nvarchar](250) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[image] [nvarchar](250) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
	[detail_vn] [nvarchar](1000) NULL,
	[detail_en] [nvarchar](1000) NULL,
	[group_id] [int] NULL,
 CONSTRAINT [PK_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[new_news]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[new_news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_new] [smallint] NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[detail_vn] [nvarchar](1000) NULL,
	[detail_en] [nvarchar](1000) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
	[image] [nvarchar](250) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_new_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[group_product]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[group_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](50) NULL,
	[orderby] [int] NULL,
 CONSTRAINT [PK_group_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[config]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [nvarchar](50) NULL,
	[value] [nvarchar](250) NULL,
 CONSTRAINT [PK_config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 05/29/2016 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[birthday] [date] NULL,
	[role] [smallint] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 05/29/2016 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DangNhap]
@id nvarchar(250),
@pass nvarchar(250)
as 
begin
 select top 1 * from users where username = @id and  password = @pass
end
GO
