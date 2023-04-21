namespace MarktguruProject.DTOModels
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public Product()
        {

        }
        public Product(DomainModels.Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Available = product.Available;
            this.Description = product.Description;
            this.DateCreated = product.DateCreated;
        }

        public DomainModels.Product ToModel()
        {
            return new DomainModels.Product
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Available = this.Available,
                Description = this.Description,
            };
        }
    }
}
