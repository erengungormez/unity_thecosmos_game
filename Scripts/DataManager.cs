using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

     EasyFileSave myFile;


     void Awake()
    {
        if(Instance == null) // henüz bir şey atanmamışsa.
        {
            Instance=this;
            StartProcess();
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }

    void Update()
    {
        
    }

     public int ShotBullet // amacımız bu data'ları daha güvende tutabilmek.
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET:" + shotBullet.ToString();
        }
    }

    public int EnemyKilled // private olan değerleri public işleme dönüştürerek dataların güvenliğini sağlıyoruz.
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KİLLED :" + enemyKilled.ToString();
            WinProcess();
           
        }
    }

    void StartProcess()
    {
       myFile = new EasyFileSave();
       LoadData();
    }
     

      public void SaveData() // kaydetme sistemi.
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    public void LoadData() // geri yüklme sistemi.
    {
        if(myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }

    public void WinProcess()
    {
        if(enemyKilled >= 5)
        {
            print("kazandınız :)");
        }
    }

    public void LoseProcess()
    {
         print("kaybettiniz :(");
    }

}
