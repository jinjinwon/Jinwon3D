using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText,XskillText, ZSkillText;
    public GameObject skill;
    public GameObject timer;

    
    public Text timeText, RecordText, zSklieText,xSkillText;
    public Text levelText;

    private float timeSpeed;
    private int zSkill = 3;
    private int xSkill = 3;
    private int levelMode = 1;

    
    private float skillTime;
    public float SurviveTime;
    public bool isGameover;

    // Start is called before the first frame update
    void Start()
    {       
        SurviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            Skill();

            if ((int)SurviveTime == 10f || (int)SurviveTime == 20f || (int)SurviveTime == 30f)
            {
                LevelText();
                Invoke("Timer", 2f);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        
    }

    public void EndGame()
    {
        isGameover = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        
        if(SurviveTime > bestTime)
        {
            bestTime = SurviveTime;
            PlayerPrefs.SetFloat("BestTime" ,bestTime);
        }

        RecordText.text = "BestTime: " + (int)bestTime;
    }

    public void Skill()
    {
        SurviveTime += Time.deltaTime;      
        timeText.text = "Time: " + (int)SurviveTime;
        zSklieText.text = "Z Skill(폭탄) : " + zSkill;
        xSkillText.text = "X Skill(거대화) : " + xSkill;

        if (Input.GetKeyDown(KeyCode.Z) && zSkill > 0)
        {
            GameObject[] Sk = GameObject.FindGameObjectsWithTag("Bullet");
            ZSkillText.SetActive(true);
            Invoke("Z_SkillActive", 2f);
            for (int i = 0; i < Sk.Length; i++)
                Destroy(Sk[i]);
            zSkill--;
        }        
        if (Input.GetKeyDown(KeyCode.X) && xSkill > 0)
        {
            skillTime += Time.deltaTime;
            if (skillTime <= 3f)
            {
                XskillText.SetActive(true);
                Invoke("X_SkillActive", 2f);
                skill.gameObject.SetActive(true);
                xSkill--;
                Invoke("SkillFalse", 5f);              
            }           
        }
    }

    public void SkillFalse()
    {
        skill.gameObject.SetActive(false);
        skillTime = 0;
    }

    public void X_SkillActive()
    {
        XskillText.SetActive(false);
    }

    public void Z_SkillActive()
    {
        ZSkillText.SetActive(false);
    }

    public void Timer()
    {
        timer.SetActive(false);
    }

    public void LevelText()
    {
        Bullet bullet = FindObjectOfType<Bullet>();
        timeSpeed = bullet.speed;
        timer.SetActive(true);
        levelText.text = (int)SurviveTime + " 초가 지났습니다." + " 속도가 " + timeSpeed + "로 설정합니다.";
    }
}
