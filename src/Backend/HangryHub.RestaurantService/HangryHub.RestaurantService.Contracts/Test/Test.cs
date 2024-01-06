namespace HangryHub.RestaurantService.Contracts.Test;

public class TestRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class TestResponse
{
    public string FullName { get; set; }
    public bool IsOver18 { get; set; }
}
