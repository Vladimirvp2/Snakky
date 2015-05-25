using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System;

namespace Snakyy
{
	public class LocalizationManager : ILocalizationManager
	{
		
		static LocalizationManager manager;
		LanguagesEnum m_CurrLanguage = LanguagesEnum.EN;
		Dictionary<string, string> m_Vocabulaty = new Dictionary<string, string> ();
	
		public static LocalizationManager GetInstance ()
		{
			if (manager == null) {
				lock (typeof(LocalizationManager)) {
					if (manager == null)
						manager = new LocalizationManager ();
				}
			}
			
			return manager;
		}
		
		public LocalizationManager ()
		{
			loadLocalization ();
		}

		void loadLocalization ()
		{
			m_Vocabulaty.Clear ();
			// get localization file
			string locFile = GameConfig.ConfigFiles.getLoclizationFile (m_CurrLanguage);
			// parse and load localization data for the current language


			TextAsset fileData = (TextAsset)Resources.Load (locFile, typeof(TextAsset));
			// if config file exist, parse it
			if (fileData == null) {
				Debug.Log ("LocalizationManager. " + locFile + " doesn't exists.");
				return;
			}

			string text = fileData.text;
			
			var N = SimpleJSON.JSON.Parse (text);
			// parse and load data
			Debug.Log ("Parse and load localization data for " + m_CurrLanguage.ToString ());

			string version = N ["version"].Value;
			
			// parse and load object-bonus types match
			JSONArray stringData = N ["string_data"].AsArray;
			foreach (JSONNode stringNode in stringData) {
				string tag = stringNode ["tag"];
				string word = stringNode ["word"];
				m_Vocabulaty.Add (tag, word);
			}
		}

		public void setCurrLanguage (LanguagesEnum l)
		{
			if (l != m_CurrLanguage) {
				m_CurrLanguage = l;
				loadLocalization ();
			}
		}

		public LanguagesEnum currLanguage {
			get {
				return m_CurrLanguage;
			}
		}
		
		public string getString (string tag)
		{
			if (m_Vocabulaty.ContainsKey (tag)) {
				return m_Vocabulaty [tag];
			}

			Debug.Log ("LocalizationManager. No word found for the tag " + tag + "." +
				"Empty string returned");

			return "";
		}

		public void setNextLanguage ()
		{
			// determines if the current language was found in the enum.
			// The next value must be returned
			bool currLanFound = false;
			LanguagesEnum nextL = m_CurrLanguage;
			foreach (LanguagesEnum value in Enum.GetValues(typeof(LanguagesEnum))) {
				if (currLanFound) {
					nextL = value;
				}
				// find next enum element relativ to the current language
				if (value == m_CurrLanguage) {
					currLanFound = true;
				}
			} 

			m_CurrLanguage = nextL;
			loadLocalization ();
		}
	}
}