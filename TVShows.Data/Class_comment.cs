using System;

namespace TVShows.Data
{
    public class Class_comment : Class_base<Class_comment>
    {
        public static string Dtable = "Comments";

        public int IdUser;
        public int IdTVShow;
        public string Comment;

        public override object[] Objparams
        {
            get
            {
                objects = new object[4];
                objects[0] = Id;
                objects[1] = IdUser;
                objects[2] = IdTVShow;
                objects[3] = Comment;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdUser = (int)objects[1];
                IdTVShow = (int)objects[2];
                Comment = (string) objects[3];
            }
        }

        public Class_user User
        {
            get { return (Class_user) Class_user.Items[IdUser]; }
            set { IdUser = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Class_comment(){}

        public Class_comment(Class_user user, Class_tvshow tvshow, string comment)
        {
            User = user;
            Tvshow = tvshow;
            Comment = comment;
            Save();
        }
    }
}
