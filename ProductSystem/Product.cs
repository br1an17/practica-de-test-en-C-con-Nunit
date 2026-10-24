

class Product
{
    public int Id {get;set;}
    public string Name {get;set;}
    public decimal Price {get;set;}
    public string Category {get;set;}


    public Product(int id,string name,decimal price, string category)
    {
        Id = id;
        Name = name;
        if(price < 0)
        {
            throw new ArgumentException("el precio tiene que ser mayor  a cero");
        }
        else
        {
        Price= price;
        }

        if(category!="Electronica" && category != "Alimentos")
        {
            throw new ArgumentException("Las categorias solo pueden ser Electrónica o Alimentos");
        }
        else
        {
        Category=category;
        }

    }

};