namespace HangryHub.OderService.UseCases.Order
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public PriceDTO PriceEuro { get; set; }
        public AcceptDTO OrderAccepted { get; set; }
        public DeclineDTO OrderDeclined { get; set; }
        public OrderReadyDTO OrderReady { get; set; }
    }
}
