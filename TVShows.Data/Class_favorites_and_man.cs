﻿using System;
using System.Collections.ObjectModel;

namespace TVShows.Data
{
    public class Class_favorites_and_man : Class_base<Class_favorites_and_man>
    {
        public static string Dtable = "Favorites_and_Mans";

        public int IdMan;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdTVShow;
                objects[2] = IdMan;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdTVShow = (int)objects[1];
                IdMan = (int)objects[2];
            }
        }

        public Class_man Man
        {
            get { return Class_man.Get_obj(IdMan); }
            set { IdMan = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Class_favorites_and_man(Class_man user, Class_tvshow tvshow)
        {
            Man = user;
            Tvshow = tvshow;
            Save(Dtable);
        }

        public Class_favorites_and_man(){}

        public static ObservableCollection<Class_favorites_and_man> Init_favorites_and_man()
        {
            var favoritesAndMan = new Class_favorites_and_man();
            Items = favoritesAndMan.Get(Dtable);
            return Items;
        }
    }
}