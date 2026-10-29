using imc.Models;

Console.WriteLine("Calculadora de Indice de Masa Corporal");
Console.WriteLine("");


decimal peso = ReadDecimal("Proporcione el peso de la persona el kilogramos: ");
decimal estatura = ReadDecimal("Proporcione la estatura en metros: ");


//Realizar calculos
var imc = CalculadoraImc.IndiceDeMasaCorporal(peso, estatura);
Console.WriteLine($"El indice de masa corporal de la persna es {imc:F4}");
var situacionNutricional = CalculadoraImc.SituacionNutricional(imc);
Console.WriteLine($"El estado de la situacion nutricional de la persona es {situacionNutricional}");
return 0;

static decimal ReadDecimal(string indicacion)
{
    decimal valor;
    bool valorEsValido = false;
    do
    {
        Console.WriteLine($"{indicacion}");
        var entrada = Console.ReadLine();
        valorEsValido = decimal.TryParse(entrada, out valor);
        if (!valorEsValido)
        {
            Console.WriteLine("El dato proporcionado debe ser numerico: ");
        }
    } while (!valorEsValido);
    return valor;
}