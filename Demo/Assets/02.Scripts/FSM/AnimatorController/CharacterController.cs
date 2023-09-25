using UnityEngine;

namespace FSM.AnimatorController
{
    public class CharacterController : MonoBehaviour
    {
        public virtual float horizontal { get; set; }
        public virtual float vertical { get; set; }
        public bool isMovable { get; set; }
        public Vector3 move { get; set; }
        [SerializeField] private float _moveSpeed = 1.5f;
        private Rigidbody rb;
        public bool isGrounded
        {
            get
            {
                Collider[] cols = Physics.OverlapSphere(transform.position + _groundDetectCenter,
                       _groundDetectRadius,
                       _groundDetectlayerMask);
                return cols.Length > 0;
            }
        }

        [SerializeField] private Vector3 _groundDetectCenter;
        [SerializeField] private float _groundDetectRadius;
        [SerializeField] private LayerMask _groundDetectlayerMask;
        protected Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponentInChildren<Animator>();

            StateBase[] states = animator.GetBehaviours<StateBase>();
            for(int i = 0; i < states.Length; i++)
            {
                states[i].Initialize(this);
            }
        }
    }
}
