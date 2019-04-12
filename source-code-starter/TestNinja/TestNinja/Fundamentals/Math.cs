using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b)
        { 
            return a + b; // condition이 하나이므로 테스트케이스도 1개이다
        }

        public int AddWrong(int a, int b)
        {
            //return 0;
            //return 1; // 값을 바꾸었는데도 계속 pass되면 잘못된 것일 확률이 높다
            return int.MaxValue;
        }

        public int Max(int a, int b)
        {
            return (a > b) ? a : b; // 조건식이 있기때문에 테스트 케이스도 2개이다
                                    // 테스트 케이스는 보통 condition의 개수와 같거나 더 많다
                                    // brainstorming으로 가능한 테스트를 다 생각해두는 것이좋다
        }

        // 테스트 케이스를 작성할 때 블랙박스와 같다고 생각하는 편이 좋다
        // 그래야 가능한 경우의 수를 더 많이 생각 할 수 있다

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i; 
        }
    }
}