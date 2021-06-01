using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHurdle : MonoBehaviour
{
    [Header("Movement Systems")]
    public float hurdleSpeed;
    private float hurdleX;

    [Header("Score Systems")]
    public GameObject player;
    public bool score;
    // Start is called before the first frame update
    void Start()
    {
        //## Instanciate player for each object that spawns
        player = GameObject.Find("Player") as GameObject;
        //##
    }

    // Update is called once per frame
    void Update()
    {
        // ## Hurdle Movement ##
        hurdleX = transform.position.x;
        hurdleX += hurdleSpeed * Time.deltaTime;
        transform.position = new Vector3(hurdleX, transform.position.y, transform.position.z);
        // ##---------------##
        if (hurdleX < player.transform.position.x && !score)
        {
            score = true;
            playerScript.score++;

        }

        // ## Hurdle Destroy ##
        if (hurdleX < -5)
        {
            Destroy(this.gameObject);
        }
        //##

    }
}
