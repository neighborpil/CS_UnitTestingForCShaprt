namespace TestNinja.Fundamentals
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            // 2가지 testcase가 필요 : two execution path가 있으므로
            if (id == 0)
                return new NotFound();
            
            return new Ok();
        }        
    }
    
    public class ActionResult { }
    
    public class NotFound : ActionResult { }
 
    public class Ok : ActionResult { }
}