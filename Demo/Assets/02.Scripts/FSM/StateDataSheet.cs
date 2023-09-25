using System.Collections.Generic;

namespace FSM
{
    public static class StateDataSheet
    {
        public static IEnumerable<KeyValuePair<int, IState>> GetPlayerData(StateMachine machine)
        {
            return new Dictionary<int, IState>()
        {
            { 0, new Move(0, machine) },
        };
        }
    }
}