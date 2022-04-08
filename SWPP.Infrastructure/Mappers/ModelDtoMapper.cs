using SWPP.Infrastructure.Dto.Model;

namespace SWPP.WebApi.Mappers
{
    public class ModelDtoMapper
    {
        private Domain.Entities.Module Module;

        public static ModelDtoMapper For(Domain.Entities.Module module)
        {
            return new ModelDtoMapper()
            {
                Module = module
            };
        }

        public ModuleDetailsDto Map()
        {
            return new ModuleDetailsDto()
            {
                Code = Module.Code,
                Name = Module.Name,
                Price = Module.Price,
                AssemblyTime = Module.AssemblyTime,
                Weight = Module.Weight,
                Description = Module.Description,
            };
        }
    }
}
