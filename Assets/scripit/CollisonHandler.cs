using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashvfx;
    [SerializeField] GameObject[] meshShip;
    float delay = 2f;
    void OnTriggerEnter(Collider other) {
    crashvfx.Play();
    GetComponent<playercontroller>().enabled= false;
     GetComponent<BoxCollider>().enabled= false;
    diableMesh();
    Invoke("reloadlevel",delay);
   }
   void reloadlevel(){
    int secneindex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(secneindex);
   }
   void diableMesh(){
    foreach(GameObject mesh in meshShip){
        mesh.GetComponent<MeshRenderer>().enabled=false;
    }
   }
}
