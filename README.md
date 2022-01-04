#Instrucciones Dron

## Introduccion

- La solucion tiene:
+ La API con un controlador "InstruccionesDronController" que contiene un método GET que recibe unas instrucciones para X drones y te devuelve la posicion y la direccion en la que acaban.
+ El dominio donde está la lógica que usará la API.

## Mapper

Automapper para mapear los DTOs

##  Swagger

Añadido swagger para ver el metodo del controller y poder probarlo
- La request que he usado es:

```JSON
{
  "tamañoRectangulo": {
    "rectanguloX": 5,
    "rectanguloY": 5
  },
  "datosDrones": [
    {
      "posicionDronInicial": {
        "posicionX": 0,
        "posicionY": 0,
        "direccion": "N"
      },
      "movimientoDron": "MMRMMM"
    },
    {
      "posicionDronInicial": {
        "posicionX": 1,
        "posicionY": 1,
        "direccion": "N"
      },
      "movimientoDron": "MMRMMM"
    }
  ]
}
```

- La respuesta es:
```JSON
{
    "instruccionId": "8aacaa91-1229-4845-b4fe-ec618f2f396f",
    "posicionFinalDrones": [
        {
            "dronId": "86fbd7c6-515c-4228-bc92-b2bafc26b936",
            "posicionX": 3,
            "posicionY": 2,
            "direccion": "O"
        },
        {
            "dronId": "8a6888c9-b66e-4148-815c-023bb10bac1f",
            "posicionX": 4,
            "posicionY": 3,
            "direccion": "O"
        }
    ]
}
```

- En el caso que un dron se salga del AREA configurada ese dron devolverá -1 y el front podrá controlarlo:
```JSON
{
    "instruccionId": "72bc88e7-fb10-4fd3-a0d2-f07161552b71",
    "posicionFinalDrones": [
        {
            "dronId": "8f0e7556-16ce-443a-963e-304c5e599663",
            "posicionX": 3,
            "posicionY": 2,
            "direccion": "O"
        },
        {
            "dronId": "6ae68c86-6918-459e-9415-697a7a0a3470",
            "posicionX": -1,
            "posicionY": -1,
            "direccion": null
        }
    ]
}
```

## Unit Test

Hay un test para verificar que la respuesta del controlador no es nula