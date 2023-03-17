using Repository;



namespace Models
{   

    public class Usuarios
    {   
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}

        public Usuarios() {}


        public override string ToString()
        {
        return $"Id: {this.Id} - Nome: {this.Nome} - Email: {this.Email} - Perfil: {Models.Perfil.GetPerfilByUser(this)}";
        }



        public Usuarios(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;

            Context db = new Context();
            db.Usuarios.Add(this);
            db.SaveChanges();
        }

        public static Usuarios GetUserById(int id)
        {
            Context db = new Context();

            try
            {
                db.Usuarios.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro usuário não encontrado: {e.Message}");
            }
            
            return db.Usuarios.Find(id);
        }
       
        public static Usuarios GetUserByEmail(string email)
        {
            Context db = new Context();

            return(from usuario in db.Usuarios
                where usuario.Email == email
                select usuario).First();
        }

        public static IEnumerable<Usuarios> GetAllUsers()
        {
            Context db = new Context();

            return from usuario in db.Usuarios
                select usuario;
        }

        public static Usuarios UpdateUsuario(Usuarios usuario, string nome, string email, string senha)
        {
            Context db = new Context();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;

            db.Usuarios.Update(usuario);
            db.SaveChanges();

            return usuario;
        }

        public static Usuarios DeleteUsuario(Usuarios usuario)
        {
            Context db = new Context();

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return usuario;
        }
        
    }


}