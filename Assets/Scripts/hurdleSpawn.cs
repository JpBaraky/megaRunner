using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleSpawn : MonoBehaviour
{
    public GameObject hurdlePreFab;
    public float spawnRateMin;
    public float spawnRateMax;
    public bool spawning;
    private int position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawning){
        StartCoroutine("spawnTimer");
        }
    }

    // ## Hurdle Spawner with random position and timer ##
    private IEnumerator spawnTimer(){
        spawning = true;
        position = Random.Range(0,2); 
        
        yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        GameObject tempPreFab =  Instantiate(hurdlePreFab) as GameObject;
       
        if(position == 1){
             tempPreFab.transform.position = new Vector3(transform.position.x, -1.47f, tempPreFab.transform.position.z);
        } else {
             tempPreFab.transform.position = new Vector3(transform.position.x, -0.8f, tempPreFab.transform.position.z);
        }
        spawning = false;
    } 
    //##
}
