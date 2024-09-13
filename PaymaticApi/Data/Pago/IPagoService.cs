






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


using Cl.Intertrade.ActivPay.Request.Pago;
using Cl.Intertrade.ActivPay.Result.Pago;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Pago
{
    /// <summary>
    /// Esta Clase Pago  permite gestionar la interacción con la base de datos para la tabla Pago
    /// </summary>
    public interface IPagoService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
       // ListadoPagoResult ObtenerPagos();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        ListadoPagoResult BuscarPagos(string pagoId);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        PagoResult ObtenerPago(string pagoId);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoRequest"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        PagoResult CrearPago(PagoRequest pagoRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public PagoResult ActualizarPago(PagoRequest pagoRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        PagoResult EliminarPago(string pagoId);
        ListadoPagoResult BuscarPagosEdificio(string codigoEdificio);
        ListadoPagoResult BuscarPagosConvenio(string codigoConvenio);
        ListadoPagoResult ObtenerPagos(PagoRequest pagoRequest);

    }
}

