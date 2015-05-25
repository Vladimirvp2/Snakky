using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


namespace Snakyy
{
	public class FlyLabelView  : View {

		public Text m_Text;

		float m_LiveTime = 3.0f;
		float m_TimeCounter = 0;
		float m_Speed = 1f;
		Color m_currColor = new Color(1, 1, 1, 1);
		float decreaseAPerFrame = 0.0f;

		public FlyLabelView()
		{
			// use game config settings
			m_LiveTime = GameConfig.FlyLabel.LIVE_TIME;
			m_Speed = GameConfig.FlyLabel.FLY_SPEED;
		}
		  
		public void setText( int value ){
			m_Text.text = value.ToString();
		}
		
		public void setText( string value ){
			m_Text.text = value;
		}

		void Start()
		{
			Vector3 scale = m_Text.transform.localScale * GameConfig.FlyLabel.SIZE;
			m_Text.transform.localScale = scale;

			m_currColor = m_Text.color;

			// count decrase rate per frame
			decreaseAPerFrame = m_currColor.a * (Time.deltaTime / m_LiveTime ) * 1.8f;

		}

		void Update()
		{
			m_TimeCounter += Time.deltaTime;
			if (m_TimeCounter > m_LiveTime)
			{
				Destroy( gameObject );
				Debug.Log ("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
			}
			//GUI.color.a = 0.5f;
			Color c = GUI.color;
			c.a = 0.9f;
			m_Text.transform.position = m_Text.transform.position + new Vector3(0, 0.01f * m_Speed, 0);
			m_currColor.a = m_currColor.a - decreaseAPerFrame;
			m_Text.color = m_currColor;
			//m_Text.color = decreaseAPerFrame;
			//GUI.color.a = 1.0f;
			
			//GUI.color.a = 1.0f;
		}

		void OnGUI()
		{
			//Color c = GUI.color;
			//c.a = 0.2f;
			//GUI.color = c;
		}


	}
}
