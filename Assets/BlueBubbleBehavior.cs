using UnityEngine;
using System.Collections;

public class BlueBubbleBehavior : MonoBehaviour {

	enum status {MOVING = 1, IDLE = 2}
	int currStatus = 2;
	float baseTime = 0;
	Vector3 direction;
	float timeScale;

	void Start () {
		
	}

	void Update () {
		if (currStatus == (int)status.MOVING) {
			Move ();

			if (baseTime >= timeScale) {
				currStatus = (int)status.IDLE;
				baseTime = 0;
			}
		} else if (currStatus == (int)status.IDLE) {
			PickNewDestination ();
			currStatus = (int)status.MOVING;
		}
	}

	void PickNewDestination() {
		direction = new Vector3 (Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f), 0);
		timeScale = Random.Range (3, 10);
	} // end PickNewDestination

	void Move() {
		this.transform.position += direction * Time.deltaTime;
		baseTime += Time.deltaTime;
	} // end Move
}
