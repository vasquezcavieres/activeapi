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


using Cl.Intertrade.ActivPay.Request.Transferencia;
using Cl.Intertrade.ActivPay.Result.Transferencia;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Transferencia
{
    /// <summary>
    /// Esta Clase Transferencia  permite gestionar la interacción con la base de datos para la tabla Transferencia
    /// </summary>
    public interface ITransferenciaService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        ListadoTransferenciaResult ObtenerTransferencias();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        ListadoTransferenciaResult BuscarTransferencias(int transferenciaId);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        TransferenciaResult ObtenerTransferencia(int transferenciaId);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaRequest"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        TransferenciaResult CrearTransferencia(TransferenciaRequest transferenciaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        public TransferenciaResult ActualizarTransferencia(TransferenciaRequest transferenciaRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        TransferenciaResult EliminarTransferencia(int transferenciaId);
        ListadoTransferenciaResult BuscarTransferenciasPorConvenio(int codigoConvenio);
        TransferenciaResult AprobarTransferencia(int transferenciaId);
        ListadoTransferenciaResult ObtenerTransferencias(TransferenciaRequest transferenciaRequest);
        ListadoTransferenciaResult BuscarTransferenciasPorEdificio(string codigoEdificio);
        Task<TransferenciaResult> ProcesoTransferencia();

    }
}

