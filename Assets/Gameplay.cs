using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public GameObject redBubble;
	public GameObject blueBubble;

	const int MIN_NUM_OF_BUBBLES = 20;
	const int MAX_NUM_OF_BUBBLES = 30;

	const int MIN_SCALE = 1;
	const int MAX_SCALE = 5;

	float leftBorder;
	float rightBorder;
	float topBorder;
	float downBorder;

	void Start () {
		setScreenBoundaries ();
		spawnBlueBubbles ();
	}

	void Update () {
		moveRedBubble ();
	}

	// Generates n bubbles in random sizes and positions.
	void spawnBlueBubbles() {
		int number = Random.Range(MIN_NUM_OF_BUBBLES, MAX_NUM_OF_BUBBLES);

		if (blueBubble != null) {
			for (int i = 0; i < number; i++) {
				Vector3 position = new Vector3 (Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f), 0);

				float scale = Random.Range (MIN_SCALE, MAX_SCALE)/10.0f;
				GameObject bubble = Instantiate (blueBubble, position, Quaternion.identity) as GameObject;
				bubble.transform.localScale = new Vector3 (scale, scale, 1);
			}
		}
	} // end spawnBlueBubbles

	// Moves the red bubble with mouse hovering.
	void moveRedBubble() {
		if (redBubble == null)
			return;

		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 mousePos = Input.mousePosition;

		mousePos = new Vector3 (mousePos.x, mousePos.y, screenPos.z);
		Vector3 world = Camera.main.ScreenToWorldPoint (mousePos);

		// limit the red bubble inside screen
		if (world.x < leftBorder || world.x > rightBorder || world.y < downBorder || world.y > topBorder)
			return;

		redBubble.transform.position = world;
		Debug.Log (redBubble.transform.position.x + "," + redBubble.transform.position.y);
	} // end moveRedBubble


	void setScreenBoundaries() {
		Vector3 cornerPos = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 1f, Mathf.Abs(-Camera.main.transform.position.z)));
		leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
		rightBorder = cornerPos.x;
		topBorder = cornerPos.y;
		downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);
	} // end setScreenBoundaries

}
