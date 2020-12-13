using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Sprite head;
	public Sprite body;
	public Sprite tail;

	public int characterSize = 5;
	public float blockSize = 25f;
	public float speed = 0.1f;

	private float[,] positions;

    // Start is called before the first frame update
    void Start() {
        SetRepr(); //new float[5,2]{{0,0}, {0,1}, {0,2}, {1,2}, {1,3}};

        for (int i = 0; i < positions.GetLength(0); i++) {
        	GameObject block = new GameObject("Child");
        	SpriteRenderer sp = block.AddComponent<SpriteRenderer>();
        	if (i == 0) {
        		sp.sprite = head;
        	} else if (i == positions.GetLength(0) - 1) {
        		sp.sprite = tail;
        	} else {
        		sp.sprite = body;
        	}
        	
        	sp.drawMode = SpriteDrawMode.Sliced;
        	sp.size = new Vector2(blockSize, blockSize);
        	block.transform.parent = transform;
        	block.transform.position = new Vector3(positions[i,0] * blockSize, positions[i,1] * blockSize, 0f);
        	Debug.Log(block.transform.position);
        }
    }

    void SetRepr() {
    	positions = new float[characterSize,2]; 
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

    float[,] GetPositions() {
    	return positions;
    } 
}
