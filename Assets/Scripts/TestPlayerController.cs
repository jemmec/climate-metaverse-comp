using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerController : MonoBehaviour
{
    private PlayerActions _actions;


    void Awake()
    {
        _actions = new PlayerActions();
    }

    void OnEnable()
    {
        _actions.PLAYER.Enable();
    }

    void OnDisable()
    {
        _actions.PLAYER.Disable();
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(transform.right * (_actions.PLAYER.Movement.ReadValue<float>() * 0.1f));
    }
}
