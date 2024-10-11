using System;

namespace AcerteOnumero
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variável que controla se o jogo deve continuar
            bool jogarNovamente = true;

            // Loop principal do jogo, que permite jogar várias vezes
            while (jogarNovamente)
            {
                // Cria um objeto Random para gerar números aleatórios
                Random numAleatorio = new Random();
                // Gera um número secreto aleatório entre 1 e 20
                int numSecreto = numAleatorio.Next(1, 21);
                int num; // Variável para armazenar o número que o usuário tenta adivinhar
                int maxTentativas = 3; // Número máximo de tentativas permitidas
                int tentativas = 0; // Contador de tentativas realizadas

                // Mensagem inicial para o usuário
                Console.WriteLine("\nTente adivinhar o número secreto entre 1 e 20.");
                Console.WriteLine("Você tem 3 tentativas.");

                // Loop que permite ao usuário fazer tentativas
                for (int i = 0; i < maxTentativas; i++)
                {
                    tentativas++; // Incrementa o contador de tentativas
                    Console.WriteLine("\nTentativa " + (i + 1));
                    Console.WriteLine("Digite o seu número: ");

                    // Tentativa de conversão segura: continua pedindo o número até que uma entrada válida seja fornecida
                    while (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("Entrada inválida! Por favor, digite um número inteiro.");
                    }

                    // Verifica se o número adivinhado é o número secreto
                    if (num == numSecreto)
                    {
                        Console.WriteLine("Parabéns, você acertou o número secreto!");
                        break; // Encerra o loop de tentativas
                    }
                    else if (num < 1 || num > 20)
                    {
                        // Verifica se o número está fora do intervalo permitido
                        Console.WriteLine("Por favor, digite um número de 1 a 20.");
                        i--; // Decrementa o contador de tentativas para não contar como uma tentativa válida
                        continue; // Continua para a próxima iteração do loop
                    }
                    else if (num < numSecreto)
                    {
                        // Indica que o número secreto é maior que o número adivinhado
                        Console.WriteLine("O número secreto é maior.");
                    }
                    else
                    {
                        // Indica que o número secreto é menor que o número adivinhado
                        Console.WriteLine("O número secreto é menor.");
                    }

                    // Verifica se o número máximo de tentativas foi alcançado
                    if (tentativas == maxTentativas)
                    {
                        Console.WriteLine($"Acabaram as tentativas, o número secreto era {numSecreto}.");
                    }
                }

                // Pergunta se o jogador quer jogar novamente
                Console.Write("\nDeseja jogar novamente? (s/n): ");
                string resposta = Console.ReadLine().ToLower(); // Lê a resposta do usuário e converte para minúsculas

                // Verifica a resposta do usuário
                if (resposta != "s")
                {
                    jogarNovamente = false; // Encerra o loop principal se o usuário não quiser jogar novamente
                    Console.WriteLine("Obrigado por jogar! Até a próxima.");
                }
            }
        }
    }
}
