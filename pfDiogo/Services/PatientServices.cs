using TF.Entities;
using TF.Entities.Enums;

namespace TF.Services
{
    internal class PatientService
    {
        public List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            Console.WriteLine("\n\n[Atualizar Paciente]");
            Console.Write("Nome (deixe vazio para manter): ");
            patient.Name = Console.ReadLine();
            Console.Write("Número de Saúde (deixe vazio para manter): ");
            patient.NumeroSaude = int.Parse(Console.ReadLine());
            Console.Write("Doença (deixe vazio para manter): ");
            patient.Disease = Enum.Parse<DiseaseTypes>(Console.ReadLine());
        }

        public List<Patient> ListPatients()
        {
            return patients;
        }

        public Patient GetPatientHealthNumber(int numeroSaude)
        {
            return patients.FirstOrDefault(p => p.NumeroSaude == numeroSaude);
        }

    }
}

