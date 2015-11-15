using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campo_Minado_Game
{
    class construindo_jogo
    {

        public static int altura, largura;
        public static int[,] Campo_Minado;
        public bool achei_bomba = false;
        public bool achei_zeros = false;
        public static bool[,] Campo_Esconder;
        //-----------------------------------------------------------------------------------------------------
        //inicializando largura e altura do campo,criando campo
        //-----------------------------------------------------------------------------------------------------
        public void inicializando_LeC()
        {
            Console.WriteLine("  ----------------------------");
            Console.WriteLine("  --------Campo-Minado--------");
            Console.WriteLine("  ----------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite a largura do campo minado:");
            largura = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a altura do campo minado:");
            altura = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Campo_Minado = new int[largura, altura];
        }        
        //-----------------------------------------------------------------------------------------------------
        //colocando bombas no campo
        //-----------------------------------------------------------------------------------------------------
        public void colocando_BOMBAS()
        {
            int numero_de_bombas;
            Random B_aleatorio = new Random();
            numero_de_bombas = (largura * altura) / 6;
            for (int i = 0; i < numero_de_bombas; i++)
            {
                int x = B_aleatorio.Next(0, largura);
                int y = B_aleatorio.Next(0, altura);
                Campo_Minado[x, y] = 9;
            }
        }
        //-----------------------------------------------------------------------------------------------------
        //Colocando números no Campo
        //-----------------------------------------------------------------------------------------------------
        public void colocando_NUMEROS()
        {
            for (int col = 0; col <= altura - 1; col++)
            {
                for (int line = 0; line <= largura - 1; line++)
                {
                    if (Campo_Minado[line, col] != 9)
                    {
                        if (line - 1 >= 0 && line - 1 <= (largura - 1) && col - 1 >= 0 && col - 1 <= (altura - 1))
                        {
                            //1
                            if (Campo_Minado[line - 1, col - 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (line - 1 >= 0 && line - 1 <= (largura - 1))
                        {
                            //2
                            if (Campo_Minado[line - 1, col] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (line - 1 >= 0 && line - 1 <= (largura - 1) && col + 1 >= 0 && col + 1 <= (altura - 1))
                        {
                            //3
                            if (Campo_Minado[line - 1, col + 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (col - 1 >= 0 && col - 1 <= (altura - 1))
                        {
                            //4
                            if (Campo_Minado[line, col - 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (col + 1 >= 0 && col + 1 <= (altura - 1))
                        {
                            //5
                            if (Campo_Minado[line, col + 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (line + 1 >= 0 && line + 1 <= (largura - 1) && col - 1 >= 0 && col - 1 <= (altura - 1))
                        {
                            //6
                            if (Campo_Minado[line + 1, col - 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (line + 1 >= 0 && line + 1 <= (largura - 1))
                        {
                            //7
                            if (Campo_Minado[line + 1, col] == 9)
                                Campo_Minado[line, col]++;
                        }
                        if (line + 1 >= 0 && line + 1 <= (largura - 1) && col + 1 >= 0 && col + 1 <= (altura - 1))
                        {
                            //8
                            if (Campo_Minado[line + 1, col + 1] == 9)
                                Campo_Minado[line, col]++;
                        }
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------
        //criando campo que esconde e chamando o metodo imprimircampo()
        //-----------------------------------------------------------------------------------------------------
        public void campo_esconder()
        {
            Campo_Esconder = new bool[largura, altura];
            Imprimircampo(largura, altura, Campo_Esconder, achei_bomba, achei_zeros);
        }
        //-----------------------------------------------------------------------------------------------------
        //JOGANDO
        //-----------------------------------------------------------------------------------------------------
        public void JOGANDO()
        {
            Console.WriteLine("  ----------------------------");
            Console.WriteLine("  -----------JOGANDO----------");
            Console.WriteLine("  ----------------------------");
            int jogada_linha, jogada_coluna;
            while (achei_bomba == false)
            {
                Console.WriteLine("Digite a linha que vc quer jogar:");
                jogada_linha = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a coluna que vc quer jogar:");
                jogada_coluna = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (Campo_Minado[jogada_linha, jogada_coluna] == 0)
                {
                    achei_zeros = true;
                    Campo_Esconder[jogada_linha, jogada_coluna] = false;
                }
                if (jogada_linha < largura && jogada_coluna < altura)
                {
                    Campo_Esconder[jogada_linha, jogada_coluna] = true;
                    if (Campo_Minado[jogada_linha, jogada_coluna] == 9)
                    {
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("     ----------------------------");
                        Console.WriteLine("     --------B O O O O M---------");
                        Console.WriteLine("     --------P E R D E U---------");
                        Console.WriteLine("     ----------------------------");
                        Console.WriteLine();
                        achei_bomba = true;
                        Campo_Esconder[jogada_linha, jogada_coluna] = true;
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite os valores de linha e coluna dentro dos limites do campo");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Imprimircampo(largura, altura, Campo_Esconder, achei_bomba, achei_zeros);
                Console.WriteLine();
            }
        }
        //-----------------------------------------------------------------------------------------------------
        //Imprimindo Campo no terminal
        //-----------------------------------------------------------------------------------------------------
        public static void Imprimircampo(int largura, int altura, bool[,] Campo_Esconder, bool encontrou_bomba, bool encontrou_zeros)
        {
            Console.Write("   ");

            for (int i = 0; i < altura; i++)
            {
                if (i <= 9)
                {
                    Console.Write("  " + i);
                }
                else
                {
                    Console.Write(" " + i);
                }
            }
            Console.WriteLine();
            for (int l = 0; l < largura; l++)
            {
                if (l <= 9)
                {
                    Console.Write("  " + l);
                }
                else
                {
                    Console.Write(" " + l);
                }
                for (int c = 0; c < altura; c++)
                {
                    if (encontrou_bomba && Campo_Minado[l, c] == 9)
                    {
                        //ja encontrou bomba, e tem que mostrar a instrução de toda forma
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  B");
                        Console.ResetColor();
                    }
                    else if (encontrou_zeros && Campo_Minado[l, c] == 0)
                    {
                        //ja encontrou zeros, e mostrara todos ate o final do for
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("  0");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (Campo_Esconder[l, c] == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("  -");
                            Console.ResetColor();
                        }
                        else
                        {
                            if (Campo_Minado[l, c] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("  1");
                                Console.ResetColor();
                            }
                            if (Campo_Minado[l, c] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  2");
                                Console.ResetColor();
                            }
                            if (Campo_Minado[l, c] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("  3");
                                Console.ResetColor();
                            }
                            if (Campo_Minado[l, c] == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("  4");
                                Console.ResetColor();
                            }
                            if (Campo_Minado[l, c] == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("  5");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
