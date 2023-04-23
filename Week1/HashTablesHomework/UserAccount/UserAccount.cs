
using System.Security.Cryptography;
using System.Text;

namespace ClassTasks
{
    
    public class UserAccount
    {
        public static string HashPassword(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }


        public string Username{ get; init; }
        public string Password { get; set; }

        public UserAccount(string username, string password)
        {
            this.Username = username;   
           this.Password = HashPassword(password);
        }
    }
}