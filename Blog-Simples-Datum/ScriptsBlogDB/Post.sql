CREATE TABLE Post (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave prim�ria com incremento autom�tico
    Title NVARCHAR(200) NOT NULL,     -- T�tulo do post, obrigat�rio
    Content NVARCHAR(MAX) NOT NULL,  -- Conte�do do post, obrigat�rio
    AuthorId INT NOT NULL,           -- Relacionamento com o usu�rio ([User].Id)
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de cria��o
    UpdatedAt DATETIME NULL,         -- Data de atualiza��o
    FOREIGN KEY (AuthorId) REFERENCES [User](Id) -- Chave estrangeira para [User]
);