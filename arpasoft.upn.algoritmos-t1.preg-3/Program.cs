using arpasoft.upn.algoritmos_t1.preg_3.Models;

Producto GetProductoFromUser(int numProducto)
{
    Producto producto = null;

    Console.WriteLine($"** Producto {numProducto} **");
    try
    {
        Console.Write("- Codigo: ");
        var codigo = int.Parse(Console.ReadLine()!);

        Console.Write("- Nombre: ");
        var nombre = Console.ReadLine();

        Console.Write("- Precio: ");
        var precio = float.Parse(Console.ReadLine()!);

        Console.Write("- Cantidad: ");
        var cantidad = int.Parse(Console.ReadLine()!);

        producto = new Producto()
        {
            Codigo = codigo,
            Nombre = nombre,
            Precio = precio,
            Cantidad = cantidad
        };

        Console.WriteLine();
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(!) Producto mal registrado");
        Console.ForegroundColor = ConsoleColor.White;
        producto = new Producto() { Codigo = -1 };
    }

    return producto;
}

void SortByImprovedBubbleMethod(Producto[] productos)
{
    for (int i = 0; i < productos.Length; i++)
    {
        for (int j = 0; j < productos.Length - (i + 1); j++)
        {
            if (productos[j].Codigo > productos[j + 1].Codigo)
            {
                var productoAux = productos[j];
                productos[j] = productos[j + 1];
                productos[j + 1] = productoAux;
            }
        }
    }
}

int GetIndexByBinarySearching(Producto[] productos, int codigoBuscar)
{
    int inicio = 0, fin = productos.Length - 1, centro;

    while (inicio <= fin)
    {
        centro = (inicio + fin) / 2;

        if (codigoBuscar == productos[centro].Codigo)
        {
            return centro;
        }
        else if (codigoBuscar > productos[centro].Codigo)
        {
            inicio = centro + 1;
        }
        else if (codigoBuscar < productos[centro].Codigo)
        {
            fin = centro - 1;
        }
    }

    return -1;
}

void PrintProducto(Producto producto)
{
    Console.WriteLine("** Producto encontrado **");
    Console.WriteLine($"- Código: {producto.Codigo}");
    Console.WriteLine($"- Nombre: {producto.Nombre}");
    Console.WriteLine($"- Precio: {producto.Precio}");
    Console.WriteLine($"- Cantidad: {producto.Cantidad}");
}

void main()
{
    Console.Write("Cantidad de productos a registrar: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidadProductos))
        cantidadProductos = 0;

    if (cantidadProductos <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(!) Error en el número de productos");
        Console.ForegroundColor = ConsoleColor.White;
    }

    var productos = new Producto[cantidadProductos];
    Console.WriteLine();

    for (int i = 0; i < productos.Length; i++)
    {
        productos[i] = GetProductoFromUser(i + 1);
    }

    SortByImprovedBubbleMethod(productos);

    Console.Write("Codigo a buscar: ");
    if (!int.TryParse(Console.ReadLine(), out int codigoBuscar))
        codigoBuscar = 0;

    if (cantidadProductos <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(!) Error en el código de producto");
        Console.ForegroundColor = ConsoleColor.White;
    }

    int indexSearching = GetIndexByBinarySearching(productos, codigoBuscar);

    if (indexSearching == -1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"(!) No se encontró el producto con código {codigoBuscar}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("** Producto encontrado **");
        PrintProducto(productos[indexSearching]);
        Console.ForegroundColor = ConsoleColor.White;
    }

    Console.WriteLine();
    Console.WriteLine("Lista de productos ordenados");

    for (int i = 0; i < productos.Length; i++)
    {
        PrintProducto(productos[i]);
    }
}

main();