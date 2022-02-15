using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    private Transform _transform;
    private Vector3 _rotationOffset = new Vector3(0,.5f,0);


    public PlayerModel(Transform transform)
    {
        _transform = transform;
    }

    public void Rotate(float direction)
    {
        Vector3 rotation = _transform.rotation.eulerAngles + _rotationOffset * direction;
        _transform.rotation = Quaternion.Euler(rotation);
    }
}
