using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Romiee RomScript;
    public GameObject Dog;
    //public GameObject Borular;


    
    void Start()
    {
       StartCoroutine(SpawnObject());
       
    }

    
    void Update()
    {
        
    }

    public IEnumerator SpawnObject()
    {
        while (!RomScript.isDead)
        {
            Instantiate(Dog, new Vector3(17,(float)(-2.4)), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
        

    }

    
}
