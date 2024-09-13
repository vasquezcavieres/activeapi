/**
* (c)2013-2023 CodeBase SPA Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-09-2023,Generador de Código, Clase Inicial 
*/

using AutoMapper;

using Cl.Intertrade.ActivPay.Entities.CicloTransferencia;
using Cl.Intertrade.ActivPay.Request.CicloTransferencia;
using Cl.Intertrade.ActivPay.Result.CicloTransferencia;

using Cl.Intertrade.ActivPay.Entities.Convenio;
using Cl.Intertrade.ActivPay.Request.Convenio;
using Cl.Intertrade.ActivPay.Result.Convenio;

using Cl.Intertrade.ActivPay.Entities.DetalleFactura;
using Cl.Intertrade.ActivPay.Request.DetalleFactura;
using Cl.Intertrade.ActivPay.Result.DetalleFactura;

using Cl.Intertrade.ActivPay.Entities.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Request.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Result.DetalleTransferencia;

using Cl.Intertrade.ActivPay.Entities.Edificio;
using Cl.Intertrade.ActivPay.Request.Edificio;
using Cl.Intertrade.ActivPay.Result.Edificio;

using Cl.Intertrade.ActivPay.Entities.Factura;
using Cl.Intertrade.ActivPay.Request.Factura;
using Cl.Intertrade.ActivPay.Result.Factura;

using Cl.Intertrade.ActivPay.Entities.Transferencia;
using Cl.Intertrade.ActivPay.Request.Transferencia;
using Cl.Intertrade.ActivPay.Result.Transferencia;

using Cl.Intertrade.ActivPay.Entities.Usuario;
using Cl.Intertrade.ActivPay.Request.Usuario;
using Cl.Intertrade.ActivPay.Result.Usuario;
using Cl.Intertrade.ActivPay.Request.Pago;
using Cl.Intertrade.ActivPay.Result.Pago;
using Cl.Intertrade.ActivPay.Entities.Pago;
using Cl.Intertrade.ActivPay.Entities.Acceso;
using Cl.Intertrade.ActivPayApi.Request.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Result.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPay.Entities.Banco;
using Cl.Intertrade.ActivPay.Entities.TipoAbono;
using Cl.Intertrade.ActivPay.Request.Banco;
using Cl.Intertrade.ActivPay.Request.TipoAbono;
using Cl.Intertrade.ActivPay.Result.Banco;
using Cl.Intertrade.ActivPay.Result.TipoAbono;
using Cl.Intertrade.ActivPay.Entities.Uf;
using Cl.Intertrade.ActivPay.Request.Uf;
using Cl.Intertrade.ActivPay.Result.Uf;

namespace Cl.Intertrade.ActivPay.Helpers.Mapper
{
    /// <summary>
    /// Acá se realizara el mappeo entre los To y los Models de la facade y viceversa.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CicloTransferenciaRequest, CicloTransferenciaModel>().ReverseMap();
            CreateMap<CicloTransferenciaResult, CicloTransferenciaModel>().ReverseMap();
            CreateMap<ConvenioRequest, ConvenioModel>().ReverseMap();
            CreateMap<ConvenioResult, ConvenioModel>().ReverseMap();
            CreateMap<DetalleFacturaRequest, DetalleFacturaModel>().ReverseMap();
            CreateMap<DetalleFacturaResult, DetalleFacturaModel>().ReverseMap();
            CreateMap<DetalleTransferenciaRequest, DetalleTransferenciaModel>().ReverseMap();
            CreateMap<DetalleTransferenciaResult, DetalleTransferenciaModel>().ReverseMap();
            CreateMap<EdificioRequest, EdificioModel>().ReverseMap();
            CreateMap<EdificioResult, EdificioModel>().ReverseMap();
            CreateMap<FacturaRequest, FacturaModel>().ReverseMap();
            CreateMap<FacturaResult, FacturaModel>().ReverseMap();
            CreateMap<TransferenciaRequest, TransferenciaModel>().ReverseMap();
            CreateMap<TransferenciaResult, TransferenciaModel>().ReverseMap();
            CreateMap<UsuarioRequest, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioResult, UsuarioModel>().ReverseMap();
            CreateMap<PagoRequest, PagoModel>().ReverseMap();
            CreateMap<PagoResult, PagoModel>().ReverseMap();
            CreateMap<UsuarioResult, AccesoModel>().ReverseMap();
            CreateMap<ArchivoPagoProveedoresRequest, ArchivoPagoProveedoresModel>().ReverseMap();
            CreateMap<ArchivoPagoProveedoresResult, ArchivoPagoProveedoresModel>().ReverseMap();
            CreateMap<BancoRequest, BancoModel>().ReverseMap();
            CreateMap<BancoResult, BancoModel>().ReverseMap();
            CreateMap<TipoAbonoRequest, TipoAbonoModel>().ReverseMap();
            CreateMap<TipoAbonoResult, TipoAbonoModel>().ReverseMap();
            CreateMap<UfRequest, UfModel>().ReverseMap();
            CreateMap<UfResult, UfModel>().ReverseMap();
        }
    }
}      
