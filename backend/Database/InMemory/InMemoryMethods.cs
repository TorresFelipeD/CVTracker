using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Newtonsoft.Json;

namespace Database.InMemory
{
    public sealed class InMemoryMethods
    {
        private InMemoryMethods() { }
        private static InMemoryMethods? _instance;
        public static InMemoryMethods GetInstance()
        {
            if (_instance == null)
                _instance = new InMemoryMethods();

            return _instance;
        }

        private List<Company> companies;
        private List<EmploymentExchange> employmentExchanges;
        private List<Requirement> requirements;
        private List<Skill> skills;
        private List<Status> status;
        private List<Job> jobs;

        private Random random = new Random();
        string[] companiesNames = { "Rooxo", "Photospace", "Tagfeed", "Lazz", "Fiveclub", "Jabbersphere", "Vimbo", "Oyoba", "Devpulse", "Gigabox", "Photobug", "Katz", "Fanoodle", "Aimbo", "Jaxnation", "Teklist", "Thoughtworks", "Voonder", "Realmix", "Flipopia", "Mydo", "Tagcat", "Snaptags" };
        string[] descriptionWords = { "yo", "ir", "navegar", "en", "bote", "mar", "sol", "viento", "olas", "horizonte", "destino", "viaje", "aventura", "emoción", "tranquilidad", "vela", "timón", "ancla", "costa", "puerto", "explorar", "descubrir", "náutica", "océano" };
        string[] skillsNames = { "Comunicación efectiva", "Liderazgo", "Trabajo en equipo", "Resolución de problemas", "Pensamiento crítico", "Innovación", "Planificación estratégica", "Adaptabilidad", "Creatividad", "Toma de decisiones", "Gestión del tiempo", "Organización", "Negociación", "Aprendizaje continuo", "Empatía", "Colaboración", "Flexibilidad", "Proactividad", "Comunicación verbal", "Comunicación no verbal", "Toma de decisiones en equipo", "Gestión de proyectos", "Gestión de recursos", "Pensamiento lógico", "Paciencia" };
        string[] requirementsNames = { "Experiencia previa", "Habilidades sociales", "Inglés avanzado", "Licencia vigente", "Excel avanzado", "Trabajo en equipo", "Puntualidad absoluta", "Disponibilidad horaria", "Adaptabilidad rápida", "Responsabilidad demostrada", "Comunicación efectiva", "Habilidades analíticas", "Liderazgo colaborativo", "Capacidad multitarea", "Orientación al cliente", "Conocimientos técnicos", "Autonomía laboral", "Capacidad resolutiva", "Creatividad e innovación", "Toma de decisiones" };
        string[] employmentExchangesNames = { "Indeed", "LinkedIn", "Glassdoor", "Monster", "Infojobs", "Empléate", "Occmundial", "Computrabajo", "SimplyHired", "CareerBuilder" };
        string[] statusNames = { "Solicitado", "Entrevista Tecnica", "Entrevista", "Finalizado" };
        string[] positionNames = { "Gerente de Proyectos", "Analista de Datos", "Coordinador de Marketing", "Jefe de Recursos Humanos", "Especialista en Finanzas", "Ingeniero de Software", "Asistente de Ventas", "Director de Operaciones", "Supervisor de Producción", "Gerente de Calidad", "Analista de Sistemas", "Jefe de Desarrollo de Negocios", "Ejecutivo de Cuentas", "Consultor de Marketing Digital", "Diseñador Gráfico", "Administrador de Redes", "Coordinador de Eventos", "Asesor de Ventas", "Especialista en Logística", "Encargado de Mantenimiento" };
        string[] jobPostingUrlFake = { "https://www.noticiasfalsas.com", "https://www.tiendaonlinefalsa.com", "https://www.bancofalso.com", "https://www.socialmediafalso.com", "https://www.empresaimaginaria.com", "https://www.serviciotecnicoenganyoso.com", "https://www.productofalso.com", "https://www.paginawebfalsa.com", "https://www.appfalsa.com", "https://www.concursotrucho.com" };
        public List<Company> CreateCompanies(int quantity = 10)
        {
            if (!IsNullorEmptyList(companies))
                return companies;

            List<Company> listCompanies = new();
            int totalPhrases = random.Next(20, 30);
            List<string> randomWords = new();

            for (int i = 1; i <= totalPhrases; i++)
            {
                string randomPhrase = string.Join(" ", (from word in descriptionWords.OrderBy(x => Guid.NewGuid())
                                                        select word).Take(random.Next(5, 10)).ToList());
                randomWords.Add(randomPhrase);
            }

            var listCompaniesNames = (from cp in companiesNames.Select((name, index) => new { name, index })
                                      let randomIndex = random.Next(0, randomWords.Count)
                                      select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name, Description = randomWords[randomIndex] })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var company in listCompaniesNames)
            {
                listCompanies.Add(new Company()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description
                });
            }

            companies = listCompanies;

            return companies;
        }
        public List<EmploymentExchange> CreateEmploymentExchanges(int quantity = 10)
        {
            if (!IsNullorEmptyList(employmentExchanges))
                return employmentExchanges;

            List<EmploymentExchange> employmentExchange = new();
            var listNames = (from cp in employmentExchangesNames.Select((name, index) => new { name, index })
                             select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var item in listNames)
            {
                employmentExchange.Add(new EmploymentExchange()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            employmentExchanges = employmentExchange;

            return employmentExchanges;
        }
        public List<Requirement> CreateRequirement(int quantity = 10)
        {
            if (!IsNullorEmptyList(requirements))
                return requirements;

            List<Requirement> listRequirements = new();
            var listNames = (from cp in requirementsNames.Select((name, index) => new { name, index })
                             select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var item in listNames)
            {
                listRequirements.Add(new Requirement()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            requirements = listRequirements;
            return requirements;
        }
        public List<Skill> CreateSkills(int quantity = 10)
        {
            if (!IsNullorEmptyList(skills))
                return skills;

            List<Skill> listSkills = new();
            var listNames = (from cp in skillsNames.Select((name, index) => new { name, index })
                             select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var item in listNames)
            {
                listSkills.Add(new Skill()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            skills = listSkills;
            return skills;
        }
        public List<Status> CreateStatus(int quantity = 10)
        {
            if (!IsNullorEmptyList(status))
                return status;

            List<Status> listStatus = new();
            var listNames = (from cp in statusNames.Select((name, index) => new { name, index })
                             select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var item in listNames)
            {
                listStatus.Add(new Status()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            status = listStatus;
            return status;
        }
        public List<Job> CreateJobs(int quantity = 20)
        {
            if (!IsNullorEmptyList(jobs))
                return jobs;

            List<Job> listJobs = new();
            for (int i = 1; i <= quantity; i++)
            {
                Job item = new Job()
                {
                    Id = i,
                    IdCompany = companies[random.Next(0, companies.Count)].Id,
                    PositionName = positionNames[random.Next(0, positionNames.Count())],
                    IdEmploymentExchange = employmentExchanges[random.Next(0, employmentExchanges.Count)].Id,
                    JobPostingURL = jobPostingUrlFake[random.Next(0, jobPostingUrlFake.Count())],
                    IdStatus = status[random.Next(0, status.Count)].Id,
                    IdSkills = JsonConvert.SerializeObject((from sk in skills
                                                            select new { Guid_ = Guid.NewGuid(), sk.Id }
                                                            ).ToList().OrderBy(x => x.Guid_).Take(random.Next(1, skills.Count)).ToList().Select(x => x.Id).ToList()),
                    IdRequirements = JsonConvert.SerializeObject((from rq in requirements
                                                                  select new { Guid_ = Guid.NewGuid(), rq.Id }
                                                            ).ToList().OrderBy(x => x.Guid_).Take(random.Next(1, requirements.Count)).ToList().Select(x => x.Id).ToList()),
                };
                listJobs.Add(item);
            }
            jobs = listJobs;
            return jobs;
        }
        private bool IsNullorEmptyList<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }
    }
}