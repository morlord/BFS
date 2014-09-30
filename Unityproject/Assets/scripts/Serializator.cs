using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.scripts
{
	public class Serializator
	{
		public static void Serialize(Hero hero, string datapath)
		{
			XmlSerializer serial=new XmlSerializer(typeof(Hero));
			FileStream fs=new FileStream(datapath,FileMode.Create);
			serial.Serialize(fs,hero);
			fs.Close();
		}

		public static void Deserialize(string datapath,out Hero hero)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Hero));

			FileStream fs = new FileStream(datapath, FileMode.Open);
			hero = (Hero)serializer.Deserialize(fs);
			fs.Close();
			
		}

		public static void Serialize(Stats hero, string datapath)
		{
			XmlSerializer serial = new XmlSerializer(typeof(Hero));
			FileStream fs = new FileStream(datapath, FileMode.Create);
			serial.Serialize(fs, hero);
			fs.Close();
		}

		public static void Deserialize(string datapath,out Stats stats)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Hero));

			FileStream fs = new FileStream(datapath, FileMode.Open);
			stats = (Stats)serializer.Deserialize(fs);
			fs.Close();
		}
	}
}
