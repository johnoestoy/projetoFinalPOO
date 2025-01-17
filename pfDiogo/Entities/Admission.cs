

using TF.Entities.Enums;

namespace TF.Entities
{
    internal class Admission
    {
        public int Id { get; set; }
        public AdmissionType AdmissionType { get; set; }
        public Patient Patient { get; set; }
        public Unit OriginUnity { get; set; }
        public Unit DestinyUnity { get; set; }



        public Admission() { }
        public Admission(int id, AdmissionType admissionType, Patient patient)
        {
            Id = id;
            AdmissionType = admissionType;
            Patient = patient;
        }
        public Admission(int id, AdmissionType admissionType, Patient patient, Unit originUnity, Unit destinyUnity) : this(id, admissionType, patient)
        {
            OriginUnity = originUnity;
            DestinyUnity = destinyUnity;
        }

        //
        //
        //Menu
        //
        //



    }
}
