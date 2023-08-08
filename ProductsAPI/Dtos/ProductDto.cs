﻿namespace ProductsAPI.Dtos
{
    public class ProductDto
    {
        [MaxLength(250)]
        public string name { get; set; }
        [MaxLength(2500)]
        public string description { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public double Duration { get; set; }
        public IFormFile? Image { get; set; }

        public int UserId { get; set; }

        public byte CategoryId { get; set; }
    }
}
