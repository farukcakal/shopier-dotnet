using System.Text;

namespace ShopierService.Renderers
{
    public class IframeRenderer : FormRenderer
    {
        private string _width = "600px";
        private string _height = "600px";
        private bool _center = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shopier">Shopier instance</param>
        public IframeRenderer(Shopier shopier) : base(shopier)
        {
        }

        /// <summary>
        /// Renders the iframe content.
        /// </summary>
        public override void Render()
        {
            base.Render();

            var frameHtml = $@"
            <!DOCTYPE html>
            <html lang=""tr"">
            <body>
                {Data}
                <script type=""text/javascript"">
                    document.getElementById(""shopier_payment_form"").submit();
                </script>
            </body>
            </html>";

            var centerStyle = _center ? "height:100%; display: flex; justify-content: center; align-items: center;" : string.Empty;

            Data = $@"
            <div style=""{centerStyle}"">
                <iframe 
                    id=""shopier-payment-iframe"" 
                    name=""shopier-payment-iframe"" 
                    src=""#"" 
                    style=""width: {_width}; height: {_height}; border: 0;"">
                </iframe>
                <script type=""text/javascript"">
                    var docHtml = `{frameHtml}`;
                    var doc = document.getElementById('shopier-payment-iframe').contentWindow.document;
                    doc.open();
                    doc.write(docHtml);
                    doc.close();
                    document.getElementById(""shopier_payment_form"").submit();
                </script>
            </div>";
        }

        /// <summary>
        /// Gets the width of the iframe.
        /// </summary>
        public string GetWidth()
        {
            return _width;
        }

        /// <summary>
        /// Sets the width of the iframe.
        /// </summary>
        public IframeRenderer SetWidth(string width)
        {
            _width = width;
            return this;
        }

        /// <summary>
        /// Gets the height of the iframe.
        /// </summary>
        public string GetHeight()
        {
            return _height;
        }

        /// <summary>
        /// Sets the height of the iframe.
        /// </summary>
        public IframeRenderer SetHeight(string height)
        {
            _height = height;
            return this;
        }

        /// <summary>
        /// Determines if the iframe should be centered.
        /// </summary>
        public bool IsCenter()
        {
            return _center;
        }

        /// <summary>
        /// Sets whether the iframe should be centered.
        /// </summary>
        public IframeRenderer SetCenter(bool center)
        {
            _center = center;
            return this;
        }
    }
}