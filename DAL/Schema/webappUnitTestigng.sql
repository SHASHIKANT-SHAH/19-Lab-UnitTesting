USE [master]
GO
/****** Object:  Database [webappUnitTestigng]    Script Date: 8/15/2023 8:07:21 PM ******/
CREATE DATABASE [webappUnitTestigng]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webappUnitTestigng', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\webappUnitTestigng.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webappUnitTestigng_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\webappUnitTestigng_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [webappUnitTestigng] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webappUnitTestigng].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webappUnitTestigng] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET ARITHABORT OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webappUnitTestigng] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webappUnitTestigng] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET  DISABLE_BROKER 
GO
ALTER DATABASE [webappUnitTestigng] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webappUnitTestigng] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [webappUnitTestigng] SET  MULTI_USER 
GO
ALTER DATABASE [webappUnitTestigng] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webappUnitTestigng] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webappUnitTestigng] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webappUnitTestigng] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webappUnitTestigng] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [webappUnitTestigng] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [webappUnitTestigng] SET QUERY_STORE = ON
GO
ALTER DATABASE [webappUnitTestigng] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [webappUnitTestigng]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Books')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Courses')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Name], [Description], [UnitPrice], [CategoryId], [CreatedDate]) VALUES (1, N'ASP.NET Core Book', N'ASP.NET Core Bookdsfsdfdfgfd', CAST(1000.00 AS Decimal(18, 2)), 1, CAST(N'2022-10-12T23:24:36.7366667' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [UnitPrice], [CategoryId], [CreatedDate]) VALUES (1002, N'tests', N'tests', CAST(9000.00 AS Decimal(18, 2)), 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [UnitPrice], [CategoryId], [CreatedDate]) VALUES (1003, N'dfsdfgsd', N'sdrfdfgdf', CAST(234.00 AS Decimal(18, 2)), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [UnitPrice], [CategoryId], [CreatedDate]) VALUES (1005, N'fcdxfgds', N'dfgsdfgs', CAST(233454.00 AS Decimal(18, 2)), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
/****** Object:  StoredProcedure [dbo].[AddNewProductDetails]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewProductDetails]   
(    
@Name varchar (50),   
@Description varchar (50),    
@UnitPrice decimal,    
@CategoryId int    
)   
as  
begin     
Insert into Products(Name,Description,UnitPrice, CategoryId, CreatedDate) values(@Name,@Description,@UnitPrice,@CategoryId, GETDATE()) 
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteProductById]  
(      
@ProductId int
) 
as 
begin    
Delete from Products where ProductId=@ProductId;  
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductDetails]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateProductDetails]   
(    
@ProductId int,    
@Name varchar (50),     
@Description varchar (50),      
@UnitPrice decimal,   
@CategoryId int     
)   
as   
begin      
Update Products Set Name=@Name, Description=@Description,UnitPrice=@UnitPrice, CategoryId=@CategoryId
Where ProductId=@ProductId; 
End 
GO
/****** Object:  StoredProcedure [dbo].[usp_getproduct]    Script Date: 8/15/2023 8:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_getproduct]
@ProductId int 
As 
Begin  
Select * from Products Where ProductId = @ProductId; 
End;
GO
USE [master]
GO
ALTER DATABASE [webappUnitTestigng] SET  READ_WRITE 
GO
