using UnityEngine;
using System.Collections;

namespace Snakyy {

    public struct EatObjetcStruct {
		public EatObjectsEnum type;
		public float probabilityPerSecond;
		public int maxNumberOnField;
		public int bonusAmountMin;
		public int bonusAmountMax;
		public BonusesEnum bonusType;
    }
}
