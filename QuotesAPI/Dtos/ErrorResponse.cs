using System.Collections.Generic;

namespace QuotesAPI.Dtos
{
    public class ErrorResponse
    {
        public List<ErrorMessage> ErrorMessages { get; set; } = new List<ErrorMessage>();
    }
}