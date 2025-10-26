using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Domain.Repositories;

namespace OrganizedScannApi.Application.UseCases.Motorcycles
{
    public class MotorcycleService
    {
        private readonly IMotorcycleRepository _repository;

        public MotorcycleService(IMotorcycleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Motorcycle>> GetAllAsync(string? brand = null, int? year = null)
        {
            var allMotorcycles = await _repository.GetAllAsync();
            var motorcycles = allMotorcycles.ToList();

            if (!string.IsNullOrWhiteSpace(brand))
                motorcycles = motorcycles.Where(m => m.Brand == brand).ToList();

            if (year.HasValue)
                motorcycles = motorcycles.Where(m => m.Year == year.Value).ToList();

            return motorcycles;
        }

        public async Task<Motorcycle?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<Motorcycle> CreateAsync(Motorcycle motorcycle)
        {
            await _repository.AddAsync(motorcycle);
            return motorcycle;
        }

        public async Task UpdateAsync(int id, Motorcycle motorcycle)
        {
            motorcycle.Id = id;
            await _repository.UpdateAsync(motorcycle);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
