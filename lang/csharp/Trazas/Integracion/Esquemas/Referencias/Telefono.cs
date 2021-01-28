// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.10.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Integracion.Esquemas.Referencias
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Avro;
	using Avro.Specific;
	
	public partial class Telefono : ISpecificRecord
	{
		public static Schema _SCHEMA = Avro.Schema.Parse(@"{""type"":""record"",""name"":""Telefono"",""namespace"":""Integracion.Esquemas.Referencias"",""fields"":[{""name"":""tipo"",""type"":{""type"":""enum"",""name"":""TipoDeTelefono"",""namespace"":""Integracion.Esquemas.Referencias"",""symbols"":[""trabajo"",""celular"",""casa"",""otro""]}},{""name"":""numero"",""type"":""string""}]}");
		private Integracion.Esquemas.Referencias.TipoDeTelefono _tipo;
		private string _numero;
		public virtual Schema Schema
		{
			get
			{
				return Telefono._SCHEMA;
			}
		}
		public Integracion.Esquemas.Referencias.TipoDeTelefono tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				this._tipo = value;
			}
		}
		public string numero
		{
			get
			{
				return this._numero;
			}
			set
			{
				this._numero = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.tipo;
			case 1: return this.numero;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.tipo = (Integracion.Esquemas.Referencias.TipoDeTelefono)fieldValue; break;
			case 1: this.numero = (System.String)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
