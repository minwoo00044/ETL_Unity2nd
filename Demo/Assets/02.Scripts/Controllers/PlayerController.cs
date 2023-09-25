using UnityEngine;
using FSM;
using FSM.Generic;
using PlayerMachine = FSM.PlayerMachine;
public class PlayerController : MonoBehaviour
{
    public bool isGrounded {get; private set;}
    [SerializeField] private Vector3 _groundDetectCenter;
    [SerializeField] private float _groundDetectRadius;
    [SerializeField] private LayerMask _groundDetectlayerMask;
    private PlayerMachine _machine;

    private void Awake()
    {
        _machine = new PlayerMachine(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _machine.ChangeState(2);
        }
        _machine.Update();
    }

    private void FixedUpdate()
    {
        DetectGround();
        _machine.FixedUpdate();
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
