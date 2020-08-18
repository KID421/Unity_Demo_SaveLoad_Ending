using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("結局畫面")]
    public GameObject panel;
    [Header("每張結局畫面")]
    public GameObject[] ends;

    /// <summary>
    /// 載入場景
    /// </summary>
    /// <param name="scene">要載入的場景名稱</param>
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// 儲存資料
    /// 分別為：結局1 ~ 5
    /// 資料 1 為已觸發，0 為尚未觸發
    /// </summary>
    /// <param name="dataName">要儲存的結局資料</param>
    public void SaveData(string dataName)
    {
        PlayerPrefs.SetInt(dataName, 1);
    }

    /// <summary>
    /// 載入資料
    /// 如果資料為 1 代表已觸發就顯示結局
    /// </summary>
    public void LoadData()
    {
        panel.SetActive(true);

        for (int i = 0; i < ends.Length; i++)
        {
            int data = PlayerPrefs.GetInt("結局" + (i + 1));
            if (data == 1) ends[i].SetActive(true);
            else ends[i].SetActive(false);
        }
    }

    private void Update()
    {
        // 按 C 刪除所有資料
        if (Input.GetKeyDown(KeyCode.C)) PlayerPrefs.DeleteAll();
    }
}
