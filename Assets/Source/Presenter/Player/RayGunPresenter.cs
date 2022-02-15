using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunPresenter : MonoBehaviour
{
    private RayGunModel _rayGun;

    public void Init(Camera camera, LineRenderer lineRenderer)
    {
        _rayGun = new RayGunModel(camera, lineRenderer);
    }

    private void Update()
    {
        _rayGun.Update();
    }
}
