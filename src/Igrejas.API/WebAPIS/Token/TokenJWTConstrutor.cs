using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPIS.Token
{
    public class TokenJWTConstrutor
    {
        private SecurityKey _securityKey = null;
        private string _subject = string.Empty;
        private string _issuer = string.Empty;
        private string _audience = string.Empty;
        private Dictionary<string, string> _claims = new Dictionary<string, string>();
        private int _expiryInMinutes = 5;

        public TokenJWT Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(_claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                signingCredentials: new SigningCredentials(
                    _securityKey,
                    SecurityAlgorithms.HmacSha256));

            return new TokenJWT(token);
        }

        public TokenJWTConstrutor AddSecuityKey(SecurityKey securityKey)
        {
            _securityKey = securityKey;
            return this;
        }

        public TokenJWTConstrutor AddSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public TokenJWTConstrutor AddIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public TokenJWTConstrutor AddAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public TokenJWTConstrutor AddClaims(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public TokenJWTConstrutor AddExpiry(int expiryInMinutes)
        {
            _expiryInMinutes = expiryInMinutes;
            return this;
        }

        private void EnsureArguments()
        {
            if (_securityKey is null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrWhiteSpace(_subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrWhiteSpace(_issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrWhiteSpace(_audience))
                throw new ArgumentNullException("Audience");
        }
    }
}
