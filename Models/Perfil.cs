using Repository;

namespace Models
{
    public class Perfil
    {
        public int Id {get; set;}
        public int UsuarioId {get; set;}
       public virtual Usuarios usuario {get; set;}

        public Perfil() {}

        public Perfil(Usuarios usuario)
        {
            this.UsuarioId = usuario.Id;

            Context db = new Context();
            db.Perfil.Add(this);
            db.SaveChanges();
        }

        public static Perfil GetPerfilById(int id)
        {
            Context db = new Context();

            try
            {
                db.Perfil.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Perfil não encontrado: {e.Message}");
            }
            return db.Perfil.Find(id);
        }

        // public static Perfil GetPerfilByUser(Usuarios usuario);
        // {
        //     Context db = new Context();

        //     return(from perfil in db.Perfil 
        //             where perfil.UsuarioId == usuario.Id
        //             select perfil).First();

        // }

        public static IEnumerable<Perfil> GetAllPerfil()
        {
            Context db = new Context();

            return from perfil in db.Perfil
            select perfil;
        }

        // public static Perfil UpdatePerfil(Perfil perfil)
        // {
        //     Context db = new Context();

    
        // }

        public static Perfil DeletePerfil(Perfil perfil)
        {
            Context db = new Context();

            db.Perfil.Remove(perfil);
            db.SaveChanges();

            return perfil;
        }


    }

     
}