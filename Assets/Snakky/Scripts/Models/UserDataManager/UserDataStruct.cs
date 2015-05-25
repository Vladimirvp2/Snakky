using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snakyy{

    public struct UserDataStruct {
		public string m_UserId;
		public string m_UserName;
		public InputControllerEnum m_InputController;
		public SkinTypeEnum m_SkinType;
		public LanguageEnum m_Language;
		public CameraEnum m_CameraType;
		public bool m_Vibration;
		public bool m_Sound;

		public int m_Coins;
		public int m_MaxScore;
		// level - score
		public Dictionary<int, int> m_MaxScoreByLevel;

    }
}
