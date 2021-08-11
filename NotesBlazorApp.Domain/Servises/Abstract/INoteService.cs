using NotesBlazorApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesBlazorApp.Domain.Servises.Abstract
{
    public interface INoteService
    {
        Task<List<Note>> GetAsync();
        Task<List<Note>> FindNotes(string request);
        Task<Note> UpdateAsync(int id, string title, string text);
        Task AddAsync();
    }
}
