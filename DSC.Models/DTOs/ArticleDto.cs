namespace DSC.Models.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime CDate { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string PublicId { get; set; }
        public ArticleType ArticleType { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ArticleType[] ArticleTypes { get; set; } = Enum.GetValues<ArticleType>();

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}