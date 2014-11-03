using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
	public Transform invader1Prefab;
	public Transform invader2Prefab;
	public Transform invader3Prefab;
	public Transform[] invaders;
	public int index;
	private bool goingRight=false;

	public float vitesse;
	public int score;
	public GUIText victoryLabel;

	// Use this for initialization
	void Start ()
	{
		invaders = new Transform[55];
		index = 0;
		score = 0;
		vitesse = 15;
		victoryLabel = GameObject.Find("victoryLabel").guiText;
		//Lignes
		for (int i=0; i<5; i++) 
		{
			//Colonnes
			for (int j=0; j<11; j++)
			{
				Transform invader;
				if (i==0||i==1)
				{
					invader = Instantiate (invader1Prefab)as Transform;
					invader.transform.parent = transform;
					invaders[index] = invader;
					invaders[index].transform.position= new Vector3(j*3f-15,i*2.5f+12,0f); 
				}
				if (i==2 || i==3)
				{
					invader = Instantiate (invader2Prefab)as Transform;
					invader.transform.parent = transform;
					invaders[index] = invader;
					invaders[index].transform.position= new Vector3(j*3f-15,i*2.5f+2f,0f); 
				}
				if (i == 4)
				{

					invader = Instantiate (invader3Prefab)as Transform;
					invader.transform.parent = transform;
					invaders[index] = invader;
					invaders[index].transform.position= new Vector3(j*3f-15,i*2.5f-5.5f,0f); 
				}
				index = index +1;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (index=0; index<invaders.Length; index++)
		{
			if (invaders[index]!= null)
			{
				if(goingRight==false)
				{
					invaders[index].transform.Translate (vitesse*Time.deltaTime,0f,0f);
				}
				if (goingRight==true)
				{
					invaders[index].transform.Translate(-vitesse*Time.deltaTime,0f,0f);
				}
				Debug.Log(index);
				if ((invaders[index] == null) && (score ==540))
				{
					victoryLabel.text = "Victory !!!!!";
				}
			}
		}
	}

	public void moveInvadersCloser ()
	{
		goingRight = !goingRight;
		for (index=0; index<invaders.Length; index++) 
		{
			if(invaders[index] != null)
			{
				invaders[index].transform.Translate(0f,-50f*Time.deltaTime,0);
				vitesse = vitesse + 0.1f;
			}
		}
	}

	public void destroyInvader (Transform invader)
	{
		for (index=0; index < invaders.Length; index++)
		{
			//Debug.Log(invader.Equals(invaders[index]));
			if (invader == invaders[index]) 
			{
			//Debug.Log("gffgfdddd");
				Object.Destroy (invaders[index].gameObject);
				invaders[index] = null;
			}
		}
	}
}