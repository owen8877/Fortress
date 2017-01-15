using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitButton : MonoBehaviour {
	private Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(() => Game.instance.init());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
