IF schema_id('Data') IS NULL਍ऀ䔀堀䔀䌀唀吀䔀⠀✀挀爀攀愀琀攀 猀挀栀攀洀愀 䐀愀琀愀✀⤀㬀ഀഀ
IF schema_id('Billing') IS NULL਍ऀ䔀堀䔀䌀唀吀䔀⠀✀挀爀攀愀琀攀 猀挀栀攀洀愀 䈀椀氀氀椀渀最✀⤀㬀ഀഀ
IF schema_id('Seating') IS NULL਍ऀ䔀堀䔀䌀唀吀䔀⠀✀挀爀攀愀琀攀 猀挀栀攀洀愀 匀攀愀琀椀渀最✀⤀㬀ഀഀ
GO਍䌀刀䔀䄀吀䔀 䘀唀一䌀吀䤀伀一 䐀愀琀愀⸀䘀漀爀洀愀琀倀栀漀渀攀⠀䀀瀀栀漀渀攀 嘀䄀刀䌀䠀䄀刀⠀㈀　⤀⤀ ഀഀ
	RETURNS VARCHAR(16)਍䄀匀ഀഀ
BEGIN਍ऀ䐀䔀䌀䰀䄀刀䔀 䀀猀琀爀椀瀀瀀攀搀倀栀漀渀攀 嘀䄀刀䌀䠀䄀刀⠀㄀　⤀ഀഀ
	SET @strippedPhone = REPLACE(REPLACE(REPLACE(REPLACE(@phone, '-', ''), ' ', ''), '(', ''), ')', '');਍ऀഀഀ
	IF(LEN(@strippedPhone) = 7) RETURN SUBSTRING(@strippedPhone, 1, 3) + ' - ' + SUBSTRING(@strippedPhone, 4, 4);਍ऀ䤀䘀⠀䰀䔀一⠀䀀猀琀爀椀瀀瀀攀搀倀栀漀渀攀⤀ 㰀㸀 ㄀　⤀ 刀䔀吀唀刀一 䀀瀀栀漀渀攀㬀ഀഀ
	RETURN '(' + SUBSTRING(@strippedPhone, 1, 3) + ') ' + SUBSTRING(@strippedPhone, 4, 3) + ' - ' + SUBSTRING(@strippedPhone, 7, 4);਍䔀一䐀ഀഀ
GO਍ഀഀ
--This is the YK directory਍䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 䐀愀琀愀⸀䴀愀猀琀攀爀䐀椀爀攀挀琀漀爀礀 ⠀ഀഀ
	Id				UNIQUEIDENTIFIER	NOT NULL	ROWGUIDCOL	PRIMARY KEY DEFAULT(newid()),਍ऀ夀䬀䤀䐀ऀऀऀ䤀一吀䔀䜀䔀刀ऀऀऀऀ一唀䰀䰀Ⰰഀഀ
	LastName		NVARCHAR(100)		NOT NULL,਍ऀ䠀椀猀一愀洀攀ऀऀऀ一嘀䄀刀䌀䠀䄀刀⠀㄀　　⤀ऀऀ一唀䰀䰀Ⰰഀഀ
	HerName			NVARCHAR(100)		NULL,਍ऀ䘀甀氀氀一愀洀攀ऀऀ一嘀䄀刀䌀䠀䄀刀⠀㄀　　⤀ऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	Salutation		NVARCHAR(100)		NOT NULL,਍ऀ䄀搀搀爀攀猀猀ऀऀऀ一嘀䄀刀䌀䠀䄀刀⠀㄀　　⤀ऀऀ一唀䰀䰀Ⰰഀഀ
	City			NVARCHAR(100)		NULL,਍ऀ匀琀愀琀攀ऀऀऀ嘀䄀刀䌀䠀䄀刀⠀㈀⤀ऀऀऀ一唀䰀䰀Ⰰഀഀ
	Zip				VARCHAR(5)			NULL,਍ऀ倀栀漀渀攀ऀऀऀ嘀䄀刀䌀䠀䄀刀⠀㈀　⤀ऀऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	[Source]		NVARCHAR(64)		NOT NULL	DEFAULT('Manually Added'),਍ऀ嬀刀漀眀嘀攀爀猀椀漀渀崀ऀ刀漀眀嘀攀爀猀椀漀渀ഀഀ
);਍ऀഀഀ
਍ⴀⴀ吀礀瀀攀 挀愀渀 戀攀 䄀氀椀礀愀栀Ⰰ 䄀搀Ⰰ 䴀攀洀戀攀爀猀栀椀瀀Ⰰ ⸀⸀⸀ഀഀ
--SubType can be שלישי, Gold Ad, כל הנערים, ...਍ⴀⴀ一漀琀攀 眀椀氀氀 愀瀀瀀攀愀爀 漀渀 琀栀攀 戀椀氀氀 愀渀搀 眀椀氀氀 戀攀 甀猀攀搀 昀漀爀 琀栀椀渀最猀 氀椀欀攀 爀攀氀愀琀椀瘀攀猀⸀ഀഀ
--Comments will not appear on the bill.਍䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 䈀椀氀氀椀渀最⸀倀氀攀搀最攀猀 ⠀ഀഀ
	PledgeId		UNIQUEIDENTIFIER	NOT NULL	ROWGUIDCOL	PRIMARY KEY DEFAULT(newid()),਍ऀ倀攀爀猀漀渀䤀搀ऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀䔀䘀䔀刀䔀一䌀䔀匀 䐀愀琀愀⸀䴀愀猀琀攀爀䐀椀爀攀挀琀漀爀礀⠀䤀搀⤀Ⰰഀഀ
	[Date]			DATETIME			NOT NULL	DEFAULT getdate(),਍ऀ吀礀瀀攀ऀऀऀ一嘀䄀刀䌀䠀䄀刀⠀㘀㐀⤀ऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	SubType			NVARCHAR(64)		NOT NULL,਍ऀ䄀挀挀漀甀渀琀ऀऀऀ嘀䄀刀䌀䠀䄀刀⠀㌀㈀⤀ऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 ✀伀瀀攀爀愀琀椀渀最 䘀甀渀搀✀Ⰰഀഀ
	Amount			MONEY				NOT NULL,਍ऀ一漀琀攀ऀऀऀ一嘀䄀刀䌀䠀䄀刀⠀㔀㄀㈀⤀ऀऀ一唀䰀䰀Ⰰഀഀ
	Comments		NVARCHAR(512)		NULL,਍ऀ䴀漀搀椀昀椀攀搀ऀऀ䐀䄀吀䔀吀䤀䴀䔀ऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 最攀琀搀愀琀攀⠀⤀Ⰰഀഀ
	Modifier		NVARCHAR(32)		NOT NULL,਍ऀ䔀砀琀攀爀渀愀氀匀漀甀爀挀攀ऀ一嘀䄀刀䌀䠀䄀刀⠀㌀㈀⤀ऀऀ一唀䰀䰀ऀऀ䐀䔀䘀䄀唀䰀吀 一唀䰀䰀Ⰰഀഀ
	ExternalID		INTEGER				NULL		DEFAULT NULL,਍ऀ嬀刀漀眀嘀攀爀猀椀漀渀崀ऀ刀漀眀嘀攀爀猀椀漀渀ഀഀ
);਍ഀഀ
CREATE TABLE Billing.Deposits (਍ऀ䐀攀瀀漀猀椀琀䤀搀ऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀伀圀䜀唀䤀䐀䌀伀䰀ऀ倀刀䤀䴀䄀刀夀 䬀䔀夀 䐀䔀䘀䄀唀䰀吀⠀渀攀眀椀搀⠀⤀⤀Ⰰഀഀ
	[Date]			DATETIME			NOT NULL,਍ऀ一甀洀戀攀爀ऀऀऀ䤀一吀䔀䜀䔀刀ऀऀऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	Account			VARCHAR(32)			NOT NULL	DEFAULT 'Operating Fund',਍ऀ嬀刀漀眀嘀攀爀猀椀漀渀崀ऀ刀漀眀嘀攀爀猀椀漀渀Ⰰഀഀ
	CONSTRAINT UniqueFields UNIQUE([Date], Number, Account)਍⤀㬀 ⴀⴀ刀攀挀漀爀搀猀 搀攀瀀漀猀椀琀猀 椀渀琀漀 琀栀攀 戀愀渀欀ഀഀ
CREATE TABLE Billing.Payments (਍ऀ倀愀礀洀攀渀琀䤀搀ऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀伀圀䜀唀䤀䐀䌀伀䰀ऀ倀刀䤀䴀䄀刀夀 䬀䔀夀 䐀䔀䘀䄀唀䰀吀⠀渀攀眀椀搀⠀⤀⤀Ⰰഀഀ
	PersonId		UNIQUEIDENTIFIER	NOT NULL	REFERENCES Data.MasterDirectory(Id),਍ऀ嬀䐀愀琀攀崀ऀऀऀ䐀䄀吀䔀吀䤀䴀䔀ऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 最攀琀搀愀琀攀⠀⤀Ⰰഀഀ
	Method			NVARCHAR(64)		NOT NULL,਍ऀ䌀栀攀挀欀一甀洀戀攀爀ऀऀ嘀䄀刀䌀䠀䄀刀⠀㌀㈀⤀ऀऀऀ一唀䰀䰀Ⰰഀഀ
	Account			VARCHAR(32)			NOT NULL	DEFAULT 'Operating Fund',਍ऀ䄀洀漀甀渀琀ऀऀऀ䴀伀一䔀夀ऀऀऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	DepositId		UNIQUEIDENTIFIER	NULL		DEFAULT NULL REFERENCES Billing.Deposits(DepositId) ON DELETE SET NULL,਍ऀ䌀漀洀洀攀渀琀猀ऀऀ一嘀䄀刀䌀䠀䄀刀⠀㔀㄀㈀⤀ऀऀ一唀䰀䰀Ⰰഀഀ
	Modified		DATETIME			NOT NULL	DEFAULT getdate(),਍ऀ䴀漀搀椀昀椀攀爀ऀऀ一嘀䄀刀䌀䠀䄀刀⠀㌀㈀⤀ऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	ExternalSource	NVARCHAR(32)		NULL		DEFAULT NULL,਍ऀ䔀砀琀攀爀渀愀氀䤀䐀ऀऀ䤀一吀䔀䜀䔀刀ऀऀऀऀ一唀䰀䰀ऀऀ䐀䔀䘀䄀唀䰀吀 一唀䰀䰀Ⰰഀഀ
	[RowVersion]	RowVersion਍⤀㬀ഀഀ
਍䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 䈀椀氀氀椀渀最⸀倀氀攀搀最攀䰀椀渀欀猀 ⠀ഀഀ
	LinkId			UNIQUEIDENTIFIER	NOT NULL	ROWGUIDCOL	PRIMARY KEY DEFAULT(newid()),਍ऀ倀氀攀搀最攀䤀搀ऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ唀一䤀儀唀䔀ऀऀ刀䔀䘀䔀刀䔀一䌀䔀匀 䈀椀氀氀椀渀最⸀倀氀攀搀最攀猀⠀倀氀攀搀最攀䤀搀⤀ 伀一 䐀䔀䰀䔀吀䔀 䌀䄀匀䌀䄀䐀䔀Ⰰഀഀ
	PaymentId		UNIQUEIDENTIFIER	NOT NULL	UNIQUE		REFERENCES Billing.Payments(PaymentsId) ON DELETE CASCADE,਍ऀ䄀洀漀甀渀琀ऀऀऀ䴀伀一䔀夀ऀऀऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	[RowVersion]	RowVersion਍⤀㬀ഀഀ
GO਍ⴀⴀ吀栀椀猀 瘀椀攀眀 洀愀欀攀猀 洀愀渀甀愀氀 焀甀攀爀椀攀猀 洀甀挀栀 猀椀洀瀀氀攀爀ഀഀ
CREATE VIEW Billing.Transactions AS਍ऀ匀䔀䰀䔀䌀吀 倀攀爀猀漀渀䤀搀Ⰰ ഀഀ
		   [Date], ਍ऀऀ   ✀倀氀攀搀最攀✀ 䄀匀 嬀吀礀瀀攀崀Ⰰഀഀ
		   CASE SubType ਍ऀऀऀऀ圀䠀䔀一 ✀✀ 吀䠀䔀一 嬀吀礀瀀攀崀ഀഀ
				ELSE [Type] + ' / ' + SubType਍ऀऀ   䔀一䐀 䄀匀 嬀䐀攀猀挀爀椀瀀琀椀漀渀崀Ⰰഀഀ
		   Amount,਍ऀऀ   䄀挀挀漀甀渀琀Ⰰഀഀ
		   Comments,਍ऀऀ   䴀漀搀椀昀椀攀爀Ⰰഀഀ
		   Modified਍ऀऀ䘀刀伀䴀 䈀椀氀氀椀渀最⸀倀氀攀搀最攀猀ഀഀ
	UNION ਍ऀ匀䔀䰀䔀䌀吀 倀攀爀猀漀渀䤀搀Ⰰ ഀഀ
		   [Date], ਍ऀऀ   ✀倀愀礀洀攀渀琀✀ 䄀匀 嬀吀礀瀀攀崀Ⰰഀഀ
		   CASE ਍ऀऀऀऀ圀䠀䔀一 䌀栀攀挀欀一甀洀戀攀爀 䤀匀 一唀䰀䰀 伀刀 䌀栀攀挀欀一甀洀戀攀爀㴀✀✀ 吀䠀䔀一 䴀攀琀栀漀搀ഀഀ
				ELSE Method + ' #' + CheckNumber਍ऀऀ   䔀一䐀 䄀匀 嬀䐀攀猀挀爀椀瀀琀椀漀渀崀Ⰰഀഀ
		   -Amount AS Amount,਍ऀऀ   䄀挀挀漀甀渀琀Ⰰഀഀ
		   Comments,਍ऀऀ   䴀漀搀椀昀椀攀爀Ⰰഀഀ
		   Modified਍ऀऀ䘀刀伀䴀 䈀椀氀氀椀渀最⸀倀愀礀洀攀渀琀猀㬀ഀഀ
GO਍ഀഀ
CREATE TABLE Billing.StatementLog (਍ऀ䤀搀ऀऀऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀伀圀䜀唀䤀䐀䌀伀䰀ऀ倀刀䤀䴀䄀刀夀 䬀䔀夀 䐀䔀䘀䄀唀䰀吀⠀渀攀眀椀搀⠀⤀⤀Ⰰഀഀ
	PersonId		UNIQUEIDENTIFIER	NOT NULL	REFERENCES Data.MasterDirectory(Id),਍ऀ嬀䐀愀琀攀䜀攀渀攀爀愀琀攀搀崀ऀ䐀䄀吀䔀吀䤀䴀䔀ऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 最攀琀搀愀琀攀⠀⤀Ⰰഀഀ
	Media			NVARCHAR(32)		NOT NULL,਍ऀ匀琀愀琀攀洀攀渀琀䬀椀渀搀ऀ一嘀䄀刀䌀䠀䄀刀⠀㌀㈀⤀ऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	StartDate		DATETIME			NOT NULL,਍ऀ䔀渀搀䐀愀琀攀ऀऀऀ䐀䄀吀䔀吀䤀䴀䔀ऀऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	UserName		NVARCHAR(32)		NOT NULL,਍ऀ嬀刀漀眀嘀攀爀猀椀漀渀崀ऀ刀漀眀嘀攀爀猀椀漀渀ഀഀ
); --Logs all generated statements਍ഀഀ
CREATE TABLE Seating.SeatingReservations (਍ऀ䤀搀ऀऀऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀伀圀䜀唀䤀䐀䌀伀䰀ऀ倀刀䤀䴀䄀刀夀 䬀䔀夀 䐀䔀䘀䄀唀䰀吀⠀渀攀眀椀搀⠀⤀⤀Ⰰഀഀ
	PledgeId		UNIQUEIDENTIFIER	NOT NULL	UNIQUE		REFERENCES Billing.Pledges(PledgeId) ON DELETE CASCADE,਍ऀ䴀攀渀猀匀攀愀琀猀ऀऀ䤀一吀䔀䜀䔀刀ऀऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 　Ⰰഀഀ
	WomensSeats		INTEGER				NOT NULL	DEFAULT 0,਍ऀ䈀漀礀猀匀攀愀琀猀ऀऀ䤀一吀䔀䜀䔀刀ऀऀऀऀ一伀吀 一唀䰀䰀ऀ䐀䔀䘀䄀唀䰀吀 　Ⰰഀഀ
	GirlsSeats		INTEGER				NOT NULL	DEFAULT 0,਍ऀ一漀琀攀猀ऀऀऀ一嘀䄀刀䌀䠀䄀刀⠀㔀㄀㈀⤀ऀऀ一伀吀 一唀䰀䰀Ⰰഀഀ
	[RowVersion]	RowVersion਍⤀㬀ഀഀ
਍ഀഀ
CREATE TABLE Data.Relatives (਍ऀ刀漀眀䤀搀ऀऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀伀圀䜀唀䤀䐀䌀伀䰀ऀ倀刀䤀䴀䄀刀夀 䬀䔀夀 䐀䔀䘀䄀唀䰀吀⠀渀攀眀椀搀⠀⤀⤀Ⰰഀഀ
	MemberId		UNIQUEIDENTIFIER	NOT NULL	REFERENCES Data.MasterDirectory(Id),਍ऀ刀攀氀愀琀椀瘀攀䤀搀ऀऀ唀一䤀儀唀䔀䤀䐀䔀一吀䤀䘀䤀䔀刀ऀ一伀吀 一唀䰀䰀ऀ刀䔀䘀䔀刀䔀一䌀䔀匀 䐀愀琀愀⸀䴀愀猀琀攀爀䐀椀爀攀挀琀漀爀礀⠀䤀搀⤀Ⰰഀഀ
	Relation		NVARCHAR(64)		NOT NULL,਍ऀ嬀刀漀眀嘀攀爀猀椀漀渀崀ऀ刀漀眀嘀攀爀猀椀漀渀ഀഀ
);