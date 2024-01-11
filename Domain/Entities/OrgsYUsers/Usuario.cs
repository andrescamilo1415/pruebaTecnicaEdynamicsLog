namespace pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers
{
    public class Usuario
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid OrganizacionId { get; set; }
        public virtual Organizacion Organizacion { get; set; }
    }
}
