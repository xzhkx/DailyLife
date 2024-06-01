using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDungeon : MonoBehaviour
{
    [SerializeField] private int coinsRequire, sceneIndex;

    public async void EnterDungeon()
    {
        int coins = await CoinsLoad.Instance.GetCoins();
        if(coins - coinsRequire >= 0)
        {
            CoinsLoad.Instance.SaveCoins(-coinsRequire);
            StartCoroutine(LoadScene());
        }
    }    

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
