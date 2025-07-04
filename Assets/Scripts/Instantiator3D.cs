using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator3D : MonoBehaviour
{

    [SerializeField] GameObject _targetPrefab;
    private int number = 10;
     
    
    void Start()
    {
        if(_targetPrefab != null)
        {
            float offset = _targetPrefab.transform.localScale.x + 0.2f;
            for (int i = 0; i < number; i++)
            {
                Instantiate(_targetPrefab, new Vector3(transform.position.x + i * offset, transform.position.y, transform.position.z), Quaternion.identity, transform);
            }
        }
    }

    
    void Update()
    {
        
    }
}
