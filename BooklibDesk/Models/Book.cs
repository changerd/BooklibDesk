using System.ComponentModel.DataAnnotations.Schema;

namespace BooklibDesk.Models
{
    [Table("books", Schema = "public")]
    public class Book
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("year")]
        public int Year { get; set; }
    }
}
