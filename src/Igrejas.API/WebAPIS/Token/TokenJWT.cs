using System.IdentityModel.Tokens.Jwt;

namespace WebAPIS.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken _token;

        internal TokenJWT(JwtSecurityToken token)
        {
            _token = token;
        }

        public DateTime ValidoAte => _token.ValidTo;

        public string Valor => new JwtSecurityTokenHandler()
            .WriteToken(_token);
    }
}
