# Simulador-Cajero-Autom-tico

Proyecto personal de práctica desarrollado en C# orientado a reforzar conceptos 
de programación orientada a objetos y lógica de negocio.

## ¿Qué es?
Simulación de un cajero automático funcional desde la consola. El sistema maneja 
múltiples cuentas de usuario con sus respectivos saldos e historial de transacciones.

## ¿Qué se implementó?
- Autenticación con número de cuenta y PIN enmascarado
- Consulta de saldo y estado de cuenta
- Retiro de dinero con montos predefinidos
- Depósito de monto libre con validaciones
- Transferencias entre cuentas con validación de destinatario
- Historial de transacciones con fecha, monto y saldo resultante
- Manejo de errores en inputs del usuario

## Estructura del código
El proyecto está dividido en tres clases: `Cuenta` que representa 
a cada usuario con sus datos y saldo, `Transaccion` que modela cada 
movimiento realizado, y `Program` que contiene toda la lógica del cajero 
separada en métodos por funcionalidad.

## Nota
Se utilizan cuentas de prueba precargadas en el código para simular 
un entorno bancario básico.
