using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Models
{
    public class AuthenticateResponse: User
    {
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            this.Token = token;

            this.Id = user.Id;
            this.Name = user.Name;
            this.Document = user.Document;
            this.Email = user.Email;
            this.Phone = user.Phone;
        }
    }
}
