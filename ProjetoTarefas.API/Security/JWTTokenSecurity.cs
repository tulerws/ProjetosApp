using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetosApp.API.Security
{
  public static class JWTTokenSecurity
  {
     /// <summary>
     /// Chave secreta para assinatura dos Tokens ( Chave antifalsificatória )
     /// </summary>
     public static string SecurityKey => "205A101E-73DB-4100-9211-58E3E877261D";
      
     public static int ExpirationInHours => 1;

     public static string GenerateToken(Guid userId)
     {
         //convertendo a chave secreta para formato bytes
         var tokenHandler = new JwtSecurityTokenHandler();
         var key = Encoding.ASCII.GetBytes(SecurityKey);

         //criando o token JWT
         var tokenDescriptor = new SecurityTokenDescriptor
         {
             //adicionar o ID do usuário (identificação do usuário
             Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userId.ToString()) }),

             //definindo a data e hora de expiração do token
             Expires = DateTime.UtcNow.AddHours(ExpirationInHours),

             //adicionar a chave secreta antifalsificação do TOKEN
             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                 SecurityAlgorithms.HmacSha256Signature)
         };

         //retornando o TOKEN
         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
     }
  }
}
