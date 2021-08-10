using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesBlazorApp.Data.Entities
{
    [Table("tbl_note")]
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("data_of_creation")]
        public DateTime DateOfCreation { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
