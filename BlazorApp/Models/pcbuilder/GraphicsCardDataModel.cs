using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Models.pcbuilder
{
    public class GraphicsCardDataModel : ComponentBase
    {
        #region HTTP 
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        #endregion

        #region Parameters
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string Action { get; set; }

        [Parameter]
        public string imgUrl { get; set; }

        [Parameter]
        public byte[] imageInByte { get; set; }

        [Parameter]
        public string imageName { get; set; }

        #endregion

        private const string ServiceEndpoint = "https://localhost:44324/api/v1/GraphicsCards";

        protected List<GraphicsCard> graphicsCards  = new List<GraphicsCard>();
        public GraphicsCard graphicsCard = new GraphicsCard();

        protected string search_string = "";
        protected GraphicsCard selected_item = null;

        protected string Title { get; set; }
        protected string ButtonName { get; set; }

        protected IEnumerable<IFileListEntry> files;



        protected override async Task OnParametersSetAsync()
        {
            if (Action == "all")
            {
                await FetchGraphicsCards();
            }
            else if (Action == "create")
            {
                ButtonName = "Create";
                Title = "Add Graphics Card";
                graphicsCard = new GraphicsCard();
            }
            else if (Id != Guid.Empty)
            {
                if (Action == "edit")
                {
                    ButtonName = "Update";
                    Title = "Edit Graphics Card";
                }
                else if (Action == "delete")
                {
                    ButtonName = "Delete";
                    Title = "Delete Graphics Card";
                }

                await FetchGraphicsCard();
            }
        }

        /// <summary>
        /// Gets list of fans.
        /// </summary>
        protected async Task FetchGraphicsCards()
        {
            Title = "Graphics Cards";
            graphicsCards = await Http.GetFromJsonAsync<List<GraphicsCard>>(ServiceEndpoint);
        }

        /// <summary>
        /// Gets specific single fan details. 
        /// </summary>
        protected async Task FetchGraphicsCard()
        {
            graphicsCard = await Http.GetFromJsonAsync<GraphicsCard>($"{ServiceEndpoint}/{Id}");

            imgUrl = string.Empty;
            if (graphicsCard.ImageData != null)
            {
                string imageBase64Data = Convert.ToBase64String(graphicsCard.ImageData);
                imgUrl = string.Format("data:image/png;base64,{0}", imageBase64Data);
            }
        }

        /// <summary>
        /// Stores/updates fan in the servers' database.
        /// </summary>
        protected async Task CreateGraphicsCard()
        {
            if (imageInByte != null)
            {
                graphicsCard.ImageTitle = imageName;
                graphicsCard.ImageData = imageInByte;
            }

            if (graphicsCard.GraphicsCardId != Guid.Empty)
            {
                await Http.PutAsJsonAsync(ServiceEndpoint, graphicsCard);
            }
            else
            {
                // create
                await Http.PostAsJsonAsync(ServiceEndpoint, graphicsCard);
            }

            imgUrl = string.Empty;
            UrlNavigationManager.NavigateTo("/pcbuilder/graphics-cards/all");
        }

        /// <summary>
        /// Deletes specific fan from server.
        /// </summary>
        /// <returns></returns>
        protected async Task DeleteGraphicsCard()
        {
            await Http.DeleteAsync($"{ServiceEndpoint}/{Id}");
            UrlNavigationManager.NavigateTo("/pcbuilder/graphics-cards/all");
        }









        protected async Task UploadFiles(IFileListEntry[] entries)
        {
            files = entries;

            var file = entries.FirstOrDefault();
            if (file != null)
            {
                //Console.WriteLine(file.Type); 
                if (file.Type == "image/jpeg" || file.Type == "jpg" || file.Type == "image/png")
                {
                    imageName = file.Name;
                    using (var ms = new System.IO.MemoryStream())
                    {
                        await file.Data.CopyToAsync(ms);

                        imageInByte = ms.ToArray();


                        string imageBase64Data = Convert.ToBase64String(ms.ToArray());
                        imgUrl = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                }
            }
        }
    }
}
