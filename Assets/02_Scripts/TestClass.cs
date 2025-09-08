using UnityEngine;

/// <summary>
/// 테스트 용 클래스입니다.
/// </summary>
public class TestClass : MonoBehaviour
{
    [SerializeField] int _testInt;
    [SerializeField] string _textString;

    private void Start()
    {
        PrintNumber(_testInt);
        PrintText(_textString);
    }

    /// <summary>
    /// 테스트용으로 입력받은 숫자를 출력하는 함수
    /// </summary>
    /// <param name="number">출력할 숫자</param>
    public void PrintNumber(int number)
    {
        Debug.Log($"숫자 출력하기 : {number}");
    }

    /// <summary>
    /// 테스트용으로 입력받은 텍스트를 출력하는 함수
    /// </summary>
    /// <param name="text">출력할 텍스트</param>
    public void PrintText(string text)
    {
        Debug.Log($"텍스트 출력하기 : {text}");
    }
}
