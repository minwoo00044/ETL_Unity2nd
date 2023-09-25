using UnityEngine;
using FSM;
using FSM.Generic;
using PlayerMachine = FSM.PlayerMachine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float horizontal => Input.GetAxis("Horizontal");
    public float vertical => Input.GetAxis("Vertical");
    public bool isMovable { get; set;}
    public Vector3 move {get; set;}
    [SerializeField] private float _moveSpeed = 1.5f;
    private Rigidbody rb;
    public bool isGrounded {get; private set;}
    [SerializeField] private Vector3 _groundDetectCenter;
    [SerializeField] private float _groundDetectRadius;
    [SerializeField] private LayerMask _groundDetectlayerMask;
    private PlayerMachine _machine;

    private void Awake()
    {
        _machine = new PlayerMachine(gameObject);
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _machine.ChangeState(StateBase.JUMP);
        }
        _machine.Update();
        if(isMovable)
        {
            move = new Vector3(horizontal, 0.0f, vertical);
        }
    }
    private void FixedUpdate()
    {
        DetectGround();
        _machine.FixedUpdate();
        Move();
    }
    private void LateUpdate()
    {
        _machine.LateUpdate();
    }
    private void Move()
    {
        rb.position += move * _moveSpeed * Time.deltaTime;
    }

    private void DetectGround()
    {
        Collider[] cols =  Physics.OverlapSphere(transform.position + _groundDetectCenter,
                               _groundDetectRadius,
                               _groundDetectlayerMask);
        isGrounded = cols.Length > 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + _groundDetectCenter,
                              _groundDetectRadius);
    }
}
