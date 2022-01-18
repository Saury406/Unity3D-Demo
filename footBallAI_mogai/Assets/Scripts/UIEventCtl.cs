using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventCtl : MonoBehaviour
{
	public string sceneName = "Team";
	public string menuName = "Start";
	public int buttonID = 0;
	public void onClickBtnReset()
	{
		//重新加载场景
		SceneManager.LoadScene(sceneName);
	}

	public void onClickBtnQuit() {
		//退出当前游戏
		SceneManager.LoadScene(menuName);
	}
}
