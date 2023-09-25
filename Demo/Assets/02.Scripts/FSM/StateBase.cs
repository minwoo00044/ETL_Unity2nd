using UnityEngine;

namespace FSM
{
    public abstract class StateBase : IState
    {
        public int id { get; private set; }

        public virtual bool canExecute => true;

        protected PlayerController controller;
        protected StateMachine machine;
        protected Transform transform;
        protected Rigidbody rb;
        protected Animator animator;
        public StateBase(int id, StateMachine machine)
        {
            this.id = id;
            this.machine = machine;
            this.controller = machine.owner.GetComponent<PlayerController>();
            this.transform = machine.owner.GetComponent<Transform>();
            this.rb = machine.owner.GetComponent<Rigidbody>();
            this.animator = machine.owner.GetComponent<Animator>();
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
