using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicplayer : MonoBehaviour
{
    void Awake() {
        int numofPlayer = FindObjectsOfType<musicplayer>().Length;
        if(numofPlayer>1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
