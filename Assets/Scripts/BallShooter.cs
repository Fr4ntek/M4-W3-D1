using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private float _velocity = 5;
    [SerializeField] GameObject _spherePrefab;
    private float _sphereRadius;
    private Camera _cam;
    [SerializeField] private PauseMenu _pauseUI;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _sphereRadius = _spherePrefab.GetComponent<SphereCollider>().radius;
        _pauseUI = FindAnyObjectByType<PauseMenu>();
    }

    void Update()
    {
        if (_pauseUI.GameState.Equals(PauseMenu.GAME_STATE.PAUSED)) return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = _cam.ScreenPointToRay(mousePos);
            
            if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Barrier"))
                {
                    Debug.Log("Non istanzio la sfera perchè colpirei la barriera");
                }
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Target"))
                {
                    Vector3 spawnPos = _cam.transform.position + _cam.transform.forward * 10f;
                    GameObject sphereClone = Instantiate(_spherePrefab, spawnPos, Quaternion.identity);
                    Rigidbody rb = sphereClone.GetComponent<Rigidbody>();
                    Vector3 direction = (hit.point - spawnPos).normalized;
                    rb.velocity = direction * _velocity;
                    Destroy(sphereClone, 5);
                }
            }

        }
    }
}
