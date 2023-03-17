



namespace Utils
{
    public class Utils

    {
        public static string isValidEmail(string email)
        {
            if(!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) 
            {
                throw new Exception("Email inválido");
            }
    
        }

        public static string isValidPassword(string password)
        {
            if(Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")) 
            {
                throw new Exception("Senha inválida");
            }
            else
            {
                Response.Write("Senha válida");
            }
        }
    }

}
