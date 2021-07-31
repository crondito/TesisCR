using UnityEngine;
using System.Collections;

public class Proyectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelfDestroy();
    }

    private void Start()
    {
        
        Invoke("SelfDestroy", 1.5f);
    }

    private void SelfDestroy()
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke();
        }
        Destroy(this.gameObject);
    }
}
