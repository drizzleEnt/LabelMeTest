using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    private ParticleSystem _particleSystem;

    public EnemyModel(ParticleSystem particleSystem)
    {
        _particleSystem = particleSystem;
    }

    public void SetHitted()
    {
        if (_particleSystem.gameObject.activeSelf == true)
            return;

        Debug.Log("включился");
        _particleSystem.gameObject.SetActive(true);
    }

    public void SetUnhitted()
    {
        if (_particleSystem.gameObject.activeSelf == false)
            return;

        Debug.Log("выключился");
        _particleSystem.gameObject.SetActive(false);
    }
}
