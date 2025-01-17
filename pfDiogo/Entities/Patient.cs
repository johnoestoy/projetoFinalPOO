using System.Globalization;
using TF.Entities.Enums;

namespace TF.Entities
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bed { get; set; }
        public int NumeroSaude { get; set; }
        public DateTime EntryDate { get; set; }
        public DiseaseTypes Disease { get; set; }
        


        public Patient() { }
        public Patient(int id, string name, DateTime entryDate, DiseaseTypes disease, int bed, int numeroSaude)
        {
            Id = id;
            Name = name;
            EntryDate = entryDate;
            Disease = disease;
            Bed = bed;
            NumeroSaude = numeroSaude;
        }

    }
}
