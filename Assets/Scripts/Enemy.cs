using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        // move down at 4m/sec
        // if bottom of screen
        // respawn it at top a new random x position

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-10.0f, 10.0f); 
            transform.position = new Vector3(randomX, 6f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            // Access Damage method from Player.cs
            Player player = other.transform.GetComponent<Player>();

            // Better error handling
            if(player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
