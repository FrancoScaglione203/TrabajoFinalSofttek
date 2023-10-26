# TrabajoFinalSofttek
Proyecto desarrollado en .NET CORE 6, consiste en una billetera virtual donde se manejan usuarios y cuentas en pesos, dólares y BTC (BitCoin). La funcionalidad de la pagina se basa en las consignas que se encuentran en el siguiente link: https://drive.google.com/file/d/1z8ALNU_B7PixbEL5mbtBieyvUL39o1d0/view?usp=sharing

---
---
## **Funcionalidad**
Para utilizar la API es necesario iniciar sesion ya que cuenta con autenticacion, de ser necesario crearse un usuario con un numero de CUIL que no se puede repetir entre usuarios. Una vez creado, este podrá crear una cuenta fiduciaria y una cuenta cripto. 

El usuario puede consultar últimos movimientos, consultar saldo, depositar, extraer y transferir entre mismo tipo de cuentas. En la cuenta fiduciaria se puede vender dólares para obtener pesos. En la cuenta cripto, la venta de BTC se pasa a pesos que serán depositados en la cuenta fiduciaria del usuario y la compra solo se puede realizar a partir del saldo pesos de la cuenta fiduciaria, es decir que no se pueden comprar BTC con los dólares, en caso de querer usar los dólares los tiene que vender para que se transformen en pesos y ahí comprar BTC.

En cuanto a la consulta de últimos movimientos, cada vez que se realiza una acción de las siguientes: compra, venta, deposito, extracción, consulta o transferencia se genera un elemento nuevo en la tabla Historial que deja registrado el id usuario Origen, cuil de usuario destino, tipo de movimiento, tipo de moneda y el monto de movimiento. Si el cuil destino coincide con el id de origen significa que puede ser cualquier tipo de movimiento menos una transferencia, en estos casos si deberían de no coincidir

---
---
## **Especificación de la Arquitectura**
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext. Ademas, tiene dos subcapas
•	DataBaseSeeding: donde se encuentran las seeds de cada entidad para cargar en la DB cuando se hace el Migration con EntityFrameWork
•	Repositories: donde definiremos las clases e interfaces correspondientes para realizar el repositorio genérico y los repositorios individuales, donde estara la mayor parte de la logica.

### **Capa DTOS**
En esta capa estan definidos todos los DataTransferObjects.

### **Capa Entities**
En esta capa estan definidas todas las entidades 
​
### **Capa Helpers**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. En este caso el generador de JWT y la clase DolarCotizacion que utiliza una API externa para obtener la cotización del dólar actualizada en pesos (https://estadisticasbcra.com/api/documentacion).

### **Capa Migrations**
Capa que se genera al realizar el migration con EntityFrameWork donde registra el migration y los datos insertados en la base de datos

### **Capa Services**
Capa donde se desarrollan la clase e interfaz UnitOfWorkService que trabaja en conjunto con el patron Repository

---
---
## **Entidades**
Tenemos 4 entidades principales: Usuario, CuentaCripto y CuentaFiduciaria e Historial 
Además también están las entidades Dólar, Moneda y TipoMovimiento

---
---

## **Base de Datos**
Las tablas Usuarios, CuentasFiduciarias, CuentasCriptos e Historiales se llenaron con datos rapidos para poder testear.

Usuarios

![Usuarios](https://i.imgur.com/ZhDMDv4.jpg)

Cuentas Fiduciarias
![CuentasFiduciarias](https://i.imgur.com/kv4K0eO.jpg)

Cuentas Criptos

![CuentasCriptos](https://i.imgur.com/qomETq6.jpg)

Historiales

![Historiales](https://i.imgur.com/LrGUxTs.jpg)

Monedas

![Monedas](https://i.imgur.com/5THkRTf.jpg)

Tipo Movimientos

![TipoMovimientos](https://i.imgur.com/clTbUzc.jpg)


---
---
## **Controllers**

LoginController: Tiene un EndPoint para realizar el login de usuario

UsuarioController: Tiene un EndPoint para agregar un Usuario y otro para mostrar todos los Usuarios

CuentaFiduciariaController: Tiene varios EndPoints que le permiten consultar saldo, consultar cuenta, depositar, extraer y transferir, todas estas funciones aplican para Pesos y Dólares. También hay un EndPoint que permite la venta de dólares depositando el valor de la venta en el saldo de pesos. Las transferencias se hacen entre mismo tipo de monedas.

CuentaCriptoController: Tiene varios EndPoints que le permiten consultar saldo, consultar cuenta, depositar, extraer y transferir BTC. La transferencia se hace solamente entre BTC. Tambien tiene un EndPoint que permite vender las BTC y pasarla a pesos y otro para compra BTC a partir del saldo pesos de la cuenta fiduciaria correspondiente al usuario

HistorialController: Tiene un EndPoint para agregar un Historial y otro para mostrar los historiales del cuil que se envia por parametro

---
---

## **Paquetes Instalados**
![Logo de Mi Proyecto](https://i.imgur.com/j08aXYr.jpeg)

---
---


## **FrontEnd**
El frontend se realizo con razor: https://github.com/FrancoScaglione203/TrabajoFinalSofttekFront/tree/master

Por el momento esta incompleto

---
---
## **Mejoras Versiones Futuras**
Debido a la falta de tiempo tuve que optar por no agregar algunas funciones que podrían agregarse en futuras versiones:
-	Cotizacion BTC: la idea es utilizar una API externa para obtener la cotizacion en dólares de BTC
-	Seguridad: para mayor seguridad se agregaría un encriptado a la clave.
-	Numero de cuenta Fiduciaria y UUID de cuenta cripto: lo ideal es que se genere un numero random cuando se crea un elemento nuevo y asignarselos a estas propiedades.


---
---

## **Especificación de GIT**​
* Se implento el patron GitFlow. La rama donde se encuentran las versiones finales es Master, la rama principal a partir de la cual se crean ramas es Develop. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/xx-Titulo (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.
---
---
## **Autor**​
* Scaglione Franco
---
---
## **Contacto**
franco.scaglione2@gmail.com
