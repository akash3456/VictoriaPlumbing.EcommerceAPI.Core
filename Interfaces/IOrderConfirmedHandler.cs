namespace VictoriaPlumbing.EcommerceAPI.Core.Interfaces
{
    public interface IOrderConfirmedHandler
    {
        Result Handle(Order order);
    }

    public struct Result
    {
        public bool IsSuccess { get; set; }

        public bool IsFailure { get; set; }

        public string Message { get; set; }
    }


}
