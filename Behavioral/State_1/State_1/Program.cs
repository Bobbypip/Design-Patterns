using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Example
{
    public enum State
    {
        Cesante,
        ConEmpleo,
        DeJefe,
        Millionario
    }

    public enum Actions
    {
        PasarEntrevista,
        DeleteFromSinWhereProduccion,
        JugarLoteria,
        ObtenerBuenaEvaluacion
    }
    class Program
    {
        public static bool GanarseLoteria { get; private set; }

        static void Main(string[] args)
        {
            var stateMachine = new StateMachine<State, Actions>(State.Cesante);
            stateMachine.Configure(State.Cesante)
                .Permit(Actions.PasarEntrevista, State.ConEmpleo);
            stateMachine.Configure(State.ConEmpleo)
                .Permit(Actions.ObtenerBuenaEvaluacion, State.DeJefe)
                .PermitIf(Actions.JugarLoteria, State.Millionario, () =>
                 GanarseLoteria
                );
            stateMachine.Configure(State.ConEmpleo)
                 .Permit(Actions.DeleteFromSinWhereProduccion, State.Cesante);
        }
    }
}
