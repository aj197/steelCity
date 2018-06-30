using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New Tank", menuName = "Tanks/Tank")]
    public class TankObject : ScriptableObject
    {
        //holds all the info needed for each tank
        public string tankType;
        public int health;

        public int frontHullArmor;
        public int leftHullArmor;
        public int rightHullArmor;
        public int rearHullArmor;

        public int frontHullERA;
        public int leftHullERA;
        public int rightHullERA;

        public int frontTurretArmor;
        public int leftTurretArmor;
        public int rightTurretArmor;
        public int rearTurretArmor;

        public int frontTurretERA;
        public int leftTurretERA;
        public int rightTurretERA;

        public string ability1;
        public string ability2;
        public string ability3;

        public int maxMovement;

        //can write methods in this script that can be called by TankDisplay

        public void printHealth()
        {
        Debug.Log(health + " HP");
        }

        
    }