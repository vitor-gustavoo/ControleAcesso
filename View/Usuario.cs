using System;
using System.Collections.Generic;

namespace View
{
    public class Usuario
    {
        public static void CriarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Criar Usuário");
            Console.WriteLine("-------------");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            
            try
            {
               Model.Usuario usuario = Controller.Usuario.CriarUsuario(nome, email, senha);
                Console.WriteLine("Usuário criado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void AlterarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Alterar Usuário");
            Console.WriteLine("---------------");
            Console.WriteLine("Digite o ID do usuário: ");
            string id = Console.ReadLine();
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            
            try
            {
                Model.Usuario usuario = Controller.Usuario.AlterarUsuario(id, nome, email, senha);
                Console.WriteLine("Usuário alterado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuário");
            Console.WriteLine("---------------");
            Console.WriteLine("Digite o ID do usuário: ");
            string id = Console.ReadLine();
            
            try
            {
                Controller.Usuario.ExcluirUsuario(id);
                Console.WriteLine("Usuário excluído com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("Listar Usuário");
            Console.WriteLine("--------------");
            List<Model.Usuario> usuarios = Controller.Usuario.ListarUsuarios();
            foreach (Model.Usuario user in usuarios)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}               