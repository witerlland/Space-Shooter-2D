using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody2D;
    private GameObject GameController;

    public short playerTotalLife = 50;
    private short playerAtualLife;

    public GameObject  Bullet;

    public float PlayerVelocity = 5f;
    public float BulletVelocity = 10f;
    public bool right, left;
    // Start is called before the first frame update
    void Start()
    {
        // playerAnimator       = GetComponent<Animator>();
        playerRigidBody2D   = GetComponent<Rigidbody2D>();
        playerAtualLife     = playerTotalLife;
        GameController = GameObject.Find("GameController");
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction();    
        PlayerMoviment();

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject  bulletClone;

            bulletClone = Instantiate(Bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletVelocity);
        }
    }

    void PlayerMoviment(){
        float horizontalMov = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float verticalMov   = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        playerRigidBody2D.velocity = new Vector2(horizontalMov, verticalMov).normalized * PlayerVelocity;
    }

    void Direction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log("Valor: " + horizontal);

        //  Verifica a direcao do movimento e ativa animacao
        if(horizontal < 0){
            left = true;

            if(left){
                right = false;
            }

        }else if(horizontal > 0){
            right = true;

            if(right){
                left = false;
            }
        }else{
            right   = false;
            left    = false;
        }

        // Seta a animacao correta
        // playerAnimator.setBool('toLeft', left);
        // playerAnimator.setBool('toRight', right)

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("EnemyBullet")){
            GameController.GetComponent<GameController>().removePlayerLife(10);
        }
    }
}
