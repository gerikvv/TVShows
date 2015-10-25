using System;

namespace TVShows.Data.Interfaces
{
     public interface IBase
     {
         int Id { get; set; }
         string Name { get; set; }

         Object[] Objparams { get; set; }
    }
}
