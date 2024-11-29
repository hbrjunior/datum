CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave primária com incremento automático
    Username NVARCHAR(50) NOT NULL,  -- Nome do usuário, obrigatório
    Email NVARCHAR(100) NOT NULL,    -- Email, obrigatório
    PasswordHash NVARCHAR(255) NOT NULL, -- Hash da senha, obrigatório
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de criação
    UpdatedAt DATETIME NULL -- Data de atualização
);
