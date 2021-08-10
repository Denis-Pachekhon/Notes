using System;
using System.ComponentModel.DataAnnotations;

namespace NotesBlazorApp.Contracts
{
    public class Note
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Exceeding the maximum number of characters")]
        public string Title { get; set; }

        [StringLength(3000, ErrorMessage = "Exceeding the maximum number of characters")]
        public string Text { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
