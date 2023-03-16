using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //select * from usuarios
            using (var contexto = new ControleAcessoContexto())
            {
                foreach (var usuario in contexto.Usuarios)
                {
                    System.Console.WriteLine();
                }

            }
        }
    }
}
