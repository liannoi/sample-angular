-- Copyright 2020 Maksym Liannoi
--
-- Licensed under the Apache License, Version 2.0 (the "License");
-- you may not use this file except in compliance with the License.
-- You may obtain a copy of the License at
--
--    http://www.apache.org/licenses/LICENSE-2.0
--
-- Unless required by applicable law or agreed to in writing, software
-- distributed under the License is distributed on an "AS IS" BASIS,
-- WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
-- See the License for the specific language governing permissions and
-- limitations under the License.
USE master;
GO
  IF (DB_ID('SampleAngular') IS NOT NULL) DROP DATABASE SampleAngular;
GO
  CREATE DATABASE SampleAngular;
GO
  USE SampleAngular;
GO
  IF (OBJECT_ID('dbo.Manufacturers', 'U') IS NOT NULL) DROP TABLE dbo.Manufacturers;
GO
  CREATE TABLE dbo.Manufacturers (
    ManufacturerId INT NOT NULL IDENTITY,
    Name NVARCHAR(64) NOT NULL,
    CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerId),
    CONSTRAINT CHK_Manufacturers CHECK (DATALENGTH(Name) >= 4),
    CONSTRAINT UNQ_Manufacturers UNIQUE (Name)
  );
GO
  IF (OBJECT_ID('dbo.Products', 'U') IS NOT NULL) DROP TABLE dbo.Products;
GO
  CREATE TABLE dbo.Products (
    ProductId INT NOT NULL IDENTITY,
    ManufacturerId INT NOT NULL,
    Name NVARCHAR(32) NOT NULL,
    ProductNumber VARCHAR(15) NOT NULL,
    CONSTRAINT PK_Products PRIMARY KEY (ProductId),
    CONSTRAINT FK_Products FOREIGN KEY (ManufacturerId) REFERENCES dbo.Manufacturers (ManufacturerId),
    CONSTRAINT CHK_Products_Name CHECK (DATALENGTH(Name) >= 4),
    CONSTRAINT CHK_Products_ProductNumber CHECK (DATALENGTH(ProductNumber) >= 4),
    CONSTRAINT UNQ_Products_Name UNIQUE (Name),
    CONSTRAINT UNQ_Products_ProductNumber UNIQUE (ProductNumber)
  );
GO
  IF (OBJECT_ID('dbo.ProductPhotos', 'U') IS NOT NULL) DROP TABLE dbo.ProductPhotos;
GO
  CREATE TABLE dbo.ProductPhotos (
    PhotoId INT NOT NULL IDENTITY,
    ProductId INT NOT NULL,
    Path NVARCHAR(256) NOT NULL,
    CONSTRAINT PK_Photos PRIMARY KEY (PhotoId, ProductId),
    CONSTRAINT FK_Photos_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products (ProductId),
    CONSTRAINT CHK_Photos_Path CHECK (DATALENGTH(Path) >= 4)
  );
GO
  -- Adding tuples to relationships
SET
  IDENTITY_INSERT dbo.Manufacturers ON;
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (1, 'Wikizz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (2, 'Devcast');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (3, 'Zoombeat');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (4, 'Vitz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (5, 'Dabjam');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (6, 'Jabberbean');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (7, 'Kwilith');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (8, 'Twimbo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (9, 'Yakitri');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (10, 'Zazio');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (11, 'Omba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (12, 'Zoomcast');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (13, 'Oloo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (14, 'Kwinu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (15, 'Youfeed');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (16, 'Twitterwire');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (17, 'Trudoo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (18, 'Wikivu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (20, 'Oba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (21, 'Twimm');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (22, 'Jabbercube');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (23, 'Jetwire');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (24, 'Teklist');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (25, 'Tagfeed');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (27, 'Innotype');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (28, 'DabZ');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (29, 'Twiyo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (30, 'Voonix');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (31, 'Edgewire');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (32, 'Thoughtstorm');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (33, 'Dabvine');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (34, 'Rhynoodle');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (35, 'Pixonyx');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (36, 'Quimm');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (37, 'Zoovu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (38, 'Tavu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (39, 'Wikibox');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (40, 'Meezzy');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (41, 'Oozz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (42, 'Photobug');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (43, 'Oyoyo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (44, 'Vinte');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (46, 'Aimbu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (47, 'Trunyx');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (48, 'Bubbletube');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (49, 'Twitterworks');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (50, 'Voomm');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (51, 'Skippad');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (52, 'Skyvu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (53, 'Tagchat');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (54, 'Skipstorm');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (56, 'Skimia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (57, 'Skibox');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (59, 'Kwimbee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (60, 'Jabbersphere');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (61, 'Ainyx');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (62, 'Browsecat');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (63, 'Skyba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (64, 'Roombo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (65, 'Blogtag');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (66, 'Feedmix');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (67, 'Demimbu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (68, 'Gigashots');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (69, 'Yotz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (70, 'Divanoodle');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (71, 'Zoomzone');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (72, 'Skiba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (73, 'Babbleopia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (74, 'Babbleset');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (75, 'Demivee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (76, 'Yata');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (77, 'Topicshots');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (78, 'Tazzy');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (79, 'Layo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (80, 'Meedoo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (81, 'Kanoodle');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (82, 'Npath');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (83, 'Tekfly');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (84, 'Wordpedia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (86, 'Quatz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (87, 'Zava');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (88, 'Shuffletag');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (89, 'Trupe');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (90, 'Jayo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (91, 'Muxo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (92, 'Meevee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (93, 'Yamia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (94, 'Abata');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (95, 'Fanoodle');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (98, 'Agivu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (100, 'Vidoo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (101, 'Flashset');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (102, 'Oyoba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (103, 'Blogpad');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (104, 'Skinix');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (105, 'Pixope');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (106, 'Skyble');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (107, 'Skalith');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (108, 'Miboo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (109, 'Edgeify');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (110, 'Photolist');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (111, 'Eare');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (112, 'Bubblebox');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (113, 'Flashspan');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (117, 'Topdrive');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (118, 'Thoughtworks');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (119, 'Vinder');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (120, 'Edgeblab');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (121, 'Yodoo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (123, 'Digitube');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (124, 'Rooxo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (125, 'Tambee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (126, 'Plajo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (127, 'Blognation');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (128, 'Skaboo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (131, 'Buzzdog');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (132, 'Riffpedia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (133, 'Zooveo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (134, 'Skynoodle');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (135, 'Tagcat');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (137, 'Devbug');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (138, 'Blogtags');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (139, 'Skiptube');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (140, 'Eimbee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (141, 'Kayveo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (142, 'Realcube');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (144, 'Browsedrive');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (145, 'Browseblab');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (147, 'Flipopia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (148, 'Fatz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (152, 'Fivebridge');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (154, 'Fliptune');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (156, 'Ooba');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (159, 'Leenti');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (160, 'Twitternation');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (163, 'Yambee');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (164, 'Ailane');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (165, 'Latz');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (168, 'Rhybox');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (171, 'Dablist');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (173, 'Trilia');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (174, 'Eazzy');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (177, 'Kazu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (178, 'JumpXS');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (183, 'Feedbug');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (184, 'Oyope');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (187, 'Realpoint');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (188, 'Skajo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (189, 'Kaymbo');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (192, 'Brightbean');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (193, 'Youspan');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (194, 'Oyondu');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (197, 'Innojam');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (198, 'Fiveclub');
insert into
  dbo.Manufacturers (ManufacturerId, Name)
values
  (199, 'Buzzster');
SET
  IDENTITY_INSERT dbo.Manufacturers OFF;
SET
  IDENTITY_INSERT dbo.Products ON;
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (1, 117, 'Butte Desertparsley', '35804-2669076');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (2, 119, 'Bonpland Willow', '01738-6576156');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (4, 109, 'Pachycereus', '67667-8705299');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    5,
    110,
    'Spotted Lady''s Slipper',
    '42120-1423286'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (6, 79, 'Seacliff Beggarticks', '19856-9449156');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (7, 46, 'Oxeye', '97897-8566896');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    9,
    62,
    'Jost Van Dyke''s Indian Mallow',
    '00708-2877572'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (10, 6, 'Curved Woodrush', '57152-9905307');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    12,
    30,
    'Santa Catalina Prairie Clover',
    '29250-0901867'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (13, 109, 'Cola', '44014-4826644');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    14,
    112,
    'Cuthbert''s Turtlehead',
    '39209-7594936'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    15,
    125,
    'Naked Rhizomnium Moss',
    '72618-9974137'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (17, 14, 'Virginia Wakerobin', '06718-3731667');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (18, 106, 'Chihuahuan Stickseed', '25506-1879476');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (19, 87, 'Mexican Avocado', '87732-8786986');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    20,
    119,
    'Matting Rosette Grass',
    '85323-3520125'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (22, 39, 'Parry''s Sedge', '95018-3849783');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (23, 63, 'Dropseed Rockcress', '25436-2929376');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (24, 147, 'Ohelo ''ai', '45560-1257601');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (25, 140, 'Beach Pea', '11881-0655012');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (26, 66, 'Umbrella Thorn', '32229-5425290');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (27, 50, 'Tapertip Cupgrass', '98078-3379779');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (29, 31, 'Common Box', '54274-6710376');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (30, 47, 'Branching Phacelia', '13094-0917189');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (31, 100, 'Yellowcress', '33396-1889106');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    32,
    147,
    'Haleakala Tetramolopium',
    '89735-3718156'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (33, 12, 'Limestone Bugheal', '26420-8350120');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    35,
    73,
    'Richardson''s Pondweed',
    '79108-3184983'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (36, 38, 'Leathery Pore Lichen', '42114-8995777');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (37, 132, 'Rabbit-tobacco', '59579-4535430');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (38, 3, 'Wild Cinnamon', '57960-6216947');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (39, 66, '''uiwi', '34251-5750206');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (40, 3, 'Mountain Deathcamas', '78499-8241853');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (41, 94, 'Dot Lichen', '46000-6996880');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (43, 47, 'Cows Clover', '88224-6941205');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    44,
    94,
    'Goodrich Eared Rockcress',
    '05559-9634763'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (46, 5, 'Distant Sedge', '80458-6696763');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (48, 78, 'Violet Milkwort', '02848-8106679');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (50, 105, 'Bailey''s Greasewood', '97306-2197473');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    51,
    126,
    'Gooseneck Yellow Loosestrife',
    '21941-7514502'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (52, 6, 'Utah Sweetvetch', '74069-9610020');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    54,
    31,
    'Largeflower Hawksbeard',
    '96522-4385123'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (55, 38, 'Bald Brome', '41518-1802342');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (56, 126, 'Soapweed Yucca', '16511-6685970');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (58, 77, 'Clubmoss', '83273-9489275');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (59, 33, 'Beardgrass', '61878-3371068');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    60,
    126,
    'Climbing Alsinidendron',
    '03299-4247947'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (61, 12, 'Soft Brome', '81966-1274834');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (62, 46, 'Short''s Hedgehyssop', '14103-6441991');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (63, 56, 'Schoepfia', '52777-8073675');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (65, 47, 'Hybrid Willow', '01088-4659402');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (66, 127, 'Sedge', '25677-3837681');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (67, 138, 'Foxtail Pricklegrass', '18227-8663336');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (68, 83, 'Eastern Beebalm', '09998-1965796');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (69, 148, 'Sphagnum', '18973-8714795');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (70, 74, 'Wavyleaf Thistle', '73361-7615864');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (72, 141, 'Vervain', '43957-5324519');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (73, 23, 'Pandanus', '15200-2914785');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    74,
    93,
    'Hinckley''s Golden Columbine',
    '32922-5993365'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    76,
    65,
    'Douglas'' Golden Violet',
    '02848-8542642'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (77, 43, 'Ciliate Hedwigia Moss', '24130-1139476');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (78, 108, 'Spotted Beebalm', '08653-9870872');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (79, 102, 'California Jointfir', '82117-7781895');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (80, 30, 'Green Fiddleneck', '93365-2078213');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (81, 38, 'Fragile Oat', '38144-7380264');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (82, 105, 'Sideoats Grama', '91339-4747908');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (83, 35, 'Iris', '24514-3627855');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    84,
    134,
    'Monte Cerrote Water-willow',
    '83026-3465556'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (85, 126, 'Swiss Stone Pine', '56759-7317520');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    87,
    10,
    'Correll''s False Dragonhead',
    '83217-0052149'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (88, 57, 'Rumohra', '94970-4827560');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (89, 52, 'Eastern Yampah', '26753-1264959');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (90, 3, 'Yellow Pond-lily', '94483-3496735');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (91, 147, 'Rock Buttercup', '09133-5031515');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (93, 20, 'Whitemargin Knotweed', '06839-2614815');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (94, 100, 'Santa Fe Phlox', '12072-2540091');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (95, 107, 'Lyall''s Rockcress', '87144-3817638');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (96, 133, 'Meadow Bistort', '65811-1845618');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (97, 121, 'Chinquapin', '29366-2926972');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (98, 117, 'Matted Lupine', '01296-3329634');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (99, 91, 'Texas Salt', '45162-8315075');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (100, 37, 'Hopsage', '41601-1356553');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (101, 107, 'Prairie Parsley', '90904-2194390');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    102,
    92,
    'Cliff Desertdandelion',
    '83084-6365071'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (104, 76, 'Desert Honeysuckle', '81364-2239506');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (106, 20, 'Geheebia Moss', '25319-6144495');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (107, 3, 'Compassplant', '48296-2245956');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (109, 10, 'Broadleaf Lupine', '50753-6203515');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (110, 102, 'Virginia Wildrye', '67087-2253058');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (111, 4, 'Wedgeleaf Fleabane', '63980-4202094');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (112, 123, 'Corrigiola', '26585-3273704');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    113,
    43,
    'Savicz''s Snow Lichen',
    '62181-2514462'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (114, 20, 'Myrionora', '06075-2858422');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (115, 77, 'Wright''s Spiderwort', '48525-2680861');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (116, 105, 'Curlyleaf Muhly', '07248-3893263');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (117, 120, 'Brilliant Campion', '74385-1205909');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (118, 135, 'Swamp Carex', '90180-2591617');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    119,
    142,
    'Bristlystalked Sedge',
    '80314-9664811'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    121,
    119,
    'Balbis'' Maiden Fern',
    '51975-3794057'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    122,
    46,
    'Brandegee''s Milkvetch',
    '00267-2248653'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (123, 63, 'Florida Greeneyes', '35811-6434447');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    125,
    42,
    'Peruvian Cartilage Lichen',
    '20546-9053241'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    126,
    13,
    'Babington''s Roccella Lichen',
    '62852-7000935'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (127, 30, 'Bloodleaf', '01387-9870708');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (129, 148, 'Aztec Gilia', '44024-8721194');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (131, 10, 'Inyo Buckwheat', '61138-8398676');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (132, 91, 'Japanese Sedge', '09020-1557436');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (133, 31, 'Large Toothwort', '61330-0186610');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    134,
    105,
    'Blueleaf Honeysuckle',
    '29683-9938519'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    135,
    100,
    'Peirson''s Milkvetch',
    '89090-8180478'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (136, 7, 'Poet''s Narcissus', '74127-8203852');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (137, 89, 'Indian Tobacco', '13532-6971206');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (139, 83, 'Piedmont Staggerbush', '88222-0395314');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (140, 123, 'Giant Taro', '16682-6954951');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (142, 18, 'Ridged Goosefoot', '38832-7275276');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (143, 27, 'Caryopteris', '89930-7247738');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (144, 51, 'Haematoxylum', '29652-8659159');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (146, 145, 'Waxydogbane', '43978-0646363');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (147, 145, 'Rinodina Lichen', '56947-7005572');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (148, 1, 'Mound Phlox', '39568-5956365');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (150, 4, 'Menzies'' Wallflower', '80911-2117158');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    151,
    75,
    'Compact Prairie Clover',
    '90128-4373905'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (152, 59, 'Sweet Iris', '55889-0806283');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (153, 148, 'Pampas Grass', '53065-0647143');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (154, 102, 'Mudplantain', '95766-9232094');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    155,
    128,
    'Alaska Blue-eyed Grass',
    '70095-6111269'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (157, 71, 'Eucalyptus', '41915-5421037');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (159, 76, 'Silver Lupine', '64609-3214624');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (162, 7, 'Noddingcaps', '43373-6933942');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    163,
    46,
    'Tufted Townsend Daisy',
    '20780-8890005'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (165, 80, 'Whitesnow', '45875-4901408');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (166, 84, 'Ballhead Waterleaf', '80468-3934111');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (167, 42, 'Longtom Filmy Fern', '02298-9249791');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (168, 32, 'Gordonia', '66740-6234280');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (169, 112, 'Redskin Onion', '52960-4244257');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (170, 24, 'Dwarf Coastweed', '34258-8046693');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    171,
    111,
    'Hairy Umbrella-sedge',
    '05932-3652416'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (172, 95, 'Disc Lichen', '23678-0511198');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (173, 113, 'Pride Of Ohio', '90740-6950001');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (174, 89, 'Western Astomum Moss', '22367-6983613');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (175, 72, 'Pumice Alpinegold', '17023-1731641');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    176,
    121,
    'Black Hills Meadow-rue',
    '43109-4921755'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    177,
    15,
    'Mediterranean Hairgrass',
    '83869-9278890'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (178, 91, 'Queen Palm', '52167-1385797');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (179, 95, 'Swiss Kidney Lichen', '57062-7609460');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    180,
    51,
    'Olivegreen Calcareous Moss',
    '37482-1028463'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    181,
    104,
    'Kern County Larkspur',
    '94472-3852690'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (182, 64, 'Globe Artichoke', '22053-2875440');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (183, 57, 'Swollen Duckweed', '33916-5204123');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    184,
    4,
    'Variableleaf Evening Primrose',
    '06158-1539162'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (185, 51, 'Dendroalsia Moss', '45286-8007711');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (186, 47, 'Texas Star', '08063-6860578');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    187,
    4,
    'Argentinian Biddy-biddy',
    '53723-1183173'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (188, 40, 'Silvery Sedge', '00261-3924568');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    189,
    34,
    'Oblongleaf Basindaisy',
    '88397-7140688'
  );
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (190, 60, 'Felt Lichen', '16543-7206520');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (191, 47, 'Gray-woolly Twintip', '81691-8197973');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (193, 50, 'Florist''s Daisy', '36154-3124991');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (194, 145, 'Venus Flytrap', '91805-0906717');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (196, 125, 'Slender Spikerush', '48109-6216823');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (197, 29, 'Mountain-ash', '79651-0840627');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (198, 73, 'Yellow Fumewort', '41134-8561986');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (199, 52, 'Harvey''s Buttercup', '83544-3320638');
insert into
  dbo.Products (ProductId, ManufacturerId, Name, ProductNumber)
values
  (
    200,
    86,
    'Linearleaf Primrose-willow',
    '68369-2704353'
  );
SET
  IDENTITY_INSERT dbo.Products OFF;
SET
  IDENTITY_INSERT dbo.ProductPhotos ON;
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    1,
    123,
    'http://dummyimage.com/1635x746.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    2,
    136,
    'http://dummyimage.com/1385x867.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    3,
    152,
    'http://dummyimage.com/1371x940.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    4,
    119,
    'http://dummyimage.com/1668x816.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    6,
    10,
    'http://dummyimage.com/1290x1064.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    7,
    44,
    'http://dummyimage.com/1695x789.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    8,
    13,
    'http://dummyimage.com/1733x1029.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    9,
    62,
    'http://dummyimage.com/1529x867.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    11,
    146,
    'http://dummyimage.com/1371x867.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    12,
    46,
    'http://dummyimage.com/1893x991.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    13,
    61,
    'http://dummyimage.com/1292x753.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    14,
    96,
    'http://dummyimage.com/1337x942.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    16,
    72,
    'http://dummyimage.com/1545x811.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    17,
    44,
    'http://dummyimage.com/1711x1034.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    18,
    143,
    'http://dummyimage.com/1306x857.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    21,
    134,
    'http://dummyimage.com/1774x1008.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    22,
    159,
    'http://dummyimage.com/1467x1035.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    23,
    146,
    'http://dummyimage.com/1374x985.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    24,
    84,
    'http://dummyimage.com/1749x856.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    25,
    25,
    'http://dummyimage.com/1902x1023.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    26,
    87,
    'http://dummyimage.com/1370x1001.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    28,
    65,
    'http://dummyimage.com/1858x917.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    29,
    1,
    'http://dummyimage.com/1566x953.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    30,
    121,
    'http://dummyimage.com/1673x949.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    32,
    58,
    'http://dummyimage.com/1889x776.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    33,
    98,
    'http://dummyimage.com/1590x861.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    34,
    59,
    'http://dummyimage.com/1759x1039.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    35,
    46,
    'http://dummyimage.com/1846x956.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    36,
    143,
    'http://dummyimage.com/1820x955.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    37,
    106,
    'http://dummyimage.com/1627x1059.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    38,
    150,
    'http://dummyimage.com/1437x802.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    39,
    111,
    'http://dummyimage.com/1434x752.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    40,
    4,
    'http://dummyimage.com/1405x968.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    42,
    112,
    'http://dummyimage.com/1715x945.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    44,
    55,
    'http://dummyimage.com/1813x1011.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    45,
    65,
    'http://dummyimage.com/1503x1076.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    46,
    154,
    'http://dummyimage.com/1857x957.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    47,
    85,
    'http://dummyimage.com/1596x1056.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    48,
    44,
    'http://dummyimage.com/1289x802.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    49,
    59,
    'http://dummyimage.com/1894x822.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    50,
    136,
    'http://dummyimage.com/1877x995.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    51,
    88,
    'http://dummyimage.com/1701x960.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    52,
    131,
    'http://dummyimage.com/1297x1033.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    53,
    73,
    'http://dummyimage.com/1806x991.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    55,
    96,
    'http://dummyimage.com/1817x962.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    56,
    20,
    'http://dummyimage.com/1862x814.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    58,
    133,
    'http://dummyimage.com/1464x1080.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    59,
    91,
    'http://dummyimage.com/1368x896.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    60,
    82,
    'http://dummyimage.com/1748x941.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    61,
    126,
    'http://dummyimage.com/1777x818.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    62,
    63,
    'http://dummyimage.com/1446x922.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    64,
    7,
    'http://dummyimage.com/1836x902.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    66,
    70,
    'http://dummyimage.com/1455x1004.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    67,
    2,
    'http://dummyimage.com/1499x974.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    69,
    18,
    'http://dummyimage.com/1452x927.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    72,
    126,
    'http://dummyimage.com/1866x828.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    73,
    109,
    'http://dummyimage.com/1749x978.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    74,
    94,
    'http://dummyimage.com/1728x784.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    75,
    97,
    'http://dummyimage.com/1401x832.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    76,
    91,
    'http://dummyimage.com/1292x1000.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    78,
    85,
    'http://dummyimage.com/1502x978.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    79,
    40,
    'http://dummyimage.com/1416x1014.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    80,
    12,
    'http://dummyimage.com/1896x986.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    81,
    135,
    'http://dummyimage.com/1376x966.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    82,
    88,
    'http://dummyimage.com/1428x1033.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    83,
    113,
    'http://dummyimage.com/1468x750.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    84,
    115,
    'http://dummyimage.com/1606x978.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    86,
    79,
    'http://dummyimage.com/1653x933.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    87,
    121,
    'http://dummyimage.com/1288x720.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    89,
    67,
    'http://dummyimage.com/1580x880.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    90,
    102,
    'http://dummyimage.com/1389x958.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    91,
    33,
    'http://dummyimage.com/1282x881.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    93,
    155,
    'http://dummyimage.com/1870x732.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    94,
    41,
    'http://dummyimage.com/1591x900.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    95,
    91,
    'http://dummyimage.com/1804x771.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    96,
    5,
    'http://dummyimage.com/1480x937.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    97,
    157,
    'http://dummyimage.com/1760x845.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    99,
    67,
    'http://dummyimage.com/1758x1021.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    101,
    35,
    'http://dummyimage.com/1916x999.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    102,
    85,
    'http://dummyimage.com/1486x984.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    104,
    1,
    'http://dummyimage.com/1795x772.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    105,
    109,
    'http://dummyimage.com/1369x1023.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    106,
    27,
    'http://dummyimage.com/1845x1059.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    107,
    146,
    'http://dummyimage.com/1611x773.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    108,
    143,
    'http://dummyimage.com/1625x1044.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    109,
    123,
    'http://dummyimage.com/1631x1015.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    110,
    81,
    'http://dummyimage.com/1444x997.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    112,
    30,
    'http://dummyimage.com/1770x928.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    113,
    7,
    'http://dummyimage.com/1760x894.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    114,
    9,
    'http://dummyimage.com/1754x764.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    115,
    144,
    'http://dummyimage.com/1392x1031.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    116,
    122,
    'http://dummyimage.com/1311x948.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    117,
    96,
    'http://dummyimage.com/1884x800.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    118,
    144,
    'http://dummyimage.com/1550x1077.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    119,
    76,
    'http://dummyimage.com/1737x854.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    120,
    113,
    'http://dummyimage.com/1710x1000.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    121,
    155,
    'http://dummyimage.com/1564x867.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    123,
    132,
    'http://dummyimage.com/1338x742.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    124,
    143,
    'http://dummyimage.com/1357x730.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    125,
    52,
    'http://dummyimage.com/1426x1042.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    126,
    101,
    'http://dummyimage.com/1562x792.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    130,
    18,
    'http://dummyimage.com/1915x916.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    131,
    10,
    'http://dummyimage.com/1634x983.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    132,
    94,
    'http://dummyimage.com/1356x861.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    133,
    38,
    'http://dummyimage.com/1851x815.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    135,
    142,
    'http://dummyimage.com/1703x984.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    136,
    74,
    'http://dummyimage.com/1751x879.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    137,
    63,
    'http://dummyimage.com/1826x1000.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    138,
    85,
    'http://dummyimage.com/1794x896.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    139,
    29,
    'http://dummyimage.com/1814x1060.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    140,
    150,
    'http://dummyimage.com/1790x727.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    141,
    152,
    'http://dummyimage.com/1784x814.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    142,
    9,
    'http://dummyimage.com/1676x841.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    143,
    26,
    'http://dummyimage.com/1714x907.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    144,
    121,
    'http://dummyimage.com/1356x866.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    145,
    12,
    'http://dummyimage.com/1544x861.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    147,
    152,
    'http://dummyimage.com/1699x980.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    148,
    79,
    'http://dummyimage.com/1793x997.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    151,
    60,
    'http://dummyimage.com/1548x1028.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    152,
    84,
    'http://dummyimage.com/1888x1078.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    153,
    107,
    'http://dummyimage.com/1731x993.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    154,
    54,
    'http://dummyimage.com/1700x924.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    156,
    66,
    'http://dummyimage.com/1459x810.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    157,
    150,
    'http://dummyimage.com/1491x1031.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    158,
    40,
    'http://dummyimage.com/1650x808.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    159,
    13,
    'http://dummyimage.com/1591x841.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    160,
    99,
    'http://dummyimage.com/1456x1032.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    161,
    80,
    'http://dummyimage.com/1489x935.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    162,
    144,
    'http://dummyimage.com/1333x824.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    163,
    69,
    'http://dummyimage.com/1365x898.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    164,
    147,
    'http://dummyimage.com/1557x1012.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    165,
    82,
    'http://dummyimage.com/1298x940.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    166,
    131,
    'http://dummyimage.com/1753x883.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    167,
    111,
    'http://dummyimage.com/1712x981.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    168,
    62,
    'http://dummyimage.com/1735x988.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    169,
    110,
    'http://dummyimage.com/1369x929.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    170,
    54,
    'http://dummyimage.com/1622x994.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    171,
    93,
    'http://dummyimage.com/1450x981.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    172,
    30,
    'http://dummyimage.com/1352x960.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    173,
    79,
    'http://dummyimage.com/1467x849.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    176,
    88,
    'http://dummyimage.com/1430x790.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    177,
    89,
    'http://dummyimage.com/1500x799.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    178,
    68,
    'http://dummyimage.com/1630x791.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    179,
    109,
    'http://dummyimage.com/1602x889.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    180,
    101,
    'http://dummyimage.com/1416x1064.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    182,
    26,
    'http://dummyimage.com/1819x1011.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    183,
    98,
    'http://dummyimage.com/1732x823.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    185,
    107,
    'http://dummyimage.com/1909x1008.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    186,
    118,
    'http://dummyimage.com/1461x852.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    187,
    83,
    'http://dummyimage.com/1482x809.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    188,
    17,
    'http://dummyimage.com/1457x801.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    189,
    150,
    'http://dummyimage.com/1645x1045.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    190,
    119,
    'http://dummyimage.com/1451x892.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    191,
    40,
    'http://dummyimage.com/1416x828.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    192,
    89,
    'http://dummyimage.com/1589x762.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    193,
    159,
    'http://dummyimage.com/1450x795.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    194,
    98,
    'http://dummyimage.com/1395x883.png/5fa2dd/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    195,
    35,
    'http://dummyimage.com/1655x1068.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    196,
    155,
    'http://dummyimage.com/1528x993.png/ff4444/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    197,
    104,
    'http://dummyimage.com/1489x793.png/cc0000/ffffff'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    198,
    126,
    'http://dummyimage.com/1479x753.png/dddddd/000000'
  );
insert into
  dbo.ProductPhotos (PhotoId, ProductId, Path)
values
  (
    199,
    93,
    'http://dummyimage.com/1915x947.png/cc0000/ffffff'
  );
SET
  IDENTITY_INSERT dbo.ProductPhotos OFF;
