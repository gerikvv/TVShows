using System;

namespace TVShows.Data.Interfaces
{
    public interface ITvShow : IBase
    {
        int Year { get; set; }
        string Country { get; set; }
        string Slogan { get; set; }
        string Script_writer { get; set; }
        string Producer { get; set; }
        int Budget { get; set; }
        int Global_charges { get; set; }
        DateTime Time { get; set; }
        double Overall_rating { get; set; }
        string Name_image { get; set; }
        string Link_image { get; set; }
        string Director { get; set; }
    }
}
