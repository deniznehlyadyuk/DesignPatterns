using System;
using State.DocumentPublication.DocumentStates;

namespace State.DocumentPublication
{
    public class Document
    {
        private DocumentState _documentState;

        public Document(DocumentState documentState)
        {
            ChangeState(documentState);
        }

        public void ChangeState(DocumentState documentState)
        {
            _documentState = documentState;
            _documentState.SetDocument(this);
        }

        public void Render()
        {
            _documentState.Render();
        }

        public void Publish()
        {
            _documentState.Publish();
        }

        public void Reject()
        {
            _documentState.Reject();
        }

        public string GetStateName()
        {
            return _documentState.Name;
        }
    }
}