using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Peco : MonoBehaviour
{
	// スピード
	public float speedX = 5;
	public float speedY = 7;

	void Update ()
	{
		// 移動
		float x = Input.GetAxisRaw ("Horizontal");
		Vector2 direction = new Vector2 (x, 0).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * speedX;

		// ジャンプ
		Vector2 jump = new Vector2 (0, 1).normalized;

		if (Input.GetKeyDown("space"))
		{
			GetComponent<Rigidbody2D>().velocity += jump * speedY;
    }
	}
}
