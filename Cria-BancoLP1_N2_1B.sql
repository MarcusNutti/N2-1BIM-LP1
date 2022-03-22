if db_id('banco_LP1_N2_1B') is null
begin
    create database banco_LP1_N2_1B
end

use banco_LP1_N2_1B
create table curriculos
(
	cpf varchar(11) not null primary key,

	nome varchar(60) not null,
	endereco varchar(60) not null,
	telefone varchar(25) not null,
	email varchar(60),

	pretensaoSalarial decimal (8, 2),
	cargoPretendido varchar(60),

	formacaoAcademica1 varchar(100) not null, /* <curso>, <sigla_instituicao>, <ano> */
	formacaoAcademica2 varchar(100),
	formacaoAcademica3 varchar(100),
	formacaoAcademica4 varchar(100),
	formacaoAcademica5 varchar(100),

	experiencia1 varchar(100),
	experiencia2 varchar(100),
	experiencia3 varchar(100),

	idiomas varchar(100) /* <idioma, proficiência> */
)


--carga inicial
insert into curriculos values
('1', 'Márcio Rodrigues da Silva', 
'Av. Caminho Mar, 2652, Rudge Ramos, SBC - SP', '(11) 4366-9777',
'marciao@faculdade.cefsa.edu.br', 
50000.00, 
'Diretor da Termomecânica SA', 
'Engenharia Mecânica, FEI, 2009', 'Mestrado em Eng. Mecãnica, USP, 2015', null, null, null,
'Professor Celetista FESA', 'Coordenador de P&D na Termomecânica', null,
'Português (Nativo), Inglês (Avançado)'),

('2', 'João Eduardo Lamesa', 
'Jaú - SP', '(11) 91234-5678',
'lamesa@faculdade.cefsa.edu.br', 
15000.00, 
'Professor de Física', 
'Bacharelado em Física, USP, 1998', 'Mestrado em Ciências Atmosféricas, USP, 2001', null, null, null,
'Professor Celetista FESA', 'Professor Celetista USJT', null,
'Português (Nativo), Inglês(Intermediário), Francês (Avançado)'),

('3', 'Flávio Viotti', 
'Estrada dos Alvarengas, 4001 - Alvarenga, SBC - SP', '(11) 4359-6565',
'viotti@faculdade.cefsa.edu.br', 
1000.00,
'Coordenador de Banco de Dados', 
'Tecnólogo em Processamento de Dados, IESA, 1993', 'Mestrado em Informática, UNISANTOS, 2008', null, null, null,
'DBA na Empresa X', 'Professor na FESA', null, 
'Português (Intermidiário), Inglês (Avançado)'),

('4', 'Wagner Wuo',
'Interior - SP', '(11) 99999-9999',
'wuo@faculdade.cefsa.edu.br',
100000.00,
'Coach Quântico',
'Bacharelado em Física, USP, 1977', 'Mestrado em Educação, PUC-SP, 1999', 'Doutorado em Educação, PUC, 2005', null, null,
'Professor Titular FESA', 'Professor Celetisa, UMG', 'Professor Assistente PUC-SP',
'Português (Nativo), Inglês (Intermediário)'),

('5', 'Fernando Pizzo',
'SBC - SP', '(11)77777-7777',
'pizza@faculdade.cefsa.edu.br',
80000.00,
'Mágico',
'Bacharelado em Eng. Elétrica, FEI, 2005', 'Mestrado em Eng. Elétrica, FEI, 2010', null, null, null,
'Professor FESA', 'Professor USJT', 'Youtuber',
'Português (Nativo), (Italiano)')

select * from curriculos