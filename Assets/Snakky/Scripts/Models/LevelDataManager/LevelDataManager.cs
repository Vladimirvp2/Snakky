using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

namespace Snakyy
{
	public class LevelDataManager : ILevelDataManager
	{
		static LevelDataManager manager;
		string m_DataFile = GameConfig.ConfigFiles.LEVELS_DATA_CONFIG;

		// these dates can change over game time
		int m_CurrLevel = 1;
		int m_LeftLives = 3;
		EatObjectsEnum m_MainEatObject = EatObjectsEnum.FROG;
		Dictionary<int, LevelDataStruct > m_EatObjectsData = new Dictionary<int, LevelDataStruct > ();
		Dictionary<EatObjectsEnum, BonusesEnum > m_ObjectBonusMatch = new Dictionary<EatObjectsEnum, BonusesEnum> ();
		LevelDataStruct m_CurrLevelData;
	
		public static LevelDataManager GetInstance ()
		{
			if (manager == null) {
				lock (typeof(LevelDataManager)) {
					if (manager == null)
						manager = new LevelDataManager ();
				}
			}
		
			return manager;
		}

		public LevelDataManager ()
		{
			init ();
			//loadDefaultData();
		}

		private void init ()
		{
			m_EatObjectsData.Clear ();
			m_ObjectBonusMatch.Clear ();

			TextAsset fileData = (TextAsset)Resources.Load (m_DataFile, typeof(TextAsset));

			if (fileData == null) {
				Debug.Log (m_DataFile + " doesn't exists.");
				// load default data
				loadDefaultData ();
				return;
			}

			// if config file exist, parse it
					
			string text = fileData.text;

			var N = SimpleJSON.JSON.Parse (text);
			// parse and load data
			Debug.Log ("Parse and load levels data");

			string version = N ["version"].Value;

			// parse and load object-bonus types match
			JSONArray bonusesData = N ["ObjectsBonuses"].AsArray;
			foreach (JSONNode bonusNode in bonusesData) {
				EatObjectsEnum objectType = (EatObjectsEnum)bonusNode ["objectType"].AsInt;
				BonusesEnum bonusType = (BonusesEnum)bonusNode ["bonusType"].AsInt;
				m_ObjectBonusMatch.Add (objectType, bonusType);
			}

			// parse game objects data
			JSONArray levelsData = N ["levelsData"].AsArray;
			foreach (JSONNode levelNode in levelsData) {
				LevelDataStruct levelData = new LevelDataStruct ();
				levelData.eatObjectsData = new List<EatObjetcStruct> ();
				levelData.levelN = levelNode ["level"].AsInt;
				levelData.livesN = levelNode ["livesN"].AsInt;
				levelData.fieldTileWidth = levelNode ["fieldTileWidth"].AsInt;
				levelData.mainEatObject = (EatObjectsEnum)levelNode ["mainEatObject"].AsInt;
				levelData.snakeEatAcceleration = levelNode ["snakeAcceleration"].AsFloat;
				Debug.Log ("Level: " + levelData.levelN.ToString () + " Lives: " + levelData.livesN.ToString () +
					" FieldWidth: " + levelData.fieldTileWidth.ToString () + " MainObject: " + levelData.mainEatObject.ToString () + 
					" Snake Acceleration: " + levelData.snakeEatAcceleration.ToString ());

				// parse field objects data
				JSONArray objectsData = levelNode ["objects"].AsArray;
				foreach (JSONNode objectNode in objectsData) {
					EatObjetcStruct data;

					data.type = (EatObjectsEnum)objectNode ["objectType"].AsInt;
					data.probabilityPerSecond = objectNode ["random"].AsFloat;
					data.maxNumberOnField = objectNode ["maxNum"].AsInt;
					data.bonusAmountMin = objectNode ["bonusAmountMin"].AsInt;
					data.bonusAmountMax = objectNode ["bonusAmountMax"].AsInt;
					data.bonusType = getBonusTypeByObjectType (data.type);

					levelData.eatObjectsData.Add (data);
				}

				m_EatObjectsData.Add (levelData.levelN, levelData);
			}



			renewCurrLevelData ();
			Debug.Log ("Levels data loaded successfully");

		}

		void loadDefaultData ()
		{
			m_ObjectBonusMatch.Add ((EatObjectsEnum)0, (BonusesEnum)0);
			m_ObjectBonusMatch.Add ((EatObjectsEnum)1, (BonusesEnum)2);
			
			LevelDataStruct levelData = new LevelDataStruct ();
			levelData.eatObjectsData = new List<EatObjetcStruct> ();
			levelData.levelN = 1;
			levelData.livesN = 3;
			levelData.fieldTileWidth = 29;
			levelData.mainEatObject = (EatObjectsEnum)0;
			levelData.snakeEatAcceleration = 0.04f;

			// add object data
			EatObjetcStruct data;
			
			data.type = (EatObjectsEnum)1;
			data.probabilityPerSecond = 0.2f;
			data.maxNumberOnField = 2;
			data.bonusAmountMin = 10;
			data.bonusAmountMax = 20;
			data.bonusType = getBonusTypeByObjectType (data.type);
			levelData.eatObjectsData.Add (data);

			m_EatObjectsData.Add (levelData.levelN, levelData);

			renewCurrLevelData ();
		}

		public int currLevel {
			get{ return m_CurrLevel;}
			set {
				if (m_EatObjectsData.ContainsKey (m_CurrLevel)) {
					m_CurrLevel = value;
					renewCurrLevelData ();
				} else {
					Debug.Log ("Level " + m_CurrLevel + " not exists");
				}
			}
		}

		private void renewCurrLevelData ()
		{
			if (m_EatObjectsData.ContainsKey (m_CurrLevel)) {
				m_CurrLevelData = m_EatObjectsData [m_CurrLevel];
				setFullLives ();
			}
		}

		public int fieldTileWidth {
			get{ return m_CurrLevelData.fieldTileWidth;}
		}

		public int livesLeft {
			get{ return m_LeftLives;}
		}

		public EatObjectsEnum mainEatObject {
			get{ return m_CurrLevelData.mainEatObject;}
		}

		public float snakeAcceleration {
			get{ return m_CurrLevelData.snakeEatAcceleration; }
		}

		public List<EatObjetcStruct> eatObjectsData {
			get{ return m_CurrLevelData.eatObjectsData; }
		}

		// if no data found, throws NullReferenceException
		public EatObjetcStruct eatObjectData (EatObjectsEnum type)
		{
			foreach (EatObjetcStruct data in m_CurrLevelData.eatObjectsData) {
				if (data.type == type) {
					return data;
				}
			}

			return new EatObjetcStruct ();
		}

		public BonusesEnum getBonusTypeByObjectType (EatObjectsEnum type)
		{
			if (m_ObjectBonusMatch.ContainsKey (type)) {
				return m_ObjectBonusMatch [type];
			}
	        
			return BonusesEnum.NONE;
		}
		
		public void decreaseLive ()
		{
			if (m_LeftLives > 0) {
				m_LeftLives--;
			}
		}

		public void setFullLives ()
		{
			m_LeftLives = m_CurrLevelData.livesN;
		}
	}

}



