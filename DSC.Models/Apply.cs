namespace DSC.Models
{
	public class Apply
	{
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
/*		public int StudentId { get; set; }
		public Student Student { get; set; }*/
	}
}
