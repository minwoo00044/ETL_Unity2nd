using UnityEngine;
using FSM;
using FSM.Generic;

public class PlayerController : MonoBehaviour
{
    private StateMachine _machine;
    private FSM.Generic.PlayerMachine _playerMachine;

    private void Awake()
    {
        _machine = new StateMachine(gameObject);
        _playerMachine = new FSM.Generic.PlayerMachine(gameObject);
    }

    private void Update()
    {
        _machine.Update();
        _playerMachine.Update();
    }

    private void FixedUpdate()
    {
        _machine.Update();
        _playerMachine.Update();
    }
}
