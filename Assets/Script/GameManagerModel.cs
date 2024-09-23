using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

class GameManagerModel {
    private static GameManagerModel singleton;
    private float initialX = -1100; 
    private float initialY = 400; 
    public static GameManagerModel GetInstance() {
        if (singleton == null) {
            singleton = new GameManagerModel();
        }
        return singleton;
    }

    public List<int> shuffleCards {
        get {
            List<int> intList = new List<int>();
            for (int i  = 0 ; i < 52 ; i++) {
                intList.Add(i);
            }
            for (int i = intList.Count - 1; i > 0; i--) {
                var j = UnityEngine.Random.Range(0, i + 1);
                var temp = intList[i];
                intList[i] = intList[j];
                intList[j] = temp;
            }
            return intList;
        }
    }

    public float[] setupNumber(int number) 
    {
        float x = 0;
        float y = 0;
        if (number < 26) {
            x = 70 * number + initialX;
            y = initialY;
        }
        if (26 <= number) {
            x = 70 * (number - 26) + initialX;
            y = initialY - 800;
        }
        return new float[] { x, y };;
    }

    public string getCardFileName(string name) {
        long number = name.ConvertedInteger();
        string spriteName = "";
        if (number < 14) {
            spriteName = string.Format("Cards/Clubs/{0}_club", number);
        }
        if (14 <= number && number < 27) {
            number -= 13;
            spriteName = string.Format("Cards/Diamonds/{0}_diamond", number);
        }
        if (27 <= number && number < 40) {
            number -= 26;
            spriteName = string.Format("Cards/Hearts/{0}_heart", number);
        }
        if (40 <= number) {
            number -= 39;
            spriteName = string.Format("Cards/Spades/{0}_spade", number);
        }
        return spriteName;
    }
}