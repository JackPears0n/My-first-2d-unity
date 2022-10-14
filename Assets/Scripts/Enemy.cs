using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject player;
    Transform target;
    Vector2 moveDirection;
    public GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        float xDifference = player.transform.position.x - transform.position.x;
        Debug.Log(xDifference);
        float yDifference = player.transform.position.y - transform.position.y;
        Debug.Log(yDifference);
        /*
        Vector3 difference = player.transform.position - enemyProjectile.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        enemyProjectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Time.time > nextFire)
        {
            if (!Bullet)
                return;
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        }
        */
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation

        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Debug.Log("Enemy died!");
        // Death animation

        // Disable enemy
    }
}
