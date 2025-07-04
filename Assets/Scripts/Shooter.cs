using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _force = 10;
    [SerializeField] private GameObject _bulletHolePreab;
    
    
    void Start()
    {
        _cam = Camera.main;
    }

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = _cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Rigidbody rb = hit.collider.attachedRigidbody;
                if(rb != null)
                {
                    GameObject hole = Instantiate(_bulletHolePreab, new Vector3(hit.point.x, hit.point.y, hit.point.z -0.01f), Quaternion.LookRotation(-hit.normal), hit.transform);
                    hole.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                    rb.AddForceAtPosition(ray.direction * _force, hit.point, ForceMode.Impulse);
                    Destroy(hole,3);
                }
                
            }
        }
    }
}
