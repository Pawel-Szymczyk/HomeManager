using IdentityServer4.Models;

namespace IdentityServer.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }

        public ErrorViewModel(string error)
        {
            this.Error = new ErrorMessage { Error = error };
        }

        public ErrorMessage Error { get; set; }
    }
}
