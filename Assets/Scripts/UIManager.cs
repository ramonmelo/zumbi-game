using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Slider healthBar;

	

	public void RestartGameHandler()
	{
		GameManager.instance.RaiseRestart();
	}
}
