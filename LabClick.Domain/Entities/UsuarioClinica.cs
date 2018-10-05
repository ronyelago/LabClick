namespace LabClick.Domain.Entities
{
    public class UsuarioClinica : Usuario
    {
        public int ClinicaId { get; set; }
        public virtual  Clinica Clinica { get; set; }
    }
}
