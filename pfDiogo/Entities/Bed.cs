using TF.Entities.Enums;

namespace TF.Entities
{
    internal class Bed
    {
        public int Id { get; set; }
        public BedState BedState { get; set; }

        public Bed() { }
        public Bed(int id, BedState bedState)
        {
            Id = id;
            BedState = bedState;
        }
    }
}
