
bool EsVocal(char caracter)
{
    var arrVocales = new char[] { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú' };

    for (int i = 0; i < arrVocales.Length; i++)
    {
        if (caracter == arrVocales[i])
            return true;
    }

    return false;
}

int CuentaVocales(string cadena)
{
    int contador = 0;
    var arrCaracteres = cadena.ToCharArray();

    for (int i = 0; i < arrCaracteres.Length; i++)
    {
        var caracter = arrCaracteres[i];
        if (EsVocal(caracter))
            contador++;
    }

    return contador;
}

var cadenasDePrueba = new string[] { "Perú", "Colombia", "Chile", "Ecuador" };
Console.WriteLine("*** Cantidad de vocales ***");
for (int i = 0; i < cadenasDePrueba.Length; i++)
{
    var cadena = cadenasDePrueba[i];
    Console.WriteLine($"- {cadena}: { CuentaVocales(cadena.ToLower()) }");
}
