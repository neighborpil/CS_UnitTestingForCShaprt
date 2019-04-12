
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        private Guid _errorId;

        public event EventHandler<Guid> ErrorLogged; 
        public event EventHandler<Guid> ErrorLoggedForPrivateMethod;

        public void Log(string error)
        {
            // 필요 테스트케이스 3
            // 1. 널체크
            // "" : emptystring
            // " " : whitespace

            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException(); // 지워보면 정상적으로 작동하는지 알 수 있다


            LastError = error; // void메소드이지만, 멤버변수인 LastError를 변경시킨다
                               // 만약 이 구문을 삭제해도 테스트 결과가 정상으로 나오면 잘못된 테스트이다
            
            // Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }

        public void LogForProtectedMethod(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
            LastError = error;

            _errorId = Guid.NewGuid();

            OnErrorLogged();
        }

        public virtual void OnErrorLogged() // 안좋은 케이스다. 내부 로직이 public으로 노출되어 있다
        {
            ErrorLoggedForPrivateMethod?.Invoke(this, _errorId); // 테스트가 통과한다
        }
    }
}