using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public GameObject teleporter;
    //float
    public float speed;
    public float jumpForce;
    //ints
     public int score;
    private int enemy;
    private int lives;
    //text
    public Text winText;
    public Text scoreText;
    public Text livesText;
    private bool isTeleported;
    private bool isright;
    //audio
    public AudioSource sfxsource;
    public AudioClip sfx;
    //anim
    private Animator anim;

   
    void Start()
    {
        isright=true;
        anim= GetComponent<Animator>();
        sfxsource.clip= sfx;
         rb = GetComponent <Rigidbody2D> ();
        enemy= 0;
        score= 0;
        lives= 3;
        isTeleported= false;
        SetScoreText();
        SetLivesText();
        winText.text = " ";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal= Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (moveHorizontal,0);
        rb.AddForce (movement * speed);
        anim.SetBool("isRunning", true);
        if (isright == true){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (isright == false){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
       
        if (moveHorizontal == 0){
            anim.SetBool("isRunning", false);
        }
        if (moveHorizontal > 0){
            isright=true;
        }
        if (moveHorizontal < 0){
            isright=false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool ("isJumping", false);
            if(Input.GetKey (KeyCode.UpArrow))
            {
                rb.AddForce (new Vector2(0,jumpForce), ForceMode2D.Impulse);   
                anim.SetBool("isJumping",true);  
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score= score +1;
            SetScoreText();
        }
         if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();   
        }
    }
        void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 8)
     {
       winText.text = "You Win" ;
       sfxsource.Play();
     } 
     if (score == 4)
     {
       Teleport() ;
     } 
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
         if (lives == 0)
     {
       winText.text = "You Lost" ;
       player.SetActive(false);
     } 
    }
    void Teleport(){
            isTeleported = true;
            player.transform.position = teleporter.transform.position;
            lives = 3;
            SetLivesText();
        }
}
