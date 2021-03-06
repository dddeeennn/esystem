USE [ex_system_test]
GO
/****** Object:  Table [dbo].[esAnswers]    Script Date: 10/11/2014 5:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[esAnswers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNodeQuestion] [int] NOT NULL,
	[data] [nvarchar](max) NOT NULL,
	[idNodeSubject] [int] NOT NULL,
 CONSTRAINT [PK_esAnswers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[esNodes]    Script Date: 10/11/2014 5:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[esNodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNode] [int] NOT NULL,
	[data] [nvarchar](max) NULL,
	[isLeaf] [bit] NOT NULL,
	[idParentNode] [int] NOT NULL,
	[isRemove] [bit] NOT NULL,
 CONSTRAINT [PK_esNodes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[esAnswers] ON 

INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (152, 263, N'Москва', 264)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (153, 264, N'Тихонов, Ковтун, Юран, Карпин', 265)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (154, 264, N'Вагнер Лав, Карвальо, Семак, Алдонин', 266)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (155, 264, N'Шунин, Березовский,Габулов, Воронин', 267)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (156, 264, N'Янбаев ,Павлюченко, Шишкин', 268)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (157, 263, N'Санкт-Петербург', 269)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (158, 269, N'Анюков, Аршавин, Кержаков', 270)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (159, 269, N'Милан Вьештица, Александр Панов', 271)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (160, 263, N'Ростов-на-Дону', 273)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (161, 273, N'да', 274)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (162, 273, N'нет', 275)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (163, 276, N'Да', 277)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (164, 277, N'Да', 278)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (165, 278, N'Да', 265)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (166, 278, N'Нет', 280)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (167, 277, N'Нет', 281)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (168, 281, N'Да', 282)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (169, 281, N'Нет', 283)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (170, 276, N'Нет', 284)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (171, 284, N'Да', 285)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (172, 284, N'Нет', 286)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (173, 289, N'да', 290)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (174, 290, N'Да', 291)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (175, 290, N'Нет', 292)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (176, 292, N'Да', 293)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (177, 292, N'Нет', 294)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (178, 289, N'Нет', 295)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (179, 295, N'Да', 296)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (180, 295, N'нет', 297)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (181, 297, N'Да', 298)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (182, 300, N'да', 301)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (183, 301, N'да', 302)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (184, 301, N'нет', 303)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (185, 300, N'нет', 263)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (186, 306, N'Да', 307)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (187, 307, N'Да', 308)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (188, 308, N'Да', 309)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (189, 308, N'нет', 310)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (190, 307, N'Нет', 311)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (191, 311, N'Да', 312)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (192, 312, N'Да', 313)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (193, 312, N'Нет', 314)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (194, 311, N'Нет', 315)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (195, 315, N'Да', 316)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (196, 315, N'Нет', 317)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (197, 317, N'Да', 318)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (198, 317, N'Нет', 319)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (199, 319, N'Да', 320)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (200, 320, N'Да', 321)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (201, 321, N'Да', 322)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (202, 321, N'Нет', 323)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (203, 320, N'Нет', 324)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (204, 319, N'Нет', 325)
INSERT [dbo].[esAnswers] ([id], [idNodeQuestion], [data], [idNodeSubject]) VALUES (205, 306, N'нет', 300)
SET IDENTITY_INSERT [dbo].[esAnswers] OFF
SET IDENTITY_INSERT [dbo].[esNodes] ON 

INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (1, 1, N'', 0, 0, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (263, 263, N'ФК расположен в...', 0, 1, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (264, 264, N'Там играет или когда-либо играл ...', 0, 263, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (265, 265, N'ФК Спартак Москва', 1, 264, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (266, 266, N'ФК ЦСКА Москва', 1, 264, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (267, 267, N'ФК Динамо Москва', 1, 264, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (268, 268, N'ФК Локомотив Москва', 1, 264, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (269, 269, N'Там играют или когда-либо играли...', 0, 263, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (270, 270, N'ФК Зенит', 1, 269, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (272, 271, N'Динамо Спб', 1, 269, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (273, 273, N'ФК играет в премьер лиге?', 0, 263, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (274, 274, N'ФК Ростов', 1, 273, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (275, 275, N'СКА Ростов-на-Дону', 1, 273, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (276, 276, N'Домашняя форма этого клуба красно-белого цвета ?', 0, 1, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (277, 277, N'Выездная форма данного клуба бело-красная?', 0, 276, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (278, 278, N'У данного клуба имеется дополнительный комплект черно-красного цвета?', 0, 277, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (280, 280, N'ФК Спартак Нальчик', 1, 278, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (281, 281, N'Выездная форма данного клуба зеленая?', 0, 277, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (282, 282, N'ФК Рубин Казань', 1, 281, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (283, 283, N'ФК СКА Энергия', 1, 281, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (284, 284, N'Выездная форма данного клуба голубая с белыми вставками ?', 0, 276, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (285, 285, N'ФК Динамо Киев', 1, 284, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (286, 286, N'ФК Волга Нижний Новгород', 1, 284, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (289, 289, N'Домашняя форма этого клуба желто-зеленая?', 0, 1, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (290, 290, N'Выездная форма этого клуба черного цвета?', 0, 289, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (291, 291, N'ФК Анжи Махачкала', 1, 290, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (292, 292, N'Этот клуб имеет прозвище "казаки", "жабы"?', 0, 290, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (293, 293, N'ФК Кубань Краснодар', 1, 292, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (294, 294, N'ФК Томь Томск', 1, 292, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (295, 295, N'Домашняя форма этого клуба зелено-белая?', 0, 289, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (296, 296, N'ФК Терек Грозный', 1, 295, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (297, 297, N'Этот клуб называют обычно "Самарцы" или "Волжане"?', 0, 295, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (298, 298, N'ФК Крылья Советов Самара', 1, 297, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (300, 300, N'Футбольный клуб из Урала России?', 0, 1, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (301, 301, N'Домашняя форма этого клуба красно-черная?', 0, 300, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (302, 302, N'ФК Амкар Пермь', 1, 301, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (303, 303, N'ФК Урал Екатеринбург', 1, 301, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (304, 263, N'ФК расположен в...', 0, 300, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (306, 306, N'Футбольный клуб из Украины?', 0, 1, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (307, 307, N'Футбольный клуб когда-либо участвовал в евро-кубках ?', 0, 306, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (308, 308, N'Клуб имеет прозвище "горняки" и имеет черно-оранжевую домашнюю форму?', 0, 307, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (309, 309, N'ФК Шахтер Донецк', 1, 308, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (310, 310, N'ФК Металлист Харьков', 1, 308, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (311, 311, N'Футбольный клуб из Киева?', 0, 307, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (312, 312, N'Клуб имеет прозвище "пивовары"?', 0, 311, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (313, 313, N'ФК Оболонь Киев', 1, 312, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (314, 314, N'ФК Арсенал Киев', 1, 312, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (315, 315, N'Футбольный клуб из Донецка?', 0, 311, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (316, 316, N'ФК Металлург Донецк', 1, 315, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (317, 317, N'Этот футбольный клуб из Александрии?', 0, 315, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (318, 318, N'ФК Александрия Александрия', 1, 317, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (319, 319, N'У этого клуба домашняя форма синего цвета?', 0, 317, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (320, 320, N'Выездная форма этого клуба белая?', 0, 319, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (321, 321, N'Этот клуб имеет прозвище "моряки", "чудо", "черно-синие"?', 0, 320, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (322, 322, N'ФК Черноморец Одесса', 1, 321, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (323, 323, N'ФК Днепр  Днепропетровск', 1, 321, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (324, 324, N'ООО ФК Севастополь', 1, 320, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (325, 325, N'ФК Карпаты Львов', 1, 319, 0)
INSERT [dbo].[esNodes] ([id], [idNode], [data], [isLeaf], [idParentNode], [isRemove]) VALUES (328, 328, N'ФК играет в премьер лиге?', 0, 1, 0)
SET IDENTITY_INSERT [dbo].[esNodes] OFF
ALTER TABLE [dbo].[esNodes] ADD  CONSTRAINT [DF_esNodes_isRemove_1]  DEFAULT ((0)) FOR [isRemove]
GO
