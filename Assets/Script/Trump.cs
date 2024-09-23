using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trump : MonoBehaviour
{
    private GameObject gamemanagerOBJ 
    {
        get {
            return GameObject.FindGameObjectWithTag("GameManager");
        }
    }
    private GameManager gameManager 
    {
        get {
            return gamemanagerOBJ.GetComponent<GameManager>();
        }
    }

    private Vector3 getMouseWorldPos 
    {
        get {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private Vector3 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAct() 
    {
        // gameManager.didCardTapped(this.gameObject.name);
    }

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - getMouseWorldPos;
    }

    public void OnMouseDrag()
    {
        transform.position = getMouseWorldPos + offset;
    }
}