using System;
using System.Linq;
using System.Collections.Generic;
using Repository;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Usuario
    {
        public static Model.Usuario CriarUsuario(string nome, string email, string senha)

        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
                throw new Exception("Email inválido");

            Model.Usuario usuario = new Model.Usuario(
                nome,
                email,
                senha
            );
            return usuario;
        }

        public static Model.Usuario AlterarUsuario(string id, string nome, string email, string senha)
        {
            try
            {
                int UsuarioId = Int32.Parse(id);
                return Model.Usuario.AlterarUsuario(UsuarioId,nome, email, senha);

            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public static void ExcluirUsuario(string id)
        {
            try
            {
                int UsuarioId = Int32.Parse(id);
                Model.Usuario.ExcluirUsuario(UsuarioId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Usuario> ListarUsuarios() {
            return Model.Usuario.ListarUsuarios();
        }

        public static Model.Usuario BusacarEmail(string email) {
            return Model.Usuario.BuscarEmail(email);
        }
    }
}