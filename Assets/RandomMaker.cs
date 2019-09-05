using UnityEngine;
using UnityEngine.UI;

public class RandomMaker : MonoBehaviour
{
    public GameObject randomTextUI;
    private Text[] texts;
    private System.Random sRandom = new System.Random();
    private Scrollbar scroll;

    void Start()
    {
        scroll = FindObjectOfType<Scrollbar>();
    }

    public void MakeRandom()
    {
        GameObject temp = Instantiate(randomTextUI, transform);
        texts = temp.GetComponentsInChildren<Text>(randomTextUI);
        texts[0].text = UnityEngine.Random.Range(0, 255).ToString();
        byte[] byteStream = new byte[1];
        float result;
        sRandom.NextBytes(byteStream);
        result = byteStream[0];
        texts[1].text = result.ToString();
        scroll.value = 0;
    }
}
