// --------------------------------
// <copyright file="ControlFacturacion.cs" company="InterGrupo S.A.">
//     COPYRIGHT(C) 2013, Intergrupo S.A
// </copyright>
// <summary>Archivo ControlConfiguracion.</summary>
// --------------------------------

namespace CliCountry.Facturacion.Negocio.Controlador
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using CliCountry.Facturacion.Negocio.Interfaces;
    using Dominio.Entidades;
    using SAHI.Comun.Aspectos;
    using SAHI.Comun.AuditoriaBase;
    using SAHI.Comun.Utilidades;
    using SAHI.Dominio.Entidades;
    using SAHI.Dominio.Entidades.Facturacion;
    using SAHI.Dominio.Entidades.Facturacion.Auditoria;
    using SAHI.Dominio.Entidades.Facturacion.Ventas;
    using SAHI.Dominio.Entidades.Productos;
    using CliCountry.Facturacion.Datos.DAO;

    public class ControlConceptos
    {
        /// <summary>
        /// Permite Consultar Conceptos Asociados a una Atencion.
        /// </summary>
        /// <param name="atencion">The atencion.</param>
        /// <returns>Lista de conceptos.</returns>
        /// <remarks>
        /// Autor: Jorge Arturo Cortes - INTERGRUPO\jcortesm.
        /// FechaDeCreacion: 04/06/2013.
        /// UltimaModificacionPor: (Nombre del Autor de la modificacion - Usuario del dominio).
        /// FechaDeUltimaModificacion: (dd/MM/yyyy).
        /// EncargadoSoporte: (Nombre del Autor - Usuario del dominio).
        /// Descripcion: (Descripcion detallada del metodo, procure especificar todo el metodo aqui).
        /// </remarks>
        public Resultado<List<ConceptoCobro>> ConsultarConceptos(Atencion atencion)
        {
            Resultado<List<ConceptoCobro>> resultado = new Resultado<List<ConceptoCobro>>();
            try
            {
                DataTable datos = new DAOFacturacion("").ConsultarConceptos(atencion);

                resultado.Ejecuto = true;
                resultado.Objeto = this.ConsultarConceptos(datos);
            }
            catch (Exception exception)
            {
                resultado.Ejecuto = false;
                resultado.Mensaje = exception.Message;
                resultado.Objeto = null;
            }

            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public List<ConceptoCobro> ConsultarConceptos(DataTable datos)
        {
            IEnumerable<ConceptoCobro> registros = null;
            using (datos)
            {
                registros = from fila in datos.Select()
                            select new ConceptoCobro(fila);
            }

            return registros.ToList();
        }
    }
}
