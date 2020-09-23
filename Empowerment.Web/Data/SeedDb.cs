using Empowerment.Web.Data.Entities;
using Empowerment.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var fechaInscripcion = DateTime.Now;
            var fechaNacimiento = DateTime.Now;

            var manager = await CheckUserAsync(fechaInscripcion, "Cédula de Ciudadanía", "80148070", "Gabriel", "Sánchez", 
                "gayesa8@gmail.com", "320 222 7706", "Calle 23c No. 70-50", fechaNacimiento , "Bogota", "30 años", "Masculino", "75 Kgs", 
                "1.70 Mts", "Profesional", "Universidad Autonoma", "Danza, Teatro", "", "", "", "Myriam Sánchez", "Abogada", 
                "3113584411", "Admin");
            var customer = await CheckUserAsync(fechaInscripcion, "Cédula de Ciudadanía", "79566332", "Yesid", "Sarmiento", 
                "yesi_941@hotmail.com", "350 634 2747", "Diagonal 26 calle 56-89", fechaNacimiento, "Cali", "24 años", "Masculino", 
                "75 Kgs", "1.70 Mts", "Profesional", "Universidad del Valle", "Danza, Teatro", "Fútbol", "", "Video Juegos",
                "Alberto Ramirez", "Ingeniero","3015789122", "Customer");

            await CheckPlanesAsync();
            await CheckAgendasAsync();
            await CheckInscripcionesAsync();
            await CheckManagersAsync(manager);
            await CheckClientesAsync(customer);
            await CheckCortesiasAsync();
            await CheckAsistenciasAsync();
        }

        private async Task<User> CheckUserAsync(
            
            DateTime fechaInscripcion,
            string tipoDocumento,
            string documento, 
            string nombre, 
            string apellido, 
            string email, 
            string telefono, 
            string direccion, 
            DateTime fechaNacimiento,
            string lugarNacimiento,  
            string edad, 
            string genero, 
            string peso, 
            string estatura, 
            string escolaridad, 
            string institucion, 
            string cultural, 
            string deportiva, 
            string artistica, 
            string recreativa,
            string nombreAcudiente,
            string ocupacion,
            string telefonoAcudiente,
            string rol)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);

            if (user == null)
            {

                user = new User
                {
                    FechaInscripcion = fechaInscripcion,
                    TipoDocumento = tipoDocumento,
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    UserName = email,
                    PhoneNumber = telefono,
                    Direccion = direccion,
                    FechaNacimiento = fechaNacimiento,
                    LugarNacimiento = lugarNacimiento,
                    Edad = edad,
                    Genero = genero,
                    Peso = peso,
                    Estatura = estatura,
                    GradoEscolaridad = escolaridad,
                    InstitucionEducativa = institucion,
                    Cultural = cultural,
                    Deportiva = deportiva,
                    Artistica = artistica,
                    Recreativa = recreativa,
                    NombreAcudiente = nombreAcudiente,
                    OcupacionAcudiente = ocupacion,
                    TelefonoAcudiente = telefonoAcudiente,
                    Documento = documento
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, rol);
            }
            return user;
        }


        private async Task CheckManagersAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        /* Tablas Microsoft User - Roles */

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        /* Tablas Originales */

        private async Task CheckAsistenciasAsync()
        {
            var fechaEntrada = DateTime.Now;
            var fechaSalida = DateTime.Now;

            if (!_dataContext.Asistencias.Any())
            {
                AddAsistencia("51744923", fechaEntrada, fechaSalida);
                AddAsistencia("80148070", fechaEntrada, fechaSalida);
                AddAsistencia("79563774", fechaEntrada, fechaSalida);
                AddAsistencia("56123774", fechaEntrada, fechaSalida);
                AddAsistencia("51744923", fechaEntrada, fechaSalida);
                AddAsistencia("80148070", fechaEntrada, fechaSalida);
                AddAsistencia("80148070", fechaEntrada, fechaSalida);
                AddAsistencia("80148070", fechaEntrada, fechaSalida);
                AddAsistencia("56123774", fechaEntrada, fechaSalida);
                AddAsistencia("56123774", fechaEntrada, fechaSalida);
                AddAsistencia("56123774", fechaEntrada, fechaSalida);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddAsistencia(string documento, DateTime fechaEntrada, DateTime fechaSalida)
        {
            _dataContext.Asistencias.Add(new Asistencia
            {
                Usuario = documento,
                FechaEntrada = fechaEntrada,
                FechaSalida = fechaSalida,
            });
        }

        private async Task CheckClientesAsync(User user)
        {
            if (!_dataContext.Clientes.Any())
            {
                _dataContext.Clientes.Add(new Cliente { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckCortesiasAsync()
        {
            var fechaInicio = DateTime.Now;
            if (!_dataContext.Cortesias.Any())
            {
                _dataContext.Cortesias.Add(new Cortesia { TipoDocumento = "Tarjeta de Identidad", Documento = "800327-08882", Nombre = "Ricardo Andres", Apellido = "Hernandez Suarez", Telefono = "3116665544", Email = "RicardoS23@hotmail.com", Direccion = "Calle 56b no. 79-56 sur", Web = true, Instagram = false, Facebook = false, Otro = true, Cual = "Amigo de academia", FechaInscripcion = fechaInicio, ClaseCortesia = false });
                _dataContext.Cortesias.Add(new Cortesia { TipoDocumento = "Cédula de Ciudadanía", Documento = "80159633", Nombre = "Andres", Apellido = "Sandoval", Telefono = "3104456688", Email = "AndresSan@gmail.com", Direccion = "Calle 56 carrera 55-66", Web = false, Instagram = true, Facebook = false, Otro = false, Cual = "", FechaInscripcion = fechaInicio, ClaseCortesia = true });
                _dataContext.Cortesias.Add(new Cortesia { TipoDocumento = "Cédula de Extranjería", Documento = "51596233", Nombre = "Diana", Apellido = "Bastidas", Telefono = "3102227706", Email = "DianaBastidas@gmail.com", Direccion = "Avenida Pradilla 79 - 08", Web = false, Instagram = false, Facebook = true, Otro = false, Cual = "", FechaInscripcion = fechaInicio, ClaseCortesia = true });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckAgendasAsync()
        {
            if (!_dataContext.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _dataContext.Agendas.Add(new Agenda
                            {
                                Fecha = initialDate.ToUniversalTime(),
                                Disponibilidad = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPlanesAsync()
        {
            if (!_dataContext.Planes.Any())
            {
                _dataContext.Planes.Add(new Plan { Nombre = "Clase", Categoria = "SEI-KB-HKD", Sigla = "SEI-KB-HKD", Sesiones = "1 Clase", Costo = "$20.000", Descripcion = "Valor de una clase.", });
                _dataContext.Planes.Add(new Plan { Nombre = "Full Training SEI", Categoria = "Sistema Entrenamiento Integrado", Sigla = "SEI", Sesiones = "6 Clases x Semana", Costo = "$205.000", Descripcion = "El plan incluye 6 clases por semana de SEI, clases de 1 hora de practica, sumando al mes 24 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Full Training KB", Categoria = "Kick Boxing", Sigla = "KB", Sesiones = "6 Clases x Semana", Costo = "$205.000", Descripcion = "El plan incluye 6 clases por semana de Kick Boxing, clases de 1 hora de practica, sumando al mes 24 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Victory SEI", Categoria = "Sistema Entrenamiento Integrado", Sigla = "SEI", Sesiones = "3 Clases x Semana", Costo = "$180.000", Descripcion = "El plan incluye 3 clases de SEI por semana de 1 hora de practica, sumando al mes 12 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Victory KB", Categoria = "Kick Boxing", Sigla = "KB", Sesiones = "3 Clases x Semana", Costo = "$180.000", Descripcion = "El plan incluye 3 clases de Kick Boxing por semana de 1 hora de practica, sumando al mes 12 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Adrenalina SEI", Categoria = "Sistema Entrenamiento Integrado", Sigla = "SEI", Sesiones = "2 Clases x Semana", Costo = "$130.000", Descripcion = "El plan incluye 2 clases de SEI por semana de 1 hora de practica, sumando al mes 8 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Adrenalina KB", Categoria = "Kick Boxing", Sigla = "KB", Sesiones = "2 Clases x Semana", Costo = "$130.000", Descripcion = "El plan incluye 2 clases de KB por semana de 1 hora de practica, sumando al mes 8 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Hapkido + Kick Boxing", Categoria = "Hapkido y Kick Boxing", Sigla = "HKD + KB", Sesiones = "(2 Clases HKD + 2 Clases KB) x Semana", Costo = "$170.000", Descripcion = "El plan incluye (2 clases de HKD + 2 clases de KB) por semana de 1 hora de practica, sumando al mes 16 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Hapkido", Categoria = "Hapkido", Sigla = "HKD", Sesiones = "6 Clases x Semana", Costo = "$102.000", Descripcion = "El plan incluye 6 clases por semana de Hapkido, clases de 1 hora de practica, sumando al mes 24 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Elite 2", Categoria = "Personalizado 100%", Sigla = "ELT2", Sesiones = "2 Clases x Semana", Costo = "$400.000", Descripcion = "El plan incluye 2 clases de Cualquier modalidad, clases de 1 hora de practica, sumando al mes 8 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Elite 3", Categoria = "Personalizado 100%", Sigla = "ELT3", Sesiones = "3 Clases x Semana", Costo = "$564.000", Descripcion = "El plan incluye 3 clases de Cualquier modalidad, clases de 1 hora de practica, sumando al mes 12 clases." });
                _dataContext.Planes.Add(new Plan { Nombre = "Elite 4", Categoria = "Personalizado 100%", Sigla = "ELT4", Sesiones = "4 Clases x Semana", Costo = "$720.000", Descripcion = "El plan incluye 4 clases de Cualquier modalidad, clases de 1 hora de practica, sumando al mes 16 clases." });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckInscripcionesAsync()
        {
            var cliente = _dataContext.Clientes.FirstOrDefault();
            var plan = _dataContext.Planes.FirstOrDefault();
            var fechainicio = DateTime.Now;
            var fechafin = DateTime.Now;

            if (!_dataContext.Inscripciones.Any())
            {
                AddInscripcion(cliente, plan, "3 Meses", fechainicio, fechafin, "si", "Se registra a plan de 3 meses.", true, false, false);
                AddInscripcion(cliente, plan, "6 Meses", fechainicio, fechafin, "no", "Se registra a plan de 6 meses.", false, true, false);
                AddInscripcion(cliente, plan, "1 año", fechainicio, fechafin, "no", "Se registra a plan de 1 año.", false, false, true);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddInscripcion(Cliente cliente, Plan plan, string vigencia, DateTime fechainicio, DateTime fechafin, string renovacion, string observacion, bool efectivo, bool tarjeta, bool deuda)
        {
            _dataContext.Inscripciones.Add(new Inscripcion
            {
                Cliente = cliente,
                Plan = plan,
                Vigencia = vigencia,
                FechaInicio = fechainicio,
                FechaFin = fechafin,
                Renovacion = renovacion,
                Observacion = observacion,
                Efectivo = efectivo,
                Tarjeta = tarjeta,
                Deuda = deuda
            });
        }
    }
}
