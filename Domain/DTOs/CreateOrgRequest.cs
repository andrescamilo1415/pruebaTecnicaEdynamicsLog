namespace pruebaTecnicaEdynamicsLog.Domain.DTOs
{
    public class CreateOrgRequest
    {

        public string orgName {  get; set; }
        public string orgSlug { get; set; } 

        public string email { get; set; }
        public string password { get; set; }
    }
}
