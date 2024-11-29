using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace NotificationClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting WebSocket Client...");

            // Substitua pela URL correta do Hub no servidor
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7100/notifications")  // URL do Hub
                .Build();

            // Registrar o evento para receber mensagens
            connection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine("Notificação recebida: " + message);
            });

            try
            {
                // Conecta ao Hub
                await connection.StartAsync();
                Console.WriteLine("Conectado ao servidor de notificações.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao Hub: {ex.Message}");
            }

            // Mantém o cliente em execução
            Console.WriteLine("Aguardando notificações... Pressione Enter para sair.");
            Console.ReadLine();

            // Fecha a conexão ao encerrar
            await connection.StopAsync();
            await connection.DisposeAsync();
        }
    }
}
