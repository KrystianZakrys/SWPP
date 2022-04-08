using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Domain.Entities
{
    public class Module : BaseEntity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public double AssemblyTime { get; private set; }
        public double Weight { get; private set; }
        public string Description { get; private set; }
        public virtual List<SearchHistory> SearchHistories { get; private set; } = new List<SearchHistory>();

        public Module() { }

        public static Module Create(string code, string name, double price, double assemblyTime, double weight, string description)
        {
            return new Module()
            {
                Code = code,
                Name = name,
                Price = price,
                AssemblyTime = assemblyTime,
                Weight = weight,
                Description = description,
            };
        }

        public void Update(string code, string name, double price, double assemblyTime, double weight, string description)
        {
            Code = code;
            Name = name;
            Price = price;
            AssemblyTime = assemblyTime;
            Weight = weight;
            Description = description;
        }
    }
}
