using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
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
	private XDocument document;
	// Use this for initialization
	void Start () {
		//Debug.Log(Application.dataPath+", "+Application.persistentDataPath);
		var levelsAsset = Resources.Load<TextAsset>("levels");
		document=XDocument.Parse(levelsAsset.text);
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
				Invoke("CreateBoss",7);
			else
			{
				Application.LoadLevel(4);
			}
	    }
		else
			Invoke("CreateMob",SpawnTime);
    }

	void CreateBoss()
	{
		int randomSpawn = Random.Range(0, SpawnLocationArray.Count());

		Instantiate(Boss, SpawnLocationArray[randomSpawn].position,
			SpawnLocationArray[randomSpawn].rotation);
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
