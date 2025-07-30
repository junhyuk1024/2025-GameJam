using UnityEngine;
using System;
using System.Collections.Generic;
public class GameManager : BaseSingleton<GameManager>
{
    public Stack<GameObject> currentAnimals;
    public Transform spawnPoint;

    public bool hasCat;
    public bool hasSnake;
    public bool hasBird;
    public bool hasTiger;
    public bool hasMonkey;

    public void PushStack(GameObject g)
    {
        switch (g.name)
        {
            case "Cat":
                {
                    hasCat = true;
                    print("고양이가 true가 되었다");
                    break;
                }
            case "Snake":
                {
                    hasSnake = true;
                    print("뱀이 true가 되었다");
                    break;
                }
            case "Bird":
                hasBird = true;
                break;
            case "Tiger":
                hasTiger = true;
                break;
            case "Monkey":
                hasMonkey = true;
                break;
        }
        currentAnimals.Push(g);
    }

    public void PopStack()
    {
        if (currentAnimals.Count > 0)
        {
            MissAnimal(currentAnimals.Peek().name);

            currentAnimals.Peek().gameObject.SetActive(false);
            currentAnimals.Pop();
            //if (currentAnimals.Count <= 0)
            //{
            //    print("게임오버");
            //}
        }
        else
        {
            print("게임오버상태");
        }
    }

    private void MissAnimal(string str)
    {
        if (str == "Monkey")
        {
            hasMonkey = false;
            return;
        }
        else if (str == "Tiger")
        {
            hasTiger = false;
            return;
        }
        else if (str == "Bird")
        {
            hasBird = false;
            return;
        }
        else if (str == "Snake")
        {
            hasSnake = false;
            return;
        }
        else hasCat = false; // str == "Cat"
    }

    protected override void Awake()
    {
        base.Awake();

        currentAnimals = new Stack<GameObject>();
    }

    private void Update()
    {
        print(currentAnimals.Count);

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    PopStack();
        //}
    }
}
