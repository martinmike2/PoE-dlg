﻿/*******************************************************************************
 * Copyright 2015 Valentin Milea
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ******************************************************************************/

using System;
using System.IO;
using System.Reflection;

namespace PoEDlgExplorer
{
	[Serializable]
	public sealed class Settings
	{
		public string GamePath;
		public string Localization;
		public bool PlayAudio;

		private static Settings _instance;

		public static Settings Instance
		{
			get { return _instance ?? (_instance = Xml.Deserialize<Settings>(FilePath)); }
		}

		public void Save()
		{
			Xml.Serialize(FilePath, this);
		}

		private Settings() { }

		private static string FilePath
		{
			get
			{
				string dirUri = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
				return new Uri(dirUri).LocalPath + @"\Settings.xml";
			}
		}
	}
}
