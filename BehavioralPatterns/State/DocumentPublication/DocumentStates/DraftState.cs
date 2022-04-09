using System;

namespace State.DocumentPublication.DocumentStates
{
    public class DraftState : DocumentState
    {
        public DraftState()
        {
            Name = "Draft State";
        }
        
        public override void Render()
        {
            var currentUser = CurrentUser.Get();
            if (currentUser.Role == UserRoles.Guest)
            {
                Console.WriteLine("Method: Render, Response: Error");
                return;
            }
            Console.WriteLine("Method: Render, Response: Ok");
        }

        public override void Publish()
        {
            var currentUser = CurrentUser.Get();
            
            if (currentUser.Role == UserRoles.Guest)
            {
                Console.WriteLine("Method: Publish, Response: Error");
                return;
            }
            
            if (currentUser.Role == UserRoles.Admin)
            {
                Console.WriteLine("Method: Publish, Response: Ok");
                Document.ChangeState(new PublishedState());
            }
            else if (currentUser.Role == UserRoles.Author)
            {
                Console.WriteLine("Method: Publish, Response: Ok");
                Document.ChangeState(new ModerationState());
            }
        }

        public override void Reject()
        {
            Console.WriteLine("Method: Reject, Response: Error");
        }
    }
}