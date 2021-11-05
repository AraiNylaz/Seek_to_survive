using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider _slider;
    private float _targetProgress=0f;
    [SerializeField] private float fillSpeed = 0.5f;
    [SerializeField] private string generatorTag;
    private GameObject[] _generators;
    [SerializeField] private UnityEvent gameOver;

    private void Awake()
    {
        PlayerPrefs.SetInt("Result", 0);
        _generators = GameObject.FindGameObjectsWithTag(generatorTag);
        _slider = gameObject.GetComponent<Slider>();
        _slider.value = _targetProgress;
        _slider.maxValue = _generators.Length;
    }
    

    private void Update()
    {
        
        if (_targetProgress >= _generators.Length)
        {
            PlayerPrefs.SetInt("Result",1);
            gameOver.Invoke();
            Destroy(gameObject);
        }
        if (_slider.value < _targetProgress)
        {
            _slider.value += fillSpeed * Time.deltaTime;
        }
    }

    public void Increment()
    {
        _targetProgress = _slider.value + 1;
    }
}
