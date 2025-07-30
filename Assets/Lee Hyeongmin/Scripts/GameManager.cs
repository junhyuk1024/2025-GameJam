using UnityEngine;
using System;
using System.Collections.Generic;
public class GameManager : BaseSingleton<GameManager>
{
    public Stack<GameObject> currentAnimals;
    public Transform spawnPoint;

    public void PushStack(GameObject g)
    {
        currentAnimals.Push(g);
    }

    public void PopStack()
    {
        if (currentAnimals.Count > 0)
        {
            currentAnimals.Peek().gameObject.SetActive(false);
            currentAnimals.Pop();
        }
        else
        {
            print("ÆÐ¹è");
        }
    }

    protected override void Awake()
    {
        base.Awake();

        currentAnimals = new Stack<GameObject>();
    }

    private void Update()
    {
        print(currentAnimals.Count);

        if (Input.GetKeyDown(KeyCode.E))
        {
            PopStack();
        }
    }
}
