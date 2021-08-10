using AutoMapper;
using NotesBlazorApp.Contracts;

namespace NotesBlazorApp.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NotesBlazorApp.Domain.Models.Note>().ReverseMap();
        }
    }
}
