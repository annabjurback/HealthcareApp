namespace HealthCare.WebApp.Services;

public class UserDataService
{
    private string _userId;

    public void SetUserId(string userId)
    {
        _userId = userId;
    }

    public string GetUserId()
    {
        return _userId;
    }
}
