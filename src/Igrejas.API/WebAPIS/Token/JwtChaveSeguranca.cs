using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPIS.Token
{
    public class JwtChaveSeguranca
    {
        public static SymmetricSecurityKey Criar(string segredo)
        {
            var segredoCriptografado = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(segredo));
            return segredoCriptografado;
        }
    }
}
