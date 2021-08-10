using Microsoft.EntityFrameworkCore;
using NotesBlazorApp.Data.DB;
using NotesBlazorApp.Data.Entities;
using NotesBlazorApp.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesBlazorApp.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteBlazorAppDbContext _context;

        public NoteRepository(NoteBlazorAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(string title, string text)
        {
            var note = new NoteEntity()
            {
                IsDeleted = false,
                Title = title,
                Text = text,
                DateOfCreation = DateTime.Now
            };

            await _context.AddAsync(note);

            await _context.SaveChangesAsync();
        }

        public async Task<List<NoteEntity>> GetAsync()
        {
            var entities = await _context.Notes
                .Where(n => n.IsDeleted == false)
                .OrderByDescending(n => n.DateOfCreation)
                .ToListAsync();

            return entities;
        }

        public async Task<int> GetCountOfNotes()
        {
            var entities = await _context.Notes
                .Where(n => n.IsDeleted == false)
                .ToListAsync();

            var count = entities.Count;

            return count;
        }

        public async Task<NoteEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            return entity;
        }

        public async Task<List<NoteEntity>> FindNotes(string request)
        {
            var entities = await _context.Notes
                .Where(n => n.IsDeleted == false &&
                n.Title.ToLower().Contains(request.ToLower()) || 
                n.Text.ToLower().Contains(request.ToLower()))
                .OrderByDescending(n => n.DateOfCreation)
                .ToListAsync();

            return entities;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            entity.IsDeleted = true;

            _context.Notes.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<NoteEntity> UpdateAsync(NoteEntity note)
        {
            var result = _context.Update(note);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public bool IsDeleted(int id)
        {
            return _context.Notes.Count(n => n.Id == id && n.IsDeleted == true) > 0;
        }
    }
}
