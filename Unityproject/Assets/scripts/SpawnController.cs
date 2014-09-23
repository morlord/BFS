using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
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
	private int nextlvl;
	// Use this for initialization
	void Start()
	{
		if (Application.loadedLevel == 1)
			File.Delete("scores.txt");
		//Debug.Log(Application.dataPath+", "+Application.persistentDataPath);
		if (File.Exists("scores.txt"))
		{
			var f = File.OpenText("scores.txt");
			_score = int.Parse(f.ReadLine());
			f.Close();
		}
		var levelsAsset = Resources.Load<TextAsset>("levels");
		document=XDocument.Parse(levelsAsset.text);
		var node = document.Root;
		var t = node.Descendants("level").Single(a => a.Attribute("sceneid").Value == Application.loadedLevel.ToString());
		nextlvl = int.Parse(t.Attribute("nextlvl").Value);
	Invoke("CreateMob",SpawnTime);
	    ScoreText.text = _score.ToString();
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
				if (File.Exists("scores.txt"))
				{
					File.Delete("scores.txt");
					var f = File.CreateText("scores.txt");
					f.WriteLine(_score);
					f.Close();
				}
				else
				{
					var f = File.CreateText("scores.txt");
					f.WriteLine(_score);
					f.Close();
				}
				Application.LoadLevel(nextlvl);
			}
	    }
		else
			Invoke("CreateMob",SpawnTime);
    }

	void CreateBoss()
	{
		//int randomSpawn = Random.Range(0, SpawnLocationArray.Count());

		Instantiate(Boss, SpawnLocationArray[4].position,
			SpawnLocationArray[4].rotation);
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
