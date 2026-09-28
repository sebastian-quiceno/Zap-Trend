using System;
using System.Linq;
using ZapTrendBackend.Model.Enums;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Model.Entities
{
    //Esta clase tiene implementado internamente el patron BUILDER
    public class User
    {
        // Atributos de clase (Campos privados)
        private int id;
        public UserName Username;
        private string passwordHash;
        public Name Name { get; }
        public SecondName SecondName { get; }
        private DocumentType documentType;
        public Document Document { get; }
        private DateTime birthday;
        public Phone Phone { get; }
        public Mail Mail { get; }
        private Association association;

        // Constructor: Lo hacemos 'internal' para que solo el Builder de esta capa pueda usarlo directamente
        internal User(int id, UserName username, string passwordHash, Name name, SecondName secondName, DocumentType documentType, Document document, DateTime birthday, Phone phone,Mail mail, Association association)
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
            Association = association;
        }

        // Getters y Setters con validaciones
        public int Id { get => id; set => id = value; }

        public string PasswordHash
        {
            get => passwordHash;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El hash de contraseña de Usuario no puede estar vacío");
                passwordHash = value;
            }
        }
        public DocumentType DocumentType { get => documentType; set => documentType = value; }

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (value >= DateTime.Now)
                    throw new ArgumentException("La fecha de nacimiento de Usuario no puede ser en el futuro");
                birthday = value;
            }
        }
        public Association Association { get => association; set => association = value; }

    }

    // -----------------
    // PATRÓN BUILDER
    // -----------------
    public class UserBuilder
    {
        //Reglas de negocio
        private static readonly int DefalutAge = 18;

        //Se inicializan los atributos
        private int id;
        private UserName? username;
        private string passwordHash;
        private Name? name;
        private SecondName? secondName;
        private DocumentType documentType;
        private Document? document;
        private DateTime birthday; // Valor por defecto
        private Phone? phone;
        private Mail? mail;
        private Association? association;

        // Constructor
        public UserBuilder()
        {
            Reset();
        }

        // Métodos del Builder
        public UserBuilder Reset()
        {
            id = 0;
            username = null;
            passwordHash = string.Empty;
            name = null;
            secondName = null;
            documentType = default;
            document = null;
            birthday = DateTime.Now.AddYears(-DefalutAge);
            phone = null;
            mail = null;
            association = null;

            return this;
        }

        public UserBuilder WithId(int id)
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

        public UserBuilder WithAssociation(Association association)
        {
            this.association = association;
            return this;
        }

        // Método creacional
        public User Build()
        {
            if (username is null)
                throw new InvalidOperationException(
                    "El Username es requerido para construir el Usuario.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new InvalidOperationException(
                    "El PasswordHash es requerido.");

            if (name is null)
                throw new InvalidOperationException(
                    "El Nombre es requerido.");

            if (mail is null)
                throw new InvalidOperationException(
                    "El Correo es requerido.");

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
                association
            );
        }
    }
}
