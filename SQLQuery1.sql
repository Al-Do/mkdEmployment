create table JobPostings (
PostID int primary key identity(1,1)NOT NULL,
    CompanyID int NOT NULL,
    CompanyName nvarchar(255)NOT NULL,
    JobPostedDate date NOT NULL,
    JobAvailableToDate date NOT NULL,
    ComapanyEmail nvarchar(255) NOT NULL,
	HoursPerWeek nvarchar(10) null,
    JobTitle nvarchar(255)NOT NULL,
	JobDescription nvarchar(500)null,
	Region nvarchar(50) NOT NULL
	);

	alter table Companies 
	alter column [Password] nvarchar(max)
	create table Companies (
 CompanyID int primary key identity(10,1) NOT NULL,
    CompanyName nvarchar(255) NOT NULL,
    CompanyLogoPath nvarchar(500) NULL,
    ComapanyEmail nvarchar(255)NOT NULL,
	[Password] nvarchar(100)NOT NULL,
	CompanyDescription nvarchar(500) NULL
	);
		create table Regions (
 RegionID int primary key identity(1,1) NOT NULL,
    RegionName nvarchar(100) NOT NULL
	);
	select * from Companies
	INSERT INTO dbo.JobPostings (CompanyID,JobPostedDate,JobAvailableToDate, HoursPerWeek,JobTitle,JobDescription,RegionID)
VALUES (11,
	'2019-11-11',
	'2019-12-11',
	'50',
	'Software developer',
	'Something bla bla bla bla',
	'4');
	insert into dbo.JobPostings
	values (
	11,
	'2019-11-11',
	'2019-12-11',
	'~/Images/ROI-Web-Marketing-500px - Copy195827346.jpg',
	'50',
	'Software developer',
	'Something bla bla bla bla',
	'4'
	);
	select * from dbo.JobPostings
	insert into dbo.Companies values (
	'Google',
	'home/photo',
	'aleksandar.d_@hotmail.com',
	'bla',
	'nekoja neshto dobra losha'
	)
	;
	ALTER TABLE Companies
ADD IsEmailVerified bit not null
	ALTER TABLE Companies
ADD ActivationCode uniqueidentifier not null
ALTER TABLE JobPostings
ADD RegionID int not null

	ALTER TABLE dbo.JobPostings  WITH CHECK ADD  CONSTRAINT [FK_JobPostings_Companies] FOREIGN KEY(CompanyID)
REFERENCES dbo.Companies (CompanyID)

ALTER TABLE dbo.JobPostings  CHECK CONSTRAINT [FK_JobPostings_Companies]

ALTER TABLE dbo.JobPostings  WITH CHECK ADD  CONSTRAINT [FK_JobPostings_Regions] FOREIGN KEY(RegionID)
REFERENCES dbo.Regions (RegionID)
select * from Companies

insert into dbo.Regions values (
'Pelagonija'
	);

		insert into dbo.Companies values (
	'Google',
	'home/photo',
	'aleksandar.d_@hotmail.com',
	'bla',
	'nekoja neshto dobra losha',
	1,
	'3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE'
	);

	delete from Companies where CompanyID = 13

	DATATABLES JQUERY-PROVERI

		insert into dbo.Regions values (
	'Eastern'
	);
	insert into dbo.Regions values (
	'Pelagonia'
	);insert into dbo.Regions values (
	'Southestern'
	);insert into dbo.Regions values (
	'Polog'
	);insert into dbo.Regions values (
	'Northeastern'
	);insert into dbo.Regions values (
	'Southwestern'
	);insert into dbo.Regions values (
	'Vardar'
	);
	insert into dbo.Regions values (
	'Skopje'
	);
	select * from Regions
