CREATE DATABASE brgDb;

-- Colaborador.

CREATE TABLE colaborador(
    id SERIAL PRIMARY KEY,
    cargo VARCHAR(50) NOT NULL,
    departamento VARCHAR(50) NOT NULL
);

-- Habilidade.

CREATE TABLE habilidade(
    id SERIAL PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    tipo SMALLINT NOT NULL
);

-- Trilha.

CREATE TABLE trilha(
    id SERIAL PRIMARY KEY,
    prazo timestamp NOT NULL,
    colaborador_id INTEGER NOT NULL,
    habilidade_id INTEGER NOT NULL,

    CONSTRAINT "FK_trilhas_colaboradores_colaborador_id" FOREIGN KEY ("colaborador_id") REFERENCES "colaborador" ("id") ON DELETE CASCADE,
    CONSTRAINT "FK_trilhas_habilidades_habilidade_id" FOREIGN KEY ("habilidade_id") REFERENCES "habilidade" ("id") ON DELETE CASCADE
);

-- MIGRATION.

    -- Colaborador.
    
    INSERT INTO colaborador (cargo, departamento) SELECT 'Açougueiro','Operacional';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Administrador','Recursos Humanos';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Analista Administrativo','Recursos Humanos';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Almoxarife','Empenho';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Administrador de Sistemas','Tributário';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Analista de Documentaçãos','Tributário';
    INSERT INTO colaborador (cargo, departamento) SELECT 'Ajudante Geral','Geral';

    -- Habilidade.

    INSERT INTO habilidade (nome, tipo) SELECT 'Gestão de Projetos',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Mecânica de Motores',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Programação',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Domínio de C#',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Domínio de Exel',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Domínio de Contabilidade',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Inglês',1;
    INSERT INTO habilidade (nome, tipo) SELECT 'Comunicação Interpessoal',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Persuasão',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Proatividade',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Resiliência',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Resolução de conflitos',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Liderança',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Confiança',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Criatividade',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Comunicação',2;
    INSERT INTO habilidade (nome, tipo) SELECT 'Organização',2;

    -- Trilha.

    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '18/07/2020', 1, 8;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '19/07/2020', 1, 10;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '20/07/2020', 1, 17;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '21/07/2020', 5, 3;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '22/07/2020', 5, 7;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '23/07/2020', 5, 10;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '24/07/2020', 7, 2;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '25/07/2020', 7, 12;
    INSERT INTO trilha (prazo, colaborador_id, habilidade_id) SELECT '26/07/202', 7, 15;