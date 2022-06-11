using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool isClock = false;

    private void Update()
    {
        var isMinus = isClock ? -1 : 1;
        transform.Rotate(0, 0, isMinus * 360 * speed * Time.deltaTime);    
    }
}
