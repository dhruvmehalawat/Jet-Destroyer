using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    scoreboard scoreBoard;
    [SerializeField] GameObject explosionenemy;
    [SerializeField] GameObject explosionHit;
    GameObject parentgameObject;
     [SerializeField] int scorePerkill = 15;
     [SerializeField] int HitPoint=3;
     int numberofHits = 1;
    void Start() {
        parentgameObject = GameObject.FindWithTag("runtimeActive");
        scoreBoard = GameObject.FindObjectOfType<scoreboard>();
        createRigidbody();
     }
    private void OnParticleCollision(GameObject other) {
       
       KillEnemy(HitPoint);
    }
    void processScore(){
        scoreBoard.IncreaseScore(scorePerkill);
    }
    void createRigidbody(){
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void KillEnemy(int HitPoints){
        if(numberofHits >= HitPoints){
         processScore();
         
        GameObject vfx = Instantiate(explosionenemy,transform.position,Quaternion.identity);

        vfx.transform.parent =  parentgameObject.transform;
        Destroy(gameObject);
        }
       
        GameObject vfxHit = Instantiate(explosionHit,transform.position,Quaternion.identity);
        vfxHit.transform.parent =  parentgameObject.transform;
        numberofHits +=1;
    }
}
