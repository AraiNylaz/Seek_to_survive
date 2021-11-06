using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehavior<GameManager>, IGameManager
{
   [SerializeField] private string startScene;
   [SerializeField] private string seekerScene;
   [SerializeField] private string survivorScene;
   [SerializeField] private UnityEvent OnEndGame;
   [SerializeField] private UnityEvent OnStartGame;
   [SerializeField] private UnityEvent ResultWinner;
   [SerializeField] private UnityEvent ResultLooser;

   public void Quit()
   {
      Application.Quit();
   }

   public void StartGame()
   {
      ChooseSurvivorMode();
   }

   public void Start()
   {
      PlayerPrefs.SetInt("Result", 0);
   }

   private IEnumerator SwitchScene(string newScene, Action callback =null)
   {
      if (SceneManager.sceneCount > 1)
      {
         var currentScene = SceneManager.GetActiveScene().name;
         yield return SceneManager.UnloadSceneAsync(currentScene);
      }

      yield return SceneManager.LoadSceneAsync(newScene,LoadSceneMode.Additive);
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));

      callback?.Invoke();
   }


   public void ChooseSeekerMode()
   {
      //pas implémenté
      //StartCoroutine(SwitchScene(survivorScene,()=>OnStartGame?.Invoke()));
   }
   public void ChooseSurvivorMode()
   {
      StartCoroutine(SwitchScene(survivorScene,()=>OnStartGame?.Invoke()));
   }

   //Gagner
   public void EndGame()
   {
      Scene s =SceneManager.GetSceneByName(survivorScene);
      Cursor.lockState = CursorLockMode.None;
      StartCoroutine(End());
   }

   private IEnumerator End()
   {
      if(PlayerPrefs.GetInt("Result") ==1) ResultWinner.Invoke();
      else ResultLooser.Invoke();
      yield return new WaitForSeconds(1f);
      OnEndGame?.Invoke();

      SwitchScene(startScene);
   }
}