using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	private bool[][] status = new bool[][]{new bool[]{false, false, false, false},
		new bool[]{false, false, false, false},
		new bool[]{false, false, false, false},
		new bool[]{false, false, false, false}};
	
	void Update() {
		GameObject barrier = transform.FindChild("barrier").gameObject;
		barrier.transform.FindChild("top").gameObject.SetActive(status[0][0]);
		barrier.transform.FindChild("left").gameObject.SetActive(status[0][1]);
		barrier.transform.FindChild("bottom").gameObject.SetActive(status[0][2]);
		barrier.transform.FindChild("right").gameObject.SetActive(status[0][3]);
		GameObject borderEntrance = transform.FindChild("border-entrance").gameObject;
		borderEntrance.transform.FindChild("top").gameObject.SetActive(status[1][0]);
		borderEntrance.transform.FindChild("left").gameObject.SetActive(status[1][1]);
		borderEntrance.transform.FindChild("bottom").gameObject.SetActive(status[1][2]);
		borderEntrance.transform.FindChild("right").gameObject.SetActive(status[1][3]);
		GameObject border = transform.FindChild("border").gameObject;
		border.transform.FindChild("top").gameObject.SetActive(status[2][0]);
		border.transform.FindChild("left").gameObject.SetActive(status[2][1]);
		border.transform.FindChild("bottom").gameObject.SetActive(status[2][2]);
		border.transform.FindChild("right").gameObject.SetActive(status[2][3]);
		GameObject line = transform.FindChild("line").gameObject;
		line.transform.FindChild("top").gameObject.SetActive(status[3][0]);
		line.transform.FindChild("left").gameObject.SetActive(status[3][1]);
		line.transform.FindChild("bottom").gameObject.SetActive(status[3][2]);
		line.transform.FindChild("right").gameObject.SetActive(status[3][3]);
	}

	public bool[] getBarrierStatus() {
		return status[0];
	}

	public Block setBarrierStatus(bool[] barrierStatus) {
		status[0] = barrierStatus;
		return this;
	}

	public bool[] getBorderEntranceStatus() {
		return status[1];
	}

	public Block setBorderEntranceStatus(bool[] borderEntranceStatus) {
		status[1] = borderEntranceStatus;
		return this;
	}

	public bool[] getBorderStatus() {
		return status[2];
	}

	public Block setBorderStatus(bool[] borderStatus) {
		status[2] = borderStatus;
		return this;
	}

	public bool[] getLineStatus() {
		return status[3];
	}

	public Block setLineStatus(bool[] lineStatus) {
		status[3] = lineStatus;
		return this;
	}
}
