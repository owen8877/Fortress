using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBlock : MonoBehaviour {
	int direction;
	int[][] directionSet;

	// Use this for initialization
	void Start () {
		directionSet = new int[][]{new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}};
		    //up, left, down, right
	}

	int GetDirection() {
		if (Input.GetKey("up"))
			return 0;
		if (Input.GetKey("left"))
			return 1;
		if (Input.GetKey("down"))
			return 2;
		if (Input.GetKey("right"))
			return 3;
		return -1;
	}
	
	// Update is called once per frame
	void Update () {
		int direction = GetDirection();
		if (direction != -1) {
			this.transform.position += new Vector3(directionSet[direction][0], directionSet[direction][1], 0) * transform.localScale.x;
		}
	}
}
