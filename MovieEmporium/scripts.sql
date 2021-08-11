CREATE DATABASE [movie_emporium]
GO
USE [movie_emporium]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[cust_id] [int] IDENTITY(100,1) NOT NULL,
	[first_name] [varchar](100) NULL,
	[last_name] [varchar](100) NULL,
	[address] [varchar](500) NULL,
	[phone_no] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cust_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplayAllCustomer]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DisplayAllCustomer]
as
SELECT cust_id, first_name + ' ' + last_name AS name
FROM   customer;
GO
/****** Object:  Table [dbo].[movie]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie](
	[movie_id] [int] IDENTITY(1000,1) NOT NULL,
	[title] [varchar](100) NULL,
	[rental_cost] [float] NULL,
	[release_year] [int] NULL,
	[copies] [int] NULL,
	[genre_id] [int] NULL,
	[rating] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplayAllMovie]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DisplayAllMovie]
as
SELECT movie_id, title + ' $' + CAST(rental_cost AS varchar(10)) AS title
FROM   movie;
GO
/****** Object:  Table [dbo].[genre]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[genre_id] [int] IDENTITY(1,1) NOT NULL,
	[genre_name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movie_rent_details]    Script Date: 8/8/2021 5:45:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie_rent_details](
	[movie_rent_id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NULL,
	[cust_id] [int] NULL,
	[date_rented] [datetime] NULL,
	[date_returned] [datetime] NULL,
	[rented_cost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_rent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 
GO
INSERT [dbo].[customer] ([cust_id], [first_name], [last_name], [address], [phone_no]) VALUES (100, N'Richard', N'D Coppola', N'71  French Street, Hamilton Central, Hamilton', N'0295751613')
GO
INSERT [dbo].[customer] ([cust_id], [first_name], [last_name], [address], [phone_no]) VALUES (101, N'Donna', N'R Carter', N'69  Helen-Mary Place, Matokitoki', N'0275108453')
GO
INSERT [dbo].[customer] ([cust_id], [first_name], [last_name], [address], [phone_no]) VALUES (102, N'Daniel', N'Adams', N'69  Helen-Mary Place, Motiti Island', N'0283559980')
GO
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[genre] ON 
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (1, N'Action')
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (5, N'Comedy')
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (3, N'Drama')
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (2, N'Horror')
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (4, N'Romance')
GO
INSERT [dbo].[genre] ([genre_id], [genre_name]) VALUES (6, N'Thriller')
GO
SET IDENTITY_INSERT [dbo].[genre] OFF
GO
SET IDENTITY_INSERT [dbo].[movie] ON 
GO
INSERT [dbo].[movie] ([movie_id], [title], [rental_cost], [release_year], [copies], [genre_id], [rating]) VALUES (1000, N'Gone With The Wind', 5, 2020, NULL, 4, 5)
GO
INSERT [dbo].[movie] ([movie_id], [title], [rental_cost], [release_year], [copies], [genre_id], [rating]) VALUES (1001, N'Extraction', 5, 2020, NULL, 6, 5)
GO
INSERT [dbo].[movie] ([movie_id], [title], [rental_cost], [release_year], [copies], [genre_id], [rating]) VALUES (1002, N'Close', 5, 2019, NULL, 6, 4)
GO
INSERT [dbo].[movie] ([movie_id], [title], [rental_cost], [release_year], [copies], [genre_id], [rating]) VALUES (1003, N'365 Days', 2, 2015, NULL, 4, 4)
GO
INSERT [dbo].[movie] ([movie_id], [title], [rental_cost], [release_year], [copies], [genre_id], [rating]) VALUES (1004, N'Poster Boy', 2, 2000, NULL, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[movie] OFF
GO
SET IDENTITY_INSERT [dbo].[movie_rent_details] ON 
GO
INSERT [dbo].[movie_rent_details] ([movie_rent_id], [movie_id], [cust_id], [date_rented], [date_returned], [rented_cost]) VALUES (1, 1001, 100, CAST(N'2021-06-20T14:06:54.947' AS DateTime), CAST(N'2021-06-20T14:08:46.723' AS DateTime), 5)
GO
SET IDENTITY_INSERT [dbo].[movie_rent_details] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__genre__1E98D151EDD29E7B]    Script Date: 8/8/2021 5:45:54 PM ******/
ALTER TABLE [dbo].[genre] ADD UNIQUE NONCLUSTERED 
(
	[genre_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[movie]  WITH CHECK ADD FOREIGN KEY([genre_id])
REFERENCES [dbo].[genre] ([genre_id])
GO
ALTER TABLE [dbo].[movie_rent_details]  WITH CHECK ADD FOREIGN KEY([cust_id])
REFERENCES [dbo].[customer] ([cust_id])
GO
ALTER TABLE [dbo].[movie_rent_details]  WITH CHECK ADD FOREIGN KEY([movie_id])
REFERENCES [dbo].[movie] ([movie_id])
GO
/****** Object:  StoredProcedure [dbo].[ShowRentedMovies]    Script Date: 8/8/2021 5:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ShowRentedMovies]
as
select movie_rent_id, first_name + ' ' + last_name as name,address,phone_no, title ,
mrd.rented_cost , date_rented, date_returned
from movie_rent_details mrd join customer c on mrd.cust_id = c.cust_id
join movie m on mrd.movie_id = m.movie_id;
GO
/****** Object:  StoredProcedure [dbo].[ShowRentedOutMovies]    Script Date: 8/8/2021 5:45:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ShowRentedOutMovies]
as
select movie_rent_id, first_name + ' ' + last_name as name,address,phone_no, title ,
mrd.rented_cost , date_rented, date_returned
from movie_rent_details mrd join customer c on mrd.cust_id = c.cust_id
join movie m on mrd.movie_id = m.movie_id where date_returned is null;
GO
