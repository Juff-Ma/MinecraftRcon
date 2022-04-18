using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MinecraftRcon
{

	[XmlRoot(ElementName = "query")]
	public class Query
	{

		[XmlAttribute(AttributeName = "enabled")]
		public bool Enabled { get; set; }

		[XmlText]
		public int Text { get; set; }
	}

	[XmlRoot(ElementName = "session")]
	public class Session
	{

		[XmlElement(ElementName = "query")]
		public Query Query { get; set; }

		[XmlAttribute(AttributeName = "host")]
		public string Host { get; set; }

		[XmlAttribute(AttributeName = "port")]
		public int Port { get; set; }

	}

	[XmlRoot(ElementName = "sessions")]
	public class Sessions
	{

		[XmlElement(ElementName = "session")]
		public List<Session> Session { get; set; }
	}

	[XmlRoot(ElementName = "settings")]
	public class Settings
	{

		[XmlElement(ElementName = "theme")]
		public string Theme { get; set; }

		[XmlElement(ElementName = "sessions")]
		public Sessions Sessions { get; set; }
	}
}
