using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerScript : MonoBehaviour
{

    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private AudioSource playerAudio;
    [Header("Movement Systems")]
    public bool sliding;
    public bool jumping;
    public bool grounded;
    public float jumpForce;
    public float slideTime;
    [Header("Colision Systems")]
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Transform colisor;
    [Header("Audio Systems")]
    public AudioClip[] sounds;
    [Header("Score Systems")]
    public static int score;
    public TextMeshProUGUI scoreTxt;

    
    
    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // Turn off VSync
        Application.targetFrameRate = 45; // limit game frame rate
    }
    void Start()
    {
        //## Component to variable starters ##
        playerAudio = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        //## 
        score = 0;
        PlayerPrefs.SetInt("Score", score);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString(); // Put the score in the text box
        //# Sliding System ##
        if (Input.GetMouseButtonDown(1) && grounded && !sliding)
        {

            StartCoroutine("tempoSlide");
        }
        //##
        //## Jumping System ##
        if (Input.GetMouseButtonDown(0) && grounded)
        { 
            sliding = false;
            jumping = true;
            playerRb.AddForce(new Vector2(0, jumpForce));
            playerAudio.PlayOneShot(sounds[0]);

        }
        //##   

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround); // Circle to check ground colision
        //## Animator/Script correlations ##
        playerAnimator.SetBool("Jump", !grounded);
        playerAnimator.SetBool("Slide", sliding);
        //## 
    }
    // ## Slide timer countdown and colider changer ##
    IEnumerator tempoSlide()
    {
        sliding = true;
        playerAudio.PlayOneShot(sounds[1]);
        colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.2f, colisor.position.z);
        yield return new WaitForSecondsRealtime(slideTime);
        sliding = false;
        colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.2f, colisor.position.z);
    }
    // ##
    //## Hurdle colision system ##
    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("Score", score);
        if(score > PlayerPrefs.GetInt("HiScore")){
            PlayerPrefs.SetInt("HiScore", score);
        }


        SceneManager.LoadScene("GameOver");

    }
    // ##
   
}
