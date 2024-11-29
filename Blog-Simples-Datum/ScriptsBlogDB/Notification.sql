CREATE TABLE Notification (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave prim�ria com incremento autom�tico
    UserId INT NOT NULL,              -- Relacionamento com o usu�rio ([User].Id)
    Message NVARCHAR(255) NOT NULL,  -- Mensagem da notifica��o
    IsRead BIT NOT NULL DEFAULT 0,    -- Indicador se a notifica��o foi lida
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de cria��o
    FOREIGN KEY (UserId) REFERENCES [User](Id) -- Chave estrangeira para [User]
);
