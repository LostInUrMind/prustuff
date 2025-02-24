using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonConfig : MonoBehaviour
{
    public float rotationSpeed = 90f;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Danger"))
        {
            Destroy(gameObject);
        }
    }
}
