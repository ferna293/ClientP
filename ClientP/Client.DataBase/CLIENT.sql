CREATE TABLE [dbo].[CLIENT](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[second_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[second_last_name] [varchar](50) NOT NULL,
	[address] [varchar](100) NOT NULL,
	CONSTRAINT [PK_CLIENT] PRIMARY KEY ([id_client]),
)
GO
