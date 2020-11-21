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

        public async Task<User> GetUserAsync(Guid id)
            => await this.Context.Users
                                 .Include(x => x.FavoriteMusics)
                                 .ThenInclude(x => x.Music)
                                 .ThenInclude(x => x.Album)
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IList<User>> GetAllAsync()
            => await this.Context.Users
                                 .Include(x => x.FavoriteMusics)
                                 .ThenInclude(x => x.Music)
                                 .ThenInclude(x => x.Album).ToListAsync();
        

        public async Task UpdateAsync(User user)
        {
            this.Context.Users.Update(user);
            await this.Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(User user)
        {
            this.Context.Users.Remove(user);
            await this.Context.SaveChangesAsync();
        }
    }
}
