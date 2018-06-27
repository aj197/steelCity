using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "New Tank", menuName = "Tanks/Light")]
    public class Tank : ScriptableObject
    {

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

        public int ability1;
        public int ability2;
        public int ability3;

        public int maxMovement;

    
    }