using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodersAcademy.API.Model
{
    public class UserFavoriteMusic
    {
        public Guid  Id { get; set; }
        public Guid MusicId { get; set; }
        public Guid UserId { get; set; }
        public Music Music { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
