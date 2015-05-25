using UnityEngine;
using System.Collections;


namespace Snakyy
{
    public class FreePositionFinder : IFreePositionFinder {

		[Inject]
		public ISnake  m_Snake{ get; set;} 
		
		[Inject]
		public IField  m_Field{ get; set;} 

		const int TRIES_TO_GEN_RANDOM_POS = 2;

		public Vector3 findFreeTilePosition(){
			Vector3 randomVec = new Vector3();
			for (int i = 0; i < TRIES_TO_GEN_RANDOM_POS; i++) {
				// generate random position
				randomVec.x = Random.Range(0, m_Field.FieldTileWidth - 1);
				randomVec.y = Random.Range(0, m_Field.FieldTileHeight - 1);
				randomVec.z = 0;
				// check if a generated position is free
				if (m_Field.tilePointIsFree(randomVec) && m_Snake.tilePointIsFree(randomVec)){
					Debug.Log("Generated quick random position " + randomVec.ToString());
					return randomVec;
				}
			}

			// if quick method not worked, find free position by passing all the field tiles
			// devide field in 2 halfs
			int startTileH = Random.Range(0, m_Field.FieldTileHeight);
			randomVec = freeTilePosition(startTileH, m_Field.FieldTileHeight);
			if (randomVec != Vector3.zero)
				return randomVec;
			
			randomVec = freeTilePosition(0, startTileH);
			if (randomVec != Vector3.zero)
				return randomVec;

			return randomVec;
		}


		Vector3 freeTilePosition(int startTileH, int finishTileH){
			Vector3 randomVec = new Vector3();
			for(int x = 0; x < m_Field.FieldTileWidth; x++){
				for (int y = startTileH; y < finishTileH; y++){
					randomVec.x = Random.Range(0, m_Field.FieldTileWidth - 1);
					randomVec.y = Random.Range(0, m_Field.FieldTileHeight - 1);
					randomVec.z = 0;
					if (m_Field.tilePointIsFree(randomVec) && m_Snake.tilePointIsFree(randomVec)){
						Debug.Log("Generated random position by passing tiles" + randomVec.ToString());
						return randomVec;
					}
				}
			}
			
			return randomVec;
		}
    }
}
