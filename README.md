# Integracion.Esquemas.Avro

![avro tools](https://github.com/architecture-it/Integracion.Esquemas.Avro/workflows/avro%20tools/badge.svg)

Este repositorio contienen:

* Archivos de protocolo necesarios para la generacion de schemas [avro](https://avro.apache.org/) in formato [idl](https://avro.apache.org/docs/current/idl.html).
* Archivos para la generacion de librerias necesarias para trabajar con los esquemas desde los distintos lenguajes de programacion.

## Por que debemos generar schemas Avro?

Los esquemas Avro son generados para poder ser incorporados en la [registry](https://www.apicur.io/registry/) que utilizaremos como fuente de validacion de los mensajes que publicaremos en los topicos de Kafka.

## Como se generan los schemas Avro?

Los esquemas Avro que son incorporados a la registry se generan a partir de los archivos `.avdl`que se encuentran en la carpeta `./idl`, estos archivos de protocolo estan escritos en un lenguaje de alto nivel llamado `idl` que sirve para crear schemas Avro en formato `json`.
Aqui se puede ver un ejemplo de como queda un schema declarado en idl.

```js

  record EnvioEntregado{
    
    Traza traza;
    Integracion.Esquemas.Referencias.TipoDeEntrega tipoDeEntrega;
  }
```

Una vez que tenemos definidos nuestros esquemas en el archivo `.avdl` se debera usar una herramienta para la generacion de esquemas en formato `json` los cuales utilizaremos para incorporar a la registry. Para la generacion de los schemas se utiliza el siguiente comando:

```console
java -jar avro-tools-{version}.jar idl2schemata {archivo}.idl ./{carpeta destino}
```
Este comando nos generar tantos archivos `.avsc` como tipos tengamos declarados en el archivo `.avdl`. Luego podremos utilizar estos archivos para agregar o actualizar los esquemas en la registry.


## Como se genera el codigo fuente incluido en las librerias?

Por el momento solo se esta generando codigo fuente en el lenguaje C#. Para la generacion del mismo partiremos nuevamente del archivo `.avdl` para generar un archivo de procolo pero esta vez en formato `json` con la extension `.avpr`. Para la generacion de este archivo se utiliza el siguiente comando:


```console
java -jar avro-tools-{version}.jar idl {archivo}.idl {archivo}.avpr
```

Una vez obtenido el archivo `.avpr` usaremos una netcore tool llamada `avrogen` para generar codigo fuente C#.

```console
avrogen -p {archivo}.avpr ./{carpeta destino}

```

Este comando nos generar tantos archivos `.cs` como tipos tengamos declarados en el archivo `.avdl`. Luego utilizaremos estos archivos para genera un paquete nuget el cual utilizaremos dentro de nuestros desarrollos.


## Generacion Automatica de Schemas y librerias

La generacion de schemas, su posterior sincronizacion con la registry y la generacion de librerias para los lenguajes de programacion se realiza automaticamente utilizando Github Actions. Por lo cual, cada vez que generemos un pull request con cambios en los archivos `.avdl`, una accion de github generara los esquemas y realizara una validacion contra la registry. Este proceso nos dira si algunos de los esquemas fue modificado y dejo de respetar las reglas de validacion y compatibilidad que tenemos establecidas en la registry.

Una vez que la validacion sea exitosa, se procedera con el merge del pull request (Operacion manual). Terminado el merge se ejecutara otra accion de Github que se encargara de:

* Registrar nuevos esquemas en la registry.
* Actualizar esquemas existentes solo si se realizaron cambios.
* Generacion de paquete Nuget y publicacion del mismo dentro de Github Packages.


## headers

Con el modelo anterior, al ser un modelo jerarquico donde eventos heredan de otros, era facil trasladar propiedades a todos los eventos, por ejemplo todos los eventos que heredan de `EventoDeNegocio` heredan todas sus propiedades. __Avro__ no soporta herencia por lo cual trasladar esos campos comunes no es tan simple. Por ese motivo las propiedades que anteriormente se encontraban en `EventoDeNegocio` en el modelo actual se agregaran como headers del evento a publicar.

```xml
<complexType abstract="false" name="EventoDeNegocio">
  <sequence>
    <element name="timestamp" type="date" minOccurs="1"
      maxOccurs="1" />
    <element name="remitente" type="string" minOccurs="1"
      maxOccurs="1" />
    <element name="destinatario" type="string" minOccurs="0"
      maxOccurs="1" />
    <element name="numeroDeOrden" type="string" maxOccurs="1"
      minOccurs="0" />
    <element name="vencimiento" type="date" minOccurs="0"
      maxOccurs="1" />
  </sequence>
</complexType>

```
A continuacion se detalle el futuro de cada uno de estos campos:

* __timestamp__: La metadata de los eventos en kafka ya poseen esta propiedad por lo cual este propiedad no sera mantenida.
* __remitente__: Esta propiedad se debera publicar como header
* __destinatario__: Esta propiedad se usaba para especificar si este mensaje va a una cola especifica. En este modelo no sera necesaria y se descartara.
* __numeroDeOrden__: Esta propiedad posiblemente pueda sar el offset.
* __vencimiento__: Se descarta ya que el vencimiento de los mensajes no es como en mq.
 
