using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Animator playerAnimator; // cria uma variavel do tipo animator para poder ultilizar o animator do personagem
    private Rigidbody2D playerRb; // cria uma variavel tipo RigidBody 2d para poder ser ultilizada posteriormente 

    public bool sliding; // verifica se o personagem esta fazendo um slide
    public bool jumping; // verifica se o personagem esta pulando
    public bool grounded; // verifica se o personagem esta no chão
    public float jumpForce; // define a força de pulo do personagem
    public float slideTime; // define o quanto tempo dura o slide; tempo em Segundos
    public LayerMask whatIsGround; // definem quais Layers vão ser consideradas Chão
    public Transform groundCheck; //pega a posição do objeto Ground Check
    public Transform colisor; // posição do colisor 
    // Start is called before the first frame update
    private void Awake() {
        QualitySettings.vSyncCount = 0; // desliga o VSync
        Application.targetFrameRate = 45; // limita a taxa de quadros do jogo
    }
    void Start()
    {
        playerAnimator = GetComponent<Animator>(); // pega o animator do personagem e coloca ele em uma variavel
        playerRb = GetComponent<Rigidbody2D>(); // pega o rigid Body do personagem e coloca ele em uma variavel
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Slide") && grounded && !sliding) { // comando para fazer o slide se o player estiver no chão
                      
            StartCoroutine("tempoSlide"); // comeca a rotina tempo Slide, que coloca o bool sliding como falso depois de um tempo determinado
        }
            if(Input.GetButtonDown("Jump") && grounded) { // comando para fazer o pulo se o player estiver no chão
            sliding = false;
            jumping = true;
            playerRb.AddForce(new Vector2(0,jumpForce)); // adiciona força no RigidBody do personagem para jogar ele para cima
            
            }
      
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);// cria um circulo na posição do objeto Ground Check com o tamanho de 0.2f. Verifica somente a colisão com as Layers que estão definidas no What is Ground
        playerAnimator.SetBool("Jump", !grounded); // define que a variavel grounded ao contrario se relaciona com o parametro Jump no Animator
        playerAnimator.SetBool("Slide",sliding); // define que a variavel sliding se relaciona com o parametro Slide no Animator
    }
    IEnumerator tempoSlide() { // uma rotina que roda simultaniamente com o resto, sem parar para ter que esperar
        sliding = true;
        colisor.position = new Vector3(colisor.position.x,colisor.position.y - 0.2f , colisor.position.z); // muda a posição do colisor durante o slide
        yield return new WaitForSecondsRealtime(slideTime); // espera em segundos o valor da variavel slideTime
        sliding = false;
        colisor.position = new Vector3(colisor.position.x,colisor.position.y + 0.2f,colisor.position.z); // volta o colisor para a posição original

    }
}
