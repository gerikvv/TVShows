using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TVShows.Data;

namespace TVShows.Tests
{
    [TestFixture]
    public class Class_tests_lab2
    {
        [SetUp]
        public void IntitRepositories()
        {
            Class_tvshow.Repository = new Fake_repository<Class_tvshow>();
            Class_user.Repository = new Fake_repository<Class_user>();
            Class_administrator.Repository = new Fake_repository<Class_administrator>();
            Class_favorites_and_user.Repository = new Fake_repository<Class_favorites_and_user>();
            Class_favorites_and_admin.Repository = new Fake_repository<Class_favorites_and_admin>();
        }

        [SetUp]
        public void ClearItems()
        {
            Class_tvshow.Items.Clear();
            Class_user.Items.Clear();
            Class_administrator.Items.Clear();
            Class_favorites_and_user.Items.Clear();
            Class_favorites_and_admin.Items.Clear();
        }

        [Test]
        public void AddFavoriteTv_CreateUserAndTv_FavoriteTvAddedToUser()
        {
            // Arrange
            var user = new Class_user();

            // Act
            user.AddFavoriteTv(new Class_tvshow());
            user.AddFavoriteTv(new Class_tvshow());

            //Assert
            Assert.AreEqual(Class_favorites_and_user.Items.Count, 2, "К пользователю не добавился избранный фильм");
        }

        [Test]
        public void AddFavoriteTv_CreateAdminAndTv_FavoriteTvAddedToAdmin()
        {
            // Arrange
            var admin = new Class_administrator();

            // Act
            admin.AddFavoriteTv(new Class_tvshow());
            admin.AddFavoriteTv(new Class_tvshow());

            //Assert
            Assert.AreEqual(Class_favorites_and_admin.Items.Count, 2, "К администратору не добавился избранный фильм");
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteUser_LinkUserTvRemoved()
        {
            // Arrange
            var user = new Class_user(){Id = 0};
            user.AddFavoriteTv(new Class_tvshow());
            new Class_favorites_and_user (new Class_user(){Id = 1}, new Class_tvshow());

            // Act
            user.Delete();

            //Assert
            bool isContains = Class_favorites_and_user.Items.Any(favorUser => favorUser.IdUser == user.Id);
            Assert.False(isContains, "Не удалилась связь пользователь-фильм");
        }

        [Test]
        public void Delete_CreateLinkAdminTvAndDeleteAdmin_LinkAdminTvRemoved()
        {
            // Arrange
            var admin = new Class_administrator() { Id = 0 };
            admin.AddFavoriteTv(new Class_tvshow());
            new Class_favorites_and_admin(new Class_administrator() {Id = 1}, new Class_tvshow());

            // Act
            admin.Delete();

            //Assert
            bool isContains = Class_favorites_and_admin.Items.Any(favorAdmin => favorAdmin.IdAdmin == admin.Id);
            Assert.False(isContains, "Не удалилась связь администратор-фильм");
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteLink_LinkUserTvRemoved()
        {
            // Arrange
            new Class_favorites_and_user(new Class_user(), new Class_tvshow()) {Id = 0};
            new Class_favorites_and_user(new Class_user(), new Class_tvshow()) {Id = 1};

            var favoritesAndUser = new Class_favorites_and_user(new Class_user(), new Class_tvshow()) {Id = 2};

            // Act
            favoritesAndUser.Delete();

            //Assert
            bool isContains = Class_favorites_and_user.Items.Contains(favoritesAndUser);
            Assert.False(isContains, "Не удалилась связь пользователь-фильм");

            Assert.AreEqual(Class_favorites_and_user.Items.Count, 2, "Не удалилась связь пользователь-фильм");
        }
    }
}
