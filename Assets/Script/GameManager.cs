using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] public GameObject cardsObject;
    GameManagerModel gameModel {
        get {
            return GameManagerModel.GetInstance();
        }
    }
    List<int> cardList {
        get {
            return gameModel.shuffleCards;
        }
    }
    // Start is called before the first frame update
    async void Start()
    {
        try {
            await makeCards(cardList);
            await setupCardImage();
        } catch {} finally {}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async Task makeCards(List<int> list)
    {
        int count = 0;
        foreach (int i in list) {
            float[] array = gameModel.setupNumber(i);
            GameObject prefab = null;
            prefab = Instantiate(cardsObject, new Vector3(array[0], array[1], 0), Quaternion.identity);
            makePrefab(count, prefab);
            count ++;
        }
    }

    private void makePrefab(int number, GameObject prefab) {
        int numberAdd = number + 1;
        prefab.name = numberAdd.ToString();
        prefab.transform.localScale = new Vector3(75, 75, 0);
        prefab.transform.SetParent(canvas.transform, false);
    }

    async Task setupCardImage() {
        for (int i  = 1 ; i < 53 ; i++) {
            didCardTapped(i.ToString());
        }
    }

    public void didCardTapped(string name) {
        string cardFileName = gameModel.getCardFileName(name);
        Sprite sprite = Resources.Load<Sprite>(cardFileName);
        SpriteRenderer sprRender = GameObject.Find(name).GetComponent<SpriteRenderer>();
        if (sprite) {
            sprRender.sprite = sprite;
        } else {
            Debug.Log("Sprite Not found");
        }
    }

    private void setupBackgounrd() {
        
    }
}
