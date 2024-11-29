-- Tabela de Notificações
CREATE TABLE Notifications (
    Id INT PRIMARY KEY IDENTITY(1,1),        -- Id da Notificação (auto-incremento)
    Message NVARCHAR(MAX) NOT NULL,           -- Mensagem da notificação
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Data de criação da notificação
    IsRead BIT DEFAULT 0                      -- Flag para indicar se a notificação foi lida (0 = não lida, 1 = lida)
);
