using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Proyectile laserPrefab;
    
    public float speed = 5.0f;

    private bool _laserActive = false;

    private void Update()
    {
        // Player Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -13.8f)
            {
                this.transform.position += Vector3.left * this.speed * Time.deltaTime;
            }
            
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 13.8f)
            {
                this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
                
        }

        // Player Shooting
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Proyectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
            
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            FindObjectOfType<GameManager>().QuitarVida();
            this.gameObject.SetActive(false);
            Invoke("Respawn", 1.0f);
        }
    }

    private void Respawn()
    {
        this.transform.position.Set( 0f, -13.0f, 0f);
        this.gameObject.SetActive(true);
    }
}
