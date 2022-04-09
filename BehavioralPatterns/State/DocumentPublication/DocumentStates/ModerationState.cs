using System;

namespace State.DocumentPublication.DocumentStates
{
    public class ModerationState : DocumentState
    {
        public ModerationState()
        {
            Name = "Moderation State";
        }
        
        public override void Render()
        {
            var currentUser = CurrentUser.Get();
            if (currentUser.Role == UserRoles.Admin || currentUser.Role == UserRoles.Author)
            {
                Console.WriteLine("Method: Render, Response: Ok");
            }
            else
            {
                Console.WriteLine("Method: Render, Response: Error");
            }
        }

        public override void Publish()
        {
            var currentUser = CurrentUser.Get();
           
            if (currentUser.Role != UserRoles.Admin)
            {
                Console.WriteLine("Method: Publish, Response: Error");
                return;
            }
            
            Console.WriteLine("Method: Publish, Response: Ok");
            Document.ChangeState(new PublishedState());
        }

        public override void Reject()
        {
            var currentUser = CurrentUser.Get();

            if (currentUser.Role != UserRoles.Admin)
            {
                Console.WriteLine("Method: Reject, Response: Error");
                return;
            }
            
            Console.WriteLine("Method: Reject, Response: Ok");
            Document.ChangeState(new DraftState());
        }
    }
}