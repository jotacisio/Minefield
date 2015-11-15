using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campo_Minado_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            construindo_jogo objJOGO = new construindo_jogo();

            objJOGO.inicializando_LeC();
            objJOGO.colocando_BOMBAS();
            objJOGO.colocando_NUMEROS();
            objJOGO.campo_esconder();
            objJOGO.JOGANDO();
            Console.ReadKey();
        }
    }
}
