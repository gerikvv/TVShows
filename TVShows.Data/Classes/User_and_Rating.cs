using System.Collections.Generic;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class User_and_Rating : Base<User_and_Rating>
    {
        public Rating Rating;

        public IUser UserRate { get; set; }
        public ITvShow TvRate { get; set; }

        public User_and_Rating(){}

        public User_and_Rating(IUser user, ITvShow tvshow, Rating rating)
        {
            UserRate = user;
            TvRate = tvshow;
            Rating = rating;

            Items.Add(this);

            CalculateNewRating();
        }

        public static bool IsRated(IUser user, ITvShow tvshow)
        {
            return Items.Any(user_and_rating => user_and_rating.UserRate.Id == user.Id && user_and_rating.TvRate.Id == tvshow.Id);
        }

        private void CalculateNewRating()
        {
            var ratings = new List<int> { Rating.TvRating };

            foreach (var user_and_rating in Items)
            {
                if (user_and_rating.TvRate.Id == TvRate.Id)
                {
                    ratings.Add(user_and_rating.Rating.TvRating);
                }
            }

            var new_rating = ratings.Average();

            TvRate.Rating = new_rating;
        }
    }
}
