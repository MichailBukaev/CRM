using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMDevEducation
{
    public class AuthOptions
    {
        public const string ISSUER = "CRMDevEducation";
        public const string AUDIENCE = "ClientCRMDevEducation"; 
        const string KEY = "tvoyajizn_jopen_qqq_kazalobivse_Uspeh_pizdulina_Coneeec";   
        public const int LIFETIME = 30; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
