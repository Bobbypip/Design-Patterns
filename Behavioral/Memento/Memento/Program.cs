// Originador: Clase que representa el objeto cuyo estado se desea guardar
class Originador
{
    private string? estado;

    public string Estado
    {
        get => estado;
        set
        {
            estado = value;
            Console.WriteLine("Estado actualizado a: " + estado);
        }
    }

    // Método para crear un Memento que contenga una instantánea del estado actual
    public Memento CrearMemento()
    {
        return new Memento(estado);
    }

    // Método para restaurar el estado a partir de un Memento
    public void RestaurarMemento(Memento memento)
    {
        estado = memento.Estado;
        Console.WriteLine("Estado restaurado a: " + estado);
    }
}

// Memento: Clase que almacena el estado interno del Originador
class Memento
{
    private readonly string estado;

    public string Estado
    {
        get { return estado; }
    }

    public Memento(string estado)
    {
        this.estado = estado;
    }
}

// Cuidador: Clase encargada de solicitar y almacenar los Mementos
class Cuidador
{
    private Memento? memento;

    // Propiedad para acceder al Memento actual
    public Memento Memento
    {
        get => memento;
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

        Console.ReadLine();
    }
}
