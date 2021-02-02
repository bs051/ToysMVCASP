 SET IDENTITY_INSERT [dbo].[Category] ON
INSERT INTO [dbo].[Category] ([CategoryId], [Brand], [ForGender]) VALUES (1, N'Lego', 0)
INSERT INTO [dbo].[Category] ([CategoryId], [Brand], [ForGender]) VALUES (2, N'FISHER', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF

SET IDENTITY_INSERT [dbo].[ToyStore] ON
INSERT INTO [dbo].[ToyStore] ([ToyStoreId], [StoreNAme], [City], [Phone], [OpeningTime], [ClosingTime]) VALUES (1, N'AJ Store', N'New York', N'555-54789551', N'2021-02-01 09:00:00', N'2021-02-01 10:00:00')
INSERT INTO [dbo].[ToyStore] ([ToyStoreId], [StoreNAme], [City], [Phone], [OpeningTime], [ClosingTime]) VALUES (2, N'DJ STORE', N'CALIFORNIA', N'6666-544124', N'2021-02-01 08:00:00', N'2021-02-01 09:00:00')
INSERT INTO [dbo].[ToyStore] ([ToyStoreId], [StoreNAme], [City], [Phone], [OpeningTime], [ClosingTime]) VALUES (3, N'M&D', N'CALIFORNIA', N'0221364953', N'2021-02-01 10:00:00', N'2021-02-01 11:00:00')
SET IDENTITY_INSERT [dbo].[ToyStore] OFF


SET IDENTITY_INSERT [dbo].[ToyRel] ON
INSERT INTO [dbo].[ToyRel] ([ToyRelId], [InStock], [AvailableQuantity], [ToyId], [ToyStoreId]) VALUES (1, 1, 5, 1, 1)
INSERT INTO [dbo].[ToyRel] ([ToyRelId], [InStock], [AvailableQuantity], [ToyId], [ToyStoreId]) VALUES (2, 1, 6, 2, 1)
INSERT INTO [dbo].[ToyRel] ([ToyRelId], [InStock], [AvailableQuantity], [ToyId], [ToyStoreId]) VALUES (3, 1, 8, 3, 2)
SET IDENTITY_INSERT [dbo].[ToyRel] OFF


 SET IDENTITY_INSERT [dbo].[Toy] ON
INSERT INTO [dbo].[Toy] ([ToyId], [ToyName], [Price], [AgeGroup], [ToyRating], [CategoryID]) VALUES (1, N'Airsoft Pistol', 250, 14, 8, 1)
INSERT INTO [dbo].[Toy] ([ToyId], [ToyName], [Price], [AgeGroup], [ToyRating], [CategoryID]) VALUES (2, N'Remote CAR', 500, 12, 8, 1)
INSERT INTO [dbo].[Toy] ([ToyId], [ToyName], [Price], [AgeGroup], [ToyRating], [CategoryID]) VALUES (3, N'SPEAKING DOLL', 300, 12, 8, 2)
SET IDENTITY_INSERT [dbo].[Toy] OFF


