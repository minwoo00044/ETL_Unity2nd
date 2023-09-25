using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class Jump : StateBase
    {
        public override bool canExecute => base.canExecute &&
                                           controller.isGrounded &&
                                           machine.current == 1;                                 
        public Jump(int id, StateMachine machine) : base(id, machine)
        {
        }
    }
}