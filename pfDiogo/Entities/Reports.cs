
namespace TF.Entities
{
    internal class Reports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Visit> Visits { get; set; } = new List<Visit>();
        public List<Unit> Unities { get; set; } = new List<Unit>();

        public Reports() { }

        public Reports(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
