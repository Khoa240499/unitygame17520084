using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float speed = 100f, maxspeed = 4, maxjump = 4, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false;

    public int ourHealth;
    public int maxhealth = 5;

    public Rigidbody2D r2;
    public Animator anim;
    public float h = 0;
    public bool jump = false;
    public gamemaster gm;
    public PauseUI endUI;
    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        ourHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
        ///////////////
        //if (jump == true)
        //{
        //    if (grounded)
        //    {
        //        grounded = false;
        //        doublejump = true;
        //        r2.AddForce(Vector2.up * jumpPow);

        //    }
        //    else
        //    {
        //        StartCoroutine(Djump());
        //    }

        //}
    }

    public IEnumerator Djump()
    {
        yield return new WaitForSeconds(0.5f);
        if (doublejump && (jump == true) )
        {
            doublejump = false;
            r2.velocity = new Vector2(r2.velocity.x, 0);
            r2.AddForce(Vector2.up * jumpPow);

        }

    }
    public void Jumping(bool Bjump)
    {
        jump = Bjump;
    }
    public void Move(float Binput)
    {
        h = Binput;
    }
    void FixedUpdate()
    {
        //Move(h);

        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);



        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        if (ourHealth <= 0)
        {
            Death();
        }
    }


    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void Damage(int damage)
    {
        ourHealth -= damage;
       gameObject.GetComponent<Animation>().Play("redflash");
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        if (faceright)
              r2.AddForce(new Vector2(Knockdir.x * -50, Knockdir.y * 50));
        else
            r2.AddForce(new Vector2(Knockdir.x * 50, Knockdir.y * 50));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }
        if (col.CompareTag("end"))
        {
            SceneManager.LoadScene(1);
        }

    }
   
}