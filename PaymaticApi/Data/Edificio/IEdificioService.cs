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


using Cl.Intertrade.ActivPay.Request.Edificio;
using Cl.Intertrade.ActivPay.Result.Edificio;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Edificio
{
    /// <summary>
    /// Esta Clase Edificio  permite gestionar la interacción con la base de datos para la tabla Edificio
    /// </summary>
    public interface IEdificioService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        ListadoEdificioResult ObtenerEdificios();
        ListadoEdificioResult ObtenerEdificiosAsociados();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        ListadoEdificioResult BuscarEdificios(string codigoEdificio);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        EdificioResult ObtenerEdificio(string codigoEdificio);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioRequest"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        EdificioResult CrearEdificio(EdificioRequest edificioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult ActualizarEdificio(EdificioRequest edificioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        EdificioResult EliminarEdificio(string codigoEdificio);

        EdificioResult AsociarEdificios(int rutRazonSocial, List<EdificioRequest> edificiosRequest);
        ListadoEdificioResult BuscarEdificiosConvenio(int rutRazonSocial);
        ListadoEdificioResult BuscarEdificiosConvenio(EdificioRequest edificioRequest);
        EdificioResult ObtenerEdificioComunidad(int rutComunidad);

    }
}

