using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunModel
{
    private LineRenderer _lineRenderer;
    private Camera _camera;
    private EnemyPresenter _firstHitCurrentTarget;
    private EnemyPresenter _secondHitCurrentTarget;
    private EnemyPresenter _thirdHitCurrentTarget;

    public RayGunModel(Camera camera, LineRenderer lineRenderer)
    {
        _camera = camera;
        _lineRenderer = lineRenderer;
    }

    public void Update()
    {
        RaycastHit firstHit;
        bool isHittedFist = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out firstHit, Mathf.Infinity);
        if (isHittedFist == false)
            return;

        var position = firstHit.point;

        Vector3 firstDirection = Vector3.Reflect(_camera.transform.forward, firstHit.normal);
        _lineRenderer.SetPosition(1, position);
        TryGetEnemy(ref firstHit, ref _firstHitCurrentTarget);
        Debug.Log($"first{_firstHitCurrentTarget == null}");

        RaycastHit secondHit;
        bool isHittedSecond = Physics.Raycast(position, firstDirection, out secondHit, Mathf.Infinity);
        if (isHittedSecond == false)
            return;

        var secondPosition = secondHit.point;
        Vector3 senondDirection = Vector3.Reflect(firstDirection, secondHit.normal);
        _lineRenderer.SetPosition(2, secondPosition);
        TryGetEnemy(ref secondHit, ref _secondHitCurrentTarget);
        Debug.Log($"second{_secondHitCurrentTarget == null}");

        RaycastHit thirdHit;
        bool isHettedThird = Physics.Raycast(secondPosition, senondDirection, out thirdHit, Mathf.Infinity);
        if (isHettedThird == false)
            return;

        var thirdPosition = thirdHit.point;
        _lineRenderer.SetPosition(3, thirdPosition);
        TryGetEnemy(ref thirdHit, ref _thirdHitCurrentTarget);
        Debug.Log($"third{_thirdHitCurrentTarget == null}");
    }

    private void TryGetEnemy(ref RaycastHit hit, ref EnemyPresenter target)
    {
        bool hasEnemy = hit.collider.TryGetComponent(out EnemyPresenter enemy);
        
        if (hasEnemy == false)
        {
            if(target != null)
            {
                target.SetUnhitted();
                target = null;
            }
            return;
        }

        target = enemy;
        target.SetHitted();
    }
}
