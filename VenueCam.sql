USE [CampusvenueReservation_V1]
GO
/****** Object:  Table [dbo].[PlaceRequest]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RemarkID] [int] NULL,
	[PlaceID] [int] NULL,
	[RequestStatus] [int] NULL,
	[StudentID] [int] NULL,
	[RequestedBy] [int] NULL,
	[RequestedTo] [int] NULL,
	[RequestingUserID] [int] NULL,
	[ResponsingUserID] [int] NULL,
	[RequestedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Capacity] [nvarchar](100) NULL,
	[Costs] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Remarks]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remarks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[RollNo] [int] NULL,
	[CNIC] [nvarchar](100) NULL,
	[FatherName] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[ConfirmPassword] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[Phone] [nvarchar](100) NULL,
	[UserType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PlaceRequest] ON 
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (1, NULL, 1, 1, 1, 1, NULL, 1, NULL, CAST(N'2021-11-25T22:07:49.320' AS DateTime), 1, CAST(N'2021-11-09T22:12:00.000' AS DateTime), CAST(N'2021-11-29T22:13:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (2, 3, 2, 1, 1, 0, 2, 0, 2, CAST(N'2021-11-27T16:13:34.127' AS DateTime), 1, CAST(N'2021-11-08T16:13:00.000' AS DateTime), CAST(N'2021-11-29T16:13:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (3, NULL, 2, 1, 1, 0, 2, 0, NULL, CAST(N'2021-11-27T16:13:34.797' AS DateTime), 1, CAST(N'2021-11-08T16:13:00.000' AS DateTime), CAST(N'2021-11-29T16:13:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (4, NULL, 2, 1, 1, 0, 2, 0, NULL, CAST(N'2021-11-27T16:13:44.200' AS DateTime), 1, CAST(N'2021-11-08T16:13:00.000' AS DateTime), CAST(N'2021-11-29T16:13:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (5, NULL, 2, 1, 1, 0, 1, 0, NULL, CAST(N'2021-12-07T00:26:37.590' AS DateTime), 1, CAST(N'2021-12-03T00:26:00.000' AS DateTime), CAST(N'2021-12-22T00:26:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (6, NULL, 1, 1, 1, 1, 2, 1, NULL, CAST(N'2021-12-07T01:12:47.010' AS DateTime), 1, CAST(N'2021-12-01T01:12:00.000' AS DateTime), CAST(N'2021-12-24T01:12:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (7, 4, 11, 2, 1, 4, 2, 12, 13, CAST(N'2021-12-14T23:52:07.767' AS DateTime), 1, CAST(N'2021-12-15T23:51:00.000' AS DateTime), CAST(N'2021-12-20T23:52:00.000' AS DateTime))
GO
INSERT [dbo].[PlaceRequest] ([ID], [RemarkID], [PlaceID], [RequestStatus], [StudentID], [RequestedBy], [RequestedTo], [RequestingUserID], [ResponsingUserID], [RequestedDate], [IsActive], [FromDate], [ToDate]) VALUES (8, 5, 12, 2, 1, 4, 3, 15, 16, CAST(N'2021-12-15T00:27:15.817' AS DateTime), 1, CAST(N'2021-12-16T00:27:00.000' AS DateTime), CAST(N'2021-12-30T00:27:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PlaceRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[Places] ON 
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (1, N'Zero Point', N'lkjsadf', CAST(N'2021-11-25T21:05:29.040' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (2, N'Chair', NULL, CAST(N'2021-11-26T20:08:53.107' AS DateTime), 0, N'30 Seats', CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (3, N'Table', NULL, CAST(N'2021-11-27T15:47:19.383' AS DateTime), 0, N'40 T', CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (4, N'Table', NULL, CAST(N'2021-11-27T15:47:20.653' AS DateTime), 1, N'40 T', CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (5, N'Table', NULL, CAST(N'2021-11-27T15:47:21.647' AS DateTime), 1, N'40 T', CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (6, N'KOOL', NULL, CAST(N'2021-11-27T15:51:44.883' AS DateTime), 1, N'600 ET', CAST(7000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (7, N'GOOD', NULL, CAST(N'2021-12-07T00:39:36.967' AS DateTime), 1, N'45', CAST(400.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (8, NULL, NULL, CAST(N'2021-12-14T23:33:28.300' AS DateTime), 1, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (9, NULL, NULL, CAST(N'2021-12-14T23:37:47.547' AS DateTime), 1, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (10, N'Leslie Swanson', NULL, CAST(N'2021-12-14T23:42:57.960' AS DateTime), 1, N'1200', CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (11, N'zaroon', NULL, CAST(N'2021-12-14T23:51:18.093' AS DateTime), 1, N'78', CAST(300.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Places] ([ID], [Name], [Description], [CreatedAt], [IsActive], [Capacity], [Costs]) VALUES (12, N'Campus', NULL, CAST(N'2021-12-15T00:26:21.173' AS DateTime), 1, N'60', CAST(300.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Places] OFF
GO
SET IDENTITY_INSERT [dbo].[Remarks] ON 
GO
INSERT [dbo].[Remarks] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (1, N'Accepted', NULL, CAST(N'2021-11-27T16:45:00.860' AS DateTime), 1)
GO
INSERT [dbo].[Remarks] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (2, N'Accepted', NULL, CAST(N'2021-11-27T16:45:37.440' AS DateTime), 1)
GO
INSERT [dbo].[Remarks] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (3, N'ok. Nice', NULL, CAST(N'2021-12-07T01:22:50.850' AS DateTime), 1)
GO
INSERT [dbo].[Remarks] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (4, N'Good Accepted', NULL, CAST(N'2021-12-14T23:54:11.153' AS DateTime), 1)
GO
INSERT [dbo].[Remarks] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (5, N'OK.', NULL, CAST(N'2021-12-15T00:29:07.660' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Remarks] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (1, N'HOD', N'Head of Department', CAST(N'2021-11-26T01:36:49.210' AS DateTime), 1)
GO
INSERT [dbo].[Role] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (2, N'Dean', N'CP', CAST(N'2021-11-26T01:37:03.730' AS DateTime), 1)
GO
INSERT [dbo].[Role] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (3, N'Vice Chancellor', N'UN', CAST(N'2021-11-26T01:37:54.490' AS DateTime), 1)
GO
INSERT [dbo].[Role] ([ID], [Name], [Description], [CreatedAt], [IsActive]) VALUES (4, N'Student', N'STD', CAST(N'2021-11-26T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([ID], [Name], [RollNo], [CNIC], [FatherName], [MobileNo], [CreatedAt], [IsActive]) VALUES (1, N'Farhan', 123, N'922223213', N'Akmal', N'98343233242', CAST(N'2021-11-25T21:03:38.963' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (1, N'Hello', N'Hello@gmail.com', N'123', N'123', 1, CAST(N'2021-11-06T20:18:58.187' AS DateTime), N'628342984', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (2, N'KHAN', N'KHAN@Gmail.com', N'1234', N'1234', 1, CAST(N'2021-11-26T01:47:21.330' AS DateTime), N'92334566543', 2)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (5, N'DemoUser', N'Demo@gmail.com', N'123', N'123', 1, CAST(N'2021-12-14T23:10:24.553' AS DateTime), N'03347768698', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (6, N'DemoUser', N'Demo@gmail.com', N'123', N'123', 1, CAST(N'2021-12-14T23:10:27.457' AS DateTime), N'03347768698', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (7, N'DemoUser', N'Demo@gmail.com', N'123', N'123', 1, CAST(N'2021-12-14T23:15:04.667' AS DateTime), N'03347768698', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (8, N'DemoUser', N'Demo@gmail.com', N'1232', N'1232', 1, CAST(N'2021-12-14T23:18:08.300' AS DateTime), N'03347768698', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (9, N'DemoUser', N'Demo@gmail.com', N'1232', N'1232', 1, CAST(N'2021-12-14T23:18:10.653' AS DateTime), N'03347768698', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (10, N'DemoUser', N'DEmo@gamil.com', N'1234', N'1234', 1, CAST(N'2021-12-14T23:19:36.467' AS DateTime), N'03324342342', 1)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (11, N'Student', N'Std@Gmail.com', N'123', N'123', 1, CAST(N'2021-12-14T23:31:53.583' AS DateTime), N'0332456783', 4)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (12, N'Hello', N'Hello@gmail.com', N'1234', N'1234', 1, CAST(N'2021-12-14T23:49:52.180' AS DateTime), N'0332683222', 4)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (13, N'aslam', N'aslam@gmail.com', N'1234', N'1234', 1, CAST(N'2021-12-14T23:53:20.480' AS DateTime), N'0334367868', 2)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (14, N'Hassan', N'Hassan@gmail.com', N'123', N'123', 1, CAST(N'2021-12-15T00:21:10.797' AS DateTime), N'0332456876', 4)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (15, N'Mohsin', N'Mohsin@gmail.com', N'12345', N'12345', 1, CAST(N'2021-12-15T00:24:34.347' AS DateTime), N'0332456788', 4)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (16, N'Vice', N'Vice@gmail.com', N'123', N'123', 1, CAST(N'2021-12-15T00:28:20.173' AS DateTime), N'03345679877', 3)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (17, NULL, NULL, NULL, NULL, 1, CAST(N'2022-01-04T22:25:31.273' AS DateTime), NULL, 0)
GO
INSERT [dbo].[User] ([ID], [Username], [Email], [Password], [ConfirmPassword], [IsActive], [CreatedAt], [Phone], [UserType]) VALUES (18, NULL, NULL, NULL, NULL, 1, CAST(N'2022-01-04T22:48:09.557' AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[PlaceRequest] ADD  DEFAULT (getdate()) FOR [RequestedDate]
GO
ALTER TABLE [dbo].[PlaceRequest] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Places] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Places] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Remarks] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Remarks] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddVenue]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_AddVenue]    
@Name nvarchar(100) = null,    
@Capacity nvarchar(100) =null,    
@Costs int =null     
as     
begin    
    
insert into Places(Name,Capacity,Costs,IsActive,CreatedAt) values (@Name,@Capacity,@Costs,1,GETDATE())    

Declare @ID int = (select SCOPE_IDENTITY())  

Select @ID as ID


end 
GO
/****** Object:  StoredProcedure [dbo].[Sp_ChangePassword]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_ChangePassword]        
@oldPassword nvarchar(100),
@NewPassword nvarchar(100),
@UserID int
as        
begin         
    
begin try

update [User] set Password=@NewPassword where Password=@oldPassword and ID=@UserID

end try

begin catch

select ERROR_MESSAGE() as StatusMessage, ERROR_NUMBER() as StatusCode

end catch
        
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_CreateUser]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_CreateUser]      
@Username nvarchar(150),      
@Email nvarchar(150),      
@Phone nvarchar(150),      
@Password nvarchar(150),      
@CPassword nvarchar(150) ,    
@UserType int  
as      
begin      
begin try       
 insert into [User](Username,Email,Phone,Password,ConfirmPassword,UserType) values (@Username,@Email,@Phone,@Password,@CPassword,@UserType)      
      
 select SCOPE_IDENTITY() as StatusCode,'User Created Successfully!' as StatusMessage      
      
end try       
begin catch      
      
select ERROR_MESSAGE() as StatusMessage,ERROR_NUMBER() as StatusCode      
      
end catch      
      
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteVenue]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_DeleteVenue]   
@ID int=null 
as    
begin     
   
   
 update Places set IsActive=0 where ID=@ID
    
select @ID as ID
    
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllDashboardData]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_getAllDashboardData]
as
begin


select count(ID) as TotalRequest,(select count(ID) from PlaceRequest where RequestStatus=1) as Pending,(select count(ID) from PlaceRequest where RequestStatus=2) as Accepted,(select Count(ID)  from PlaceRequest where RequestStatus=3 ) as Rejected from PlaceRequest


select  pr.ID,r.Name RequestedBy,tr.Name RequestedTo,FromDate,ToDate,    
case RequestStatus     
when 1 then 'Pending'     
when 2 then 'Accepted'    
when 3 then 'Rejected'    
end  Status,   
pl.Name PlaceID,rm.Name  RemarkID from PlaceRequest pr   
left join Places pl on pl.ID=pr.PlaceID   
left join Role r on r.ID=pr.RequestedBy  
left join Role tr on tr.ID=pr.RequestedTo
left join [User] u on u.ID=pr.RequestingUserID  
left join Remarks rm on pr.RemarkID=rm.ID where pr.IsActive=1  

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllRequestedPlace]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllRequestedPlace]    
@LastRowID int =0,    
@PageSize int=25,    
@SearchCriteria nvarchar(100)=''   
as    
begin     
  declare @TotalRecord int = (select COUNT(pr.ID) as TotalRecord from PlaceRequest pr   
 left join Places pl on pl.ID=pr.PlaceID   
left join [User] u on u.ID=pr.RequestingUserID  
left join Role r on r.ID=pr.RequestedBy   
left join Remarks rm on pr.RemarkID=rm.ID where pr.IsActive=1)   
  
  
select  pr.ID,r.Name RequestedBy,tr.Name RequestedTo,FromDate,ToDate,    
case RequestStatus     
when 1 then 'Pending'     
when 2 then 'Accepted'    
when 3 then 'Rejected'    
end  Status,   
@TotalRecord as TotalRecord,  
pl.Name PlaceID,rm.Name  RemarkID from PlaceRequest pr   
left join Places pl on pl.ID=pr.PlaceID   
left join Role r on r.ID=pr.RequestedBy  
left join Role tr on tr.ID=pr.RequestedTo
left join [User] u on u.ID=pr.RequestingUserID  
left join Remarks rm on pr.RemarkID=rm.ID where pr.IsActive=1  
order by pr.ID  
OFFSET @LastRowId ROW                       
 FETCH NEXT @PageSize ROWS ONLY  
    
    
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllResponsePlace]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllResponsePlace]      
@LastRowID int =0,      
@PageSize int=25,      
@UserType int =null,  
@UserID int =null,  
@SearchCriteria nvarchar(100)=''     
as      
begin       
  declare @TotalRecord int = (select COUNT(pr.ID) as TotalRecord from PlaceRequest pr     
 left join Places pl on pl.ID=pr.PlaceID     
left join [User] u on u.ID=pr.RequestingUserID    
left join Role r on r.ID=pr.RequestedBy     
left join Remarks rm on pr.RemarkID=rm.ID where pr.IsActive=1 and RequestedTo=@UserType)     
    
    
select  pr.ID,r.Name RequestedBy,rl.Name RequestedTo,FromDate,ToDate,      
case RequestStatus       
when 1 then 'Pending'       
when 2 then 'Accepted'      
when 3 then 'Rejected'      
end  Status,     
@TotalRecord as TotalRecord,    
pl.Name PlaceID,rm.Name  RemarkID from PlaceRequest pr     
left join Places pl on pl.ID=pr.PlaceID     
left join Role r on r.ID=pr.RequestedBy    
left join Role rl on rl.ID=pr.RequestedTo
left join [User] u on u.ID=pr.RequestingUserID    
left join Remarks rm on pr.RemarkID=rm.ID where pr.IsActive=1  and RequestedTo=@UserType  
order by pr.ID    
OFFSET @LastRowId ROW                         
 FETCH NEXT @PageSize ROWS ONLY    
      
      
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllUsers]     
@LastRowID int =0,      
@PageSize int=25,      
@SearchCriteria nvarchar(100)=''     
as      
begin       
  declare @TotalRecord int = (select COUNT(ID) as TotalRecord from [User]   where IsActive=1)     
    
    
select  pr.ID,pr.Username,pr.Email,r.Name UserType,      
@TotalRecord as TotalRecord from [User] pr join Role r on r.ID=pr.UserType  where pr.IsActive=1    
order by pr.ID    
OFFSET @LastRowId ROW                         
 FETCH NEXT @PageSize ROWS ONLY    
      
      
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllVenue]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllVenue]   
@LastRowID int =0,    
@PageSize int=25,    
@SearchCriteria nvarchar(100)=''   
as    
begin     
  declare @TotalRecord int = (select COUNT(pr.ID) as TotalRecord from Places pr  where pr.IsActive=1)   
  
  
select  pr.ID,pr.Name,pr.Capacity,pr.Costs,    
@TotalRecord as TotalRecord from Places pr  where pr.IsActive=1  
order by pr.ID  
OFFSET @LastRowId ROW                       
 FETCH NEXT @PageSize ROWS ONLY  
    
    
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaces]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetPlaces]
as
begin

select ID,Name from Places

end 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudent]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetStudent]
as
begin

select ID,Name from Student

end 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserType]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_GetUserType]
as
begin 
Select ID,Name from Role


end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetVenueAgainstID]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetVenueAgainstID]   
@ID int=null 
as    
begin     
   
  
  
select  pr.ID,pr.Name,pr.Capacity,pr.Costs   
 from Places pr  where pr.IsActive=1 and pr.ID=@ID  

    
    
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Login]  
@UserName nvarchar(100),  
@Password nvarchar(100)  
as  
begin  
begin try   
  
select u.ID,UserType,r.Name as UserName from [User] u inner join Role r on u.UserType=r.ID where Username=@UserName and Password=@Password  
  
end try  
  
begin catch  
  
select ERROR_MESSAGE() as StatusMessage , ERROR_LINE() as StatusCode  
end catch  
  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ReponseVenue]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ReponseVenue]     
@ID int =null,    
@Remarks nvarchar(100)=null,
@Status int,
@UserID int=null    
as        
begin         
    
insert into Remarks(Name) values (@Remarks)    
    
declare @RID int =(select SCOPE_IDENTITY())    
    
update PlaceRequest set RemarkID=@RID ,ResponsingUserID=@UserID,RequestStatus=@Status where ID=@ID   
  
select 200 as StatusCode,'Respons Added Successfully!'  
       
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Requestforplace]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Requestforplace]    
@StudentID int = null,    
@PlaceID int =null,    
@FromDate datetime =null,    
@UserID int=null,  
@UserType int=null,  
@ToDate datetime = null,  
@RequestTo int =null  
as     
begin    

declare @Count int =(select count(ID) from PlaceRequest where ((FromDate=@FromDate and ToDate=@ToDate) or (FromDate >= @FromDate and ToDate <= @FromDate)) and PlaceID=@PlaceID)    

if @Count > 0
begin
select 'Request Aready Initiated' as StatusMessage ,400 as StatusCode
end
else
begin
insert into PlaceRequest(StudentID,PlaceID,RequestedBy,RequestedTo,RequestingUserID,RequestStatus,FromDate,ToDate) values (@StudentID,@PlaceID,@UserType,@RequestTo,@UserID,1,@FromDate,@ToDate)

select 'Requested Initiated Successfully' as StatusMessage ,200 as StatusCode
end
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateVenue]    Script Date: 1/5/2022 5:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_UpdateVenue]   
@ID int =null,  
@Name nvarchar(100)=null,  
@Capacity nvarchar(100)=null,  
@Costs int  
as      
begin       
  
update Places set Name=@Name,Capacity=@Capacity,Costs=@Costs where ID=@ID  

select 200 as StatusCode,'Data Update Successfully!' as StatusMessage     

end
GO
