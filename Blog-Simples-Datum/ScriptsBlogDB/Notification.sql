-- Tabela de Notifica��es
CREATE TABLE Notifications (
    Id INT PRIMARY KEY IDENTITY(1,1),        -- Id da Notifica��o (auto-incremento)
    Message NVARCHAR(MAX) NOT NULL,           -- Mensagem da notifica��o
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Data de cria��o da notifica��o
    IsRead BIT DEFAULT 0                      -- Flag para indicar se a notifica��o foi lida (0 = n�o lida, 1 = lida)
);
