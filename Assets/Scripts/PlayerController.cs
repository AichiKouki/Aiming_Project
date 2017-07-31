using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//public GameObject playerCollider;
	ThirdPersonEnemyController enemy;
	private bool collied = false;
	public bool catched=false;
	public bool thrown=false;

	private int func;//機能切り替え
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 

		if(Input.GetKeyDown(KeyCode.Space) && collied==true){
			if (func == 0) {
				catched = enemy.Catched ();
				Debug.Log (catched);
				func++;
			}else if (func == 1) {
				Thrown_Button ();
				func = 0;
			}
		}
		

	}


	void OnTriggerStay (Collider other){
        if( collied == true)
        {
            return;
        }

		if (other.gameObject.tag == "Enemy") {
			collied = true;
			Debug.Log ("敵にぶつかりました");
			enemy = other.gameObject.GetComponent<ThirdPersonEnemyController> ();
			//catched = enemy.Catched ();
			//Debug.Log (catched);
		}
	}

	void Thrown_Button(){
		collied = false;
		enemy.Thrown ();
        enemy = null;
	}
}
