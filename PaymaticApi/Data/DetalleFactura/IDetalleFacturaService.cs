






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Request.DetalleFactura;
using Cl.Intertrade.ActivPay.Result.DetalleFactura;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.DetalleFactura
{
	/// <summary>
	/// Esta Clase DetalleFactura  permite gestionar la interacción con la base de datos para la tabla DetalleFactura
	/// </summary>
	public interface IDetalleFacturaService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		ListadoDetalleFacturaResult ObtenerDetalleFacturas();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		ListadoDetalleFacturaResult BuscarDetalleFacturas(int numeroFactura );
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		DetalleFacturaResult ObtenerDetalleFactura(int numeroFactura, int transferenciaId);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaRequest"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		DetalleFacturaResult CrearDetalleFactura(DetalleFacturaRequest detalleFacturaRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public DetalleFacturaResult ActualizarDetalleFactura(DetalleFacturaRequest detalleFacturaRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		DetalleFacturaResult EliminarDetalleFactura(int numeroFactura, int transferenciaId);
	}
}

