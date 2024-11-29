CREATE TABLE Notification (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave primária com incremento automático
    UserId INT NOT NULL,              -- Relacionamento com o usuário ([User].Id)
    Message NVARCHAR(255) NOT NULL,  -- Mensagem da notificação
    IsRead BIT NOT NULL DEFAULT 0,    -- Indicador se a notificação foi lida
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de criação
    FOREIGN KEY (UserId) REFERENCES [User](Id) -- Chave estrangeira para [User]
);
