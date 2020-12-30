using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class FanDataModel : ComponentBase
    {
        #region HTTP 
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        #endregion

        #region Parameters
        [Parameter]
        public Guid ParamFanId { get; set; }
        [Parameter]
        public string Action { get; set; }

        #endregion

        private const string ServiceEndpoint = "https://localhost:44324/api/v1/fans";

        protected List<Fan> fans = new List<Fan>();
        public Fan fan = new Fan();

        protected string search_string = "";
        protected Fan selected_item = null;

        protected string Title { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Action == "all")
            {
                await FetchFans();
            }
            else if (Action == "create")
            {
                Title = "Add Fan";
                fan = new Fan();
            }
            else if (ParamFanId != Guid.Empty)
            {
                if (Action == "edit")
                {
                    Title = "Edit Fan";
                }
                else if (Action == "delete")
                {
                    Title = "Delete Fan";
                }

                await FetchFan();
            }
        }

        /// <summary>
        /// Gets list of fans.
        /// </summary>
        protected async Task FetchFans()
        {
            Title = "Fans";
            fans = await Http.GetFromJsonAsync<List<Fan>>(ServiceEndpoint);
        }

        /// <summary>
        /// Gets specific single fan details. 
        /// </summary>
        protected async Task FetchFan()
        {
            //"https://localhost:44324/api/v1/fans/" + ParamFanId
            fan = await Http.GetFromJsonAsync<Fan>($"{ServiceEndpoint}/{ParamFanId}");
        }

        /// <summary>
        /// Stores/updates fan in the servers' database.
        /// </summary>
        protected async Task CreateFan()
        {
            if ( fan.FanId != Guid.Empty )
            {
                await Http.PutAsJsonAsync(ServiceEndpoint, fan);
            }
            else
            {
                // create
                await Http.PostAsJsonAsync(ServiceEndpoint, fan);
            }
            UrlNavigationManager.NavigateTo("/pcbuilder/fans/all");
        }

        /// <summary>
        /// Deletes specific fan from server.
        /// </summary>
        /// <returns></returns>
        protected async Task DeleteFan()
        {
            await Http.DeleteAsync($"{ServiceEndpoint}/{ParamFanId}");
            UrlNavigationManager.NavigateTo("/pcbuilder/fans/all");
        }




        protected bool FilterFunc(Fan element)
        {
            if (string.IsNullOrWhiteSpace(search_string))
                return true;
            if (element.Manufacturer.Contains(search_string))
                return true;
            if (element.Name.Contains(search_string))
                return true;
            //if ($"{element.Number} {element.Position} {element.Molar}".Contains(search_string))
            //    return true;
            return false;
        }



    }
}
