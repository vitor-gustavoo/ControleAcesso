using Repository;
using Utils;

namespace Controller
{
    public class Usuarios
    {
        public  static void CadastraUsuario(string nome, string email, string senha)
        {
            Utils.Utils.isValidEmail();
            Utils.Utils.isValidPassword();

            Models.Usuarios usuario = new Models.Usuarios(nome, email, senha);
            usuario.cadastrar();
        }

        public static ExcluirUsuario(int id)
        {
            Models.Usuarios usuario = Models.Usuarios.GetUserById(id);
            usuario.excluir();
        }

        public static void AlterarUsuario(string nome, string email, string senha)
        {
            Models.Usuarios usuario = Models.Usuarios.UpdateUsuario(nome, email, senha);
            usuario.update();
        }

        public static void ListarUsuarios()
        {
            Models.Usuarios usuario = Models.Usuarios.GetAllUsers();
            usuario.listar();
        }

        public static void ListarUsuarioPorId(int id)
        {
            Models.Usuarios usuario = Models.Usuarios.GetUserById(id);
            usuario.listar();
        }

        public static ExcluirUsuario(int id)
        {
            Models.Usuarios usuario = Models.Usuarios.GetUserById(id);
            usuario.excluir(); 
        }

    }

}
