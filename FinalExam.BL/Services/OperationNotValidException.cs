
namespace FinalExam.BL.Services
{
    [Serializable]
    internal class OperationNotValidException : Exception
    {
        public OperationNotValidException()
        {
        }

        public OperationNotValidException(string? message) : base(message)
        {
        }

        public OperationNotValidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}