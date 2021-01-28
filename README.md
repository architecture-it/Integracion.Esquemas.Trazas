# Integracion.Esquemas.Avro


## Generar archivo de protocol (avpr) desde archivo idl (avdl)

```
java -jar avro-tools-1.10.1.jar idl idl\EventosDeTraza.avdl EventosDeTraza.avpr

```

## Generar codigo fuente desde archivo de protocolo (avpr)

```
dotnet avrogen.dll -p EventosDeTraza.avpr .\lang\c

```