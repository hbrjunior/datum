-- Tabela de Usuários
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),       -- Id do Usuário (auto-incremento)
    Username NVARCHAR(50) NOT NULL,         -- Nome de usuário (máximo 50 caracteres)
    Email NVARCHAR(255) NOT NULL,           -- Endereço de email (máximo 255 caracteres)
    PasswordHash NVARCHAR(255) NOT NULL,    -- Hash da senha (máximo 255 caracteres)
    CreatedAt DATETIME DEFAULT GETDATE(),   -- Data de criação (valor padrão: data atual)
    UpdatedAt DATETIME,                     -- Data de atualização (pode ser nulo)
    CONSTRAINT UC_Email UNIQUE (Email)      -- Restringe emails únicos (não pode haver dois com o mesmo email)
);
