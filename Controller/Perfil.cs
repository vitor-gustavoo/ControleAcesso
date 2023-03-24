using System;
using System.Collections.Generic;


namespace Controller
{
    public class Perfil
    {

        public static Model.Perfil CriarPerfil(string usuarioId, string tipo)
        {
            int idUsuarioInt = int.Parse(usuarioId);
            Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);
            if (!Enum.TryParse<Model.TipoPerfil>(tipo, out Model.TipoPerfil tipoPerfil) == false) {
                throw new Exception("Tipo de perfil não é válido");
            }

            if (Model.Perfil.BuscarPerfilPorUsuario(usuario.Id) != null) {
                throw new Exception("Usuário já possui perfil cadastrado");
            }

            return new Model.Perfil(usuario.Id, tipoPerfil);
        }

        public static void ExcluirPerfil(string id)
        {
            
            try
            {
                int idusuario = int.Parse(id);
                Model.Perfil.ExcluirPerfil(idusuario);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static List<Model.Perfil> ListarPerfis() {
            return Model.Perfil.ListarPerfis();
        }

        

    }



}