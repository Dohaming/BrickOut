using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Dictionary<string, Sprite> SpriteDic = new Dictionary<string, Sprite>();
    public Sprite sp;
    //
    //������ ���� ����
    private int brickCreate;
    //�μ� ���� ���� (Need Count)
    private int brickDestroy;
    public int BrickDestroy
    {
        get
        {
            brickLeft = brickCreate - brickDestroy;
            if (brickCreate == brickDestroy)
            {
                GameOver();
            }
            return brickDestroy;
        }

        set
        {
            brickDestroy = value;
        }
    }
    // ���� ���� ���� (���� = ���� - �μ�)
    private int brickLeft;

    //Ȱ������ �� ���� (0�� �Ǹ� ���� ����)
    private int ballCount;
    public int BallCount
    {
        get 
        { 
            if (ballCount < 1) 
            {
                GameOver();
            }
            return ballCount; 
        }

        set
        {
            ballCount = value;
        }
    }

    //
    //������ �����ɶ� ���Ǵ� �Լ�
    public void BrickTouch()
    {
        brickDestroy--;
    }

    public void GameOver()
    {
        //GameOver
        Time.timeScale = 0;
    }

    public override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        SpriteInit();
    }

    public void SpriteLoad(GameObject obj , string name)
    {
        obj.GetComponent<SpriteRenderer>().sprite = SpriteDic[name];

    }

    public void SpriteInit()
    {
        string path = "Assets/Resources/Sprites";
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo file in di.GetFiles())
        {
            if (!file.Name.Contains(".meta"))
            {
                string[] fileName = file.Name.Split('.');
                Sprite s = Resources.Load<Sprite>("Sprites/" + fileName[0]);
                SpriteDic.Add(fileName[0], s);
                //Debug.Log("���ϸ� : " + fileName[0]);

            }
           
        }
    }
}
