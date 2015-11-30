using NUnit.Framework;
using Rhino.Mocks;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    [TestFixture]
    public class Class_tests_lab3
    {
        [SetUp]
        public void IntitRepositories()
        {
            Tvshow.Repository = MockRepository.GenerateMock<IRepository<Tvshow>>();
            User.Repository = MockRepository.GenerateMock<IRepository<User>>();
            Administrator.Repository = MockRepository.GenerateMock<IRepository<Administrator>>();
            Favorites_and_user.Repository = MockRepository.GenerateMock<IRepository<Favorites_and_user>>();
            Favorites_and_admin.Repository = MockRepository.GenerateMock<IRepository<Favorites_and_admin>>();
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
        public void AddFavoriteTv_CreateUserAndTv_FavoriteTvAndUserSavedToDb()
        {
            Favorites_and_user.Repository.Expect(x => x.Save(null)).IgnoreArguments();
            Favorites_and_user.Repository.Expect(x => x.GetId()).Return(Arg<int>.Is.Anything);

            var user = new User();
            
            user.AddFavoriteTv(new Dummy());
            user.AddFavoriteTv(new Dummy());

            Favorites_and_user.Repository.VerifyAllExpectations();
        }

        [Test]
        public void AddFavoriteTv_CreateAdminAndTv_FavoriteTvAndAdminSavedToDb()
        {
            Favorites_and_admin.Repository.Expect(x => x.Save(null)).IgnoreArguments();
            Favorites_and_admin.Repository.Expect(x => x.GetId()).Return(Arg<int>.Is.Anything);

            var admin = new Administrator();

            admin.AddFavoriteTv(new Dummy());
            admin.AddFavoriteTv(new Dummy());

            Favorites_and_admin.Repository.VerifyAllExpectations();
        }

        [Test]
        public void Delete_CreateLinkUserTvAndDeleteUser_LinkUserTvRemoved()
        {
            var user = new User {Id = 1};
            
            Favorites_and_user.Repository = MockRepository.GenerateStrictMock<IRepository<Favorites_and_user>>();

            Favorites_and_user.Repository.Expect(x => x.Save(null)).IgnoreArguments();
            Favorites_and_user.Repository.Expect(x => x.GetId()).Return(Arg<int>.Is.Anything);
            Favorites_and_user.Repository.Expect(x => x.Delete(user.Id));
            
            user.AddFavoriteTv(new Dummy());
            user.Delete();
            
            Favorites_and_user.Repository.VerifyAllExpectations();
        }

        [Test]
        public void Delete_CreateLinkAdminTvAndDeleteAdmin_LinkAdminTvRemoved()
        {
            var admin = new Administrator {Id = 1};

            Favorites_and_admin.Repository = MockRepository.GenerateStrictMock<IRepository<Favorites_and_admin>>();

            Favorites_and_admin.Repository.Expect(x => x.Save(null)).IgnoreArguments();
            Favorites_and_admin.Repository.Expect(x => x.GetId()).Return(Arg<int>.Is.Anything);
            Favorites_and_admin.Repository.Expect(x => x.Delete(admin.Id));

            admin.AddFavoriteTv(new Dummy());
            admin.Delete();

            Favorites_and_admin.Repository.VerifyAllExpectations();
        }

        [Test]
        public void Rate_CreateUserTvAndRateTv_CreatedTvRating()
        {
            var userStub = new UserStub();

            var tv = MockRepository.GeneratePartialMock<Tvshow>();

            tv.Expect(x => x.SetRating(userStub.GetRatingFromWindow().TvRating));
            
            userStub.Rate(tv);

            tv.VerifyAllExpectations();
        }

        [Test]
        public void CalculateNewRating_CreateUsersTvAndRateTv_AverageTvRating()
        {
            var userStub = new UserStub();
            var userStub1 = new UserStub();

            var tv = MockRepository.GeneratePartialMock<Tvshow>();
            tv.Id = 1;

            tv.Expect(x => x.SetRating(userStub.GetRatingFromWindow().TvRating));
            tv.Expect(x => x.SetRating(userStub.GetRatingFromWindow().TvRating));

            userStub.Rate(tv);
            userStub1.Rate(tv);

            tv.VerifyAllExpectations();
        }
    }
}
