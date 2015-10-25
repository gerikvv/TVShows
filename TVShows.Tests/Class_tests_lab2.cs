using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TVShows.Data;
using TVShows.Data.Classes;

namespace TVShows.Tests
{
    [TestFixture]
    public class Class_tests_lab2
    {
        [SetUp]
        public void IntitRepositories()
        {
            Tvshow.Repository = new Fake_repository<Tvshow>();
            User.Repository = new Fake_repository<User>();
            Administrator.Repository = new Fake_repository<Administrator>();
            Favorites_and_user.Repository = new Fake_repository<Favorites_and_user>();
            Favorites_and_admin.Repository = new Fake_repository<Favorites_and_admin>();
        }

        [SetUp]
        public void ClearItems()
        {
            Tvshow.Items.Clear();
            User.Items.Clear();
            Administrator.Items.Clear();
            Favorites_and_user.Items.Clear();
            Favorites_and_admin.Items.Clear();
        }

        [Test]
        public void AddFavoriteTv_CreateUserAndTv_FavoriteTvAddedToUser()
        {
            // Arrange
            var user = new User();

            // Act
            user.AddFavoriteTv(new Tvshow());
            user.AddFavoriteTv(new Tvshow());

            //Assert
            Assert.AreEqual(Favorites_and_user.Items.Count, 2, "К пользователю не добавился избранный фильм");
        }

        [Test]
        public void AddFavoriteTv_CreateAdminAndTv_FavoriteTvAddedToAdmin()
        {
            // Arrange
            var admin = new Administrator();

            // Act
            admin.AddFavoriteTv(new Tvshow());
            admin.AddFavoriteTv(new Tvshow());

            //Assert
            Assert.AreEqual(Favorites_and_admin.Items.Count, 2, "К администратору не добавился избранный фильм");
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteUser_LinkUserTvRemoved()
        {
            // Arrange
            var user = new User(){Id = 0};
            user.AddFavoriteTv(new Tvshow());
            new Favorites_and_user (new User(){Id = 1}, new Tvshow());

            // Act
            user.Delete();

            //Assert
            bool isContains = Favorites_and_user.Items.Any(favorUser => favorUser.IdUser == user.Id);
            Assert.False(isContains, "Не удалилась связь пользователь-фильм");
        }

        [Test]
        public void Delete_CreateLinkAdminTvAndDeleteAdmin_LinkAdminTvRemoved()
        {
            // Arrange
            var admin = new Administrator() { Id = 0 };
            admin.AddFavoriteTv(new Tvshow());
            new Favorites_and_admin(new Administrator() {Id = 1}, new Tvshow());

            // Act
            admin.Delete();

            //Assert
            bool isContains = Favorites_and_admin.Items.Any(favorAdmin => favorAdmin.IdAdmin == admin.Id);
            Assert.False(isContains, "Не удалилась связь администратор-фильм");
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteLink_LinkUserTvRemoved()
        {
            // Arrange
            new Favorites_and_user(new User(), new Tvshow()) {Id = 0};
            new Favorites_and_user(new User(), new Tvshow()) {Id = 1};

            var favoritesAndUser = new Favorites_and_user(new User(), new Tvshow()) {Id = 2};

            // Act
            favoritesAndUser.Delete();

            //Assert
            bool isContains = Favorites_and_user.Items.Contains(favoritesAndUser);
            Assert.False(isContains, "Не удалилась связь пользователь-фильм");

            Assert.AreEqual(Favorites_and_user.Items.Count, 2, "Не удалилась связь пользователь-фильм");
        }
    }
}
