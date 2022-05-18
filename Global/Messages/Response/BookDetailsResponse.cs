using Global.Messages.Request;
using Global.Models.DTO;


namespace Global.Messages.Response
{
    public class BookDetailsResponse : BaseMessage
    {
        public BookDetailsResponse() : base() { }
        public BookDetailsResponse(BookDetailsRequest arg) : base(arg) { }
        public BookDetailsDTO BookDetails { get; set; }
    }
}
