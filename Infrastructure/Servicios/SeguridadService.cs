using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pruebaTecnicaEdynamicsLog.Domain.DTOs;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;
using pruebaTecnicaEdynamicsLog.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pruebaTecnicaEdynamicsLog.Infrastructure.Servicios
{
    public class SeguridadService: ISeguridadService
    {
        private readonly DbContextOrgsYUsers _contexto;

        public SeguridadService(DbContextOrgsYUsers contexto)
        {

            // this.appSettings = appSettings.Value;
            this._contexto = contexto;
        }

        public async Task<string> Autenticar(AutenticarRqst obj)
        {
            var usrTmp = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Email == obj.email);

            if (usrTmp != null)
            {
                if (usrTmp.Password.Equals(obj.password))
                {
                    var empresa = await _contexto.Organizaciones.FirstAsync(x => x.Id == usrTmp.OrganizacionId);
                    var token = GetToken(usrTmp, empresa);
                    return token;
                }
            }
            return string.Empty;
        }

        private string GetToken(Usuario usr, Organizacion org)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes("estaEsLaLlavePrivadaDelServidorYDebeSerMuyLargaYNopuedeEstarQuemadaEnElCodigo");// esta llave es la misma que esta en el program.cs, por tiempo se quema en codigo

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new System.Security.Claims.Claim[]
                {
                  new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()),   // este es el Id del usuario
                  new Claim(ClaimTypes.Email, usr.Email),
                  new Claim("Organizacion", org.Name),
                  new Claim("SlugTenant", org.SlugTenant),
                }
                ),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
