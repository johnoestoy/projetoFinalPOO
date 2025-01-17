using System.Globalization;
using TF.Entities.Enums;


namespace TF.Entities
{
    internal class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public District District { get; set; }
        public UsTypes UsType { get; set; }
        public Zone Zone { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public Unit() { }
        public Unit(int id, string name, int maxCapacity, District district, UsTypes usType, Zone zone)
        {
            Id = id;
            Name = name;
            MaxCapacity = maxCapacity;
            District = district;
            UsType = usType;
            Zone = zone;
        }

    }
}
