SET IDENTITY_INSERT [dbo].[TimingRecord] ON
INSERT INTO [dbo].[TimingRecord] ([Id], [RunnerId], [TrackSportEventId], [RecordedTime], [Date]) VALUES (1, 1, 2, CAST(8.90 AS Decimal(18, 2)), N'2019-12-26 10:00:00')
INSERT INTO [dbo].[TimingRecord] ([Id], [RunnerId], [TrackSportEventId], [RecordedTime], [Date]) VALUES (2, 2, 1, CAST(9.20 AS Decimal(18, 2)), N'2019-12-24 09:00:00')
SET IDENTITY_INSERT [dbo].[TimingRecord] OFF
