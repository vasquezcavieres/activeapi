






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*27-09-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Entities.Edificio;
using Cl.Intertrade.ActivPay.Entities.Pago;
using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Pago
{
    /// <summary>
    /// Esta Clase Pago  permite gestionar la interacción con la base de datos para la tabla Pago
    /// </summary>
    public interface IPagoRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>

        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<PagoModel> BuscarPagos(string pagoId);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        PagoModel ObtenerPago(string pagoId);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        PagoModel CrearPago(PagoModel pagoModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarPago(PagoModel pagoModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarPago(string pagoId);
        IList<PagoModel> BuscarPagosEdificio(string codigoEdificio);
        IList<PagoModel> BuscarPagosConvenio(string codigoConvenio);
        IList<PagoModel> BuscarDashboard(DashboardRequest dashboardRequest);
        IList<PagoModel> ObtenerPagosEdificio(EdificioModel edificioModel);
        IList<PagoModel> BuscarDashboardNoFacturado(DashboardRequest dashboardRequest);
        IList<PagoModel> ObtenerPagos(PagoModel pagoModel);
        IList<PagoModel> BuscarPagosProcesoTrasnferencia();
    }
}

