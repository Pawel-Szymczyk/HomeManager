using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
        public int ParamFanId { get; set; }
        [Parameter]
        public string Action { get; set; }

        #endregion



        //private Fan[] fans;
        protected List<Fan> fans = new List<Fan>();
        public Fan fan = new Fan();

        protected string search_string = "";
        protected Fan selected_item = null;

        protected string Title { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            //if (Action == "fetch")
            if (Action == "fans")
            {
                await FetchFans();
            }
            else if (Action == "create")
            {
                Title = "Add Fan";
                fan = new Fan();
            }
        }

        protected async Task FetchFans()
        {
            Title = "Fans";
            fans = await Http.GetFromJsonAsync<List<Fan>>("https://localhost:44324/api/v1/fans");
            //fans = await Http.GetFromJsonAsync<Fan[]>("v1/fans");
        }

        protected async Task CreateFan()
        {
            if ( fan.FanId != Guid.Empty )
            {
                //await Http.SendJsonAsync(HttpMethod.Put, "api/Employee/Edit", emp);
            }
            else
            {
                //await Http.SendJsonAsync(HttpMethod.Post, "/api/Employee/Create", emp);
            }
            UrlNavigationManager.NavigateTo("/employee/fetch");
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
