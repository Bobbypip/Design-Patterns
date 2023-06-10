using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        public class InterviewUpdateEventArgs : EventArgs
        {
            public string Name { get; set; }
        }

        public class Recruiter
        {
            public string Name { get; set; }
            public event EventHandler<InterviewUpdateEventArgs> InterviewUpdate;

            public void LastInterview()
            {
                InterviewUpdate?.Invoke(this, new InterviewUpdateEventArgs { Name = "Rodrigo" });
            }
        }

        static void Main(string[] args)
        {
            var recruiters = new List<Recruiter>
            {
                new Recruiter { Name = "John" },
                new Recruiter { Name = "Alice" }
            };

            foreach (var recruiter in recruiters)
            {
                recruiter.InterviewUpdate += CallApplicant;
                recruiter.LastInterview();
            }
        }

        private static void CallApplicant(object sender, InterviewUpdateEventArgs e)
        {
            var recruiter = (Recruiter)sender;
            Console.WriteLine($"El reclutador {recruiter.Name} entrevistó a {e.Name}");
        }
    }
}

/*
Supongamos que tienes una lista de reclutadores y cada uno de ellos tiene su propio evento InterviewUpdate.
En este caso, tener acceso al objeto que desencadenó el evento sería útil para realizar acciones específicas basadas en cada reclutador en particular.

En este ejemplo, hay una lista de reclutadores representados por objetos de la clase Recruiter. Cada reclutador tiene su propio evento InterviewUpdate asociado.
Al suscribir el método CallApplicant al evento InterviewUpdate de cada reclutador, se puede acceder al objeto Recruiter que desencadenó el evento utilizando sender.
Mediante un casting (Recruiter)sender, se puede acceder a las propiedades y realizar acciones específicas basadas en cada reclutador en particular.
En el método CallApplicant, el mensaje de salida identifica el reclutador y el candidato entrevistado en función de los datos proporcionados por el evento.

En resumen, en situaciones más complejas con múltiples objetos que desencadenan el mismo evento, tener acceso al objeto que desencadenó el evento puede ser útil para tomar decisiones o realizar acciones basadas en cada objeto específico.
*/