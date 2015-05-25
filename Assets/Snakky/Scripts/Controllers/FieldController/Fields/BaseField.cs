using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Snakyy
{
    public abstract class BaseField : IField  {

		// field params
		protected int FIELD_TILE_WIDTH = 29;
		protected const float FIELD_SCREEN_WIDTH_1024 = 283;
		protected const float FIELD_BASE_HEIGHT = 768f;
		protected const float FIELD_BASE_WIDTH = 1024f;
		// screen size of 1 coord unit by 1024 and camera size 1
		protected const float FIELD_WIDTH_ABSOLUTE_COORD = 106.8f;
		protected const float CAMERA_SIZE = 5.0f;
		protected float m_Scalef = 1f;
		protected Vector3 m_Scalev;
		protected Vector2 tileZeroPositionInAbsCoords;
		protected const int BORDER_WIDTH = 1; 
		
		
		protected int m_FieldWidthInTiles;
		protected int m_FieldHeightInTiles;
		protected float m_TileSizeInAbsCoord = 1; 
		protected Vector2 m_StartSnakeTilePosition;

		protected List<IEatObject> m_Objects = new List<IEatObject>();
		
		public int FieldTileWidth {
			get{return m_FieldWidthInTiles;}
		}
		
		public int FieldTileHeight {
			get{return m_FieldHeightInTiles;}
		}

		public float TileSizeInAbsCoord{
			get{return m_TileSizeInAbsCoord;}
		}
		
		public Vector2 StartSnakeTilePosition{
			get{return m_StartSnakeTilePosition; }
		}
		
		public float tileScalef { 
			get{return m_Scalef;}
		}
		
		public Vector3 tileScalev {
			get{return m_Scalev;}
		}
		
		protected BaseField(float screenWidth, float screenHeight){
			init();
			// define fied tile size and tile size in absolute coordinates
			defineFieldParams(screenWidth, screenHeight);
		}

		void init(){
			//ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			FIELD_TILE_WIDTH = 29;//levelDataMgr.fieldTileWidth;
		}

		protected abstract void defineFieldParams(float screenWidth, float screenHeight);

		public abstract Vector3 getAbsoluteCoordByTileCord(Vector3 v);

		public bool tilePointIsFree(Vector3 v){
			foreach (IEatObject o in m_Objects){
				if (CommonMathFunctions.tileCoordsEqual(o.tilePosition, v)){
					Debug.Log (o.tilePosition.ToString() + " " + v.ToString() + "LOOOK!!!");
			        return false;
				}
			}

			Debug.Log ("LOOOK!!!");
			return true;
		}
		
		
		public void addObject(IEatObject obj, Vector3 tilePosition){
			if (obj == null){
				Debug.Log ("RectFieldBase, placeObject: try to add a null object");
				return;
			}
			
			obj.scale = tileScalev;
			obj.position = getAbsoluteCoordByTileCord( tilePosition );
			obj.tilePosition = tilePosition;
			m_Objects.Add( obj );
		}

		public void removeObject(GameObject obj){
			if (obj == null)
				return;

			foreach (IEatObject o in m_Objects){
				if (o.gameObject == obj){
					m_Objects.Remove( o );
					break;
				}
			}
			
			GameObject.Destroy( obj );
		}

		public int objectsCount(EatObjectsEnum type){
			int count = 0;
			foreach(IEatObject obj in m_Objects){
				if (obj.type == type){
					count++;
				}
			}

			return count;
		}

		// finds field object by game object
		public IEatObject getObject( GameObject o ){
			foreach(IEatObject obj in m_Objects){
				if (obj.gameObject == o){
					return obj;
				}
			}

			return null;
		}

		public abstract bool tileBumpesBorder(Vector3 tilePos, DirectionsEnum dir);
		public abstract Vector3 getMirrorTile(Vector3 tilePos, DirectionsEnum moveDir);

		public abstract void create();
		public abstract void pause();
		public abstract void resume();
		public abstract void clear();

    }
}
