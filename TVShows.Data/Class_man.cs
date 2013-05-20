using System;

namespace TVShows.Data
{
    public class Class_man : Class_base<Class_man>
    {
        public string Password { get; set; }
        public string Email { get; set; }

        public override object[] Objparams
        {
            get
            {
                objects = new object[4];
                objects[0] = Id;
                objects[1] = Name;
                objects[2] = Password;
                objects[3] = Email;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
                Password = (string)objects[2];
                Email = (string)objects[3];
            }
        }

        protected void Login (string username_arg, int password_arg)
        {
        }

        protected void Logout (string username_arg, int password_arg)
        {
        }

        protected void View_information_tv_show (string name_tv_show)
        {
        }

        protected void Search_tv_shows(params object[] list_params)
        {
        }
    }
}
