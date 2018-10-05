namespace LabClick.Domain.Entities
{
    public class UsuarioClinica
    {
        public int UsuarioId { get; set; }
        public int ClinicaId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual  Clinica Clinica { get; set; }
        public string Perfil { get; set; }
    }
}
