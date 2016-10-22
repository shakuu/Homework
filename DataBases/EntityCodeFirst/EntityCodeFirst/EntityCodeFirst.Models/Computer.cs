namespace EntityCodeFirst.Models
{
    public class PersonalComputer
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int? MotherBoardId { get; set; }

        public virtual Motherboard MotherBoard { get; set; }
    }
}
