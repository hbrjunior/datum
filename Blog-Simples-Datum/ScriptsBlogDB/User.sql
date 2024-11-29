CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave prim�ria com incremento autom�tico
    Username NVARCHAR(50) NOT NULL,  -- Nome do usu�rio, obrigat�rio
    Email NVARCHAR(100) NOT NULL,    -- Email, obrigat�rio
    PasswordHash NVARCHAR(255) NOT NULL, -- Hash da senha, obrigat�rio
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de cria��o
    UpdatedAt DATETIME NULL -- Data de atualiza��o
);
