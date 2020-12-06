using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Sprite head;
	public Sprite body;
	public Sprite tail;

	public int blockSize = 5;
	public float speed = 0.1f;

    // Start is called before the first frame update
    void Start() {
        float[,] positions = CreateRep(); //new float[5,2]{{0,0}, {0,1}, {0,2}, {1,2}, {1,3}};

        for (int i = 0; i < positions.GetLength(0); i++) {
        	GameObject block = new GameObject("Child");
        	SpriteRenderer sp = block.AddComponent<SpriteRenderer>();
        	sp.sprite = head;
        	block.transform.parent = transform;
        	float spriteSize = 25f; //sp.sprite.rect.height;
        	block.transform.position = new Vector3(positions[i,0] * spriteSize, positions[i,1] * spriteSize, 0f);
        	Debug.Log(block.transform.position);
        }
    }

    float[,] CreateRep() {
    	float[,] positions = new float[blockSize,2]; 
    	int dif = 1;
    	positions[0,0] = positions[0,1] = 0;
    	for (int i = 1; i < positions.GetLength(0); i++) {
    		int next = Random.Range(0, 2);
    		if (next == 0) {
    			positions[i,0] = positions[i-1,0] + dif;
    			positions[i,1] = positions[i-1,1];
			} else {
				positions[i,0] = positions[i-1,0];
    			positions[i,1] = positions[i-1,1] + dif;
			}
			Debug.Log(positions[i,0] + " " + positions[i,1]);
    	}

    	return positions;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
    	float xDir = Input.GetAxis("Horizontal");
    	float yDir = Input.GetAxis("Vertical");
    	Vector3 moveDir = new Vector3(xDir, yDir, 0f);
    	transform.position += moveDir * speed;
    }
}
