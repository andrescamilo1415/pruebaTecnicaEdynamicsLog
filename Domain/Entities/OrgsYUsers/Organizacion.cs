namespace pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers
{
    public class Organizacion
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SlugTenant { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
