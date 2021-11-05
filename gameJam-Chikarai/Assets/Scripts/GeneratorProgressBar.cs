using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorProgressBar : MonoBehaviour
{

    private Slider _slider;
    private float _targetProgress=0f;
    [SerializeField] private float fillSpeed = 0.5f;
    [SerializeField] private float timeToHold =3f;

    private void Awake()
    {

        _slider = gameObject.GetComponent<Slider>();
        _slider.value = _targetProgress;
        _slider.maxValue = timeToHold;
    }


    private void Update()
    {
        if (_slider.value < _targetProgress)
        {
            _slider.value += fillSpeed * Time.deltaTime;
            StartCoroutine(Deactivate());
        }
        if(_targetProgress >= timeToHold) Destroy(gameObject);
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }

    public void Increment()
    {
        _targetProgress += PlayerPrefs.GetFloat("time");
    }
}