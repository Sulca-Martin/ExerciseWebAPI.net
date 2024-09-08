using BibliotecaVirtual_DataAccessLayer.Models;

namespace BibliotecaVirtual_WebAPI.Infrastructure.Dto
{
    public class CreateLoanDto
    {
        public int UserId { get; set; }
        public int ReturnDateId { get; set; }
        public string LoanNumber { get; set; }
        public DateTime LoanDate { get; set; }
        public string? Description { get; set; }
        public List<LoanItemDto> LoanItems { get; set; }
    }

    public class LoanItemDto
    {
        public int BookId { get; set; }
        public int Amount { get; set; }
    }

}
