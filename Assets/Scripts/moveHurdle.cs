using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHurdle : MonoBehaviour
{
    public float hurdleSpeed;
    private float hurdleX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ## Hurdle Movement ##
        hurdleX = transform.position.x;
        hurdleX += hurdleSpeed * Time.deltaTime;
        transform.position = new Vector3(hurdleX, transform.position.y, transform.position.z); 
        // ##---------------##
    }
}
