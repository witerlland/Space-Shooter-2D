using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidBody2D;
    public int Points = 10;
    private GameObject GameController;

    public short enemyTotalLife = 50;
    private short enemyAtualLife;

    public float enemyVelocity = 5f;
    public GameObject  Bullet;
    public float BulletVelocity = 5f;
    public float shotTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();

        InvokeRepeating("shotOnPlayer", shotTime, shotTime);
        enemyAtualLife = enemyTotalLife;

        GameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody2D.velocity = new Vector2(0, -1 * Time.deltaTime).normalized * enemyVelocity;

        if(enemyAtualLife <= 0){
            Destroy(this.gameObject);
            GameController.GetComponent<GameController>().addPlayerPoints(Points);
        }
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    void shotOnPlayer(){
        GameObject  bulletClone;

        bulletClone = Instantiate(Bullet, transform.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().AddForce(-transform.up * BulletVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerBullet")){
            enemyAtualLife -= 10;
        }
    }
}
