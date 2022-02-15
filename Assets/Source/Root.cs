using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private RayGunPresenter _gunPresenter;
    [SerializeField] private Camera _camera;
    [SerializeField] private LineRenderer _lineRenderer;

    private InputRouter _inputRouter;

    private void Awake()
    {
        _playerPresenter.Init();
        _gunPresenter.Init(_camera, _lineRenderer);
        _inputRouter = new InputRouter(_playerPresenter.PlayerModel);
    }

    private void OnEnable()
    {
        _inputRouter.Enable();
    }

    private void OnDisable()
    {
        _inputRouter.Disable();
    }

    private void Update()
    {
        _inputRouter.Update();
    }
}
