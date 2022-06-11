using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnCollide : MonoBehaviour
{
    [SerializeField] string text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

        }
    }
}
