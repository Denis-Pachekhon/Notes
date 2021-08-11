using AutoMapper;
using NotesBlazorApp.Data.Repositories.Abstract;
using NotesBlazorApp.Domain.Exception;
using NotesBlazorApp.Domain.Models;
using NotesBlazorApp.Domain.Servises.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesBlazorApp.Domain.Servises
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public NoteService(
            IMapper mapper,
            INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task AddAsync()
        {
            string title = "Title";
            string text = "Text";
            await _noteRepository.AddAsync(title, text);
        }

        public async Task<List<Note>> GetAsync()
        {
            var noteEntities = await _noteRepository.GetAsync();

            return _mapper.Map<List<Note>>(noteEntities);
        }

        public async Task<List<Note>> FindNotes(string request)
        {
            var noteEntities = await _noteRepository.FindNotes(request);

            return _mapper.Map<List<Note>>(noteEntities);
        }

        public async Task<Note> UpdateAsync(int id, string title, string text)
        {
            if (IsDeleted(id))
            {
                throw new ValidationException("Bad id");
            }

            var noteEntity = await _noteRepository.GetByIdAsync(id);

            if (noteEntity == null)
            {
                throw new ValidationException($"Note not found, noteId = {id}");
            }

            if (title == null)
            {
                throw new ValidationException("Invalid store title");
            }

            if (text == null)
            {
                throw new ValidationException("Invalid store text");
            }

            noteEntity.Title = title;
            noteEntity.Text = text;

            await _noteRepository.UpdateAsync(noteEntity);

            return _mapper.Map<Note>(noteEntity);
        }

        private bool IsDeleted(int id)
        {
            return _noteRepository.IsDeleted(id);
        }
    }
}
