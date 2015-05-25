using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Snakyy
{
	
	public class UserDataManager : IUserDataManager 
	{

		static UserDataManager manager;

		private UserDataStruct m_UserData;
		private int m_CurrScore;
		private int m_CurrLevel;
		private int m_LivesLeft;

		// tags for PlayerPrefs
		const string USER_ID_TAG = "User Id";
		const string USER_NAME_TAG = "User name";
		const string INPUT_CONTROLLER_TAG = "Input controller";
		const string SKIN_TYPE_TAG = "Skin type";
		const string LANGUAGE_TAG = "Language";
		const string CAMERA_TYPE_TAG = "Camera type";
		const string VIBRATION_TAG = "Vibration";
		const string SOUND_TAG = "Sound";
		const string COINS_TAG = "Coins";
		const string MAX_SCORE_TAG = "Score";
		// Level1, Level2...
		const string LEVEL_MAX_SCORE_TAG = "Level";
		
		public static UserDataManager GetInstance()
		{
			if (manager == null)
			{
				lock (typeof(UserDataManager))
				{
					if (manager == null)
						manager = new UserDataManager();
				}
			}
			
			return manager;
		}
		
		public UserDataManager()
		{
			init();
		}
	
		void init()
		{
			// case first start load default user data and save 
			if (PlayerPrefs.GetString( USER_ID_TAG ).Length == 0)
			{
				initDefaultData();
				Debug.Log ("UserDataManager, init default data");
			}
			else
			{
				Debug.Log ("UserDataManager, loading saved user data");
				m_UserData.m_UserId = PlayerPrefs.GetString( USER_ID_TAG );
			    m_UserData.m_UserName = PlayerPrefs.GetString( USER_NAME_TAG );
			    m_UserData.m_InputController = (InputControllerEnum) PlayerPrefs.GetInt( INPUT_CONTROLLER_TAG );
			    m_UserData.m_SkinType = (SkinTypeEnum) PlayerPrefs.GetInt( SKIN_TYPE_TAG );
			    m_UserData.m_Language = (LanguageEnum) PlayerPrefs.GetInt( LANGUAGE_TAG );
			    m_UserData.m_CameraType = (CameraEnum) PlayerPrefs.GetInt( CAMERA_TYPE_TAG );
			    m_UserData.m_Coins = PlayerPrefs.GetInt( COINS_TAG );
			    m_UserData.m_MaxScore = PlayerPrefs.GetInt( MAX_SCORE_TAG );
			    m_UserData.m_Vibration = PlayerPrefs.GetInt( VIBRATION_TAG ) > 0 ? true : false;
			    m_UserData.m_Sound = PlayerPrefs.GetInt( SOUND_TAG ) > 0 ? true : false;

				// load max score data
				m_UserData.m_MaxScoreByLevel = new Dictionary<int, int>();
				for (int level = 1; level <= GameConfig.LEVELS_NUMBER; level++)
				{
					string key = LEVEL_MAX_SCORE_TAG + level.ToString();
					m_UserData.m_MaxScoreByLevel.Add(level, PlayerPrefs.GetInt( key ));
					Debug.Log("Level " + level + " Max: " + PlayerPrefs.GetInt( key ).ToString());
				}

			    m_CurrScore = 0;
				m_CurrLevel = GameConfig.LEVEL_FIRST;
			}

			Debug.Log ("UserDataManager, user data loaded successfully");
		}

		void initDefaultData()
		{
			Debug.Log ("UserDataManager, loading default user data");
			m_UserData.m_UserId = "1";
			m_UserData.m_UserName = "Default user";
			m_UserData.m_InputController = InputControllerEnum.DIRECTION_KEYS;
			m_UserData.m_SkinType = SkinTypeEnum.GREEN;
			m_UserData.m_Language = LanguageEnum.ENGLISH;
			m_UserData.m_CameraType = CameraEnum.FRONT;
			m_UserData.m_Coins = 0;
			m_UserData.m_MaxScore = 0;
			m_UserData.m_Vibration = true;
			m_UserData.m_Sound = true;

			m_CurrScore = 0;
			m_CurrLevel = GameConfig.LEVEL_FIRST;
			
			save();
		}

		void save()
		{
			PlayerPrefs.SetString( USER_ID_TAG, m_UserData.m_UserId );
			PlayerPrefs.SetString( USER_NAME_TAG, m_UserData.m_UserName );
			PlayerPrefs.SetInt( INPUT_CONTROLLER_TAG, (int) m_UserData.m_InputController );
			PlayerPrefs.SetInt( SKIN_TYPE_TAG, (int) m_UserData.m_SkinType );
			PlayerPrefs.SetInt( LANGUAGE_TAG, (int) m_UserData.m_Language );
			PlayerPrefs.SetInt( CAMERA_TYPE_TAG, (int) m_UserData.m_CameraType );
			// sound
			PlayerPrefs.SetInt( VIBRATION_TAG, m_UserData.m_Vibration ? 1 : 0 );
			PlayerPrefs.SetInt( SOUND_TAG, m_UserData.m_Sound ? 1 : 0 );
			// resources
			PlayerPrefs.SetInt( COINS_TAG, m_UserData.m_Coins );
			PlayerPrefs.SetInt( MAX_SCORE_TAG, m_UserData.m_MaxScore );
		}
		
		public string userId 
		{
			get{ return m_UserData.m_UserId; }
			set
			{ 
				m_UserData.m_UserId = value;
				PlayerPrefs.SetString( USER_ID_TAG, value );
			}
		}
		
		public string userName
		{
			get{ return m_UserData.m_UserName; }
			set
			{ 
				m_UserData.m_UserName = value;
				PlayerPrefs.SetString( USER_NAME_TAG, value );
			}
		}
		
		public InputControllerEnum inputController{
			get{ return m_UserData.m_InputController;}
			set{ 
				m_UserData.m_InputController = value;
				PlayerPrefs.SetInt( INPUT_CONTROLLER_TAG, (int) value );
			}
		}
		
		public SkinTypeEnum skinType
		{
			get{ return m_UserData.m_SkinType; }
			set
			{ 
				m_UserData.m_SkinType = value;
				PlayerPrefs.SetInt( SKIN_TYPE_TAG, (int) value );
			}
		}
		
		public LanguageEnum language
		{
			get{ return m_UserData.m_Language; }
			set
			{ 
				m_UserData.m_Language = value; 
				PlayerPrefs.SetInt( LANGUAGE_TAG, (int) value );
			}
		}

		public CameraEnum cameraType
		{
			get{ return m_UserData.m_CameraType; }
			set
			{
				m_UserData.m_CameraType = value;
				PlayerPrefs.SetInt( CAMERA_TYPE_TAG, (int) value );
			}
		}
		
		// sound
		public bool vibration
		{
			get{ return m_UserData.m_Vibration; }
			set{
				m_UserData.m_Vibration = value;
				PlayerPrefs.SetInt( VIBRATION_TAG, value ? 1 : 0 );
			}
		}
		
		public bool sound
		{
			get{ return m_UserData.m_Sound; }
			set
			{ 
				m_UserData.m_Sound = value;
				PlayerPrefs.SetInt( SOUND_TAG, value ? 1 : 0 );
			}
		}
		
		public int coins{
			get{ return m_UserData.m_Coins; }
			set{ 
				m_UserData.m_Coins = value;
				PlayerPrefs.SetInt( COINS_TAG, value );
			}
		}

		public void addCoins(int amount)
		{
			coins = coins + amount;
		}
		
		public int level
		{
			get{ return m_CurrLevel; }
			set
			{ 
				if (value > GameConfig.LEVELS_NUMBER)
				{
					Debug.Log("UserDataManager, level, level to big. Short to max");
					m_CurrLevel = GameConfig.LEVELS_NUMBER;
				} 
				else if (value < GameConfig.LEVEL_FIRST )
				{
					Debug.Log("UserDataManager, level, level to small. Increase to min");
					m_CurrLevel = GameConfig.LEVEL_FIRST;
				}

				m_CurrLevel = value;
				m_CurrScore = 0;
			}
		}
		
		public int maxScoreInLevel( int levelN )
		{
			if (m_UserData.m_MaxScoreByLevel.ContainsKey( levelN ))
			{
				return m_UserData.m_MaxScoreByLevel[levelN];
			}
			else
			{
				return 0;
			}
		}
		
		public void addScoreToCurrLevel(int addScore)
		{
			m_CurrScore += addScore;
			// if curr score is bigger than max score in the same level, override it
			renewMaxScoreIfNeeded();
		}

		public int currScoreInCurrLevel
		{
			get{ return m_CurrScore; } 
			set
			{ 
				m_CurrScore = value;
				// if curr score is bigger than max score in the same level, override it
				renewMaxScoreIfNeeded();
			}
		}

		private void renewMaxScoreIfNeeded()
		{
			if (maxScoreInLevel(m_CurrLevel) < m_CurrScore)
			{
				m_UserData.m_MaxScoreByLevel[m_CurrLevel] = m_CurrScore;
				string key = LEVEL_MAX_SCORE_TAG + m_CurrLevel;
				Debug.Log("Save playerPrefsInt, " + key + ", " + m_UserData.m_MaxScoreByLevel[m_CurrLevel].ToString());
				PlayerPrefs.SetInt( key, m_UserData.m_MaxScoreByLevel[m_CurrLevel] );
			}
		}

		public int livesLeft
		{
			get{ return m_LivesLeft; }
			set{ 
				if(value > GameConfig.LIVES_PRO_LEVEL)
				{
					Debug.Log("UserDataManager, livesLeft, Too many lives pro level. Short lives");
					m_LivesLeft = GameConfig.LIVES_PRO_LEVEL;
				}
				else if (value < 0)
				{
					m_LivesLeft = 0;
				}
				else
				{
					m_LivesLeft = value; 
				}
			}
		}

		public void resetLives()
		{
			m_LivesLeft = GameConfig.LIVES_PRO_LEVEL;
		}
	}
}
