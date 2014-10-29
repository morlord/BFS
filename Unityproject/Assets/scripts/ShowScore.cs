using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
	public Text text;
	// Use this for initialization
	private void Start()
	{
		var levelsAsset = Resources.Load<TextAsset>("scores");
		var document = XDocument.Parse(levelsAsset.text);
		var node = document.Root;
		text.text = string.Empty;//node.Elements().ToString();
		var t = node.Elements("score").Select(a => a).OrderByDescending(a => int.Parse(a.Attribute("value").Value));
		for (int i=0;i<(t.Count()<10?t.Count():10);i++)
		{
			text.text += t.ElementAt(i).Attribute("name").Value + " " + t.ElementAt(i).Attribute("value").Value+"\n";
		}
	}

	// Update is called once per frame
	private void Update()
	{

	}
}