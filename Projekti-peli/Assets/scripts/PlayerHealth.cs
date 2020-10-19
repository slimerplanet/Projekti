using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour 
{
	public int Health = 150;
	void Update()
	{
		if (Health <= 0)
            Die();
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		Debug.Log("Health = " + Health.ToString());
	}

	private void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
