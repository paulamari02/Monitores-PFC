using MonitoresTFC.Models.DTO;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.RadarChart;

namespace MonitoresTFC.Pages.Graficos
{
    public partial class GraficosAlmacen
    {
        private List<ListadoentradaalmacenDTO> ListEntradaAlmacen { get; set; } = new();
        private List<ListadosalidasalmacenDTO> ListSalidasAlmacen { get; set; } = new();

        private RadarConfig _radarConfig;
        private BarConfig _barConfig;
        private void LoadData()
        {
            ListEntradaAlmacen = rep.ListadoEntradaAlmacen();
            ListSalidasAlmacen = rep.ListadoSalidasAlmacen();
        }
        protected override void OnInitialized()
        {
            LoadData();
            ConfigureRadarConfig();
            ConfigureBarConfig();
        }

        /*GRAFICO RADAR*/
        private void ConfigureRadarConfig()
        {
            List<int> dataListE = new();
            List<int> dataListS = new();
            _radarConfig = new RadarConfig
            {

                Options = new RadarOptions
                {
                    Responsive = true,
                    Title = new ChartJs.Blazor.Common.OptionsTitle
                    {
                        Display = true,
                        Text = "Porcentaje de proveedores de entradas y salidas",
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

            foreach (var party in new[] { "Pendiente", "Tránsito", "Almacenado" })
            {
                _radarConfig.Data.Labels.Add(party);
                dataListE.Add(ListEntradaAlmacen.Where(p => p.Estado.Contains(party)).Count());
                dataListS.Add(ListSalidasAlmacen.Where(p => p.Estado.Contains(party)).Count());
            };
            var dataEntrada = new RadarDataset<int>(dataListE)
            {
                Label = "Salida",
                BackgroundColor = "rgba(116,190,218, 0.5)",
                BorderColor = "rgba(116,190,218)"

            };
            _radarConfig.Data.Datasets.Add(dataEntrada);
            var dataSalida = new RadarDataset<int>(dataListS)
            {
                Label = "Entrada",
                BackgroundColor = "rgba(214,111,173, 0.5)",
                BorderColor = "rgba(214,111,173)",

            };
            _radarConfig.Data.Datasets.Add(dataSalida);
        }

        /*GRAFICO BARRAS DOBLES*/
        private void ConfigureBarConfig()
        {
            List<int> dataListE = new();
            List<int> dataListS = new();
            _barConfig = new BarConfig
            {
                Options = new BarOptions
                {
                    Responsive = true,
                    Title = new ChartJs.Blazor.Common.OptionsTitle
                    {
                        Display = true,
                        Text = "Proveedores de entradas y salidas",
                        FontSize = 20
                    },
                    Legend = new()
                    {
                        Labels = new()
                        {
                            FontSize = 14
                        }
                    },
                    Scales = new()
                    {
                        YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true,
                                SuggestedMax = 6
                            }
                        }
                    }
                    }
                }

            };

            foreach (var party in new[] { "Voss", "PIMA", "MidaTec", "CEBI" })
            {
                _barConfig.Data.Labels.Add(party);
                dataListE.Add(ListEntradaAlmacen.Where(p => p.Proveedor != null && p.Proveedor.Contains(party)).Count());
                dataListS.Add(ListSalidasAlmacen.Where(p => p.Proveedor != null && p.Proveedor.Contains(party)).Count());

            };

            var datasetE = new BarDataset<int>(dataListE)
            {
                BackgroundColor = "rgba(116,190,218, 0.5)",
                BorderColor = ColorUtil.ColorHexString(116, 190, 218),
                BorderWidth = 3,
                Label = "Entradas"

            };
            _barConfig.Data.Datasets.Add(datasetE);

            var datasetS = new BarDataset<int>(dataListS)
            {
                BackgroundColor = "rgba(110,41,146, 0.5)",
                BorderColor = ColorUtil.ColorHexString(110, 41, 146),
                BorderWidth = 3,
                Label = "Salidas"

            };
            _barConfig.Data.Datasets.Add(datasetS);
        }

        /*REDIRECCION*/
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }

    }
}