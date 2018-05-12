using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Peco : MonoBehaviour
{
	// スピード
	public float speedX = 5;
	public float speedY = 7;
    public float speedT = 10000;

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
        if (Input.GetKey("space")) {
            if(jumpEnergy > 0)
            {
                Vector2 jump = new Vector2(0, 1).normalized;
                GetComponent<Rigidbody2D>().velocity += jump * speedY;
                jumpEnergy -= 1;
            }
        }
        if(GetComponent<Rigidbody2D>().velocity.y > float.Epsilon || GetComponent<Rigidbody2D>().velocity.y < -1 * float.Epsilon)
        {
            GetComponent<Animator>().SetBool("IsJump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJump", false);                
        }

        //回転
        if(Input.GetKey(KeyCode.Z))
        {
            GetComponent<Rigidbody2D>().angularVelocity += speedT;   
        }
	}

    void OnTriggerEnter2D(Collider2D c)
    {
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// レイヤーがFoot,Groundでなければ何もしない
		if ( layerName != "Foot" && layerName != "Ground" ) return;

		// ジャンプ力の回復
        jumpEnergy = jumpEnergyMax;
    }

    public int GetJumpEnergy()
    {
        return jumpEnergy;
    }
    public int GetJumpEnergyMax()
    {
        return jumpEnergyMax;
    }
    public float GetJumpEnergyRate()
    {
        return ((float)jumpEnergy / (float)jumpEnergyMax);
    }
}
