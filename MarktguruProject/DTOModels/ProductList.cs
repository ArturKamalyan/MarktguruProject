namespace MarktguruProject.DTOModels
{
    public class ProductList : Product
    {
        public ProductList(DomainModels.Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Available = product.Available;
        }
    }
}
