using NotesBlazorApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesBlazorApp.Data.Repositories.Abstract
{
    public interface INoteRepository
    {
        Task<List<NoteEntity>> GetAsync();
        Task<NoteEntity> GetByIdAsync(int id);
        Task<List<NoteEntity>> FindNotes(string request);
        Task<int> GetCountOfNotes();
        Task<NoteEntity> UpdateAsync(NoteEntity note);
        Task RemoveAsync(int id);
        Task AddAsync(string title, string text);

        bool IsDeleted(int id);
    }
}
