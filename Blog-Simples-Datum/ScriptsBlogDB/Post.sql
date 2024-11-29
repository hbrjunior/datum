-- Tabela de Postagens
CREATE TABLE Posts (
    Id INT PRIMARY KEY IDENTITY(1,1),        -- Id da Postagem (auto-incremento)
    Title NVARCHAR(255) NOT NULL,             -- T�tulo da postagem
    Content NVARCHAR(MAX) NOT NULL,           -- Conte�do da postagem (pode ser texto longo)
    Author NVARCHAR(255) NOT NULL,            -- Nome do autor
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Data de cria��o da postagem (valor padr�o: data atual)
    CONSTRAINT FK_Author FOREIGN KEY (Author) REFERENCES Users (Username) -- Associa��o ao autor pela Username
);