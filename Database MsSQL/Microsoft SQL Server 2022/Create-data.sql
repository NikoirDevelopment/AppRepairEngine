USE [OdbRepairEngine];

INSERT INTO [Role](Title) VALUES
	('��������')
	, ('������')
	, ('��������')
	, ('��������')

INSERT INTO [User]([Surname], [Name], [MiddleName], [Phone]) VALUES
	('������', '������', '�������', '89210563128')
	, ('�������', '������', '�������', '89535078985')
	, ('��������', '������', '����������', '89210673849')
	, ('������', '���������', '���������', '89990563748')
	, ('��������', '������', '���������', '89994563847')
	, ('��������', '������', '��������', '89994563847')
	, ('��������', '������', '��������', '89994563841')
	, ('�������', '�����', '����������', '89994563842')
	, ('�����', '������', '��������', '89994563843')
	, ('������', '����', '����������', '89994563844')

INSERT INTO [Client]([UserID], [Login], [Password], [RoleID]) VALUES
    (7, 'login2', 'pass2', 4)
	, (8, 'login3', 'pass3', 4)
	, (9, 'login4', 'pass4', 4)

INSERT INTO [Employee]([UserID], [Login], [Password], [RoleID]) VALUES
	(1, 'kasoo', 'root', 1)
	, (2, 'murashov123', 'qwerty', 2)
	, (3, 'test1', 'test1', 2)
	, (4, 'perinaAD', '250519', 3)
	, (5, 'krutiha1234567', '1234567890', 1)
	, (6, 'login1', 'pass1', 2)
	, (10, 'login5', 'pass5', 2)

INSERT INTO [HomeTech]([Type]) VALUES
	('���')
	, ('������')
	, ('�����������')
	, ('���������� ������')
	, ('�����������')

INSERT INTO [TechFactory]([Title]) VALUES
	('�������')
	, ('Redmond')
	, ('Indesit')
	, ('DEXP')

INSERT INTO [ModelTechFactory]([TechFactoryID], [Title]) VALUES
	(1, 'TA112')
	, (2, 'RT-437')
	, (3, 'DS 316 W')
	, (4, 'WM-F610NTMA/WW')
	, (2, 'RMC-M95')
	, (1, 'TA113')
	, (3, 'DS 314 W')

INSERT INTO [TechColor]([Color]) VALUES
	('�����')
	, ('׸����')
	, ('�����')

INSERT INTO [RequestStatus]([Status]) VALUES
	('����� ������')
	, ('� �������� �������')
	, ('�������� ���������')
	, ('����� � ������')

INSERT INTO [Request]([StartDate], [HomeTechID], [TechFactoryID], [ModelTechFactoryID], [TechColorID], [ProblemeDescryption], [RequestStatusID], [CompletionDate], [RepairParts], [MasterID], [ClientID]) VALUES
	('2023-06-06', 1, 1, 1, 1, '�������� ��������', 2, '', '', 2, 1)
	, ('2023-05-05', 2, 2, 2, 2, '�������� ��������', 2, '', '', 3, 1)
	, ('2023-07-07', 3, 3, 3, 1, '�� ������� ���� �� ����� ������������', 3, '2023-01-01', '', 2, 2)
	, ('2023-08-02', 4, 4, 4, 1, '�������� �������� ������ ������ ������', 1, '', '', NULL, 2)
	, ('2023-08-02', 5, 2, 5, 2, '�������� ����������', 1, '', '', NULL, 3)
	, ('2023-08-02', 1, 1, 6, 2, '�������� ��������', 3, '2023-08-03', '', 2, 1)
	, ('2023-07-09', 3, 3, 7, 3, '�����, �� �� ������������', 3, '2023-08-03', '����� ������ ����������� ������ ������������', 2, 2)

INSERT INTO [Comment]([Message], [MasterID], [RequestID]) VALUES
	('���������� �������', 2, 1)
	, ('����� �������, ����� �����������!', 3, 2)
	, ('������ ����� ����������� ����� ������', 2, 7)
	, ('���������� �������', 2, 1)
	, ('����� �������, ����� �����������!', 3, 6)