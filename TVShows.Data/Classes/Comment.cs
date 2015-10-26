using System;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class Comment : Base<Comment>
    {
        public static string Dtable = "Comments";

        public int IdUser;
        public int IdTVShow;
        public string Commentary;

        public override object[] Objparams
        {
            get
            {
                objects = new object[4];
                objects[0] = Id;
                objects[1] = IdUser;
                objects[2] = IdTVShow;
                objects[3] = Commentary;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdUser = (int)objects[1];
                IdTVShow = (int)objects[2];
                Commentary = (string)objects[3];
            }
        }

        public IUser Usercomment
        {
            get { return User.Items[IdUser]; }
            set { IdUser = value.Id; }
        }

        public Tvshow Tvshowcommnet
        {
            get { return Tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Comment(){}

        public Comment(User user, Tvshow tvshow, string comment)
        {
            Usercomment = user;
            Tvshowcommnet = tvshow;
            Commentary = comment;
            Save();
        }
    }
}
