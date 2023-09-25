using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSM
{
    public class Jump : StateBase
    {
        public override bool canExecute => base.canExecute &&
                                           controller.isGrounded &&
                                           machine.current == 1;
        private float _force;
        public Jump(int id, StateMachine machine, float force) : base(id, machine)
        {
            _force = force;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
            rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
            animator.Play("Jump");
            controller.isMovable = false;
        }
        public override int OnUpdate()
        {
            int next = base.OnUpdate();
            if (next < 0)
                return id;
            if (rb.velocity.y <= 0)
                next = FALL;
            return next;
        }
    }
}