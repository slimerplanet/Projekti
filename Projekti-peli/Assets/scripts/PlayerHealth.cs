using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour 
{
	public float Health = 150;
	public float dmgRes = 0.1f;
	private float finalDamage;
	void Update()
	{
		if (Health <= 0)
            Die();
	}

	public void TakeDamage(float damage)
	{
		finalDamage = damage * dmgRes;
		Health -= finalDamage;
		Debug.Log("Health = " + Health.ToString());
	}

	private void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
