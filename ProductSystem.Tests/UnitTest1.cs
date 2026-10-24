namespace PFO_MPS;
using NUnit.Framework;

public class Tests
{

    private Product product;
    [SetUp]
    public void Setup()
    {
        product = new Product(1, "Mouse", 100m, "Electronica");
    }

    [Test]
    public void ProductCreateOk()
    {
        Assert.That(product.Id, Is.EqualTo(1));
        Assert.That(product.Name, Is.EqualTo("Mouse"));
    }

    [Test]
    public void ProductAddOK()
    {

        var manager = new ProductManager();
        var p = new Product(2, "Teclado", 80m, "Electronica");


        manager.AddProduct(p);
        var found = manager.FindProductByName("Teclado");


        Assert.That(found, Is.Not.Null);
        Assert.That(found.Name, Is.EqualTo("Teclado"));
        Assert.That(found.Price, Is.EqualTo(80m));
    }

    [Test]
    public void ProductsSearchOk()
    {
        var manager = new ProductManager();
        var monitor = new Product(3, "Monitor", 250m, "Electronica");
        var parlante = new Product(4, "Parlante", 60m, "Electronica");
        var microfono = new Product(55, "Microfono", 100m, "Electronica");

        manager.AddProduct(monitor);
        manager.AddProduct(parlante);
        manager.AddProduct(microfono);
        var found = manager.FindProductByName("Monitor");
        var found2 = manager.FindProductByName("Parlante");
        var found3 = manager.FindProductByName("Microfono");

        Assert.That(found.Name, Is.EqualTo("Monitor"));
        Assert.That(found2.Name, Is.EqualTo("Parlante"));
        Assert.That(found3.Name, Is.EqualTo("Microfono"));

    }

    [Test]
    public void ProductSearchNotFound()
    {
        var manager = new ProductManager();
        var monitor = new Product(3, "Monitor", 250m, "Electronica");

        manager.AddProduct(monitor);

        //forzamos el error escribiendolo en minuscula y con doble rr al final
        Assert.Throws<ArgumentException>(() => manager.FindProductByName("monitorr"));

    }
    [Test]
    public void CalculateElectronicsTax()
    {
        var manager = new ProductManager();

        // Utilizamos el producto creado en elo setup.
        decimal resultado = manager.CalculateTotalPrice(product);

        Assert.That(resultado, Is.EqualTo(110m));
    }

    [Test]
    public void CalculateFoodTax()
    {
        var manager = new ProductManager();
        var p = new Product(1, "Leche", 100m, "Alimentos");

        decimal resultado = manager.CalculateTotalPrice(p);

        Assert.That(resultado, Is.EqualTo(105m));
    }
    [Test]
    public void ValidatePrice()
    {


        Assert.Throws<ArgumentException>(() => new Product(2, "Pan", -50m, "Alimentos"));
    }

    [Test]
    public void ValidateCategory()
    {

        Assert.Throws<ArgumentException>(() => new Product(1, "Manzana", 150m, "Frutas"));

    }
}
