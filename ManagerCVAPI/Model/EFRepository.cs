using ManagerCVAPI.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagerCVAPI.Model
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;
        public EFRepository(ApplicationDbContext context) => this.context = context;
        public IQueryable<Sede> Sedi => context.Sedi;
        public void AddSede(Sede newSede)
        {
            context.Sedi.Add(newSede);
            context.SaveChanges();
        }
        public void DeleteSede(int id)
        {
            context.Sedi
                .Where(s => s.Id.Equals(id))
                .ExecuteDeleteAsync();
        }
        public void UpdateSede(Sede editedSede)
        {
            context.Sedi
                .Where(x => x.Id.Equals(editedSede.Id))
                .ExecuteUpdateAsync<Sede>(x =>
                x.SetProperty(x => x.Indirizzo, x => editedSede.Indirizzo)
                .SetProperty(x => x.Città, x => editedSede.Città)
                .SetProperty(x => x.Provincia, x => editedSede.Provincia)
                .SetProperty(x => x.Cap, x => editedSede.Cap)
                .SetProperty(x => x.RecapitoTel, x => editedSede.RecapitoTel)
                .SetProperty(x => x.Email, x => editedSede.Email)
                );

        }

    }
}
