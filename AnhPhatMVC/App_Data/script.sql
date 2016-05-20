USE [AnhPhat]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 05/21/2016 01:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[ID] [nvarchar](250) NOT NULL,
	[HOTEN] [nvarchar](250) NULL,
	[MATKHAU] [nvarchar](250) NULL,
	[NGAYCAP] [date] NULL,
	[QUYEN] [nvarchar](50) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 05/21/2016 01:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DangNhap]
@taikhoan nvarchar(250),
@matkhau nvarchar(250)
as
begin
	select [ID],[HOTEN],[MATKHAU],[NGAYCAP],[QUYEN] from TAIKHOAN 
	where ID = @taikhoan and MATKHAU = @matkhau
end
GO
