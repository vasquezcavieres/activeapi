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


using Cl.Intertrade.ActivPay.Request.Convenio;
using Cl.Intertrade.ActivPay.Result.Convenio;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Convenio
{
    /// <summary>
    /// Esta Clase Convenio  permite gestionar la interacción con la base de datos para la tabla Convenio
    /// </summary>
    public interface IConvenioService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        ListadoConvenioResult ObtenerConvenios();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        ListadoConvenioResult BuscarConvenios(int rutRazonSocial);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        ConvenioResult ObtenerConvenio(int rutRazonSocial);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioRequest"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        ConvenioResult CrearConvenio(ConvenioRequest convenioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        public ConvenioResult ActualizarConvenio(ConvenioRequest convenioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        ConvenioResult EliminarConvenio(int rutRazonSocial);
        ConvenioResult AsociarUsuarioAdministradaor(ConvenioRequest convenioRequest);
        ConvenioResult ObtenerConvenioPorEdificio(string codigoEdificio);
        ConvenioResult ObtenerConvenioPorAdministrador(string rutAdministrador);

    }
}

