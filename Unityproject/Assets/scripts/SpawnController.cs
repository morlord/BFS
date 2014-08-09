using System.Globalization;
using System.Linq;
using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

	public int Score, Money;
    public float SpawnTime;
    public GameObject[] MobsArray;
	public GameObject Boss;
    public Transform[] SpawnLocationArray;
    public UnityEngine.UI.Text ScoreText;
    private double _score;
	public bool IsBoss;
	// Use this for initialization
	void Start () {
	Invoke("CreateMob",SpawnTime);
	    ScoreText.text = "0";
	    _score = 0;
		Money = 0;
	}

    void CreateMob()
    {
        int randomMob = Random.Range(0, MobsArray.Count());

        int randomSpawn = Random.Range(0, SpawnLocationArray.Count());

        Instantiate(MobsArray[randomMob], SpawnLocationArray[randomSpawn].position,
            SpawnLocationArray[randomSpawn].rotation);
	    if (_score >= Score)
	    {
			if(IsBoss)
				Invoke("CreateBoss",1500);
			else
			{
				Application.LoadLevel(5);
			}
	    }
		else
			Invoke("CreateMob",SpawnTime);
    }

	void CreateBoss()
	{
		
	}
	// Update is called once per frame
	void Update ()
	{
	}

    void AddScore(object num)
    {
        AddScore((int)num);
    }

    void AddScore(int num)
    {
        _score += num;
	    Money += num;
        ScoreText.text = _score.ToString();
    }

}
