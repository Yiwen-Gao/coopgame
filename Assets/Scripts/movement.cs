using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour{
   
   private PlayerCharacter_Base playerCharacterBase;
   
   private void Awake(){
		playerCharacterBase = gameObject.GetComponent<PlayerCharacter_Base>();
    }
	
	private void Update(){
		Movement();
	}
	
	private void Movement(){
		float speed = 40f;
		float moveX = 0f;
		float moveY = 0f;
		
		if(Input.GetKey(KeyCode.W)){
			moveY = +1f;
		}
		if(Input.GetKey(KeyCode.S)){
			moveY = -1f;
		}
		if(Input.GetKey(KeyCode.A)){
			moveX = -1f;
		}
		if(Input.GetKey(KeyCode.D)){
			moveX = +1f;
		}
		
		Vector3 moveDir = new Vector3(moveX, moveY).normalized;
		transform.position += moveDir + speed + Time.deltaTime;
	}
}