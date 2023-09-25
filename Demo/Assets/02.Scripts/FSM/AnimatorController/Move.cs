namespace FSM.AnimatorController
{
    internal class Move : StateBase
    {
        public override void OnStateUpdate(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            if(controller.isGrounded == false)
            {
                ChangeState(animator, State.Fall);
            }
        }
    }
}
