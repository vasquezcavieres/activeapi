using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Helpers.Utils
{
    public static class Enumeraciones
    {
        public enum EnumError
        {
            [Description("Monto a Pagar no coincide con el valor del SOAP + Aporte realizado")]
            MontoNoCoincide,
            [Description("Nuestros registros indican que usted ya pagó su póliza. Si aún no la recibe, por favor pongase encontacto con nosotros para asistirlo.")]
            Pagado,
            [Description("Monto del SOAP que intenta comprar es menor al precio de venta, por favor verifique y vuelva internat su compra.")]
            PrimaMinima,
            [Description("No tenemos registro de la transacción que intenta realizar, por favor verifique y vuelva internat su compra.")]
            NoExiste,
            [Description("La Patente ya contrató su seguro en Soap Bomberos. Utiliza la opción Descargar Póliza.")]
            Emitida,
            [Description("Al parecer nos falta tu email o es inválido. Por favor revisa y vuelve a ingresarlo.")]
            EmailFaltante,
            [Description("Al parecer nos falta información de tu vehículo. Por favor revisa y vuelve a ingresarlo.")]
            MarcaModeloFaltante,
            [Description("No encontramos información del vehículo. Por favor ingresa la información en el próximo paso.")]
            VehiculoNoEncontrado,
            [Description("Por el momento no tenemos ofertas disponibles. Lo invitamos a intentar nuevamente.")]
            SinOfertas,
        }

        public enum EnumEstado
        {
            [Description("Reserva Confirmada y Pagada")]
            ReservaConfirmada,
            [Description("Nuestros registros indican que usted ya pagó su póliza. Si aún no la recibe, por favor pongase encontacto con nosotros para asistirlo.")]
            Pagado,
            [Description("Monto del SOAP que intenta comprar es menor al precio de venta, por favor verifique y vuelva internat su compra.")]
            PrimaMinima,
            [Description("No tenemos registro de la transacción que intenta realizar, por favor verifique y vuelva internat su compra.")]
            NoExiste,
            [Description("La Patente ya contrató su seguro en Soap Bomberos. Utiliza la opción Descargar Póliza.")]
            Emitida,
            [Description("Al parecer nos falta tu email o es inválido. Por favor revisa y vuelve a ingresarlo.")]
            EmailFaltante,
            [Description("Al parecer nos falta información de tu vehículo. Por favor revisa y vuelve a ingresarlo.")]
            MarcaModeloFaltante,
            [Description("No encontramos información del vehículo. Por favor ingresa la información en el próximo paso.")]
            VehiculoNoEncontrado,
            [Description("Por el momento no tenemos ofertas disponibles. Lo invitamos a intentar nuevamente.")]
            SinOfertas,
        }
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null;
        }
    }
}
