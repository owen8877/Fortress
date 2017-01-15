using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	private static Game _instance;
	private int N = 10;
	private List<List<GameObject>> blocks = new List<List<GameObject>>();
	private bool[,] xc, yc; // xc - xconnectivity, yc - yconnectivity

	public GameObject blockPrefab;
	public GameObject puzzleBg;
	public GameObject selectBlock;

	public static Game instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<Game>();
			}
			return _instance;
		}
	}

	public void init() {
		Debug.Log("init");
		float scale = puzzleBg.transform.localScale.x * 0.8f / N;
		for (int i = 0; i < N; ++i) {
			List<GameObject> blockList = new List<GameObject>();
			for (int j = 0; j < N; ++j) {
				GameObject block = Instantiate(blockPrefab);
				block.transform.localScale = new Vector3(scale, scale, 1);
				block.transform.position = new Vector3((i - N / 2.0f + 0.5f) * scale, (j - N / 2.0f + 0.5f) * scale, 0);
				blockList.Add(block);
			}
			blocks.Add(blockList);
		}
		selectBlock.transform.localScale = new Vector3(scale, scale, 1);
		selectBlock.transform.position = new Vector3((- N / 2.0f + 0.5f) * scale, (- N / 2.0f + 0.5f) * scale, 0);

		generateMap();
	}

	void generateMap() {
		xc = new bool[N + 1, N];
		yc = new bool[N, N + 1];
		for (int i = 0; i < N + 1; ++i) {
			for (int j = 0; j < N; ++j) {
				xc[i, j] = Random.value > 0.5f;
				yc[j, i] = Random.value > 0.5f;
			}
		}

		for (int i = 0; i < N; ++i) {
			for (int j = 0; j < N; ++j) {
				Block controller = blocks[i][j].GetComponent<Block>();
				controller.setBarrierStatus(
						new bool[]{
							(j == N - 1) ? false : yc[i, j + 1],
							(i == 0) ? false : xc[i, j],
							(j == 0) ? false : yc[i, j],
							(i == N - 1) ? false : xc[i + 1, j]
						})
					.setBorderEntranceStatus(
						new bool[]{
							(j != N - 1) ? false : yc[i, j + 1],
							(i != 0) ? false : xc[i, j],
							(j != 0) ? false : yc[i, j],
							(i != N - 1) ? false : xc[i + 1, j]
						})
					.setBorderStatus(
						new bool[]{
							(j != N - 1) ? false : !yc[i, j + 1],
							(i != 0) ? false : !xc[i, j],
							(j != 0) ? false : !yc[i, j],
							(i != N - 1) ? false : !xc[i + 1, j]
						});
			}
		}
	}
}
