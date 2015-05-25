using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


namespace Snakyy{
	
	
	public class PlayUIView  : View {
		
		public Text m_Score;
		public Text m_Coins;
		public Text m_Lives;
		public Text m_MaxScore;

		public void setScore( int value ){
			m_Score.text = "Score: " + value.ToString();
		}

		public void setCoins( int value ){
			m_Coins.text = "Coins: " + value.ToString();
		}

		public void setLives( int value ){
			m_Lives.text = "Lives: " + value.ToString();
		}

		public void setMaxScore( int value ){
			m_MaxScore.text = "m_MaxScore: " + value.ToString();
		}
	}
}
