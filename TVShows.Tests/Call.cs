using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class Call<T> where T : IBase
    {
        string Description { get; set; }
        IBase Data { get; set; }

        public Call(string description, T data)
        {
            Description = description;
            Data = data;
        } 
    }
}
