namespace ModelViewer
{
    internal class MHasProperty
    {
        public MModel model { get; set; }
        public MPropertyCategory propertyCategory { get; set; }
        public MProperty property { get; set; }
        public MHasProperty(MModel model, MPropertyCategory propertyCategory, MProperty property)
        {
            this.model = model;
            this.propertyCategory = propertyCategory;
            this.property = property;
        }
    }
}
