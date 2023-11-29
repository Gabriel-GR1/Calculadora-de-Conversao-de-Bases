using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Didática
{
    internal class Program
    {

        static void Main(string[] args)
        {


            int opcao = -1;
            while (opcao != 0)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("|Calculadora de Conversão de Bases|");
                Console.WriteLine("===================================");
                Console.WriteLine("| 1. Decimal para Binário         |");
                Console.WriteLine("| 2. Binário para Decimal         |");
                Console.WriteLine("| 3. Decimal para Octal           |");
                Console.WriteLine("| 4. Octal para Decimal           |");
                Console.WriteLine("| 5. Decimal para Hexadecimal     |");
                Console.WriteLine("| 6. Hexadecimal para Decimal     |");
                Console.WriteLine("| 7. Binário para Octal           |");
                Console.WriteLine("| 8. Octal para Binário           |");
                Console.WriteLine("| 9. Binário para Hexadecimal     |");
                Console.WriteLine("| 10. Hexadecimal para Binário    |");
                Console.WriteLine("| 11. Octal para Hexadecimal      |");
                Console.WriteLine("| 12. Hexadecimal para Octal      |");
                Console.WriteLine("===================================");
                Console.WriteLine("| 0. Sair                         |");
                Console.WriteLine("===================================");
                Console.WriteLine("Feito por: Gabriel Rodrigo");
                Console.Write("\nInforme a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        DecimalParaBinario();
                        break;
                    case 2:
                        BinarioParaDecimal();
                        break;
                    case 3:
                        DecimalParaOctal();
                        break;
                    case 4:
                        OctalParaDecimal();
                        break;
                    case 5:
                        DecimalParaHexadecimal();
                        break;
                    case 6:
                        HexadecimalParaDecimal();
                        break;
                    case 7:
                        BinarioParaOctal();
                        break;
                    case 8:
                        OctalParaBinario();
                        break;
                    case 9:
                        BinarioParaHexadecimal();
                        break;
                    case 10:
                        HexadecimalParaBinario();
                        break;
                    case 11:
                        OctalParaHexadecimal();
                        break;
                    case 12:
                        HexadecimalParaOctal();
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DecimalParaBinario()
        {
            Console.Write("Informe um número decimal: ");
            int numDecBin = int.Parse(Console.ReadLine());
            string numBin = DecimalParaBase(numDecBin, 2);
            Console.WriteLine($"\nO número {numDecBin} em binário é: {numBin}");
            Console.WriteLine("\nPasso a passo:");
            while (numDecBin > 0)
            {
                int resto = numDecBin % 2;
                Console.WriteLine($"Divida o número decimal {numDecBin} por 2 e anote o resto: {numDecBin} / 2 = Quociente: {numDecBin / 2}, Resto: {resto}");
                numDecBin /= 2;
            }
        }

        static void BinarioParaDecimal()
        {
            Console.Write("Informe um número binário: ");
            string numBinDec = Console.ReadLine();
            if (numBinDec.All(c => c == '0' || c == '1'))
            {
                int numDec = BaseParaDecimal(numBinDec, 2);
                Console.WriteLine($"\nO número binário {numBinDec} em decimal é: {numDec}");
                Console.WriteLine("\nPasso a passo:");
                int numBits = numBinDec.Length;
                int decimalNum = 0;

                for (int i = 0; i < numBits; i++)
                {
                    int bit = int.Parse(numBinDec[i].ToString());
                    decimalNum += bit * (int)Math.Pow(2, numBits - 1 - i);
                    Console.WriteLine($"Multiplique o dígito binário {bit} pela potência de 2 correspondente à sua posição: {bit} * 2^{numBits - 1 - i}");
                }

                Console.WriteLine($"\nSome os resultados das multiplicações: {decimalNum}");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número binário. Utilize apenas '0' e '1'.");
            }
        }


        static void DecimalParaOctal()
        {
            Console.Write("Informe um número decimal: ");
            int numDecOct = int.Parse(Console.ReadLine());
            string numOct = DecimalParaBase(numDecOct, 8);
            Console.WriteLine($"\nO número {numDecOct} em octal é: {numOct}");
            Console.WriteLine("\nPasso a passo:");
            while (numDecOct > 0)
            {
                int resto = numDecOct % 8;
                Console.WriteLine($"Divida o número decimal {numDecOct} por 8 e anote o resto: {numDecOct} / 8 = Quociente: {numDecOct / 8}, Resto: {resto}");
                numDecOct /= 8;
            }
        }

        static void OctalParaDecimal()
        {
            Console.Write("Informe um número octal: ");
            string numOctDec = Console.ReadLine();
            if (numOctDec.All(c => c >= '0' && c <= '7'))
            {
                int numDec = BaseParaDecimal(numOctDec, 8);
                Console.WriteLine($"\nO número octal {numOctDec} em decimal é: {numDec}");
                Console.WriteLine("\nPasso a passo:");
                int num = Convert.ToInt32(numOctDec, 8);
                int passo = 1;
                while (num > 0)
                {
                    Console.WriteLine($"Passo {passo}: {num} % 10 -> Resto: {num % 10}");
                    num /= 10;
                    passo++;
                }

                Console.WriteLine($"Passo {passo}: junte os valores obtidos da direita para esquerda, obtendo o {numDec}.");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número octal. Utilize apenas dígitos de 0 a 7.");
            }
        }

        static void DecimalParaHexadecimal()
        {
            Console.Write("Informe um número decimal: ");
            int numDecHex = int.Parse(Console.ReadLine());
            string numHex = DecimalParaBase(numDecHex, 16);
            Console.WriteLine($"\nO número {numDecHex} em hexadecimal é: {numHex}");
            Console.WriteLine("\nPasso a passo:");
            int num = numDecHex;
            int passo = 1;
            while (num > 0)
            {
                int resto = num % 16;
                Console.WriteLine($"Passo {passo}: {num} / 16 -> Quociente: {num / 16}, Resto: {resto}");
                num /= 16;
                passo++;
            }

            Console.WriteLine($"Passo {passo}: junte os valores obtidos da direita para esquerda, obtendo o {numHex}.");
        }

        static void HexadecimalParaDecimal()
        {
            Console.Write("Informe um número hexadecimal: ");
            string numHexDec = Console.ReadLine();
            if (numHexDec.All(c => char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
            {
                int numDec = BaseParaDecimal(numHexDec, 16);
                Console.WriteLine($"\nO número hexadecimal {numHexDec} em decimal é: {numDec}");
                Console.WriteLine("\nPasso a passo:");
                int num = Convert.ToInt32(numHexDec, 16);
                int passo = 1;

                while (num > 0)
                {
                    Console.WriteLine($"Passo {passo}: {num} % 10 -> Resto: {num % 10}");
                    num /= 10;
                    passo++;
                }

                Console.WriteLine($"Passo {passo}: junte os valores obtidos da direita para esquerda, multiplicados por 16 e elevado à posição do dígito, obtendo {numDec}");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número hexadecimal. Utilize dígitos de 0 a 9 e letras de A a F.");
            }
        }
        static void BinarioParaOctal()
        {
            Console.Write("Informe um número binário: ");
            string numBinOct = Console.ReadLine();
            if (numBinOct.All(c => c == '0' || c == '1'))
            {
                string numOct = BaseParaBase(numBinOct, 2, 8);
                Console.WriteLine($"\nO número binário {numBinOct} em octal é: {numOct}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numBinOct, 2);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 8;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 8 -> Resto: {resto}");
                    numDec /= 8;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos da direita para esquerda, obtendo {numOct}");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número binário. Utilize apenas '0' e '1'.");
            }
        }
        static void OctalParaBinario()
        {
            Console.Write("Informe um número octal: ");
            string numOctBin = Console.ReadLine();
            if (numOctBin.All(c => c >= '0' && c <= '7'))
            {
                string numBin = BaseParaBase(numOctBin, 8, 2);
                Console.WriteLine($"\nO número octal {numOctBin} em binário é: {numBin}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numOctBin, 8);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 2;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 2 -> Quociente: {numDec / 2}, Resto: {resto}");
                    numDec /= 2;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos dos passos {passo - 1} até 1.");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número octal. Utilize apenas dígitos de 0 a 7.");
            }
        }
        static void BinarioParaHexadecimal()
        {
            Console.Write("Informe um número binário: ");
            string numBinHex = Console.ReadLine();
            if (numBinHex.All(c => c == '0' || c == '1'))
            {
                string numHex = BaseParaBase(numBinHex, 2, 16);
                Console.WriteLine($"\nO número binário {numBinHex} em hexadecimal é: {numHex}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numBinHex, 2);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 16;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 16 -> Quociente: {numDec / 16}, Resto: {resto}");
                    numDec /= 16;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos dos passos {passo - 1} até 1");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número binário. Utilize apenas '0' e '1'.");
            }
        }
        static void HexadecimalParaBinario()
        {
            Console.Write("Informe um número hexadecimal: ");
            string numHexBin = Console.ReadLine();
            if (numHexBin.All(c => char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
            {
                string numBin = BaseParaBase(numHexBin, 16, 2);
                Console.WriteLine($"\nO número hexadecimal {numHexBin} em binário é: {numBin}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numHexBin, 16);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 2;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 2 -> Quociente: {numDec / 2}, Resto: {resto}");
                    numDec /= 2;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos dos passos {passo - 1} até 1");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número hexadecimal. Utilize dígitos de 0 a 9 e letras de A a F.");
            }
        }
        static void OctalParaHexadecimal()
        {
            Console.Write("Informe um número octal: ");
            string numOctHex = Console.ReadLine();
            if (numOctHex.All(c => c >= '0' && c <= '7'))
            {
                string numHex = BaseParaBase(numOctHex, 8, 16);
                Console.WriteLine($"\nO número octal {numOctHex} em hexadecimal é: {numHex}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numOctHex, 8);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 16;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 16 -> Quociente: {numDec / 16}, Resto: {resto}");
                    numDec /= 16;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos dos passos {passo - 1} até 1");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número octal. Utilize apenas dígitos de 0 a 7.");
            }
        }
        static void HexadecimalParaOctal()
        {
            Console.Write("Informe um número hexadecimal: ");
            string numHexOct = Console.ReadLine();

            // Verificar se todos os caracteres são dígitos válidos para hexadecimal
            if (numHexOct.All(c => char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
            {
                string numOct = BaseParaBase(numHexOct, 16, 8);
                Console.WriteLine($"\nO número hexadecimal {numHexOct} em octal é: {numOct}");
                Console.WriteLine("\nPasso a passo:");
                int numDec = BaseParaDecimal(numHexOct, 16);
                int passo = 1;

                while (numDec > 0)
                {
                    int resto = numDec % 8;
                    Console.WriteLine($"Passo {passo++}: {numDec} / 8 -> Quociente: {numDec / 8}, Resto: {resto}");
                    numDec /= 8;
                }

                Console.WriteLine($"Passo {passo}: Junte os valores dos restos dos passos {passo - 1} até 1");
            }
            else
            {
                Console.WriteLine("Entrada inválida para número hexadecimal. Utilize dígitos de 0 a 9 e letras de A a F.");
            }
        }
        static string DecimalParaBase(int num, int baseAlvo)
        {
            string resultado = "";
            while (num > 0)
            {
                int resto = num % baseAlvo;
                resultado = ObterDigito(resto) + resultado;
                num /= baseAlvo;
            }
            return resultado;
        }

        static int BaseParaDecimal(string num, int baseOrigem)
        {
            int resultado = 0;
            int expoente = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                int valor = ObterValor(num[i]);
                resultado += valor * (int)Math.Pow(baseOrigem, expoente);
                expoente++;
            }
            return resultado;
        }

        static string BaseParaBase(string num, int baseOrigem, int baseAlvo)
        {
            int decimalNum = BaseParaDecimal(num, baseOrigem);
            return DecimalParaBase(decimalNum, baseAlvo);
        }

        static char ObterDigito(int valor)
        {
            if (valor < 10)
                return (char)(valor + '0');
            else
                return (char)(valor - 10 + 'A');
        }

        static int ObterValor(char digito)
        {
            if (char.IsDigit(digito))
                return (int)(digito - '0');
            else
                return (int)(char.ToUpper(digito) - 'A') + 10;
        }
    }
}
