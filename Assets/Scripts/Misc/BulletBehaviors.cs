using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviors : MonoBehaviour
{
    public GameObject explosion;
    private GameObject explosionInstant;
    public string targetTag;
    public float timeToExplosion = 0.2F;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(targetTag)){
            explosionInstant = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }    
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    void OnDestroy() {
        if(explosionInstant != null){
            Destroy(explosionInstant, timeToExplosion);    
        }
    }
}
