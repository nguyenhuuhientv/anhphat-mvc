USE [master]
GO
/****** Object:  Database [AnhPhat]    Script Date: 06/09/2016 00:28:20 ******/
CREATE DATABASE [AnhPhat] ON  PRIMARY 
( NAME = N'AnhPhat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\AnhPhat.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AnhPhat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\AnhPhat.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  User [h]    Script Date: 06/09/2016 00:28:20 ******/
CREATE USER [h] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](250) NULL,
 CONSTRAINT [PK_slide] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
	[detail_vn] [nvarchar](1000) NULL,
	[detail_en] [nvarchar](1000) NULL,
	[image] [nvarchar](250) NULL,
	[link] [nvarchar](250) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 06/09/2016 00:28:23 ******/
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
	[highlights] [bit] NOT NULL,
	[link] [nvarchar](250) NULL,
 CONSTRAINT [PK_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[new_news]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[new_news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_new] [bit] NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[detail_vn] [nvarchar](1000) NULL,
	[detail_en] [nvarchar](1000) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
	[image] [nvarchar](250) NULL,
	[created_at] [datetime] NULL,
	[link] [nvarchar](500) NULL,
 CONSTRAINT [PK_new_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[group_product]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[group_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[caption_vn] [nvarchar](250) NULL,
	[caption_en] [nvarchar](250) NULL,
	[orderby] [int] NULL,
	[link] [nvarchar](500) NULL,
 CONSTRAINT [PK_group_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[image] [nvarchar](250) NULL,
	[describe_vn] [nvarchar](1000) NULL,
	[describe_en] [nvarchar](1000) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[config]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [nvarchar](250) NULL,
	[value] [nvarchar](4000) NULL,
 CONSTRAINT [PK_config_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brand]    Script Date: 06/09/2016 00:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](250) NULL,
	[link_action] [nvarchar](250) NULL,
 CONSTRAINT [PK_brand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 06/09/2016 00:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_Get_Service_Item]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Get_Service_Item]
@temp nvarchar(10),
@link nvarchar(500)
as
begin
	if(@temp='vn')
			SELECT top 1 [id],[caption_vn] as caption ,[describe_vn] as describe
      ,[detail_vn] as detail,[detail_en],[image], link FROM [service] where link =@link order by id desc
				
	else
			SELECT top 1 [id],[caption_en]  as caption ,[describe_en] as describe
      ,[detail_en] as detail,[image], link FROM [service] where link =@link order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Service]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Service]
@temp nvarchar(10)
as
begin
	if(@temp='vn')
			SELECT [id],[caption_vn] as caption ,[describe_vn] as describe
      ,[detail_vn] as detail,[detail_en],[image], link FROM [service]  order by id desc
				
	else
			SELECT [id],[caption_en]  as caption ,[describe_en] as describe
      ,[detail_en] as detail,[image], link FROM [service] order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Product_New]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Product_New]
@temp nvarchar(10),
@limit int
as
begin
	if(@temp='vn')
			SELECT top (@limit) [product].[id],[product].[caption_vn] as caption,[image],[describe_vn] as describe,[detail_vn] as detail
			,[group_id], highlights, [product].link, group_product.caption_vn as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  order by id desc
				
	else
			SELECT top (@limit) [product].[id],[product].[caption_en] as caption,[image],[describe_en]  as describe,[detail_en] as detail
			,[group_id], highlights, [product].link,   group_product.caption_en as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  order by id desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Product_Item]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[sp_Get_Product_Item]
@temp nvarchar(10),
@link nvarchar(500)
as
begin
	if(@temp='vn')
			SELECT top 1 [product].[id],[product].[caption_vn] as caption,[image],[describe_vn] as describe,[detail_vn] as detail
			,[group_id], highlights, [product].link, group_product.caption_vn as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id and [product].link = @link  order by id desc
				
	else
			SELECT [product].[id],[product].[caption_en] as caption,[image],[describe_en]  as describe,[detail_en] as detail
			,[group_id], highlights, [product].link,   group_product.caption_en as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  and [product].link = @link  order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Product_Highlight]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Product_Highlight]
@temp nvarchar(10),
@limit int
as
begin
	if(@temp='vn')
			SELECT top (@limit) [product].[id],[product].[caption_vn] as caption,[image],[describe_vn] as describe,[detail_vn] as detail
			,[group_id], highlights, [product].link,  group_product.caption_vn as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  and  highlights = 0 order by id desc				
	else
			SELECT top (@limit) [product].[id],[product].[caption_en] as caption,[image],[describe_en]  as describe,[detail_en] as detail
			,[group_id], highlights, [product].link,  group_product.caption_en as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  and highlights = 1  order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Product]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Product]
@temp nvarchar(10)
as
begin
	if(@temp='vn')
			SELECT [product].[id],[product].[caption_vn] as caption,[image],[describe_vn] as describe,[detail_vn] as detail
			,[group_id], highlights, [product].link, group_product.caption_vn as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  order by id desc
				
	else
			SELECT [product].[id],[product].[caption_en] as caption,[image],[describe_en]  as describe,[detail_en] as detail
			,[group_id], highlights, [product].link,   group_product.caption_en as group_caption FROM [product], [group_product] 
			where [group_product].id = product.group_id  order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_New_Limit]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Get_New_Limit]
@temp nvarchar(10),
@group bit,
@limit int
as
begin
	if(@temp='vn')
			SELECT top (@limit) [id],[group_new],[caption_vn] as caption,[detail_vn] as detail
			,[describe_vn] as describe,[image],[created_at], link FROM [new_news] 
			where [group_new] = @group order by id desc
				
	else
			SELECT top (@limit) [id],[group_new],[caption_en] as caption,[detail_en] as detail
			,[describe_en]  as describe,[image],[created_at],  link FROM [new_news]  
			where [group_new] = @group order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_New_Item]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Get_New_Item]
@temp nvarchar(10),
@group bit,
@link nvarchar(500)
as
begin
	if(@temp='vn')
			SELECT  top 1 [id],[group_new],[caption_vn] as caption,[detail_vn] as detail
			,[describe_vn] as describe,[image],[created_at], link FROM [new_news] 
			where [group_new] = @group and link = @link order by id desc
				
	else
			SELECT  top 1  [id],[group_new],[caption_en] as caption,[detail_en] as detail
			,[describe_en]  as describe,[image],[created_at],  link FROM [new_news]  
			where [group_new] = @group and link = @link order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_New]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE proc [dbo].[sp_Get_New]
@temp nvarchar(10),
@group bit
as
begin
	if(@temp='vn')
			SELECT [id],[group_new],[caption_vn] as caption,[detail_vn] as detail
			,[describe_vn] as describe,[image],[created_at], link FROM [new_news] 
			where [group_new] = @group order by id desc
				
	else
			SELECT [id],[group_new],[caption_en] as caption,[detail_en] as detail
			,[describe_en]  as describe,[image],[created_at],  link FROM [new_news]  
			where [group_new] = @group order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Group_Product]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Group_Product]
@temp nvarchar(10)
as
begin
	if(@temp='vn')
			SELECT [id],[caption_vn] as caption ,[orderby], link FROM [group_product] order by id desc
				
	else
			SELECT [id],[caption_en]  as caption,[orderby], link FROM [group_product] order by id desc
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Customer]    Script Date: 06/09/2016 00:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_Customer]
@temp nvarchar(10)
as
begin
	if(@temp='vn')
			SELECT [id],[name],[image],[describe_vn] as describe FROM customer
				
	else
			SELECT [id],[name],[image],[describe_en] as describe FROM customer
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 06/09/2016 00:28:37 ******/
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
/****** Object:  Default [DF_product_highlights]    Script Date: 06/09/2016 00:28:23 ******/
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF_product_highlights]  DEFAULT ((0)) FOR [highlights]
GO
/****** Object:  Default [DF_new_news_group_new]    Script Date: 06/09/2016 00:28:23 ******/
ALTER TABLE [dbo].[new_news] ADD  CONSTRAINT [DF_new_news_group_new]  DEFAULT ((1)) FOR [group_new]
GO
/****** Object:  Default [DF_users_role]    Script Date: 06/09/2016 00:28:23 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_role]  DEFAULT ((1)) FOR [role]
GO
