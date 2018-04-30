using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Peco : MonoBehaviour
{
	// スピード
	public float speedX = 5;
	public float speedY = 7;

    public int jumpEnergyMax = 30;

    private int jumpEnergy;

	private void Start()
	{
        jumpEnergy = jumpEnergyMax;
	}

	void Update ()
	{
		// 移動
		float x = Input.GetAxisRaw ("Horizontal");
		Vector2 direction = new Vector2 (x, 0).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * speedX;


        // ジャンプ
        if (Input.GetKey("space"))
//        if(Input.GetButton("Jump"))
        {
            if(jumpEnergy > 0)
            {
                Vector2 jump = new Vector2(0, 1).normalized;
                GetComponent<Rigidbody2D>().velocity += jump * speedY;
                jumpEnergy -= 1;
            }
        }

	}

    void OnTriggerEnter2D(Collider2D c)
    {
        jumpEnergy = jumpEnergyMax;
    }
}
