using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Caps;

namespace Com.Caps {
    public class CapFactory : System.Object {
        private static CapFactory instance;
        private GameObject CapItem;

        private Vector3[] postionSetOfCaps = new Vector3[] { new Vector3(-6, 0, 16), new Vector3(-1, 0, 19),
			new Vector3(6, 0, 16), new Vector3(-5, 0, 7), new Vector3(0, 0, 7), new Vector3(6, 0, 7)};

        public static CapFactory getInstance() {
            if (instance == null)
                instance = new CapFactory();
            return instance;
        }

        public void initItem(GameObject _PatrolItem) {
            CapItem = _PatrolItem;
        }

        public GameObject getCap() {
            GameObject newPatrol = Camera.Instantiate(CapItem);
            return newPatrol;
        }

        public Vector3[] getPosSet() {
            return postionSetOfCaps;
        }
    }
}

