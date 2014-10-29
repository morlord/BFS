using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class endOfGameMobs : MonoBehaviour
{

	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider2)
	{
		if (collider2.gameObject.tag == "mob")
		{
			Destroy(FindObjectOfType<HeroBehavior>());
			Application.LoadLevel(3);
			DestroyObject(collider2.gameObject);
			var val = int.Parse(text.text);
			var tasset = Resources.Load<TextAsset>("scores");
			var xd = XDocument.Parse(tasset.text);
			var elem = new XElement("score");
			elem.SetAttributeValue("name","player");
			elem.SetAttributeValue("value",val);
			xd.Root.Add(elem);
			File.WriteAllText("scores.xml",xd.ToString());
			XmlWriter writer = new XmlTextWriter("Assets/Resources/scores.xml", Encoding.UTF8);
			xd.WriteTo(writer);
			writer.Close();
			//k++;
		}
	}
}