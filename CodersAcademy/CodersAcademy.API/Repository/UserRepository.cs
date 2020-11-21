using CodersAcademy.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Repository
{
    public class UserRepository
    {
        private MusicContext Context { get; set; }

        public UserRepository(MusicContext context)
        {
            this.Context = context;
        }

        public async Task CreateAsync(User user)
        {
            await this.Context.Users.AddAsync(user);
            await this.Context.SaveChangesAsync();
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            return await this.Context.Users
                               .Include(x => x.FavoriteMusics)
                               .ThenInclude(x => x.Music)
                               .ThenInclude(x => x.Album)
                               .Where(x => x.Password == password && x.Email == email)
                               .FirstOrDefaultAsync();
        }
    }
}
