using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace business
{
    public class Node
    {
        public JwtSecurityToken Value;

        public Node Next;

        public Node(JwtSecurityToken value)
        {
            this.Value = value;
            Next = null;
        }
    }

    public static class StorageToken
    {
        public static Node Root;
 
        public static void Add(JwtSecurityToken _token)
        {
            if (Root == null)
            {
                Root = new Node(_token);
            }
            else
            {
                Root.Next = new Node(_token);
            }
        }

    }
}
