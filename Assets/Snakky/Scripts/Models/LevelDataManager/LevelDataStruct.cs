using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snakyy {

    public struct LevelDataStruct {
		public int livesN;
		public int levelN;
		public int fieldTileWidth;
		public float snakeEatAcceleration;
		public List<EatObjetcStruct> eatObjectsData;
		public EatObjectsEnum mainEatObject;
    }
}
