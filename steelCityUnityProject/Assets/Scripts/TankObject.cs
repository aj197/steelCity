using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New Tank", menuName = "Tanks/Tank")]
    public class TankObject : ScriptableObject
    {
        //holds all the info needed for each tank, and ONLY info
        public string tankType;
        public int health;

        public GameObject ghost;

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

        public int maxDistance;
    
        
    


   

}