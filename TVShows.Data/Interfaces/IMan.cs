namespace TVShows.Data.Interfaces
{
    public interface IMan : IBase
    {
        string Password { get; set; }
        string Email { get; set; }
    }
}
