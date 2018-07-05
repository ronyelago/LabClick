using LabClick.Infra.Repositories;

namespace LabClick.Services.Services
{
    class LaudoServices : LaudoRepository
    {
        private readonly LaudoRepository repository;

        public LaudoServices()
        {
            repository = new LaudoRepository();
        }
    }
}
