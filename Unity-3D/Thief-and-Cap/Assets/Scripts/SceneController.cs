using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Caps {
    public class Diretion {
		//数字定义移动方向
        public const int UP = 0;
        public const int DOWN = 2;
        public const int LEFT = -1;
        public const int RIGHT = 1;
    }

    public class FenchLocation {
        public const float FenchHori = 12.42f;
        public const float FenchVertLeft = -3.0f;
        public const float FenchVertRight = 3.0f;
    }

    public interface IUserAction {
        void thiefMove(int dir);
    }

    public interface IAddAction {
        void addRandomMovement(GameObject sourceObj, bool isActive);
        void addDirectMovement(GameObject sourceObj);
		void addStop ();
    }

    public interface IGameStatusOp {
        int nowThiefPosition();
        void thiefEscapeFromCap();
        void capGetThief();
    }

    public class SceneController : System.Object, IUserAction, IAddAction, IGameStatusOp {
        private static SceneController instance;
        private MainController myGameModel;
        private GameEventManager myGameEventManager;

        public static SceneController getInstance() {
            if (instance == null)
                instance = new SceneController();
            return instance;
        }

        internal void setGameModel(MainController _myGameModel) {
            if (myGameModel == null) {
                myGameModel = _myGameModel;
            }
        }

        internal void setGameEventManager(GameEventManager _myGameEventManager) {
            if (myGameEventManager == null) {
                myGameEventManager = _myGameEventManager;
            }
        }

        /*********************实现IUserAction接口*********************/
        public void thiefMove(int dir) {
            myGameModel.thiefMove(dir);
        }

        /*********************实现IAddAction接口*********************/
        public void addRandomMovement(GameObject sourceObj, bool isActive) {
            myGameModel.addRandomMovement(sourceObj, isActive);
        }

        public void addDirectMovement(GameObject sourceObj) {
            myGameModel.addDirectMovement(sourceObj);
        }

        /*********************实现IGameStatusOp接口*********************/
        public int nowThiefPosition() {
            return myGameModel.nowThiefPosition();
        }

        public void thiefEscapeFromCap() {
            myGameEventManager.thiefEscapeFromCap();
        }

        public void capGetThief() {
            myGameEventManager.capGetThief();
        }

		public void addStop (){
			myGameModel.addStop ();
		}
    }
}

