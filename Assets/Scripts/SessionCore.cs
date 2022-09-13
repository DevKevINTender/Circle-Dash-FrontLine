using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SessionCore : MonoBehaviour
    {
        public delegate void AddScoreDel();
        public delegate void LossDel();
        
        public BoxGeneratorCnt boxGeneratorCnt;
        public CircleCom3D circleObj;

        public Text scoreText;
        public int score;

        public void Start()
        {
            boxGeneratorCnt.InitCnt();
            circleObj.InitComponent(AddScore, Loss);
        }

        public void AddScore()
        {
            score++;
            scoreText.text = "" + score;
        }

        public void Loss()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}