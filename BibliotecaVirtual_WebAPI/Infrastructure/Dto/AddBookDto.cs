using BibliotecaVirtual_DataAccessLayer.Models;

namespace BibliotecaVirtual_WebAPI.Infrastructure.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string? Synopsis { get; set; }
        public int Amount { get; set; }
        public DateTime PublicacionDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
