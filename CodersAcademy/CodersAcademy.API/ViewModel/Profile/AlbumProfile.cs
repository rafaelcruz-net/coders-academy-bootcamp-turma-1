using CodersAcademy.API.Model;
using CodersAcademy.API.ViewModel.Request;

namespace CodersAcademy.API.ViewModel.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<MusicRequest, Music>();
            CreateMap<AlbumRequest, Album>();
        }
    }
}
