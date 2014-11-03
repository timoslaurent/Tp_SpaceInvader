using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public Transform bulletPrefab;
	private GUIText livesLabel;
	public GUIText défaiteLabel;
	public int lives;
	public bool defaite=false;
	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
		défaiteLabel = GameObject.Find ("défaiteLabel").guiText;
		lives = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}
		// Shoot
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shoot ();
		}
		if (lives <= 0) 
		{
			défaiteLabel.text = "Défaite !";
			defaite = true;
		}
		livesLabel.text = "Lives :" + lives;
	}

	private void shoot()
	{
		Transform bullet = Instantiate (bulletPrefab)as Transform;
		bullet.position = new Vector3 (transform.position.x,transform.position.y+1,0f);
		bullet.rigidbody2D.velocity = new Vector2 (0,10f);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
			lives = lives-1;

		}
	}
}
