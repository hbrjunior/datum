CREATE TABLE Post (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave primária com incremento automático
    Title NVARCHAR(200) NOT NULL,     -- Título do post, obrigatório
    Content NVARCHAR(MAX) NOT NULL,  -- Conteúdo do post, obrigatório
    AuthorId INT NOT NULL,           -- Relacionamento com o usuário ([User].Id)
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de criação
    UpdatedAt DATETIME NULL,         -- Data de atualização
    FOREIGN KEY (AuthorId) REFERENCES [User](Id) -- Chave estrangeira para [User]
);