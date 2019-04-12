namespace TestNinja.Fundamentals
{
    public class HtmlFormatter
    {
        public string FormatAsBold(string content)
        {
            // return <strong>; // 너무 general한 테스트 케이스를 생성하면, 에러상황도 통과 시킬 수 있다
            return $"<strong>{content}</strong>";
        }
    }
}