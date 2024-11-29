-- Tabela de Postagens
CREATE TABLE Posts (
    Id INT PRIMARY KEY IDENTITY(1,1),        -- Id da Postagem (auto-incremento)
    Title NVARCHAR(255) NOT NULL,             -- Título da postagem
    Content NVARCHAR(MAX) NOT NULL,           -- Conteúdo da postagem (pode ser texto longo)
    Author NVARCHAR(255) NOT NULL,            -- Nome do autor
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Data de criação da postagem (valor padrão: data atual)
    CONSTRAINT FK_Author FOREIGN KEY (Author) REFERENCES Users (Username) -- Associação ao autor pela Username
);