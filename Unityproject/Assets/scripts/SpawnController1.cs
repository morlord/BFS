using System.Linq;
using UnityEngine;
using System.Collections;

public class SpawnController1 : MonoBehaviour
{

    public float SpawnTime;
    public GameObject[] MobsArray;
    public Transform[] SpawnLocationArray;
    public GUIText ScoreText;
    private int _score;
	// Use this for initialization
	void Start () {
	Invoke("CreateMob",SpawnTime);
	    ScoreText.text = "0";
	    _score = 0;
	}

    void CreateMob()
    {
        int randomMob = Random.Range(0, MobsArray.Count());

        int randomSpawn = Random.Range(0, SpawnLocationArray.Count());

        Instantiate(MobsArray[randomMob], SpawnLocationArray[randomSpawn].position,
            SpawnLocationArray[randomSpawn].rotation);

        Invoke("CreateMob",SpawnTime);
    }
	// Update is called once per frame
	void Update () {
	
	}

    void AddScore(object num)
    {
        AddScore((int)num);
    }

    void AddScore(int num)
    {
        _score += num;
        ScoreText.text = _score.ToString();
    }

}
