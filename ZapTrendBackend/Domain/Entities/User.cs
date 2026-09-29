using System;
using System.Linq;
using ZapTrendBackend.Domain.Entities;
using ZapTrendBackend.Model.Enums;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Model.Entities
{
    //Esta clase tiene implementado internamente el patron BUILDER
    public class User
    {
        // Atributos de clase (Campos privados)
        //private readonly List<Role> roles = new();

        public Guid Id { get; private set; }
        public UserName Username { get; private set; }
        public string PasswordHash { get; private set; }
        public Name Name { get; private set; }
        public SecondName? SecondName { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public Document Document { get; private set; }
        public DateTime Birthday { get; private set; }
        public Phone Phone { get; private set; }
        public Mail Mail { get; private set; }

        // public IReadOnlyCollection<Role> Roles => roles.AsReadOnly();
        public List<Role> Roles { get; private set; }
        public Association? Association { get; private set; }

        // Constructor...
        public User(Guid id, UserName username, string passwordHash, Name name, SecondName secondName, DocumentType documentType, Document document, DateTime birthday, Phone phone, Mail mail, List<Role> roles, Association association)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Name = name;
            SecondName = secondName;
            DocumentType = documentType;
            Document = document;
            Birthday = birthday;
            Phone = phone;
            Mail = mail;
            Roles = roles;
            Association = association;
        }

        public void ChangePassword(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException(
                    "El hash de contraseña no puede estar vacío.");

            PasswordHash = passwordHash;
        }

        public void ChangePhone(Phone phone)
        {
            Phone = phone;
        }

        public void ChangeMail(Mail mail)
        {
            Mail = mail;
        }

        public void AddRole(Role role)
        {
            if (Roles.Contains(role))
                return;

            Roles.Add(role);
        }

        public void RemoveRole(Role role)
        {
            if (!Roles.Any())
                throw new InvalidOperationException("El usuario no puede quedar sin rol, agregue el nuevo rol y elimine el anterior");
            Roles.Remove(role);
        }

        public void ChangeAssociation(Association association)
        {
            Association = association;
        }


    }

    // -----------------
    // PATRÓN BUILDER
    // -----------------
    public class UserBuilder
    {
        //Reglas de negocio
        private static readonly int DefalutAge = 18;

        //Se inicializan los atributos
        private Guid id;
        private UserName? username;
        private string passwordHash;
        private Name? name;
        private SecondName? secondName;
        private DocumentType documentType;
        private Document? document;
        private DateTime birthday; // Valor por defecto
        private Phone? phone;
        private Mail? mail;
        private List<Role>? roles;
        private Association? association;

        // Constructor
        public UserBuilder()
        {
            Reset();
        }

        // Métodos del Builder
        public UserBuilder Reset()
        {
            id = new Guid();
            username = null;
            passwordHash = string.Empty;
            name = null;
            secondName = null;
            documentType = default;
            document = null;
            birthday = DateTime.Now.AddYears(-DefalutAge);
            phone = null;
            mail = null;
            roles = null;
            association = null;

            return this;
        }

        public UserBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public UserBuilder WithCredentials(string username, string passwordHash)
        {
            this.username = new UserName(username);
            this.passwordHash = passwordHash;

            return this;
        }

        public UserBuilder WithFullName(string name, string? secondName = null)
        {
            this.name = new Name(name);

            if (!string.IsNullOrWhiteSpace(secondName))
            {
                this.secondName = new SecondName(secondName);
            }

            return this;
        }

        public UserBuilder WithIdentityDocument(
            DocumentType documentType,
            string document)
        {
            this.documentType = documentType;
            this.document = new Document(document);

            return this;
        }

        public UserBuilder WithBirthday(DateTime birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public UserBuilder WithContactInfo(string phone, string mail)
        {
            this.phone = new Phone(phone);
            this.mail = new Mail(mail);

            return this;
        }

        public UserBuilder WithRoles(List<Role> roles) {
            this.roles = roles;

            return this;
        }

        public UserBuilder WithAssociation(Association association)
        {
            this.association = association;
            return this;
        }

        // Método creacional
        public User Build()
        {
            if (username is null)
                throw new InvalidOperationException("El Username es requerido para construir el Usuario.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new InvalidOperationException("El PasswordHash es requerido.");

            if (name is null)
                throw new InvalidOperationException("El Nombre es requerido.");

            if (mail is null)
                throw new InvalidOperationException("El Correo es requerido.");

            if (id.Equals(new Guid()))
                id = Guid.NewGuid();

            return new User(
                id,
                username,
                passwordHash,
                name,
                secondName,
                documentType,
                document,
                birthday,
                phone,
                mail,
                roles,
                association
            );
        }
    }
}
