using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSC.Models.DTOs
{
	public class TopicDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<Topic> Topics { get; set; }
	}
}