using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using TVShows.Data;

namespace TVShows.Tests
{
    [TestFixture]
    public class Class_tests
    {
        [Test]
        public void Check_Type_Init_Users()
        {
            var user = new Class_user();
            var collection = user.Get(Class_user.Dtable);
            foreach (var itemUser in collection)
                Assert.IsInstanceOf<Class_user>(itemUser, "Полученый объект User отличается от типа Class_user");
        }

        [Test]
        public void Check_Type_Init_Admins()
        {
            var user = new Class_administrator();
            var collection = user.Get(Class_administrator.Dtable);
            foreach (var itemAdmin in collection)
                Assert.IsInstanceOf<Class_administrator>(itemAdmin, "Полученый объект Admin отличается от типа Class_administrator");
        }

        [Test]
        public void Check_Is_Null_Initialized_TVShow()
        {
            Class_tvshow.Init_tv_show();
            foreach (var tvshow in Class_tvshow.Items)
                Assert.IsNotNull(tvshow, "Полученый объект TVshow ссылается на нулевую ячейку памяти, " +
                                         "загрузка объектов с базы происходит некорректно");
        }

        [Test]
        public void Check_Type_Of_Link_Image_Initialized_TVShow()
        {
            Class_tvshow randomTvshow = Class_tvshow.Init_tv_show();
            Assert.IsInstanceOf<string>(randomTvshow.Link_image, "Полученый объект Link_image отличается от типа string");
        }

        private Class_user Construct_User()
        {
            string login = "gerik";
            string password = "qwerty123";
            string email = "gerik@gmail.com";

            return new Class_user(login, password, email);
        }

        [Test]
        public void Add_User_To_Items_Get_User_By_ID_And_Compare()
        {
            Class_user user = Construct_User();
            Class_user.Items.Add(user);

            Class_user getUser = Class_user.Get_obj(user.Id);

            Assert.AreEqual(getUser, user, "Метод Get_obj возвратил неверный объект user");

            user.Delete(Class_user.Dtable, user.Id);
        }

        [Test]
        public void Add_User_To_DataBase_And_Check_Contains()
        {
            Class_user user = Construct_User();

            ObservableCollection<Class_man> collection = user.Get(Class_user.Dtable);

            List<int> idList = new List<int>();
            List<string> names = new List<string>();
            List<string> passwords = new List<string>();
            List<string> emails = new List<string>();

            foreach (var userGet in collection)
            {
                idList.Add(userGet.Id);
                names.Add(userGet.Name);
                passwords.Add(userGet.Password);
                emails.Add(userGet.Email);
            }

            Assert.Contains(user.Id, idList, "Объект User не добавился в базу или метод Get работает некорректно " +
                                             "(нету объекта с таким же ID в базе)");
            Assert.Contains(user.Name, names, "Объект User не добавился в базу или метод Get работает некорректно" +
                                              "(нету объекта с таким же Name в базе)");
            Assert.Contains(user.Password, passwords, "Объект User не добавился в базу или метод Get работает некорректно" +
                                                      "(нету объекта с таким же Password в базе)");
            Assert.Contains(user.Email, emails, "Объект User не добавился в базу или метод Get работает некорректно" +
                                                "(нету объекта с таким же Email в базе)");

            bool isIdNewUserInIdList = idList.Contains(user.Id);
            bool isNameNewUserInNames = names.Contains(user.Name);
            bool isPasswordNewUserInPasswords = passwords.Contains(user.Password);
            bool isEmailNewUserInEmails = emails.Contains(user.Email);

            Assert.True(isIdNewUserInIdList, "Объект User не добавился в базу или метод Get работает некорректно");
            Assert.True(isNameNewUserInNames, "Объект User не добавился в базу или метод Get работает некорректно");
            Assert.True(isPasswordNewUserInPasswords, "Объект User не добавился в базу или метод Get работает некорректно");
            Assert.True(isEmailNewUserInEmails, "Объект User не добавился в базу или метод Get работает некорректно");

            user.Delete(Class_user.Dtable, user.Id);
        }

        [Test]
        public void User_Not_Deleted()
        {
            Class_user user = Construct_User();
            int idNewUser = user.Id;

            ObservableCollection<Class_man> collection = user.Get(Class_user.Dtable);
            int countUsersAfterAdding = collection.Count();

            user.Delete(Class_user.Dtable, user.Id);

            collection = user.Get(Class_user.Dtable);
            int countUsersAfterRemoving = collection.Count();

            Assert.Greater(countUsersAfterAdding, countUsersAfterRemoving, 
                "Объект User не удалися с базы");

            foreach (var userGet in collection)
                Assert.AreNotEqual(userGet.Id, idNewUser, "Объект с таким же ID остался в базе");
        }
    }
}
