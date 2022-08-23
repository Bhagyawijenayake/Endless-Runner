using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaayerController : MonoBehaviour
{
    private Rigidbody playaerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround= true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtparticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    


    // Start is called before the first frame update
    void Start()
    {
        playaerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            playaerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtparticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstracle"))
        {
            gameOver=true;
            Debug.Log("Gmae over");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtparticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }

       
    }
}
