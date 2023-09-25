using System.Collections.Generic;

namespace FSM
{
    public static class StateDataSheet
    {
        public static IEnumerable<KeyValuePair<int, IState>> GetPlayerData(StateMachine machine)
        {
            return new Dictionary<int, IState>()
            {
                { 1, new Move(1, machine) },
                { 2, new Jump(2, machine) }, 
            };
        }
    }
}