using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace business
{
    public class StorageToken
    {
        List<JwtSecurityToken> tokens { get; }

        public void Add(JwtSecurityToken _token)
        {
            tokens.Add(_token);
        }

    }
}
