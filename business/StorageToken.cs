using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace business
{
    public class Node
    {
        public string Value;

        public Node Next;

        public Node(string value)
        {
            this.Value = value;
            Next = null;
        }
    }

    public static class StorageToken
    {
        public static Node Root;
 
        public static void Add(string _token)
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

        public static bool Check(string input)
        {
            Node temp = Root;
            while (temp != null)
            {
                if (temp.Value == input)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public static bool Delete(string input)
        {
            if (input == Root.Value)
            {
                Root = Root.Next;
                return true;
            }
            else
            {
                Node temp = Root;
                while (temp.Next != null)
                {
                    if (temp.Next.Value == input)
                    {
                        temp.Next = temp.Next.Next;
                        return true;
                    }
                    temp = temp.Next;
                }
            }
           
           
            return false;
        }

        public static int GetId(string input)
        {
            var jwtEncodedString = input.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            int id = Convert.ToInt32(token.Claims.First(c => c.Type == "Id").Value);
            return id;
        }
        public static string GetRole(string input)
        {
            var jwtEncodedString = input.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            string role = token.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
            return role;
        }
    }
}
