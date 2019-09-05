using UnityEngine;
using UnityEngine.UI;

public class RandomMaker : MonoBehaviour
{
    public GameObject randomTextUI;
    private Text[] texts;
    private System.Random sRandom = new System.Random(0); //System.Random 의 시드값을 0으로 초기화.

    void Start()
    {
        UnityEngine.Random.InitState(0);    //UnityEngine.Random 의 시드값을 0으로 초기화.
    }

    public void MakeRandom()
    {
        GameObject temp = Instantiate(randomTextUI, transform);
        texts = temp.GetComponentsInChildren<Text>(randomTextUI);
        //UnityEngine.Random
        texts[0].text = UnityEngine.Random.value.ToString();//0~1사이의 float 값 출력
        texts[0].text = UnityEngine.Random.Range(0f, 1f).ToString(); //0~1사이의 float 값 출력 방식 다름.
        texts[0].text = UnityEngine.Random.Range(0, 255).ToString(); //0~255 사이의 int 값 출력

        //System.Random     4바이트를 받아 float 로 변환 후 출력.
        byte[] byteStream = new byte[4];
        float result;
        sRandom.NextBytes(byteStream);
        result = System.BitConverter.ToSingle(byteStream, 0);
        texts[1].text = result.ToString();

        //System.Random     1바이트를 받아 0~255 사이의 값 출력. UnityEngine.Random 3번째 값과 비교 가능할 것이라 판단.
        /*
        byte[] byteStream = new byte[1];
        float result;
        sRandom.NextBytes(byteStream);
        result = byteStream;
        texts[1].text = result.ToString();
        */
    }

}
