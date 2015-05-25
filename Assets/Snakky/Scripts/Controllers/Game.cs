using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;
using System.IO;


namespace Snakyy {

    public class Game : MonoBehaviour {

		[Inject]
		public IField m_Field{ get; set;} 

		[Inject]
		public ISnake  m_Snake{ get; set;} 

		[Inject]
		public IEatObjectsController m_ObjectsController{ get; set;}

		[Inject]
		public ILevelDataManager m_LevelDataMgr{ get; set;}

		[Inject]
		public IObjectsHitProcessor m_HitProcessor{ get; set;}

		[Inject]
		public ISoundManager m_SoundMgr{ get; set;}


		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
	

		private static IField s_Field;


		public string filePath;
		public string result = "";
		bool loaded = false;
		
		
		public static Vector3 getAbsoluteCoordByTileCord(Vector3 v){
			if (s_Field == null){
				return new Vector3(0, 0, 0);
			}
			return s_Field.getAbsoluteCoordByTileCord( v );
		}

		public static Vector3 getFieldScale(){
			if (s_Field == null){
				return new Vector3(1, 1, 1);
			}
			return s_Field.tileScalev;
		}
		
		// Use this for initialization
	    void Start () {
			s_Field = m_Field;

		    m_Field.create();
			m_ObjectsController.start();
			eventBus.AddListener(GameCommands.SNAKE_HIT_EATABLE_FIELD_OBJECT, snakeHitEatableObject);
			eventBus.AddListener(GameCommands.LIVE_TIME_OUT_FOR_EATABLE_OBJECT, liveTimeOutForEatableObject);
			eventBus.AddListener(GameCommands.SNAKE_HIT_FIELD_BORDER, snakeHitFieldBorder);
			eventBus.AddListener(GameCommands.SNAKE_HIT_ITSELF, snakeHitItself);

			m_Snake.create(5, new Vector3(5, 7, 0f), m_Field.tileScalev * 0.8f);


			//Example();
			//StartCoroutine("Example");
//			filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "2.json");
//			{
//				if (filePath.Contains("://")) {
//					WWW www = new WWW(filePath);
//					//yield return www;
//					result = www.text;
//				} else
//					result = System.IO.File.ReadAllText(filePath);
//			}
//
//			if (File.Exists(filePath))
//			{
//				//string result2 = System.IO.File.ReadAllText(result);
//				FlyLabel.createFlyLabel(result, new Vector3(0, 0, 0));
//				Debug.Log("File found2!");
//			}
//			
//			else
//			{
//				FlyLabel.createFlyLabel("No", new Vector3(0, 0, 0));
//				Debug.Log("No file found2! " + filePath);
//			}

			//string fileLocation = Application.persistentDataPath + "3.json";
			
//			if (File.Exists(fileLocation))
//			{
//				FlyLabel.createFlyLabel()
//			}
//			else
//			{
//				Debug.LogError("Can't find file");
//			}

			print("Path " + Application.persistentDataPath);

			TextAsset propStoreTextAsset = (TextAsset)Resources.Load("1", typeof(TextAsset));
			print("Test: " + propStoreTextAsset.text);
			FlyLabel.createFlyLabel(propStoreTextAsset.text, new Vector3(0, 0, 0));
	    }

		IEnumerator Example()
		{
			filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "2.json");
			result = "";
			{
				if (filePath.Contains("://")) {
					WWW www = new WWW(filePath);
					yield return www;
					result = www.text;
				} else
					result = System.IO.File.ReadAllText(filePath);
			}
		}
//			
//			
//			// check file load
//			//			string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "2.json");
////			if (File.Exists(result))
////			{
////				string result2 = System.IO.File.ReadAllText(result);
////				FlyLabel.createFlyLabel(result2, new Vector3(0, 0, 0));
////				Debug.Log("File found!");
////			}
////			
////			else
////			{
////				FlyLabel.createFlyLabel("No", new Vector3(0, 0, 0));
////				Debug.Log("No file found!");
////			}
//		}

	    void Update(){
			m_ObjectsController.update();	
			m_Snake.update();


//			if(result != "" && loaded == false)
//			{
//						if (File.Exists(filePath))
//						{
//							//string result2 = System.IO.File.ReadAllText(result);
//							FlyLabel.createFlyLabel(result, new Vector3(0, 0, 0));
//							Debug.Log("File found2!");
//						}
//						
//						else
//						{
//							FlyLabel.createFlyLabel("No", new Vector3(0, 0, 0));
//							Debug.Log("No file found2! " + filePath);
//						}
//
//				loaded = true;
//				Debug.Log ("Real Path " + filePath);
//			}
	    }

	    private void createFrog(){
			Vector3 pos = randomFieldTilePosition();
			IEatObject frog = FieldObjectsFactory.create( EatObjectsEnum.FROG, pos );
			m_Field.addObject( frog, pos);
		}

	    Vector3 randomFieldTilePosition(){
			Vector3 randomVec = new Vector3();
			randomVec.x = Random.Range(0, m_Field.FieldTileWidth - 1);
			randomVec.y = Random.Range(0, m_Field.FieldTileHeight - 1);
			randomVec.z = 0;
			Debug.Log("Generated random position " + randomVec.ToString());
			return randomVec;
		}

	    void snakeHitEatableObject(IEvent result){
			EatableObjectEventStruct obj = (EatableObjectEventStruct)(result.data);

			IEatObject o = m_Field.getObject( obj.gameObject );
			// precess hitting with a field object
			m_HitProcessor.processObjectHit( o );

			// give sound
			m_SoundMgr.play(SoundEnum.EAT_MAIN_OBJECT);

			Debug.Log ("m_HitProcessor call");

//			m_Field.removeObject( obj.gameObject );
//			//m_Snake.increaseSpeed(0.05f);
//
//			if (obj.type == EatObjectsEnum.FROG){
//			    m_Snake.addLength(1);
//			}
//
//			else{
//				m_Snake.cutLength( 1 );
//			}
	    }

	    void liveTimeOutForEatableObject(IEvent result){
			EatableObjectEventStruct obj = (EatableObjectEventStruct)(result.data);
			
			m_Field.removeObject( obj.gameObject );
		}

	    void snakeHitFieldBorder(IEvent result){
		    Debug.Log ("Snake Hit field border!");

		    // stop game
			m_Snake.pause();
			m_ObjectsController.pause();
			m_Field.pause();

			Application.LoadLevel("Tr");
	    }

		void snakeHitItself(IEvent result){
			Debug.Log ("Snake hit itself!");
			return;
			
			// stop game
			m_Snake.pause();
			m_ObjectsController.pause();
			m_Field.pause();

			//GameObject obj = GameObject.Find("GameLevel");
			//GameObject.Destroy( obj );

			//eventBus.Dispatch(GameCommands.START_LEVEL1);
			Application.LoadLevel("Tr");
			
		}
	}
}
