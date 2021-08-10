using Microsoft.EntityFrameworkCore;
using NotesBlazorApp.Data.Entities;

namespace NotesBlazorApp.Data.DB
{
    public class NoteBlazorAppDbContext : DbContext
    {
        public NoteBlazorAppDbContext(DbContextOptions<NoteBlazorAppDbContext> options) : base(options)
        {
        }

        public DbSet<NoteEntity> Notes { get; set; }
    }
}
