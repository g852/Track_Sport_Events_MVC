SET IDENTITY_INSERT [dbo].[TrackSportEvent] ON
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (1, N'100 metres -National ', 0)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (2, N'100 metres - Olympics', 1)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (3, N'200 metres -National', 0)
INSERT INTO [dbo].[TrackSportEvent] ([Id], [EventName], [Type]) VALUES (4, N'200 metres -Olympics', 1)
SET IDENTITY_INSERT [dbo].[TrackSportEvent] OFF
