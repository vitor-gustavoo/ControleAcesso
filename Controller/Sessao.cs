using System;
using System.Collections.Generic;

namespace Controller
{

    public class Sessao
    {
        public static Model.Sessao Login(string email, string senha)
        {
            Model.Usuario usuario = Model.Usuario.BuscarEmail(email);
            if (usuario == null) {
                throw new Exception("Login incorreto ou está inválido");
            }
            if (usuario.Senha != senha) {
                throw new Exception("Senha incorreta");
            }
            return new Model.Sessao(usuario.Id);

        }

        public static void Logout(string id)
        {
            int idInt = int.Parse(id);
            Model.Sessao sessao = Model.Sessao.AlterarSessao(idInt,new DateTime());
        }
        public static List<Model.Sessao> ListarSessoes()
        {
            return Model.Sessao.ListarSessoes();
        }

    
        public static bool Ativas(string id)
        {
            int idInt = int.Parse(id);
            Model.Sessao sessao = Model.Sessao.AlterarSessao(idInt, DateTime.Now);
            if (sessao == null) {
                return true;
            }
            if (sessao.DataExpiracao < DateTime.UtcNow) {
                return true;
            }
            return false;
        }

        
    }
}