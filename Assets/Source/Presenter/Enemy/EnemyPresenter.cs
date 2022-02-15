using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : Presenter
{
    [SerializeField] private ParticleSystem _particleSystem;

    private EnemyModel _enemyModel;

    private void Awake()
    {
        _enemyModel = new EnemyModel(_particleSystem);
    }

    public void SetHitted()
    {
        _enemyModel.SetHitted();
    }

    public void SetUnhitted()
    {
        _enemyModel.SetUnhitted();
    }
}
