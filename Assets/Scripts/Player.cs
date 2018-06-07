using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed;
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image HurtFlash;
    public float flashSpeed = 5f;
    public Color flashcol = new Color(1f, 0f, 0f, 0.1f);


    Vector3 move;
    Rigidbody rig;
    int FloorMask;
    float CamRayLength = 100f;
    bool isDead;
    bool Damaged;
    bool Heal;

	// Use this for initialization
	void Start ()
    {

        FloorMask = LayerMask.GetMask("Floor");

        rig = GetComponent<Rigidbody>();

        currentHealth = startingHealth;
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

        Turn();
	}
    void Update()
    {
        if (Damaged)
        {
            HurtFlash.color = flashcol;
        }
        else
        {
            HurtFlash.color = Color.Lerp(HurtFlash.color,Color.clear, flashSpeed * Time.deltaTime);
        }

        Damaged = false;
        Heal = false;
    }
    void Move(float h, float v)
    {
        move.Set(h, 0f, v);

        move = move.normalized * Speed * Time.deltaTime;

        rig.MovePosition(transform.position + move);
    }

    void Turn()
    {
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit FloorHit;

        if(Physics.Raycast(CamRay,out FloorHit, CamRayLength, FloorMask))
        {

            Vector3 Mouse = FloorHit.point - transform.position;

            Mouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(Mouse);

            rig.MoveRotation(newRotation);

        }
    }
    public void TakeDamage(int Amount)
    {
        Damaged = true;

        currentHealth -= Amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void GetHealth(int Amount)
    {

        Heal = true;

        currentHealth += Amount;
        healthSlider.value = currentHealth;

        //if (currentHealth >= 0)
        //{

        //}

    }

    void Death()
    {
        isDead = true;


        //Destroy(gameObject);
    }
}
