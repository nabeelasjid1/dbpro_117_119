USE [master]
GO
/****** Object:  Database [DB40]    Script Date: 14/04/2019 4:44:19 AM ******/
CREATE DATABASE [DB40]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB40', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB40.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB40_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB40_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB40] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB40].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB40] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB40] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB40] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB40] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB40] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB40] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB40] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB40] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB40] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB40] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB40] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB40] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB40] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB40] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB40] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB40] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB40] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB40] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB40] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB40] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB40] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB40] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB40] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB40] SET  MULTI_USER 
GO
ALTER DATABASE [DB40] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB40] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB40] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB40] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB40] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB40] SET QUERY_STORE = OFF
GO
USE [DB40]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DB40]
GO
/****** Object:  Table [dbo].[Chalan]    Script Date: 14/04/2019 4:44:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chalan](
	[ChalanId] [int] IDENTITY(1,1) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[ChalanDate] [datetime] NOT NULL,
	[CurrentYear] [datetime] NOT NULL,
 CONSTRAINT [PK_Fee] PRIMARY KEY CLUSTERED 
(
	[ChalanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassAttendence]    Script Date: 14/04/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAttendence](
	[ClassAttendenceId] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassAttendence] PRIMARY KEY CLUSTERED 
(
	[ClassAttendenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[complaint]    Script Date: 14/04/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[complaint](
	[complaintId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[IsViewed] [bit] NOT NULL,
	[Detail] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_complaint] PRIMARY KEY CLUSTERED 
(
	[complaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 14/04/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CreditHrs] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 14/04/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentCourseRelation]    Script Date: 14/04/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentCourseRelation](
	[CourseId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentInstructorRelation]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentInstructorRelation](
	[DepartmentId] [int] NOT NULL,
	[InstructorId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentStudentRelation]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentStudentRelation](
	[DepartmentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Venue] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hostel]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hostel](
	[HostelId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Capacity] [int] NULL,
 CONSTRAINT [PK_Hostel] PRIMARY KEY CLUSTERED 
(
	[HostelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Detail] [nvarchar](50) NULL,
	[Specialization] [nvarchar](50) NULL,
	[Descrimination] [nvarchar](50) NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstructorCourseRelation]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorCourseRelation](
	[InstructorId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstructorStudentRelation]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorStudentRelation](
	[InstructorId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Description] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[NoticeId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[NoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 14/04/2019 4:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ParentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentcomplaintRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentcomplaintRelation](
	[complaintId] [int] NOT NULL,
	[ParentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentHostelIdRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentHostelIdRelation](
	[ParentId] [int] NOT NULL,
	[HostelId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentStudentRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentStudentRelation](
	[ParentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EnrollmentDate] [datetime] NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendence]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendence](
	[AttendenceId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[AttendenceStatus] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendence] PRIMARY KEY CLUSTERED 
(
	[AttendenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentChalanRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentChalanRelation](
	[StudentId] [int] NOT NULL,
	[ChalanId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentcomplaintRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentcomplaintRelation](
	[complaintId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentHostelRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentHostelRelation](
	[HostelId] [int] NOT NULL,
	[StudentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentRegSubjectRelation]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentRegSubjectRelation](
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 14/04/2019 4:44:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[DepartmentCourseRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentCourseRelation_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[DepartmentCourseRelation] CHECK CONSTRAINT [FK_DepartmentCourseRelation_Course]
GO
ALTER TABLE [dbo].[DepartmentCourseRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentCourseRelation_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentCourseRelation] CHECK CONSTRAINT [FK_DepartmentCourseRelation_Department]
GO
ALTER TABLE [dbo].[DepartmentInstructorRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentInstructorRelation_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentInstructorRelation] CHECK CONSTRAINT [FK_DepartmentInstructorRelation_Department]
GO
ALTER TABLE [dbo].[DepartmentInstructorRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentInstructorRelation_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[DepartmentInstructorRelation] CHECK CONSTRAINT [FK_DepartmentInstructorRelation_Instructor]
GO
ALTER TABLE [dbo].[DepartmentStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentStudentRelation_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentStudentRelation] CHECK CONSTRAINT [FK_DepartmentStudentRelation_Department]
GO
ALTER TABLE [dbo].[DepartmentStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentStudentRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[DepartmentStudentRelation] CHECK CONSTRAINT [FK_DepartmentStudentRelation_Student]
GO
ALTER TABLE [dbo].[InstructorCourseRelation]  WITH CHECK ADD  CONSTRAINT [FK_InstructorCourseRelation_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[InstructorCourseRelation] CHECK CONSTRAINT [FK_InstructorCourseRelation_Course]
GO
ALTER TABLE [dbo].[InstructorCourseRelation]  WITH CHECK ADD  CONSTRAINT [FK_InstructorCourseRelation_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[InstructorCourseRelation] CHECK CONSTRAINT [FK_InstructorCourseRelation_Instructor]
GO
ALTER TABLE [dbo].[InstructorStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_InstructorStudentRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[InstructorStudentRelation] CHECK CONSTRAINT [FK_InstructorStudentRelation_Student]
GO
ALTER TABLE [dbo].[ParentcomplaintRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentcomplaintRelation_complaint] FOREIGN KEY([complaintId])
REFERENCES [dbo].[complaint] ([complaintId])
GO
ALTER TABLE [dbo].[ParentcomplaintRelation] CHECK CONSTRAINT [FK_ParentcomplaintRelation_complaint]
GO
ALTER TABLE [dbo].[ParentcomplaintRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentcomplaintRelation_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([ParentId])
GO
ALTER TABLE [dbo].[ParentcomplaintRelation] CHECK CONSTRAINT [FK_ParentcomplaintRelation_Parent]
GO
ALTER TABLE [dbo].[ParentHostelIdRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentHostelIdRelation_Hostel] FOREIGN KEY([HostelId])
REFERENCES [dbo].[Hostel] ([HostelId])
GO
ALTER TABLE [dbo].[ParentHostelIdRelation] CHECK CONSTRAINT [FK_ParentHostelIdRelation_Hostel]
GO
ALTER TABLE [dbo].[ParentHostelIdRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentHostelIdRelation_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([ParentId])
GO
ALTER TABLE [dbo].[ParentHostelIdRelation] CHECK CONSTRAINT [FK_ParentHostelIdRelation_Parent]
GO
ALTER TABLE [dbo].[ParentStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentStudentRelation_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([ParentId])
GO
ALTER TABLE [dbo].[ParentStudentRelation] CHECK CONSTRAINT [FK_ParentStudentRelation_Parent]
GO
ALTER TABLE [dbo].[ParentStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_ParentStudentRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[ParentStudentRelation] CHECK CONSTRAINT [FK_ParentStudentRelation_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Lookup]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Student]
GO
ALTER TABLE [dbo].[StudentAttendence]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendence_Lookup] FOREIGN KEY([AttendenceStatus])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[StudentAttendence] CHECK CONSTRAINT [FK_StudentAttendence_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendence]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendence_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentAttendence] CHECK CONSTRAINT [FK_StudentAttendence_Student]
GO
ALTER TABLE [dbo].[StudentChalanRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentChalanRelation_Chalan] FOREIGN KEY([ChalanId])
REFERENCES [dbo].[Chalan] ([ChalanId])
GO
ALTER TABLE [dbo].[StudentChalanRelation] CHECK CONSTRAINT [FK_StudentChalanRelation_Chalan]
GO
ALTER TABLE [dbo].[StudentChalanRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentChalanRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentChalanRelation] CHECK CONSTRAINT [FK_StudentChalanRelation_Student]
GO
ALTER TABLE [dbo].[StudentcomplaintRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentcomplaintRelation_complaint] FOREIGN KEY([complaintId])
REFERENCES [dbo].[complaint] ([complaintId])
GO
ALTER TABLE [dbo].[StudentcomplaintRelation] CHECK CONSTRAINT [FK_StudentcomplaintRelation_complaint]
GO
ALTER TABLE [dbo].[StudentcomplaintRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentcomplaintRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentcomplaintRelation] CHECK CONSTRAINT [FK_StudentcomplaintRelation_Student]
GO
ALTER TABLE [dbo].[StudentHostelRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentHostelRelation_Hostel] FOREIGN KEY([HostelId])
REFERENCES [dbo].[Hostel] ([HostelId])
GO
ALTER TABLE [dbo].[StudentHostelRelation] CHECK CONSTRAINT [FK_StudentHostelRelation_Hostel]
GO
ALTER TABLE [dbo].[StudentHostelRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentHostelRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentHostelRelation] CHECK CONSTRAINT [FK_StudentHostelRelation_Student]
GO
ALTER TABLE [dbo].[StudentRegSubjectRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegSubjectRelation_Course] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentRegSubjectRelation] CHECK CONSTRAINT [FK_StudentRegSubjectRelation_Course]
GO
ALTER TABLE [dbo].[StudentRegSubjectRelation]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegSubjectRelation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentRegSubjectRelation] CHECK CONSTRAINT [FK_StudentRegSubjectRelation_Student]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Course]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Student]
GO
USE [master]
GO
ALTER DATABASE [DB40] SET  READ_WRITE 
GO
