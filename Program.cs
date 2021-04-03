using System;

namespace ProjetoCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Bem vindo a Calculadora! Selecione uma das opções:");
                Console.WriteLine("1-Soma\n2-Subtração\n3-Divisão\n4-Multiplicação\n5-Potência\n6-Raiz\n7-Sair");
                TipoOperacao tipo = (TipoOperacao)int.Parse(Console.ReadLine());
                Console.WriteLine(tipo);

                Console.Clear();

                if (tipo == TipoOperacao.Sair)
                    escolheuSair = true;
                else
                    Executar(tipo);
            }
            
        }

        private static void Executar(TipoOperacao tipo)
        {
            var variaveis = ObtemValores(tipo);
            float resultado = ExecutarOperacao(tipo, variaveis.a, variaveis.b);
            FinalizarExecucao(tipo, resultado);
        }

        private static void FinalizarExecucao(TipoOperacao tipo, float resultado)
        {
            Console.WriteLine($"O resultado da {tipo.ToString()} é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao Operacoes");
            Console.ReadLine();
            Console.Clear();
        }

        private static float ExecutarOperacao(TipoOperacao tipo, float a, float b)
        {
            switch (tipo)
            {
                case TipoOperacao.Soma:
                    return Soma(a, b);
                case TipoOperacao.Subtracao:
                    return Sub(a, b);
                case TipoOperacao.Multiplicacao:
                    return Mult(a, b);
                case TipoOperacao.Divisao:
                    return Div(a, b);
                case TipoOperacao.Potencia:
                    return (float)Pot(a, b);
                default:
                    return (float)Raiz(a);
            }
        }

        private static (float a, float b) ObtemValores(TipoOperacao tipo)
        {
            if (tipo == TipoOperacao.Raiz)
            {
                Console.WriteLine($"{tipo.ToString()} quadrada:");
                Console.WriteLine("Informe o número:");
                float a = float.Parse(Console.ReadLine());
                return (a, 0);
            }
            else
            {
                if (tipo == TipoOperacao.Sair) return (0, 0);

                Console.WriteLine($"{tipo.ToString()} de dois números:");
                Console.WriteLine("Digite o primeiro número:");
                float a = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o segundo número:");
                float b = float.Parse(Console.ReadLine());
                return (a, b);
            }
        }

        private static float Soma(float a, float b)
            => a + b;

        private static float Sub(float a, float b)
            => a - b;

        private static float Mult(float a, float b)
            => a * b;

        private static float Div(float a, float b)
            => a / b;

        private static double Pot(float a, float b)
            => Math.Pow(a, b);

        private static double Raiz(float a)
            => Math.Sqrt(a);
    }
}
