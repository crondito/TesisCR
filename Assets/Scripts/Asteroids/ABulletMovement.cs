using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABulletMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
