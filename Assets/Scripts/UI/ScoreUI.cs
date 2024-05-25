using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{

	[SerializeField] TMP_Text text;

	public void UpdateScore(int newScore) {
		text.text = newScore.ToString();
	}
}
