using UnityEngine;
using System.Collections;

public class CollisionControl : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Player")
			Application.LoadLevel (Application.loadedLevelName);
	}

}
