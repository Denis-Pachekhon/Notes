using AutoMapper;
using NotesBlazorApp.Data.Entities;
using NotesBlazorApp.Domain.Models;

namespace NotesBlazorApp.Domain.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteEntity>()
                .ForMember(dest => dest.Id, memberOptions: opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, memberOptions: opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Text, memberOptions: opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DateOfCreation, memberOptions: opt => opt.MapFrom(src => src.DateOfCreation))
                .ReverseMap();
        }
    }
}
