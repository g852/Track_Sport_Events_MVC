INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'aefe2385-568b-42e8-9ce6-c43949692314', N'admin@tracks.com', N'ADMIN@TRACKS.COM', N'admin@tracks.com', N'ADMIN@TRACKS.COM', 1, N'AQAAAAEAACcQAAAAEK8qXtIHEIkSOr5owXCrGZnTEVfgQGpzSm+0lsFQVcIvzZoWSrUIFicV9Rzpxe2uMA==', N'C3CPIU7BJK6D5OJ72UKRHR7R7WLDRAGC', N'52eb67b1-92d5-4001-8245-18495df7f31e', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Runner] ON
INSERT INTO [dbo].[Runner] ([Id], [Name], [GoldMedals]) VALUES (1, N'James Samson', 10)
INSERT INTO [dbo].[Runner] ([Id], [Name], [GoldMedals]) VALUES (2, N'Peter Simpson', 9)
INSERT INTO [dbo].[Runner] ([Id], [Name], [GoldMedals]) VALUES (3, N'John Davidson', 12)
SET IDENTITY_INSERT [dbo].[Runner] OFF
SET IDENTITY_INSERT [dbo].[TrackSportEvent] ON
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (1, N'100 metres -National ', 0)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (2, N'100 metres - Olympics', 1)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (3, N'200 metres -National', 0)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (4, N'200 metres -Olympics', 1)
SET IDENTITY_INSERT [dbo].[TrackSportEvent] OFF
SET IDENTITY_INSERT [dbo].[TimingRecord] ON
INSERT INTO [dbo].[TimingRecord] ([Id], [RunnerId], [TrackSportEventId], [RecordedTime], [Date]) VALUES (1, 1, 2, CAST(8.90 AS Decimal(18, 2)), N'2019-12-26 10:00:00')
INSERT INTO [dbo].[TimingRecord] ([Id], [RunnerId], [TrackSportEventId], [RecordedTime], [Date]) VALUES (2, 2, 1, CAST(9.20 AS Decimal(18, 2)), N'2019-12-24 09:00:00')
SET IDENTITY_INSERT [dbo].[TimingRecord] OFF
