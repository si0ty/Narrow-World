using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHolder : MonoBehaviour
{
	private bool tier1Unlocked;
	private bool tier2Unlocked;
	private bool tier3Unlocked;

	public GameObject firstPosition;

	private int totalPositions = 15;
	private float buttonSpacing = 1;

	private List<Vector3> positions;
	public List<GameObject> buttons;


	private void Start() {
		positions = new List<Vector3>();

	
	}

	private ButtonHolder(List<Vector3> positions) {
		this.positions = positions;

		for (int i = 0; i < totalPositions; i++) {
			positions.Add(new Vector3(firstPosition.transform.position.x, firstPosition.transform.position.y, transform.position.z));
			if (i > 0) {
				positions.Add(new Vector3(positions[i - 1].x + buttonSpacing, positions[i - 1].y, positions[i - 1].z));

			}
		}
	}

	private void SetButtonsPosition() {
		if (tier1Unlocked) {

		}

		if (tier2Unlocked) {

		}

		if (tier3Unlocked) {

		}
	}
}
