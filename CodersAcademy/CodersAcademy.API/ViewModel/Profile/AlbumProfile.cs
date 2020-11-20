using CodersAcademy.API.Model;
using CodersAcademy.API.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
