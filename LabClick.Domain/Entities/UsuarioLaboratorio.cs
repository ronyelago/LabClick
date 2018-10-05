namespace LabClick.Domain.Entities
{
    public class UsuarioLaboratorio : Usuario
    {
        public int LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }
    }
}
