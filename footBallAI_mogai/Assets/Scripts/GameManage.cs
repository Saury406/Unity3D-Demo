using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBallAI
{

    public class GameManage : MonoBehaviour
    {
        private static GameManage gm;
        private int leftScore = 0;
        private int rightScore = 0;
        public Animator clockAnim;

        [SerializeField] List<Agent> players = new List<Agent>();
        public Ball ball;

         void Update()
        {
            //播放时钟动态
            if (rightScore == 2 || leftScore == 2)
            {
                clockAnim.SetBool("isAction", true);
            }
        }

        private void Awake()
        {
            gm = this;
        }
        public static GameManage GetGM
        {
            get
            {
                return gm;
            }
        }

        public void addLeftScore()
        {
            leftScore++;
            setOriginal(); 
            if (leftScore == 3)
            {
                Time.timeScale = 0;
                UIManager.getUI.setWIN(0);
            }

            
        }

        public void addRightScore()
        {
            rightScore++;
            setOriginal();
            if(rightScore == 3)
            {
                Time.timeScale = 0;
                UIManager.getUI.setWIN(1);
            }
        }

        public int getLeftScore
        {
            get{
                return leftScore;
            }
        }
        public int getRightScore
        {
            get
            {
                return rightScore;
            }
        }

        public void setOriginal()
        {
            foreach(var player in players)
            {
                player.setOriginal();
            }
            ball.setOri();
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3f);
        }
    }
}
