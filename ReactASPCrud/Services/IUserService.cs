using ReactASPCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);

        User Insert(User obj);

        void Update(int id, User obj);

        void Delete(User id);
    }
}
