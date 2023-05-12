// Interfaz Mediator
public interface IChatMediator
{
    void EnviarMensaje(string mensaje, Colleague colleague);
    void AgregarColega(Colleague colleague);
}

// Clase Mediator concreta
public class ChatMediator : IChatMediator
{
    private List<Colleague> colleagues;

    public ChatMediator()
    {
        colleagues = new List<Colleague>();
    }

    public void AgregarColega(Colleague colleague)
    {
        colleagues.Add(colleague);
    }

    public void EnviarMensaje(string mensaje, Colleague colleague)
    {
        foreach (var col in colleagues)
        {
            if (col != colleague)
            {
                col.RecibirMensaje(mensaje);
            }
        }
    }
}

// Clase Colleague abstracta
public abstract class Colleague
{
    protected IChatMediator mediator;

    public Colleague(IChatMediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void EnviarMensaje(string mensaje);
    public abstract void RecibirMensaje(string mensaje);
}

// Clase Colleague concreta
public class Usuario : Colleague
{
    public Usuario(IChatMediator mediator) : base(mediator)
    {
    }

    public override void EnviarMensaje(string mensaje)
    {
        Console.WriteLine("Usuario envía mensaje: " + mensaje);
        mediator.EnviarMensaje(mensaje, this);
    }

    public override void RecibirMensaje(string mensaje)
    {
        Console.WriteLine("Usuario recibe mensaje: " + mensaje);
    }
}

// Ejemplo de uso del patrón Mediator
public class Program
{
    static void Main(string[] args)
    {
        // Crear el Mediator
        IChatMediator chatMediator = new ChatMediator();

        // Crear los colegas
        Colleague usuario1 = new Usuario(chatMediator);
        Colleague usuario2 = new Usuario(chatMediator);

        // Agregar los colegas al Mediator
        chatMediator.AgregarColega(usuario1);
        chatMediator.AgregarColega(usuario2);

        // Enviar un mensaje desde el usuario1
        usuario1.EnviarMensaje("¡Hola a todos!");

        // El usuario2 recibe el mensaje
    }
}
