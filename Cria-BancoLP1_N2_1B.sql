create database banco_LP1_N2_1B

use banco_LP1_N2_1B

create table curriculos
(
	cpf varchar(11) not null primary key,

	nome varchar(50) not null,
	endereco varchar(50) not null,
	telefone varchar(15) not null,
	email varchar(50),

	pretensaoSalarial decimal (8, 2),
	cargoPretentido varchar(40),

	formacaoAcademica1 varchar(80) not null, /* <curso>, <sigla_instituicao>, <ano> */
	formacaoAcademica2 varchar(80),
	formacaoAcademica3 varchar(80),
	formacaoAcademica4 varchar(80),
	formacaoAcademica5 varchar(80),

	experiencia1 varchar(80),
	experiencia2 varchar(80),
	experiencia3 varchar(80),

	idiomas varchar(80) /* <idioma, proficiência> */
)

insert into curriculos values
('33333333333', 'Flávio Viotti', 
'Estrada dos Alvarengas, 4001 - Alvarenga, SBC - SP', '(11) 4359-6565',
'viotti@faculdade.cefsa.edu.br', 
1000.00,
'Coordenador de Banco de Dados', 
'Tecnólogo em Processamento de Dados, IESA, 1993', 'Mestrado em Informática, UNISANTOS, 2008', null, null, null,
'DBA na Empresa X', 'Professor na FESA', null, 
'Português (Intermidiário), Inglês (Avançado)'),

('22222222222', 'João Eduardo Lamesa', 
'Jaú - SP', '(11) 91234-5678',
'lamesa@faculdade.cefsa.edu.br', 
15000.00, 
'Professor de Física', 
'Bacharelado em Física, USP, 1998', 'Mestrado em Ciências Atmosféricas, USP, 2001', null, null, null,
'Professor Celetista FESA', 'Professor Celetista USJT', null,
'Português (Nativo), Inglês(Intermediário), Francês (Avançado)'),

('11111111111', 'Márcio Rodrigues da Silva', 
'Av. Caminho Mar, 2652, Rudge Ramos, SBC - SP', '(11) 4366-9777',
'marciao@faculdade.cefsa.edu.br', 
50000.00, 
'Diretor da Termomecânica SA', 
'Engenharia Mecânica, FEI, 2009', 'Mestrado em Eng. Mecãnica, USP, 2015', null, null, null,
'Professor Celetista FESA', 'Coordenador de P&D na Termomecânica', null,
'Português (Nativo), Inglês (Avançado)'),

('44444444444', 'Wagner Wuo',
'Interior - SP', '(11) 99999-9999',
'wuo@faculdade.cefsa.edu.br',
100000.00,
'Coach Quântico',
'Bacharelado em Física, USP, 1977', 'Mestrado em Educação, PUC-SP, 1999', 'Doutorado em Educação, PUC, 2005', null, null,
'Professor Titular FESA', 'Professor Celetisa, UMG', 'Professor Assistente PUC-SP',
'Português (Nativo), Inglês (Intermediário)')

select * from curriculos