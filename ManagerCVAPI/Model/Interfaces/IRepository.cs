namespace ManagerCVAPI.Model.Interfaces
{
    public interface IRepository
    {
        public IQueryable<Sede> Sedi { get; }
        public void AddSede(Sede sede) { }
        public void DeleteSede(Sede sede) { }
        public void UpdateSede(Sede sede) { }
    }
}
