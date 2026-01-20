namespace Plataform.Domain.DomainErrors;

public static class DomainErrors
{
    public static class Car
    {
        // Standard for all entities
        public static string InvalidUser => "Invalid User";
        public static string DuplicatePlate => "The plate information is already in use.";
        public static string InvalidPlate => "The plate information is invalid.";
        public static string InvalidYear => "The year of fabrication is invalid.";
        public static string InvalidModel => "The model information is invalid.";
        public static string NotFound => "Car not found.";
    }
    
    public static class Attendant
    {
        // Standard for all entities
        public static string InvalidUser => "Invalid User";
        public static string NotFound => "Atendente não encontrado.";
        public static string DuplicateCpf => "Já existe um atendente cadastrado com este CPF.";
        public static string InvalidEmail => "O e-mail fornecido para o atendente é inválido.";
        public static string InactiveAttendant => "Não é possível realizar operações com um atendente inativo.";
    }

    public static class Driver
    {
        // Standard for all entities
        public static string InvalidUser => "Invalid User";
        public static string NotFound => "Motorista não encontrado.";
        public static string DuplicateEmail => "Este e-mail já está sendo utilizado por outro motorista.";
        public static string WeakPassword => "A senha do motorista não atende aos requisitos mínimos de segurança.";
        public static string InvalidPhone => "O número de telefone informado é inválido.";
    }
}