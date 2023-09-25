using System.Collections.Generic;

namespace FSM.Generic
{
    public static class StateDataSheet
    {
        public static IEnumerable<KeyValuePair<CharacterState, IState<CharacterState>>> GetPlayerData(StateMachine<CharacterState> machine)
        {
            return new Dictionary<CharacterState, IState<CharacterState>>()
        {
            { CharacterState.Move, new Move(CharacterState.Move, machine) },
        };
        }
    }
}