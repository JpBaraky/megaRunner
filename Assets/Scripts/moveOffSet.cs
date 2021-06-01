using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffSet : MonoBehaviour
{
    private Material material;
    private playerScript playerScript;
    public float offSetSpeed;
    private float offSet;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<playerScript>();
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += offSetSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex" , new Vector2(offSet, 0));
    }
}
