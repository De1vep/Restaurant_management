USE [master]
GO
/****** Object:  Database [Food]    Script Date: 08/11/2024 01:18:18 ******/
CREATE DATABASE [Food]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Food', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Food.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Food_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Food_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Food] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Food].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Food] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Food] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Food] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Food] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Food] SET ARITHABORT OFF 
GO
ALTER DATABASE [Food] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Food] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Food] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Food] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Food] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Food] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Food] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Food] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Food] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Food] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Food] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Food] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Food] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Food] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Food] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Food] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Food] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Food] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Food] SET  MULTI_USER 
GO
ALTER DATABASE [Food] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Food] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Food] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Food] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Food] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Food] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Food] SET QUERY_STORE = ON
GO
ALTER DATABASE [Food] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Food]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[img] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[price] [decimal](10, 2) NULL,
	[users_id] [int] NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[price] [decimal](10, 2) NULL,
	[order_id] [int] NULL,
	[menu_item_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[total_price] [decimal](10, 2) NULL,
	[status] [nvarchar](50) NULL,
	[order_time] [datetime] NULL,
	[users_id] [int] NULL,
	[table_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reservation_time] [datetime] NULL,
	[status] [nvarchar](50) NULL,
	[users_id] [int] NULL,
	[table_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[table_number] [int] NULL,
	[capacity] [int] NULL,
	[status] [nvarchar](50) NULL,
	[users_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/11/2024 01:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[password] [nvarchar](255) NULL,
	[img] [nvarchar](max) NULL,
	[role_id] [int] NULL,
	[created_at] [datetime] NULL,
	[phone] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name], [description]) VALUES (1, N'Appetizers', N'Small dishes served before the main meal')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (2, N'Main Course', N'Main dishes of the meal')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (3, N'Desserts', N'Sweet dishes served after the main meal')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (4, N'Beverages', N'Drinks, both alcoholic and non-alcoholic')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (5, N'Salads', N'Fresh vegetable or fruit dishes')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (6, N'Soups', N'Hot or cold liquid-based dishes')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (7, N'Pasta', N'Italian style pasta dishes')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (8, N'Pizza', N'Variety of pizza dishes')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (9, N'Sandwiches', N'Various types of sandwiches')
INSERT [dbo].[Category] ([id], [name], [description]) VALUES (10, N'Seafood', N'Dishes made with seafood')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 

INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (1, N'Chicken Wings', N'e.jpg', N'Spicy grilled chicken wings', CAST(8.99 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (2, N'Caesar Salad', N'i.jpg', N'Classic Caesar salad with croutons', CAST(6.50 AS Decimal(10, 2)), 2, 5)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (3, N'Margarita Pizza', N'o.jpg', N'Traditional Italian pizza', CAST(12.00 AS Decimal(10, 2)), 3, 8)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (4, N'Seafood Pasta', N'p.jpg', N'Pasta with mixed seafood', CAST(14.75 AS Decimal(10, 2)), 4, 7)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (5, N'Cheeseburger', N'q.jpg', N'Grilled beef patty with cheese', CAST(10.50 AS Decimal(10, 2)), 1, 9)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (6, N'Minestrone Soup', N'w.jpg', N'Vegetable soup with pasta', CAST(5.99 AS Decimal(10, 2)), 3, 6)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (7, N'Chocolate Cake', N'e.jpg', N'Rich chocolate dessert', CAST(7.25 AS Decimal(10, 2)), 2, 3)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (8, N'Orange Juice', N'r.jpg', N'Freshly squeezed orange juice', CAST(3.50 AS Decimal(10, 2)), 4, 4)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (9, N'Grilled Salmon', N't.jpg', N'Salmon fillet with lemon', CAST(16.00 AS Decimal(10, 2)), 5, 10)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (10, N'Tiramisu', N'y.jpg', N'Coffee-flavored Italian dessert', CAST(6.75 AS Decimal(10, 2)), 2, 3)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (11, N'Pizza Batman', N'o.jpg', N'Traditional Italian pizza', CAST(8.00 AS Decimal(10, 2)), 3, 8)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (12, N'Pizza MeoMeow', N'i.jpg', N'best of pizza', CAST(7.25 AS Decimal(10, 2)), 4, 8)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (13, N'Pizza Machiato', N'y.jpg', N'Freshly squeezed orange juice', CAST(3.50 AS Decimal(10, 2)), 4, 8)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (14, N'Tiramisu Pro', N'r.jpg', N'Coffee-flavored Italian dessert', CAST(6.75 AS Decimal(10, 2)), 4, 3)
INSERT [dbo].[MenuItems] ([id], [name], [img], [description], [price], [users_id], [category_id]) VALUES (15, N'Tiramisu Pro Plus', N'r.jpg', N'Coffee-flavored Italian dessert', CAST(6.75 AS Decimal(10, 2)), 4, 3)
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (1, 2, CAST(17.98 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (2, 1, CAST(12.00 AS Decimal(10, 2)), 2, 3)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (3, 3, CAST(19.50 AS Decimal(10, 2)), 3, 5)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (4, 1, CAST(7.25 AS Decimal(10, 2)), 4, 7)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (5, 4, CAST(22.00 AS Decimal(10, 2)), 5, 9)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (6, 2, CAST(10.50 AS Decimal(10, 2)), 6, 10)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (7, 1, CAST(14.75 AS Decimal(10, 2)), 7, 4)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (8, 2, CAST(15.98 AS Decimal(10, 2)), 8, 6)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (9, 1, CAST(16.00 AS Decimal(10, 2)), 9, 9)
INSERT [dbo].[OrderItems] ([id], [quantity], [price], [order_id], [menu_item_id]) VALUES (10, 3, CAST(21.75 AS Decimal(10, 2)), 10, 2)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (1, CAST(25.50 AS Decimal(10, 2)), N'completed', CAST(N'2024-10-15T12:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (2, CAST(45.75 AS Decimal(10, 2)), N'in_progress', CAST(N'2024-10-16T13:30:00.000' AS DateTime), 2, 2)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (3, CAST(18.99 AS Decimal(10, 2)), N'pending', CAST(N'2024-10-17T14:45:00.000' AS DateTime), 3, 3)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (4, CAST(32.00 AS Decimal(10, 2)), N'completed', CAST(N'2024-10-18T16:30:00.000' AS DateTime), 4, 4)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (5, CAST(55.25 AS Decimal(10, 2)), N'canceled', CAST(N'2024-10-19T18:15:00.000' AS DateTime), 5, 5)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (6, CAST(19.75 AS Decimal(10, 2)), N'pending', CAST(N'2024-10-20T12:00:00.000' AS DateTime), 1, 6)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (7, CAST(39.50 AS Decimal(10, 2)), N'completed', CAST(N'2024-10-21T13:45:00.000' AS DateTime), 2, 7)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (8, CAST(23.00 AS Decimal(10, 2)), N'pending', CAST(N'2024-10-22T14:30:00.000' AS DateTime), 3, 8)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (9, CAST(28.75 AS Decimal(10, 2)), N'in_progress', CAST(N'2024-10-23T15:15:00.000' AS DateTime), 4, 9)
INSERT [dbo].[Orders] ([id], [total_price], [status], [order_time], [users_id], [table_id]) VALUES (10, CAST(60.99 AS Decimal(10, 2)), N'completed', CAST(N'2024-10-24T16:00:00.000' AS DateTime), 5, 10)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (1, CAST(N'2024-10-15T12:30:00.000' AS DateTime), N'confirmed', 1, 1)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (2, CAST(N'2024-10-16T15:00:00.000' AS DateTime), N'pending', 2, 2)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (3, CAST(N'2024-10-17T18:45:00.000' AS DateTime), N'canceled', 3, 3)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (4, CAST(N'2024-10-18T20:00:00.000' AS DateTime), N'confirmed', 4, 4)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (5, CAST(N'2024-10-19T12:00:00.000' AS DateTime), N'pending', 5, 5)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (6, CAST(N'2024-10-20T14:30:00.000' AS DateTime), N'confirmed', 1, 6)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (7, CAST(N'2024-10-21T19:15:00.000' AS DateTime), N'canceled', 2, 7)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (8, CAST(N'2024-10-22T16:45:00.000' AS DateTime), N'confirmed', 3, 8)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (9, CAST(N'2024-10-23T13:30:00.000' AS DateTime), N'pending', 4, 9)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (10, CAST(N'2024-10-24T17:00:00.000' AS DateTime), N'canceled', 5, 10)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (11, CAST(N'2024-11-13T00:00:00.000' AS DateTime), N'pending', 11, 1)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (12, CAST(N'2024-11-06T00:00:00.000' AS DateTime), N'pending', 11, 4)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (13, CAST(N'2024-11-13T18:30:00.000' AS DateTime), N'pending', 11, 7)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (14, CAST(N'2024-11-19T18:35:00.000' AS DateTime), N'pending', 11, 9)
INSERT [dbo].[Reservations] ([id], [reservation_time], [status], [users_id], [table_id]) VALUES (15, CAST(N'2024-11-07T12:00:00.000' AS DateTime), N'pending', 13, 10)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Customer')
INSERT [dbo].[Role] ([id], [name]) VALUES (3, N'Employee')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (1, 1, 4, N'reserved', 3)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (2, 2, 2, N'reserved', 4)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (3, 3, 6, N'occupied', 1)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (4, 4, 4, N'reserved', 2)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (5, 5, 8, N'available', 1)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (6, 6, 4, N'reserved', 5)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (7, 7, 2, N'reserved', 3)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (8, 8, 4, N'reserved', 4)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (9, 9, 6, N'reserved', 2)
INSERT [dbo].[Tables] ([id], [table_number], [capacity], [status], [users_id]) VALUES (10, 10, 8, N'reserved', 5)
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (1, N'John Doe', N'john@example.com', N'password123', N'img1.jpg', 2, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (2, N'Jane Smith', N'jane@example.com', N'password123', N'img2.jpg', 2, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (3, N'Michael Brown', N'michael@example.com', N'password123', N'img3.jpg', 3, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (4, N'Emily Davis', N'emily@example.com', N'password123', N'img3.jpg', 3, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (5, N'Sarah Johnson', N'sarah@example.com', N'password123', N'img3.jpg', 1, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (6, N'Chris Lee', N'chris@example.com', N'password123', N'img3.jpg', 2, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (7, N'Patricia Kim', N'patricia@example.com', N'password123', N'img3.jpg', 3, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (8, N'Tommy Williams', N'tommy@example.com', N'password123', N'img3.jpg', 2, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (9, N'Laura Wilson', N'laura@example.com', N'password123', N'img3.jpg', 2, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (10, N'Samuel Adams', N'samuel@example.com', N'password123', N'img3.jpg', 1, CAST(N'2024-10-28T22:17:47.440' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (11, N'asdasd', N'a@gmail.com', N'password123', N'img3.jpg', 2, CAST(N'2024-11-04T18:09:42.490' AS DateTime), N'23423423')
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (12, N'danh', N'danh852001@gmail.com', N'$2a$11$tl/Bezjm1bQM1cLQvJqlY.4sxAoh4AvbFuaq3ahUhddaCCg0fcFja', N'string', 3, CAST(N'2024-11-07T03:57:36.400' AS DateTime), NULL)
INSERT [dbo].[Users] ([id], [name], [email], [password], [img], [role_id], [created_at], [phone]) VALUES (13, N'phuong a', N'phuongdao852001@gmail.com', N'password123', N'img3.jpg', 2, CAST(N'2024-11-07T12:00:47.717' AS DateTime), N'5468976232')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD FOREIGN KEY([users_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([menu_item_id])
REFERENCES [dbo].[MenuItems] ([id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[Tables] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([users_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[Tables] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([users_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD FOREIGN KEY([users_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CHECK  (([status]='canceled' OR [status]='completed' OR [status]='in_progress' OR [status]='pending'))
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD CHECK  (([status]='canceled' OR [status]='confirmed' OR [status]='pending'))
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD CHECK  (([status]='occupied' OR [status]='reserved' OR [status]='available'))
GO
USE [master]
GO
ALTER DATABASE [Food] SET  READ_WRITE 
GO
