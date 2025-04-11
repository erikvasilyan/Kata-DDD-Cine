Un sistema de tickets para un cine, queremos comprar tickets para una sesión de una pelicula

Negocio:
 - un asiento es para una única persona
 - multiples asientos pueden ser reservados a la vez
 - los asientos estan limitados para una sesión de una pelicula
 - una sesión se define por la sala, en una hora concreta, para una pelicula concreta

Problemas de este modelo:
 - Al aggregate Session se pasan los ids de asientos del aggregate Sala (los ids de entidades de aggregate son unicos dentro de este aggregate), ademas esto da a problemas como la encapsulación
 - El customer no puede reservar varios asientos con una llamada
