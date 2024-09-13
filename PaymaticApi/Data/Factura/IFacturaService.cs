/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-09-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Request.Factura;
using Cl.Intertrade.ActivPay.Result.Factura;
using System.Collections.Generic;
using System;
using ActivPayApi.Models.Result.Factura;

namespace Cl.Intertrade.ActivPay.Data.Factura
{
    /// <summary>
    /// Esta Clase Factura  permite gestionar la interacción con la base de datos para la tabla Factura
    /// </summary>
    public interface IFacturaService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        ListadoFacturaResult ObtenerFacturas();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        ListadoFacturaResult BuscarFacturas(int numeroFactura);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        FacturaResult ObtenerFactura(int numeroFactura);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaRequest"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        FacturaResult CrearFactura(FacturaRequest facturaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public FacturaResult ActualizarFactura(FacturaRequest facturaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        FacturaResult EliminarFactura(int numeroFactura);
        ListadoFacturaResult BuscarFacturas(FacturaRequest facturaRequest);
        FacturaResult AnularFactura(FacturaRequest facturaRequest);
        Task<FacturaResult> ObtenerNotaCredito(FacturaRequest facturaRequest);
    }
}

