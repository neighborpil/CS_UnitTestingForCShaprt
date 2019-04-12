namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }


        /*
        # 3가지 시나리오가 있다
         - admin
         - user이고
         - cancel
        */
        public bool CanBeCancelledBy(User user)
        {
            //if (user.IsAdmin)
            //    return true;

            //if (MadeBy == user)
            //    return true;

            //return false;

            // ↓Refactor

            return (user.IsAdmin || MadeBy == user);
        }
        
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}