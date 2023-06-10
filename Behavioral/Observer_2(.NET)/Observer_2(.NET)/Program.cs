using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        public class InterviewUpdateEventtArgs : EventArgs
        {
            public  string Name { get; set; }
        }

        public class Recrutier
        {
            public void LastInterview()
            {
                InterviewUpdate?.Invoke(this, new InterviewUpdateEventtArgs { Name = "Rodrigo"});
            }

            public event EventHandler<InterviewUpdateEventtArgs> InterviewUpdate;
        }

        static void Main(string[] args)
        {
            var recrutier = new Recrutier();
            recrutier.InterviewUpdate += CallApplicant;

            recrutier.LastInterview();
        }

        private static void CallApplicant(object? sender, InterviewUpdateEventtArgs e)
        {
            Console.WriteLine($"El postulante {e.Name} ha sido contratado");
        }
    }
}