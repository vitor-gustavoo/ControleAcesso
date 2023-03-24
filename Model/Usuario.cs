using Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Model
{   

    public class Usuario
    {   
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            Context db = new Context();
            db.Usuarios.Add(this);
            db.SaveChanges();
        }

        public Usuario() 
        {
        }


        public override string ToString()
        {
        return $"Id: {Id} - Nome: {Nome} - Email: {Email} - Senha: {Senha} - Sessões Ativas: {Model.Sessao.BuscarSessoesAtivas(this.Id)}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        //Com problemas na função Equals

        // public override bool Equals(object obj)
        // {
        //     if (obj == null) {
        //         return false;
        //     }
        //     if (obj == this) {
        //         return true;
        //     }
        //     if (obj.GetType() != this.GetType()) {
        //         return false;
        //     }
        //     Usuario usuario = (Usuario) obj;
        //     return this.Id == usuario.Id;
        // }

        public static Model.Usuario BuscarUsuario(int id)
        {
            Context db = new Context();

            try
            {
                // É possível realizar essa consulta com o Find 
                //db.Usuarios.Find(id);

                Model.Usuario usuario = (from user in db.Usuarios
                                        where user.Id == id
                                        select user).First();
                return usuario;

            }
            catch (Exception e)
            {
                throw new Exception($"Erro usuário não encontrado: {e.Message}");
            }
        
        }
       
        public static Usuario AlterarUsuario(int id, string nome,string email, string senha)
        {
            try
            {
                Model.Usuario usuario = BuscarUsuario(id);
                usuario.Email = email;
                usuario.Nome = nome;
                usuario.Senha = senha;

                Context db = new Context();
                db.Usuarios.Update(usuario);
                db.SaveChanges();

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

         public static void ExcluirUsuario(
            int id
        )
        {
            try
            {
                Model.Usuario usuario = BuscarUsuario(id);
                Context db = new Context();
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Usuario> ListarUsuarios() {
            
            Context db = new Context();
            List<Model.Usuario> usuarios = (from user in db.Usuarios
                                        select user).ToList();
            return usuarios;
        }

        public static Model.Usuario BuscarEmail(string email) {
            try
            {
                Context db = new Context();
                Model.Usuario usuario =(from user in db.Usuarios
                                            where user.Email == email
                                            select user).First();
                return usuario;
            }catch(Exception e)
            {
                throw new Exception($"Usuário não encontrado {e.Message}");
            }
        }

       
    }


}