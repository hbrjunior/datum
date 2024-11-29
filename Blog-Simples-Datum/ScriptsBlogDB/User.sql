-- Tabela de Usu�rios
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),       -- Id do Usu�rio (auto-incremento)
    Username NVARCHAR(50) NOT NULL,         -- Nome de usu�rio (m�ximo 50 caracteres)
    Email NVARCHAR(255) NOT NULL,           -- Endere�o de email (m�ximo 255 caracteres)
    PasswordHash NVARCHAR(255) NOT NULL,    -- Hash da senha (m�ximo 255 caracteres)
    CreatedAt DATETIME DEFAULT GETDATE(),   -- Data de cria��o (valor padr�o: data atual)
    UpdatedAt DATETIME,                     -- Data de atualiza��o (pode ser nulo)
    CONSTRAINT UC_Email UNIQUE (Email)      -- Restringe emails �nicos (n�o pode haver dois com o mesmo email)
);
