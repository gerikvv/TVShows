namespace TVShows.Data.Classes
{
    public class Rating
    {
        public int TvRating { get; set; }

        Rating(){}

        public Rating(int rating) :this()
        {
            TvRating = rating;
        }
    }
}
