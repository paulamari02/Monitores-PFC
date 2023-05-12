using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using MonitoresTFC.Models.DTO;

namespace MonitoresTFC.Pages.Graficos
{
    public partial class GraficosPedidos
    {
        private List<ListadopedidosDTO> Listpedidos { get; set; } = new();
        private List<ListadoarticulosDTO> ListArticulos { get; set; } = new();

        private PieConfig _pieConfig;
        private BarConfig _barConfig;

        private void LoadData()
        {
            Listpedidos = rep.ListadoPedidos();
            ListArticulos = rep.ListadoArticulosGraf();
        }
        protected override void OnInitialized()
        {
            LoadData();
            ConfigurePieConfig();
            ConfigureBarConfig();
        }
        
        /*GRAFICO CIRCULAR*/
        private void ConfigurePieConfig()
        {
            List<int> dataList = new();
            _pieConfig = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new ChartJs.Blazor.Common.OptionsTitle
                    {
                        Display = true,
                        Text = "Porcentaje de status de pedidos",
                        FontSize = 20
                    },
                    Legend = new() { 
                        Labels = new() { 
                            FontSize = 14
                        }
                    }
                }
            };

            foreach (var party in new[] { "Terminado", "En proceso", "Cancelado" })
            {
                _pieConfig.Data.Labels.Add(party);
                dataList.Add(Listpedidos.Where(p => p.StatusPedido.Contains(party)).Count());
            };
            var dataset = new PieDataset<int>(dataList)
            {
                BackgroundColor = new[]
                {
                    ColorUtil.ColorHexString(116,190,218),
                    ColorUtil.ColorHexString(214,111,173),
                    ColorUtil.ColorHexString(110,41,146)
                }
            };
            _pieConfig.Data.Datasets.Add(dataset);
        }
        
        /*GRAFICO BARRAS*/
        private void ConfigureBarConfig()
        {
            List<int> dataList = new();
            int count = 0;
            _barConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Responsive = true,
                    Title = new ChartJs.Blazor.Common.OptionsTitle
                    {
                        Display = true,
                        Text = "Stock de artículos",
                        FontSize = 20
                    },
                    Legend = new()
                    {
                        Labels = new()
                        {
                            FontSize = 14
                        }
                    }
                }
            };

            foreach (var party in new[] { "Disponible", "Agotado", "Descatalogado", "Total" })
            {
                _barConfig.Data.Labels.Add(party);
                if (party == "Total")
                {
                    dataList.Add(count);
                }
                dataList.Add(ListArticulos.Where(p => p.Status.Contains(party)).Count());
                count += ListArticulos.Where(p => p.Status.Contains(party)).Count();

            };

            var dataset = new BarDataset<int>(dataList)
            {
                BackgroundColor = new[]
                {
                    "rgba(116,190,218, 0.5)",
                    "rgba(214,111,173, 0.5)",
                    "rgba(110,41,146, 0.5)",
                    "rgba(0, 70, 155, 0.5)"
                },
                BorderColor = new[]
                {
                    ColorUtil.ColorHexString(116,190,218),
                    ColorUtil.ColorHexString(214,111,173),
                    ColorUtil.ColorHexString(110,41,146),
                    ColorUtil.ColorHexString(0, 70, 155)
                },
                BorderWidth = 3,
                Label = "Artículos"

            };
            _barConfig.Data.Datasets.Add(dataset);
        }

        /*REDIRECCION*/
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
    }
}
