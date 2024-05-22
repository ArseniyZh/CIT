using System;
namespace API_Project1.Models;
using Microsoft.AspNetCore.Identity;

public enum UserRole
{
    User,
    Admin
}

public class User: IdentityUser
{
    public int UserId { get; set; }  // Уникальный идентификатор пользователя
    public string FirstName { get; set; } = string.Empty;  // Имя пользователя
    public string LastName { get; set; } = string.Empty;  // Фамилия пользователя
    public string? Bio { get; set; }  // Краткое описание или биография пользователя может быть null
    public string Username { get; set; } = string.Empty;  // Логин пользователя
    public UserRole Role { get; set; } = UserRole.User;  // Роль пользователя с значением по умолчанию
}


public class Message
{
    public int MessageId { get; set; }  // Уникальный идентификатор сообщения
    public int FromUserId { get; set; }  // ID пользователя, отправившего сообщение
    public User FromUser { get; set; }  // Ссылка на пользователя, отправившего сообщение
    public string Text { get; set; }  // Текст
}

