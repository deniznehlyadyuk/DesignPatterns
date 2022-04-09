using System;

namespace State.DocumentPublication.DocumentStates
{
    public class PublishedState : DocumentState
    {
        public PublishedState()
        {
            Name = "Published State";
        }
        
        public override void Render()
        {
            Console.WriteLine("Method: Render, Response: Ok");
        }

        public override void Publish()
        {
            Console.WriteLine("Method: Publish, Response: Error");
        }

        public override void Reject()
        {
            Console.WriteLine("Method: Reject, Response: Error");
        }
    }
}