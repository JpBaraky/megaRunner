using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameOver : MonoBehaviour

{

    [Header("Score Systems")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI hiScoreTxt;
    // Start is called before the first frame update
    void Start()
    {   //## Prints Score and Hi Score
        scoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
        hiScoreTxt.text = PlayerPrefs.GetInt("HiScore").ToString();
        //##
    }

    // Update is called once per frame
   
}
