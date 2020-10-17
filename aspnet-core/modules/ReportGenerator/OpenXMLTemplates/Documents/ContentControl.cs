using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;

namespace OpenXMLTemplates.Documents
{
    public class ContentControl
    {
        public TemplateDocument TemplateDocument { get; private set; }
        public SdtElement SdtElement { get; internal set; }

        public string Tag { get; private set; }

        public OpenXmlExtensions.ContentControlType Type { get; private set; }

        public bool IsDescendantOfAContentControl { get; private set; }
        public bool IsFirstOrder => !IsDescendantOfAContentControl;

        public ContentControl Parent { get; internal set; }


        private List<ContentControl> descendingControls;
        public IEnumerable<ContentControl> DescendingControls => descendingControls;


        public ContentControl(SdtElement sdtElement, TemplateDocument templateDocument = null) : this(sdtElement,
            sdtElement.IsDescendantOfAContentControl(), templateDocument)
        {
        }

        public ContentControl(SdtElement sdtElement, bool isDescendantOfAContentControl,
            TemplateDocument templateDocument)
        {
            if (sdtElement.IsContentControl() == false)
                throw new ArgumentException("The provided SdtElement is not a content control", nameof(sdtElement));

            TemplateDocument = templateDocument;

            SdtElement = sdtElement;
            IsDescendantOfAContentControl = isDescendantOfAContentControl;
            Tag = sdtElement.GetContentControlTag();
            Type = sdtElement.GetContentControlType();
            descendingControls = new List<ContentControl>();
        }

        internal void AddDescendingControl(ContentControl control)
        {
            descendingControls.Add(control);
            if (TemplateDocument != null && TemplateDocument.AllContentControls.Contains(control) == false)
                TemplateDocument.AddControl(control, false);
        }


        internal void GenerateDescendantsFromChildren()
        {
            descendingControls.Clear();
            foreach (var descendant in SdtElement.ContentControls())
            {
                var descCon = new ContentControl(descendant, true, TemplateDocument) {Parent = this};
                descCon.GenerateDescendantsFromChildren();
                AddDescendingControl(descCon);
            }
        }

        public void Remove()
        {
            TemplateDocument?.RemoveControl(this);
            SdtElement.Remove();
        }


        public ContentControl Clone()
        {
            if (!(SdtElement.CloneNode(true) is SdtElement clonedElement)) return null;

            SdtElement.InsertBeforeSelf(clonedElement);
            var cloned = new ContentControl(clonedElement, IsDescendantOfAContentControl, TemplateDocument);
            TemplateDocument.AddControl(cloned, IsFirstOrder);
            cloned.GenerateDescendantsFromChildren();
            cloned.Parent = Parent;
            return cloned;
        }
    }
}