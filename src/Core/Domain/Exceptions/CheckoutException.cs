namespace FoodOrder.Domain.Exceptions
{
    public class CheckoutException : Exception
    {
        public CheckoutException(string message) : base(message) { }

        public CheckoutException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
