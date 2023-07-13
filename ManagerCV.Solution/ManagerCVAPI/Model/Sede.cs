using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerCVAPI.Model
{
    public class Sede
    {
        public int Id { get; set; }
        public string Città { get; set; }
        public string Indirizzo { get; set; }
        public string Provincia { get; set; }
        public string Cap { get; set; }
        public string RecapitoTel { get; set; }
        public string Email { get; set; }

        public Sede()
        {
            Città = string.Empty;
            Indirizzo = string.Empty;
            Provincia = string.Empty;
            Cap = string.Empty;
            RecapitoTel = string.Empty;
            Email = string.Empty;

        }
    }
}
