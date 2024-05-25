using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

	[SerializeField] Transform minPosition, maxPosition;
	Vector2 moveAngle;

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip soundHit;

    // Start is called before the first frame update
    void Start()
    {
		moveAngle = maxPosition.position - minPosition.position;
		moveAngle.Normalize();
		Recenter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	// Move the paddle with the given velocity, where a positive velocity moves it towards the maximum position and vice versa
	public void Move(float velocity) {

		float moveAmount = velocity * Time.deltaTime;

		if(velocity > 0) {
			transform.position = Vector2.MoveTowards(transform.position, maxPosition.position, moveAmount);
		} else if (velocity < 0) {
			transform.position = Vector2.MoveTowards(transform.position, minPosition.position, -moveAmount);
		}
	}

	// Center the paddle between the min and max position.
	public void Recenter() {
		transform.position = minPosition.position + ((maxPosition.position - minPosition.position) / 2);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		audioSource.PlayOneShot(soundHit);
	}


}
