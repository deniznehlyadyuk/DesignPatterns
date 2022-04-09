namespace State.DocumentPublication.DocumentStates
{
    public abstract class DocumentState
    {
        public void SetDocument(Document document)
        {
            Document = document;
        }

        protected Document Document { get; private set; }
        public string Name { get; set; }
        
        public abstract void Render();
        public abstract void Publish();
        public abstract void Reject();
    }
}