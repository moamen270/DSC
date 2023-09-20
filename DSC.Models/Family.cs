namespace DSC.Models
{
	public class Family
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public Relation Relation { get; set; }
        public Status Status { get; set; }
        public string Job { get; set; }
        public decimal Income { get; set; }
        public bool IsAlive { get; set; }
        public bool isDisability { get; set; }
        public string SSNImgUrl { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
