using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	[SerializeField] List<BallSpawn> spawnpoints;
	[SerializeField] float startingSpeed;
	[SerializeField] Rigidbody2D rigidBody2D;

	// Teleport the ball to a randomly chosen spawn point, reset its velocity, and put it into play
	public void Respawn() {

		rigidBody2D.velocity = Vector2.zero;

		BallSpawn chosenSpawn = spawnpoints[Random.Range(0, spawnpoints.Count)];
		Vector2 chosenAngle = chosenSpawn.spawnAngles[Random.Range(0, chosenSpawn.spawnAngles.Count)];
		chosenAngle.Normalize();

		Debug.Log("chosen angle was " + chosenAngle.ToString());

		rigidBody2D.position = chosenSpawn.transform.position;
		rigidBody2D.AddForce(chosenAngle * startingSpeed);

	}

}
