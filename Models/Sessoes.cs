using Repository;


namespace Models
{   
    public class Sessoes
    {    public int Id {get; set;}
        public int UsuarioId {get; set;}
        public string Token  {get; set;}
        public DateTime data_criacao {get; set;}
        public DateTime data_expiracao {get; set;}

        public override string ToString()
    {
      return $"Id: {this.Id} - Token: {this.Token} - data_criacao: {this.data_criacao} - data_expiracao: {this.data_expiracao} - Usuario: {Controllers.Usuarios.GetUserById(this.UsuarioId.ToString())}";
    }

        public Sessoes(Usuarios usuarios, string token, DateTime dataCriacao, DateTime dataExpiracao)
        {
            this.UsuarioId = usuarios.Id;
            this.Usuario = usuarios;
            this.Token = token;
            this.data_criacao = dataCriacao;
            this.data_expiracao = dataExpiracao;
        }

        public static Sessoes GetSessoesById(int id)
        {
            Context db = new Context();

            return db.Sessoes.Find(id);
        }

        public static Sessoes GetSessoesByUsuario(Usuarios usuarios)
        {
            Context db = new Context();

            return(from sessao in db.Sessoes
                    where sessao.UsuarioId == usuarios.Id
                    orderby sessao.data_criacao descending
                    select sessao).First();
        }

        public static IEnumerable<Sessoes> GetAllSessoes()
        {
            Context db = new Context();

            return from sessao in db.Sessoes
            select sessao;
        }

        public static Sessoes DeleteSessoes(Sessoes sessao)
        {
            Context db = new Context();

            db.Sessoes.Remove(sessao);
            db.SaveChanges();

            return sessao;

        }
    }
}