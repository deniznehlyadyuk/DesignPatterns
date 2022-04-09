using System;
using State.DocumentPublication;
using State.DocumentPublication.DocumentStates;

namespace State
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var currentUser = CurrentUser.Get();
            currentUser.SetRole(UserRoles.Guest);
            
            var documentDraft = new Document(new DraftState());
            var documentModeration = new Document(new ModerationState());
            var documentPublished = new Document(new PublishedState());

            Console.WriteLine("\nGuest trying render...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Render();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Render();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Render();
            
            currentUser.SetRole(UserRoles.Guest);
            
            Console.WriteLine("\nGuest trying publish...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Publish();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Publish();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Publish();
            
            currentUser.SetRole(UserRoles.Guest);
            
            Console.WriteLine("\nGuest trying reject...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Reject();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Reject();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Reject();
            
            currentUser.SetRole(UserRoles.Author);
            
            Console.WriteLine("\nAuthor trying render...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Render();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Render();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Render();

            currentUser.SetRole(UserRoles.Author);
            
            Console.WriteLine("\nAuthor trying publish...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Publish();
            Console.WriteLine($"Current State: {documentDraft.GetStateName()}");
            documentDraft.ChangeState(new DraftState());
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Publish();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Publish();
            
            currentUser.SetRole(UserRoles.Author);
            
            Console.WriteLine("\nAuthor trying reject...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Reject();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Reject();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Reject();
            
            currentUser.SetRole(UserRoles.Admin);
            
            Console.WriteLine("\nAdmin trying render...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Render();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Render();
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Render();
            
            currentUser.SetRole(UserRoles.Admin);
            
            Console.WriteLine("\nAdmin trying publish...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Publish();
            Console.WriteLine($"Current State: {documentDraft.GetStateName()}");
            documentDraft.ChangeState(new DraftState());
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Publish();
            Console.WriteLine($"Current State: {documentModeration.GetStateName()}");
            documentModeration.ChangeState(new ModerationState());
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Publish();

            currentUser.SetRole(UserRoles.Admin);
            
            Console.WriteLine("\nAdmin trying reject...................................");
            Console.WriteLine("For Draft Document:");
            documentDraft.Reject();
            Console.WriteLine("\nFor Moderation Document:");
            documentModeration.Reject();
            Console.WriteLine($"Current State: {documentModeration.GetStateName()}");
            documentDraft.ChangeState(new ModerationState());
            Console.WriteLine("\nFor Published Document:");
            documentPublished.Reject();
        }
    }
}