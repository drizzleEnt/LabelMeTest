using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : Presenter
{
    private PlayerModel _playerModel;

    public PlayerModel PlayerModel => _playerModel;

    public void Init()
    {
        _playerModel = new PlayerModel(transform);
    }
}
