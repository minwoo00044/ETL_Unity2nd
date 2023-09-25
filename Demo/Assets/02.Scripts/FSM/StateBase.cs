using UnityEngine;

namespace FSM
{
    public class StateBase : IState
    {
        public int id { get; private set; }

        public bool canExecute => true;

        protected StateMachine machine;
        public StateBase(int id, StateMachine machine)
        {
            this.id = id;
            this.machine = machine;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual int OnUpdate()
        {
            return id;
        }
    }
}
