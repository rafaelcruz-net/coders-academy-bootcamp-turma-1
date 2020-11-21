using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Response
{
    public class FavoriteMusicResponse
    {
        public Guid Id { get; set; }
        public Guid MusicId { get; set; }
        public String Name { get; set; }
        public int Duration { get; set; }
        public String AlbumName { get; set; }
        public String Band { get; set; }
        public String Backdrop { get; set; }
        public String AlbumId { get; set; }
    }
}
