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


using Cl.Intertrade.ActivPay.Request.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Result.DetalleTransferencia;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.DetalleTransferencia
{
    /// <summary>
    /// Esta Clase DetalleTransferencia  permite gestionar la interacción con la base de datos para la tabla DetalleTransferencia
    /// </summary>
    public interface IDetalleTransferenciaService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        ListadoDetalleTransferenciaResult ObtenerDetalleTransferencias();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        ListadoDetalleTransferenciaResult BuscarDetalleTransferencias(int transferenciaId, int rutRazonSocial);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        DetalleTransferenciaResult ObtenerDetalleTransferencia(int transferenciaId, int rutRazonSocial);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaRequest"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        DetalleTransferenciaResult CrearDetalleTransferencia(DetalleTransferenciaRequest detalleTransferenciaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaModel"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        public DetalleTransferenciaResult ActualizarDetalleTransferencia(DetalleTransferenciaRequest detalleTransferenciaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaModel"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        DetalleTransferenciaResult EliminarDetalleTransferencia(int transferenciaId, int rutRazonSocial);
        ListadoDetalleTransferenciaResult BuscarDetalleTransferencias(int transferenciaId);

    }
}

