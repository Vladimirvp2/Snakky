using UnityEngine;
using System.Collections;

namespace Snakyy {

    public interface IObjectsHitProcessor {

		void processObjectHit(IEatObject obj);
    }

}
