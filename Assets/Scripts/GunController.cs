using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform gunFire;
	public float FireRate = 0.5f;
    public AudioClip fireClip;


	private bool gameRunning = true;
	private float nextFire = 0.0f;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		GameManager.instance.OnGameOver += () =>
		{
			this.gameRunning = false;
		};
	}

	void Update()
	{
		if (gameRunning == false) { return; }

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + FireRate;
            AudioController.instance.PlayOneShot(fireClip);

			Instantiate(bulletPrefab, gunFire.position, gunFire.rotation);
		}
	}
}