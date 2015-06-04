﻿using System;
using Newtonsoft.Json.Linq;

namespace CodeWalriiNotify
{
	public class APIMeta
	{
		public string Whoami { get; private set; }

		public VersionStruct Version { get; private set; }

		public ConfigurationStruct Configuration { get; private set; }

		public DefaultStruct Defaults { get; private set; }

		public APIMeta(string Json)
		{
			try {

				// Parse the Json Data
				dynamic apiObj = JObject.Parse(Json);

				// Var declarations
				var cfg = new ConfigurationStruct();
				var def = new DefaultStruct();
				var ver = new VersionStruct();

				// Process Informations
				Whoami = (string)apiObj.whoami;

				ver.Major = (uint)apiObj.version[0];
				ver.Minor = (uint)apiObj.version[1];
				ver.Revision = (uint)apiObj.version[2];

				cfg.CacheTTL = (uint)apiObj.configuration.cache_ttl;
				cfg.CachePosts = (byte)apiObj.configuration.cache_posts;

				def.MaxPosts = (byte)apiObj.defaults.max_posts;
				def.HTMLStripmode = (string)apiObj.defaults.html_stripmode;

				Version = ver;
				Configuration = cfg;
				Defaults = def;

			} catch (Exception ex) {
				throw ex;
			}
		}

		public struct VersionStruct
		{
			public uint Minor;
			public uint Major;
			public uint Revision;
		}

		public struct ConfigurationStruct
		{
			public uint CacheTTL;
			public byte CachePosts;
		}

		public struct DefaultStruct
		{
			public byte MaxPosts;
			public string HTMLStripmode;
		}
	}
}

