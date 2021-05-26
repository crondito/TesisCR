using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAsteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject[] subAsteroids;
    public float numberOfAsteroids;

    private bool isDestroying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        ).normalized * speed;

        rb.angularVelocity = Random.Range(-50f, 50f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isDestroying) return;

        if (col.CompareTag("Bullet"))
        {
            isDestroying = true;
            FindObjectOfType<SoundManagerScript>().Play("Explotion");
            Destroy(gameObject);
            Destroy(col.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                    );
            }
        }

        if (col.CompareTag("Player"))
        {
            var asts = FindObjectsOfType<AAsteroid>();
            for (var i = 0; i < asts.Length; i++)
            {
                Destroy(asts[i].gameObject);
            }
            col.GetComponent<APlayer>().Lose();
        }

        if (col.CompareTag("Asteroid"))
        {
            FindObjectOfType<SoundManagerScript>().Play("Step");
        }
    }

}
