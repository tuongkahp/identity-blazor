using Microsoft.JSInterop;

namespace IdentityBlazor.Services
{
    public sealed class BrowserService : IDisposable
    {
        private readonly IJSRuntime _js;

        public BrowserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<BrowserDimension> GetDimensionsAsync()
        {
            return await _js.InvokeAsync<BrowserDimension>("getDimensions");
        }
        public void Dispose()
        {
            // Clean up resources...
        }
    }
    public struct BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}