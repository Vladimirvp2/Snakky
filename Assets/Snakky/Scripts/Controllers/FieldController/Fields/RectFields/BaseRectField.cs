using UnityEngine;
using System.Collections;


namespace Snakyy
{
	public class BaseRectField : BaseField {

		protected BaseRectField(float screenWidth, float screenHeight) : base (screenWidth, screenHeight){

		}


		protected override void defineFieldParams(float screenWidth, float screenHeight){
			// pixels in 1 tile
			float tileSizePixel =  (screenWidth / FIELD_TILE_WIDTH + 2*BORDER_WIDTH );
			m_FieldWidthInTiles = FIELD_TILE_WIDTH;
			m_FieldHeightInTiles = (int) (screenHeight / tileSizePixel);
			if (m_FieldHeightInTiles % 2 == 0){
				m_FieldHeightInTiles -= 1;
			}
			
			float absCoordUnitsInScreenWidth = ( FIELD_SCREEN_WIDTH_1024 / ( FIELD_WIDTH_ABSOLUTE_COORD / CAMERA_SIZE  )) * (FIELD_BASE_HEIGHT / screenHeight) * (screenWidth / FIELD_BASE_WIDTH);
			m_TileSizeInAbsCoord = absCoordUnitsInScreenWidth / (FIELD_TILE_WIDTH + 2*BORDER_WIDTH); 
			m_Scalef = m_TileSizeInAbsCoord;
			m_Scalev = new Vector3(m_Scalef, m_Scalef, m_Scalef);
			tileZeroPositionInAbsCoords = new Vector2(-( (FIELD_TILE_WIDTH - 1) / 2f) * m_TileSizeInAbsCoord, 
			                                          -( (m_FieldHeightInTiles - 1) / 2f) * m_TileSizeInAbsCoord);
			// define start snake tile position
			m_StartSnakeTilePosition = new Vector2((float) m_FieldWidthInTiles / 2, (float) m_FieldHeightInTiles / 2);
		}
		
		
		public override Vector3 getAbsoluteCoordByTileCord(Vector3 v){
			return  new Vector3 (tileZeroPositionInAbsCoords.x + v.x * m_TileSizeInAbsCoord,
			                     tileZeroPositionInAbsCoords.y + v.y * m_TileSizeInAbsCoord, 
			                     v.z);
		}


		protected virtual void createBackground(){
			GameObject background = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FieldGrass"), new Vector3(0, 0, 0), Quaternion.identity);
			background.transform.localScale = new Vector3(m_TileSizeInAbsCoord * FieldTileWidth + 2*BORDER_WIDTH + 2, m_TileSizeInAbsCoord * FieldTileHeight + 2*BORDER_WIDTH + 2, 1);
			background.transform.parent = GameObject.Find("GameLevel").transform;
		}

		protected virtual void createFieldBorder(){
			// left
			GameObject borderLeft = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FieldBorder"), new Vector3(0, 0, 0), Quaternion.identity);
			Vector3 tilePosLeft = new Vector3(-2, (int)( m_FieldHeightInTiles / 2) , 0 );
			borderLeft.transform.position = getAbsoluteCoordByTileCord( tilePosLeft );
			Vector3 scale = new Vector3(3, m_FieldHeightInTiles + 2*BORDER_WIDTH + 2 , 1) * m_TileSizeInAbsCoord;
			borderLeft.transform.localScale = scale;
			borderLeft.transform.parent = GameObject.Find("GameLevel").transform;

			BoxCollider coll = borderLeft.GetComponent<BoxCollider>();
			if (coll != null) {
				coll.transform.localScale = scale;
			}


			// right
			GameObject borderRight = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FieldBorder"), new Vector3(0, 0, 0), Quaternion.identity);
			Vector3 tilePosRight = new Vector3(FieldTileWidth + 1, (int)( m_FieldHeightInTiles / 2), 0 );
			borderRight.transform.position = getAbsoluteCoordByTileCord( tilePosRight );
			scale = new Vector3(3, m_FieldHeightInTiles + 2*BORDER_WIDTH + 2, 1) * m_TileSizeInAbsCoord;
			borderRight.transform.localScale = scale;
			borderRight.transform.parent = GameObject.Find("GameLevel").transform;

			coll = borderRight.GetComponent<BoxCollider>();
			if (coll != null) {
				coll.transform.localScale = scale;
			}


			// top
			GameObject borderTop = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FieldBorder"), new Vector3(0, 0, 0), Quaternion.identity);
			Vector3 tilePosTop = new Vector3((int)( FieldTileWidth / 2),  m_FieldHeightInTiles + 1, 0 );
			borderTop.transform.position = getAbsoluteCoordByTileCord( tilePosTop );
			scale = new Vector3(FieldTileWidth + 2*BORDER_WIDTH + 2, 3, 1) * m_TileSizeInAbsCoord;
			borderTop.transform.localScale = scale;
			borderTop.transform.parent = GameObject.Find("GameLevel").transform;

			coll =borderTop.GetComponent<BoxCollider>();
			if (coll != null) {
				coll.transform.localScale = scale;
			}

			// bottom
			GameObject borderBottom = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FieldBorder"), new Vector3(0, 0, 0), Quaternion.identity);
			Vector3 tilePosBottom = new Vector3((int)( FieldTileWidth / 2),  -2, 0 );
			borderBottom.transform.position = getAbsoluteCoordByTileCord( tilePosBottom );
			scale = new Vector3(FieldTileWidth + 2*BORDER_WIDTH + 2, 3, 1) * m_TileSizeInAbsCoord;
			borderBottom.transform.localScale = scale;
			borderBottom.transform.parent = GameObject.Find("GameLevel").transform;

			coll = borderBottom.GetComponent<BoxCollider>();
			if (coll != null) {
				coll.transform.localScale = scale;
			}

		}

		public override bool tileBumpesBorder(Vector3 tilePos, DirectionsEnum dir)
		{
			int x = (int)tilePos.x;
			int y = (int)tilePos.y;

			if ( (x <= 0 && dir == DirectionsEnum.LEFT) || ( (x >= m_FieldWidthInTiles - 1) && dir == DirectionsEnum.RIGHT ) ||
			    (y <= 0 && dir == DirectionsEnum.DOWN ) || (y >= (m_FieldHeightInTiles - 1) && dir == DirectionsEnum.UP)){
				return true;
			}

			return false;
		}

		public override Vector3 getMirrorTile(Vector3 tilePos, DirectionsEnum moveDir)
		{
			Debug.Log ("Direction " + moveDir.ToString());
		    // find center filed tile position
			int xCenter = m_FieldWidthInTiles / 2;
			int yCenter = m_FieldHeightInTiles / 2;

			int x = (int)tilePos.x;
			int y = (int)tilePos.y;

			Vector3 res = new Vector3(0, 0, 0);
			res.x = x;
			res.y = y;

			// find new (mirror) tile position
			// x - coordinate if snake moves in x axis
			if ( moveDir == DirectionsEnum.RIGHT || moveDir == DirectionsEnum.LEFT)
			{
			    if ( x > xCenter )
			    {
				    res.x = xCenter - (x - xCenter);
			    }
			    else if (x <= xCenter)
			    {
				    res.x = xCenter + (xCenter - x);
			    }
			}

			// x - coordinate if snake moves in y axis
			if ( moveDir == DirectionsEnum.UP || moveDir == DirectionsEnum.DOWN )
			{
			    if ( y > yCenter)
			    {
				    res.y = yCenter - (y - yCenter);
			    }
			    else if (y <= yCenter)
			    {
				    res.y = yCenter + (yCenter - y);
			    }
			}

			res.z = GameConfig.FIELD_OBJECTS_Z;

			return res;
		}

		public override void create(){}
		public override void pause(){}
		public override void resume(){}
		public override void clear(){}
    }

}
