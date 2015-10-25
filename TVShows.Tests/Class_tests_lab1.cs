using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TVShows.Data;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    [TestFixture]
    public class Class_tests_lab1
    {
        [SetUp]
        public void IntitRepositories()
        {
            User.Repository = new Access_repository<User>(User.Dtable);
            Administrator.Repository = new Access_repository<Administrator>(Administrator.Dtable);
            Tvshow.Repository = new Access_repository<Tvshow>(Tvshow.Dtable);

            User.Init_user();
            Administrator.Init_administrator();
        }

        [Test]
        public void Check_Type_Init_Users()
        {
            var collection = User.Repository.GetAllObjects();
            foreach (var itemUser in collection)
                Assert.IsInstanceOf<User>(itemUser, "Полученый объект User отличается от типа Class_user");
        }

        [Test]
        public void Check_Type_Init_Admins()
        {
            var collection = Administrator.Repository.GetAllObjects();
            foreach (var itemAdmin in collection)
                Assert.IsInstanceOf<Administrator>(itemAdmin, "Полученый объект Admin отличается от типа Administrator");
        }

        [Test]
        public void Check_Is_Null_Initialized_TVShow()
        {
            Tvshow.Init_tv_show();
            foreach (var tvshow in Tvshow.Items)
                Assert.IsNotNull(tvshow, "Полученый объект TVshow ссылается на нулевую ячейку памяти, " +
                                         "загрузка объектов с базы происходит некорректно");
        }

        [Test]
        public void Check_Type_Of_Link_Image_Initialized_TVShow()
        {
            Tvshow randomTvshow = Tvshow.Init_tv_show();
            Assert.IsInstanceOf<string>(randomTvshow.Link_image, "Полученый объект Link_image отличается от типа string");
        }

        private User Construct_User()
        {
            string login = "gerik";
            string password = "qwerty123";
            string email = "gerik@gmail.com";

            return new User(login, password, email);
        }

        [Test]
        public void Add_User_To_Items_Get_User_By_ID_And_Compare()
        {
            User user = Construct_User();
            User.Items.Add(user);

            var getUser = (IUser) User.Get_obj(user.Id);

            Assert.AreEqual(getUser, user, "Метод Get_obj возвратил неверный объект user");

            user.Delete();
        }

        [Test]
        public void Add_User_To_DataBase_And_Check_Contains()
        {
            User user = Construct_User();

            var collection = User.Repository.GetAllObjects();

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

            user.Delete();
        }

        [Test]
        public void User_Not_Deleted()
        {
            User user = Construct_User();
            int idNewUser = user.Id;

            var collection = User.Repository.GetAllObjects();
            int countUsersAfterAdding = collection.Count();

            user.Delete();

            collection = User.Repository.GetAllObjects();
            int countUsersAfterRemoving = collection.Count();

            Assert.Greater(countUsersAfterAdding, countUsersAfterRemoving, 
                "Объект User не удалися с базы");

            foreach (var userGet in collection)
                Assert.AreNotEqual(userGet.Id, idNewUser, "Объект с таким же ID остался в базе");
        }
    }
}
