namespace FSM
{
    public class Move : StateBase
    {
        public Move(int id, StateMachine machine) : base(id, machine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            animator.Play("Move");
            controller.isMovable = true;
        }
        public override int OnUpdate()
        {
            int next = base.OnUpdate();
            if (next < 0)
                return id;
            if(controller.isGrounded == false)
                next = FALL;
            return next;
        }
    }
}
