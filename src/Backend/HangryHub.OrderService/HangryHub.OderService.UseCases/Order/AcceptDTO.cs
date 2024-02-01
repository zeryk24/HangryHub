namespace HangryHub.OderService.UseCases.Order
{
    public class AcceptDTO
    {
        public bool IsAccepted { get; set; }
        public DateTime? Date { get; set; }

        public AcceptDTO(bool isAccepted, DateTime? date)
        {
            IsAccepted = isAccepted;
            Date = date;
        }
    }
}
