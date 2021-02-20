SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO [dbo].[Cars] ([CarId], [ColorId], [BrandId], [ModelYear], [Description], [DailyPrice]) VALUES (1, 1, 1, 2020, N'Manuel    ', CAST(500 AS Decimal(18, 0)))
INSERT INTO [dbo].[Cars] ([CarId], [ColorId], [BrandId], [ModelYear], [Description], [DailyPrice]) VALUES (2, 3, 3, 2015, N'Otomatik  ', CAST(600 AS Decimal(18, 0)))
INSERT INTO [dbo].[Cars] ([CarId], [ColorId], [BrandId], [ModelYear], [Description], [DailyPrice]) VALUES (3, 1, 2, 2018, N'Otomatik  ', CAST(450 AS Decimal(18, 0)))
INSERT INTO [dbo].[Cars] ([CarId], [ColorId], [BrandId], [ModelYear], [Description], [DailyPrice]) VALUES (4, 2, 3, 2019, N'Otomatik  ', CAST(500 AS Decimal(18, 0)))
INSERT INTO [dbo].[Cars] ([CarId], [ColorId], [BrandId], [ModelYear], [Description], [DailyPrice]) VALUES (5, 2, 3, 2015, N'Manuel  ', CAST(300 AS Decimal(18, 0)))

SET IDENTITY_INSERT [dbo].[Cars] OFF
