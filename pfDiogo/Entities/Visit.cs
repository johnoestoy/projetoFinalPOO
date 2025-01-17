

namespace TF.Entities
{
    internal class Visit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public int Authorized { get; set; }

        public Visit() { }
        public Visit(int id, string name, DateTime entryDate, DateTime leaveDate, int authorized)
        {
            Id = id;
            Name = name;
            EntryDate = entryDate;
            LeaveDate = leaveDate;
            Authorized = authorized;
        }
    }
}
