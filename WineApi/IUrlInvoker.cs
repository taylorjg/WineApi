using System;

namespace WineApi
{
    /// <summary>
    /// This interface has been introduced specifically to enable better
    /// unit testing. The ServiceBase class supports Property Injection
    /// via the UrlInvoker proptery i.e. unit tests can pass in a mock object.
    /// </summary>
    /// <remarks>
    /// Ideally, I wanted this interface to be "internal" but the Castle
    /// dynamic proxy generator used by Rhino Mocks requires the type to be
    /// public.
    /// Castle.DynamicProxy.Generators.GeneratorException : Type is not public, so a proxy cannot be generated. Type: WineApi.IUrlInvoker
    /// </remarks>
    public interface IUrlInvoker
    {
        /// <summary>
        /// Invoke the given Url and return the resultant JSON response string.
        /// </summary>
        /// <param name="url">The Url to be invoked.</param>
        /// <returns>The JSON response text.</returns>
        string InvokeUrl(string url);
    }
}
