using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRouter
{
    private PlayerInput _playerInput;
    private PlayerModel _playerModel;
    private float _delta;

    public InputRouter(PlayerModel playerModel)
    {
        _playerInput = new PlayerInput();
        _playerModel = playerModel;
    }

    public void Enable()
    {
        _playerInput.Enable();
    }

    public void Disable()
    {
        _playerInput.Disable();
    }

    public void Update()
    {
        _delta = _playerInput.Player.Look.ReadValue<Vector2>().normalized.x;
        _playerModel.Rotate(_delta);
    }
}
