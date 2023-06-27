using Apanvi.API.Models;
using System.Collections.Concurrent;

namespace Apanvi.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ConcurrentBag<User> _usersDb = new ConcurrentBag<User>();

        public UserRepository()
        {
            _usersDb.Add(new User("Daiana", "SuperAdmin")); //user eh uma funcao q pede esses parametros entao temos q passar o parametro com valor direto, senao estariamos criando novos
            _usersDb.Add(new User("Renata", "Admin"));
        }
        public List<User> GetAll()
        {
            var users = _usersDb.ToList();
            return users;
        }
    }

    
}


