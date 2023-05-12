using Microsoft.EntityFrameworkCore;
using MonitoresTFC.Contexts;
using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Data
{
    public class Repository : IRepository
    {
        private readonly IConfiguration configuration;

        private DbContextOptionsBuilder<MonitContext> MonOptBuilder { get; set; } = new();

        public Repository(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            this.configuration = configuration;

            MonitContext context = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<MonitContext>();
            string connection = this.configuration.GetConnectionString("MonitoresConnection");
            MonOptBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }

        public async Task<List<ListadoclientesDTO>> ListadoClientes()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return await context.Listadoclientes
                                .Select(mix => new ListadoclientesDTO
                                {
                                    IdCliente = mix.IdCliente,
                                    Nombre = mix.Nombre,
                                    Apellidos = mix.Apellidos,
                                    Email = mix.Email,
                                    Telefono = mix.Telefono,
                                    Direccion = mix.Direccion,
                                    CodigoPostal = mix.CodigoPostal,
                                    Fechaalta = mix.Fechaalta,
                                    Observaciones = mix.Observaciones
                                })
                                .ToListAsync();
        }
        public async Task<List<ListadoproveedoresDTO>> ListadoProveedores()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return await context.Listadoproveedores
                                .Select(mix => new ListadoproveedoresDTO
                                {
                                    IdProveedor = mix.IdProveedor,
                                    Nombre = mix.Nombre,
                                    NumFiscal = mix.NumFiscal,
                                    Email = mix.Email,
                                    Telefono = mix.Telefono,
                                    Direccion = mix.Direccion,
                                    CodigoPostal = mix.CodigoPostal,
                                    Observaciones = mix.Observaciones
                                })
                                .ToListAsync();
        }
        public List<ListadopedidosDTO> ListadoPedidos()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return context.Listadopedidos
                                .GroupJoin(context.Listadoclientes, ped => ped.IdCliente, cli => cli.IdCliente, (ped, cli) => new { ped, cli })
                                .SelectMany(mix => mix.cli.DefaultIfEmpty(), (mix, cli) => new { mix.ped, cli })
                                .Select(mix => new ListadopedidosDTO
                                {
                                    IdPedido = mix.ped.IdPedido,
                                    Nombre = mix.ped.Nombre,
                                    Cliente = mix.cli.Nombre,
                                    StatusPedido = mix.ped.StatusPedido,
                                    FechaPedido = mix.ped.FechaPedido,
                                    Descripcion = mix.ped.Descripcion
                                })
                                .ToList();
        }
        public async Task<List<ListadoarticulosDTO>> ListadoArticulos()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return await context.Listadoarticulos
                                .GroupJoin(context.Listadoproveedores, art => art.IdProveedor, prov => prov.IdProveedor, (art, prov) => new { art, prov })
                                .SelectMany(mix => mix.prov.DefaultIfEmpty(), (mix, prov) => new { mix.art, prov })
                                .Select(mix => new ListadoarticulosDTO
                                {
                                    IdArticulo = mix.art.IdArticulo,
                                    Articulo = mix.art.Articulo,
                                    CodArticulo = mix.art.CodArticulo,
                                    Status = mix.art.Status,
                                    Observaciones = mix.art.Observaciones,
                                    Proveedor = mix.prov.Nombre
                                })
                                .ToListAsync();
        }
        public List<ListadoarticulosDTO> ListadoArticulosGraf()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return  context.Listadoarticulos
                                .GroupJoin(context.Listadoproveedores, art => art.IdProveedor, prov => prov.IdProveedor, (art, prov) => new { art, prov })
                                .SelectMany(mix => mix.prov.DefaultIfEmpty(), (art, prov) => new { art, prov })
                                .Select(mix => new ListadoarticulosDTO
                                {
                                    IdArticulo = mix.art.art.IdArticulo,
                                    Articulo = mix.art.art.Articulo,
                                    CodArticulo = mix.art.art.CodArticulo,
                                    Status = mix.art.art.Status,
                                    Observaciones = mix.art.art.Observaciones,
                                    Proveedor = mix.prov.Nombre
                                })
                                .ToList();
        }
        public List<ListadoentradaalmacenDTO> ListadoEntradaAlmacen()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return context.Listadoentradaalmacens
                                .GroupJoin(context.Listadoproveedores, ent => ent.IdProveedor, prov => prov.IdProveedor, (ent, prov) => new { ent, prov })
                                .SelectMany(mix => mix.prov.DefaultIfEmpty(), (mix, prov) => new { mix.ent, prov })
                                .Select(mix => new ListadoentradaalmacenDTO
                                {
                                    IdEntrada = mix.ent.IdEntrada,
                                    Albaran = mix.ent.Albaran,
                                    FechaEntrada = mix.ent.FechaEntrada,
                                    FechaTransito = mix.ent.FechaTransito,
                                    Proveedor = mix.prov.Nombre,
                                    Estado = mix.ent.Estado,
                                    Cantidad = mix.ent.Cantidad,
                                    Bultos = mix.ent.Bultos
                                })
                                .ToList();
        }
        public List<ListadosalidasalmacenDTO> ListadoSalidasAlmacen()
        {
            MonitContext context = new(MonOptBuilder.Options);
            return context.Listadosalidasalmacens
                                .GroupJoin(context.Listadoarticulos, sal => sal.IdArticulo, art => art.IdArticulo, (sal, art) => new { sal, art })
                                .SelectMany(mix => mix.art.DefaultIfEmpty(), (mix, art) => new { mix.sal, art })
                                .GroupJoin(context.Listadoproveedores, mix => mix.sal.IdProveedor, prov => prov.IdProveedor, (mix, prov) => new { mix.sal, mix.art, prov })
                                .SelectMany(mix => mix.prov.DefaultIfEmpty(), (mix, prov) => new { mix.sal, mix.art, prov })
                                .Select(mix => new ListadosalidasalmacenDTO
                                {
                                    IdSalidas = mix.sal.IdSalidas,
                                    Albaran = mix.sal.Albaran,
                                    Proveedor = mix.prov.Nombre,
                                    FechaSalida = mix.sal.FechaSalida,
                                    Estado = mix.sal.Estado,
                                    Articulo = mix.art.Articulo,
                                    Cantidad = mix.sal.Cantidad,
                                    Bultos = mix.sal.Bultos
                                })
                                .ToList();
        }

        /*CLIENTE*/
        public Listadocliente GetCliente(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadoclientes.Where(a => a.IdCliente == id).First();
        }
        public bool AddCliente(Listadocliente cliente)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(cliente).State = EntityState.Added;
                context.Listadoclientes.Add(cliente);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCliente(Listadocliente cliente)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCliente(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadocliente articulo = context.Listadoclientes.Where(a => a.IdCliente == id).First();
                context.Entry(articulo).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*PROVEEDOR*/
        public Listadoproveedore GetProveedor(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadoproveedores.Where(a => a.IdProveedor == id).First();
        }
        public bool AddProveedor(Listadoproveedore proveedor)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(proveedor).State = EntityState.Added;
                context.Listadoproveedores.Add(proveedor);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateProveedor(Listadoproveedore proveedor)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(proveedor).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProveedor(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadoproveedore proveedor = context.Listadoproveedores.Where(a => a.IdProveedor == id).First();
                context.Entry(proveedor).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*PEDIDOS*/
        public Listadopedido GetPedido(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadopedidos.Where(a => a.IdPedido == id).First();
        }
        public bool AddPedido(Listadopedido pedido)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(pedido).State = EntityState.Added;
                context.Listadopedidos.Add(pedido);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePedido(Listadopedido pedido)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(pedido).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePedido(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadopedido pedido = context.Listadopedidos.Where(a => a.IdPedido == id).First();
                context.Entry(pedido).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*ARTICULO*/
        public Listadoarticulo GetArticulo(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadoarticulos.Where(a => a.IdArticulo == id).First();
        }
        public bool AddArticle(Listadoarticulo articulo)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(articulo).State = EntityState.Added;
                context.Listadoarticulos.Add(articulo);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateArticle(Listadoarticulo articulo)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(articulo).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteArticle(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadoarticulo articulo = context.Listadoarticulos.Where(a => a.IdArticulo == id).First();
                context.Entry(articulo).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*SALIDAS*/
        public Listadosalidasalmacen GetSalida(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadosalidasalmacens.Where(a => a.IdSalidas == id).First();
        }
        public bool AddSalida(Listadosalidasalmacen salida)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(salida).State = EntityState.Added;
                context.Listadosalidasalmacens.Add(salida);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSalida(Listadosalidasalmacen salida)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(salida).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSalida(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadosalidasalmacen salida = context.Listadosalidasalmacens.Where(a => a.IdSalidas == id).First();
                context.Entry(salida).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /*ENTRADAS*/
        public Listadoentradaalmacen GetEntrada(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            return context.Listadoentradaalmacens.Where(a => a.IdEntrada == id).First();
        }
        public bool AddEntrada(Listadoentradaalmacen entrada)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(entrada).State = EntityState.Added;
                context.Listadoentradaalmacens.Add(entrada);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateEntrada(Listadoentradaalmacen entrada)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                context.Entry(entrada).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteEntrada(int id)
        {
            MonitContext context = new(MonOptBuilder.Options);

            try
            {
                Listadoentradaalmacen entrada = context.Listadoentradaalmacens.Where(a => a.IdEntrada == id).First();
                context.Entry(entrada).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

