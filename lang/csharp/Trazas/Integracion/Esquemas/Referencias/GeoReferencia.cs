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
	
	public partial class GeoReferencia : ISpecificRecord
	{
		public static Schema _SCHEMA = Avro.Schema.Parse(@"{""type"":""record"",""name"":""GeoReferencia"",""namespace"":""Integracion.Esquemas.Referencias"",""fields"":[{""name"":""latitud"",""default"":null,""type"":[""null"",""double""]},{""name"":""longitud"",""default"":null,""type"":[""null"",""double""]},{""name"":""altura"",""default"":null,""type"":[""null"",""double""]}]}");
		private System.Nullable<System.Double> _latitud;
		private System.Nullable<System.Double> _longitud;
		private System.Nullable<System.Double> _altura;
		public virtual Schema Schema
		{
			get
			{
				return GeoReferencia._SCHEMA;
			}
		}
		public System.Nullable<System.Double> latitud
		{
			get
			{
				return this._latitud;
			}
			set
			{
				this._latitud = value;
			}
		}
		public System.Nullable<System.Double> longitud
		{
			get
			{
				return this._longitud;
			}
			set
			{
				this._longitud = value;
			}
		}
		public System.Nullable<System.Double> altura
		{
			get
			{
				return this._altura;
			}
			set
			{
				this._altura = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.latitud;
			case 1: return this.longitud;
			case 2: return this.altura;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.latitud = (System.Nullable<System.Double>)fieldValue; break;
			case 1: this.longitud = (System.Nullable<System.Double>)fieldValue; break;
			case 2: this.altura = (System.Nullable<System.Double>)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
