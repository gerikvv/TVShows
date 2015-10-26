using System.Collections.Generic;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class AdministratorSpy : IAdministrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object[] Objparams { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Call<IAdministrator>> Calls = new List<Call<IAdministrator>>();

        public void Save()
        {
            Calls.Add(new Call<IAdministrator>("Save", this));
        }

        public void Delete()
        {
            Calls.Add(new Call<IAdministrator>("Delete", this));
        }

        public void Update()
        {
            Calls.Add(new Call<IAdministrator>("Update", this));
        }

        public void AddFavoriteTv(ITvShow tvshow)
        {
            Calls.Add(new Call<IAdministrator>("AddFavoriteTv", this));
            new Favorites_and_admin(this, tvshow);
        }
    }
}
