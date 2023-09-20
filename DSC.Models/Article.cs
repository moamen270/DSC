﻿namespace DSC.Models
{
	public class Article
	{
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime CDate { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
