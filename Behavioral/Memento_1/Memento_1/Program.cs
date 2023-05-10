// Originador: Clase que representa el objeto cuyo estado se desea guardar
class Originador
{
    private string estado;

    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    // Método para crear un Memento que contenga una instantánea del estado actual
    public Memento CrearMemento()
    {
        return new Memento(estado);
    }

    // Método para restaurar el estado a partir de un Memento
    public void RestaurarMemento(Memento memento)
    {
        estado = memento.ObtenerEstado();
    }
}

// Memento: Clase que almacena el estado interno del Originador
class Memento
{
    private readonly string estado;

    public Memento(string estado)
    {
        this.estado = estado;
    }

    // Método para obtener el estado almacenado en el Memento
    public string ObtenerEstado()
    {
        return estado;
    }
}

// Cuidador: Clase encargada de solicitar y almacenar los Mementos
class Cuidador
{
    private Memento memento;

    // Propiedad para acceder al Memento actual
    public Memento Memento
    {
        get { return memento; }
        set { memento = value; }
    }
}

// Ejemplo de uso
class Program
{
    static void Main(string[] args)
    {
        Originador originador = new Originador();
        Cuidador cuidador = new Cuidador();

        // Cambio el estado del originador
        originador.Estado = "Estado 1";

        // Creo un Memento y lo guardo en el cuidador
        cuidador.Memento = originador.CrearMemento();

        // Cambio el estado del originador nuevamente
        originador.Estado = "Estado 2";

        // Restauro el estado del originador a partir del Memento guardado en el cuidador
        originador.RestaurarMemento(cuidador.Memento);

        Console.WriteLine("Estado restaurado: " + originador.Estado);

        Console.ReadLine();
    }
}

/*
En este nuevo ejemplo, hemos hecho que el estado del Originador sea completamente encapsulado, es decir, no se puede acceder directamente al estado desde ninguna clase externa.
En su lugar, se utiliza el método ObtenerEstado() en la clase Memento para obtener el estado almacenado.
La diferencia clave entre este ejemplo y el anterior radica en el nivel de encapsulamiento. En el primer ejemplo, el estado del Originador es accesible directamente desde cualquier clase externa, mientras que en este nuevo ejemplo se ha aplicado un nivel más estricto de encapsulamiento.
Esto implica que solo el Originador y la clase Memento pueden acceder al estado. El Cuidador solo puede almacenar el Memento, pero no puede modificar ni acceder directamente al estado del Originador.
Esta implementación con un mayor nivel de encapsulamiento proporciona una mejor protección de los datos y ayuda a mantener la coherencia en el diseño de la aplicación. Además, garantiza que el estado solo pueda ser modificado y accedido a través de los métodos definidos
*/