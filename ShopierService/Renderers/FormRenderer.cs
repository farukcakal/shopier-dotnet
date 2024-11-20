using System.Text;

namespace ShopierService.Renderers
{
    public class FormRenderer : AbstractRenderer
    {
        private string _formStart = string.Empty;
        private string _formEnd = string.Empty;
        private string _formTarget = string.Empty;
        protected string Data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopier">Shopier instance</param>
        public FormRenderer(Shopier shopier) : base(shopier)
        {
        }

        /// <summary>
        /// Renders the payment form.
        /// </summary>
        public override void Render()
        {
            Shopier.Prepare();

            var inputs = new StringBuilder();
            foreach (var param in Params.ToDictionary())
            {
                inputs.AppendLine($"<input type=\"hidden\" name=\"{param.Key}\" value=\"{param.Value}\">");
            }

            var target = !string.IsNullOrEmpty(_formTarget) ? $"target=\"{_formTarget}\"" : string.Empty;
            Data = $@"
            <form id=""shopier_payment_form"" method=""post"" action=""{Shopier.GetPaymentUrl()}"" {target}>
            {_formStart}
            {inputs}
            {_formEnd}
            </form>";
        }

        /// <summary>
        /// Sets the start content of the form.
        /// </summary>
        public void SetFormStart(string formStart)
        {
            _formStart = formStart;
        }

        /// <summary>
        /// Sets the end content of the form.
        /// </summary>
        public void SetFormEnd(string formEnd)
        {
            _formEnd = formEnd;
        }

        /// <summary>
        /// Sets the target attribute of the form.
        /// </summary>
        public void SetFormTarget(string formTarget)
        {
            _formTarget = formTarget;
        }

        /// <summary>
        /// Gets the rendered form as a string.
        /// </summary>
        public string GetRenderedForm()
        {
            return Data;
        }
    }
}