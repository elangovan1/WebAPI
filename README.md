1. you should add APIKey on header to access both APIs.

	Key : ApiKey
	Value : uu2ToG/dcsg3DI8CGlpLro1PyLhZNUWHpdPv8VmWFLBaxM0fvUZvkA==
2. I have added few test methods to cover basic functionality of each layer

3. I have used two sets of Enity to Map data 
	1. Table to EF Core mapping -  All entities which end with Model.
	2. I have used another set of entities to construct JSON result
4. I have created new table called Products, the scructure is like below

CREATE TABLE [dbo].[PRODUCTS](
	[PRODUCTID] [int] IDENTITY(1,1) NOT NULL,
	[PRODUCTNAME] [nvarchar](50) NULL,
	[PACKHEIGHT] [decimal](9, 2) NULL,
	[PACKWIDTH] [decimal](9, 2) NULL,
	[PACKWEIGHT] [decimal](8, 3) NULL,
	[COLOUR] [nvarchar](20) NULL,
	[SIZE] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PRODUCTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


5. There is room to improve the code coverage, but i do not have time.
6. I would like to user Navigation property inorder to load customer order and order details. As of now I have loaded individually.



