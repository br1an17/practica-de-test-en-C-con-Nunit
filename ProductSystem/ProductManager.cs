class ProductManager
{

    private List<Product> products = new List<Product>();
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice(Product product)
    {
        if (product.Category == "Alimentos")
        {
            return product.Price += product.Price * 0.05m;
        }
        if (product.Category == "Electronica")
        {
            return product.Price += product.Price * 0.1m;

        }
        return product.Price;
    }

    public Product FindProductByName(string name)
    {
        foreach (var p in products)
        {
            if (p.Name == name)
            {
                return p;
            }
        }
        throw new ArgumentException("el producto nombrado no existe");
    }
};