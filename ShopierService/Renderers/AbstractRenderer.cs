using ShopierService.Models;

namespace ShopierService.Renderers;

public abstract class AbstractRenderer
{
    /// <summary>
    /// Shopier instance
    /// </summary>
    protected Shopier Shopier;

    /// <summary>
    /// ShopierParams instance
    /// </summary>
    protected ShopierParamsModel Params;

    /// <summary>
    /// Data to be rendered
    /// </summary>
    protected string Data = string.Empty;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="shopier">Shopier instance</param>
    public AbstractRenderer(Shopier shopier)
    {
        Shopier = shopier;
        Params = shopier.GetParams();
    }

    /// <summary>
    /// Abstract render method
    /// </summary>
    public abstract void Render();

    /// <summary>
    /// Outputs the data
    /// </summary>
    /// <param name="returnData">If true, returns the data instead of printing</param>
    /// <param name="exit">If true, terminates the application</param>
    /// <returns>Rendered data</returns>
    public string Output(bool returnData = false, bool exit = false)
    {
        if (!returnData)
            Console.WriteLine(Data);
        if (exit)
            Environment.Exit(0);

        return Data;
    }
}