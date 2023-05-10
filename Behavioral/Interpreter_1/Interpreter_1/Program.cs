using System;
using System.Collections.Generic;

//En este ejemplo, se utilizan tres clases concretas que heredan de la clase abstracta `Interpreter`:
//`NumberExpression`, que interpreta expresiones numéricas simples;
//`AdditionExpression`, que interpreta expresiones de suma; y
//`SubtractionExpression`, que interpreta expresiones de resta.

//En el método `Interpret` de cada clase, se implementa la lógica específica para interpretar la expresión correspondiente.
//En el caso de las expresiones de suma y resta, se utiliza la función `Interpret` de las expresiones izquierda y derecha para obtener los operandos y realizar la operación correspondiente.
//En el ejemplo de uso del patrón, se crea un diccionario con los valores de las variables que se utilizan en la expresión,
//se construye la expresión correspondiente utilizando las clases `NumberExpression`, `AdditionExpression` y `SubtractionExpression`,
//y se interpreta la expresión utilizando el método `Interpret` de la clase `SubtractionExpression`. El resultado se muestra en la consola.

// Clase abstracta que define la interfaz de interpretación
abstract class Interpreter
{
    public abstract int Interpret(Dictionary<string, int> context);
}

// Clase concreta que interpreta expresiones numéricas
class NumberExpression : Interpreter
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public override int Interpret(Dictionary<string, int> context)
    {
        return _number;
    }
}

// Clase concreta que interpreta expresiones de suma
class AdditionExpression : Interpreter
{
    private Interpreter _leftExpression;
    private Interpreter _rightExpression;

    public AdditionExpression(Interpreter leftExpression, Interpreter rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public override int Interpret(Dictionary<string, int> context)
    {
        return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
    }
}

// Clase concreta que interpreta expresiones de resta
class SubtractionExpression : Interpreter
{
    private Interpreter _leftExpression;
    private Interpreter _rightExpression;

    public SubtractionExpression(Interpreter leftExpression, Interpreter rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public override int Interpret(Dictionary<string, int> context)
    {
        return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
    }
}

// Ejemplo de uso del patrón Interpreter
class Program
{
    static void Main(string[] args)
    {
        // Creamos un diccionario con los valores de las variables
        var context = new Dictionary<string, int>
        {
            { "a", 5 },
            { "b", 3 },
            { "c", 10 }
        };

        // Creamos una expresión que representa la operación "a + b - c"
        var expression = new SubtractionExpression(
            new AdditionExpression(
                new NumberExpression(context["a"]),
                new NumberExpression(context["b"])
            ),
            new NumberExpression(context["c"])
        );

        // Interpretamos la expresión y mostramos el resultado
        int result = expression.Interpret(context);
        Console.WriteLine($"El resultado de la expresión es: {result}");
    }
}
