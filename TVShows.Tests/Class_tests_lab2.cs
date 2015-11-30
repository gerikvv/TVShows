using System.Linq;
using NUnit.Framework;
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
            User_and_Rating.Items.Clear();
        }

        [Test]
        public void AddFavoriteTv_CreateUserAndTv_FavoriteTvAddedToUser()
        {
            // Arrange
            var userSpy = new UserSpy();

            // Act
            userSpy.AddFavoriteTv(new Dummy());
            userSpy.AddFavoriteTv(new Dummy());

            //Assert
            Assert.AreEqual(2, userSpy.Calls.Count, "К пользователю не добавился избранный фильм");
        }

        [Test]
        public void AddFavoriteTv_CreateAdminAndTv_FavoriteTvAddedToAdmin()
        {
            // Arrange
            var admin = new AdministratorSpy();

            // Act
            admin.AddFavoriteTv(new Dummy());
            admin.AddFavoriteTv(new Dummy());

            //Assert
            Assert.AreEqual(2, admin.Calls.Count, "К администратору не добавился избранный фильм");
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteUser_LinkUserTvRemoved()
        {
            // Arrange
            var user = new User {Id = 0};
            user.AddFavoriteTv(new Dummy());
            new Favorites_and_user(new User { Id = 1 }, new Dummy());

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
            var admin = new Administrator { Id = 0 };
            admin.AddFavoriteTv(new Dummy());
            new Favorites_and_admin(new Administrator { Id = 1 }, new Dummy());

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
            new Favorites_and_user(new Dummy(), new Dummy());
            new Favorites_and_user(new Dummy(), new Dummy());

            var favoritesAndUser = new Favorites_and_user(new Dummy(), new Dummy());

            // Act
            favoritesAndUser.Delete();

            //Assert
            bool isContains = Favorites_and_user.Items.Contains(favoritesAndUser);
            Assert.False(isContains, "Не удалилась связь пользователь-фильм");

            Assert.AreEqual(Favorites_and_user.Items.Count, 2, "Не удалилась связь пользователь-фильм");
        }

        [Test]
        public void Rate_CreateUserTvAndRateTv_CreatedTvRating()
        {
            // Arrange
            var userStub = new UserStub();
            var tv = new Tvshow {Id = 1};
            
            // Act
            userStub.Rate(tv);

            //Assert
            Assert.NotNull(tv.GetRating(), "Рейтинг фильма не обновился");
        }

        [Test]
        public void CalculateNewRating_CreateUsersTvAndRateTv_AverageTvRating()
        {
            // Arrange
            var userStub = new UserStub();
            var userStub1 = new UserStub();

            var tv = new Tvshow {Id = 1};

            // Act
            userStub.Rate(tv);
            userStub1.Rate(tv);

            //Assert
            Assert.AreEqual( tv.GetRating(), userStub.GetRatingFromWindow().TvRating, "Рейтинг фильма посчитан неверно");
        }

        [Test]
        public void Rate_CreateUsersTvAndRateTv_TwoUsersRated()
        {
            // Arrange
            var userStub = new UserStub();
            var userStub1 = new UserStub();

            var tv = new TvSpy() { Id = 1 };

            // Act
            userStub.Rate(tv);
            userStub1.Rate(tv);

            //Assert
            Assert.AreEqual(2, tv.Calls.Count, "Rate работает неверно, оценка не добавляется к фильму");
        }

        [Test]
        public void IsRated_CreateUserTvAndRateTv_IsRatedEqualTrue()
        {
            // Arrange
            var user = new UserStub {Id = 1};
            var tv = new Tvshow {Id = 1};

            // Act
            user.Rate(tv);

            //Assert
            Assert.True(User_and_Rating.IsRated(user, tv), "Фильм не был оценен");
        }
    }
}
